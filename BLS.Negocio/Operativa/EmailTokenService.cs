using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.MsmqIntegration;
using System.Text;

public sealed class EmailTokenService
{
    private readonly string _connectionString;

    // SMTP
    private readonly string _smtpHost;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;
    private readonly bool _smtpEnableSsl;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailTokenService(
        string smtpHost,
        int smtpPort,
        string smtpUser,
        string smtpPass,
        bool smtpEnableSsl,
        string fromEmail,
        string fromName = "Soporte")
    {
        _connectionString = ReadConnFromAppSettings("sqlConn.ConnectionString");

        _smtpHost = smtpHost ?? throw new ArgumentNullException(nameof(smtpHost));
        _smtpPort = smtpPort;
        _smtpUser = smtpUser ?? throw new ArgumentNullException(nameof(smtpUser));
        _smtpPass = smtpPass ?? throw new ArgumentNullException(nameof(smtpPass));
        _smtpEnableSsl = smtpEnableSsl;
        _fromEmail = fromEmail ?? throw new ArgumentNullException(nameof(fromEmail));
        _fromName = string.IsNullOrWhiteSpace(fromName) ? "Soporte" : fromName;
    }

    /// <summary>
    /// Genera token de 6 dígitos, guarda (hash+salt) y envía email.
    /// Devuelve el Id insertado en BD.
    /// </summary>
    public int GenerateStoreAndSendToken(string email, int expiresMinutes = 10, bool invalidatePrevious = true)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email requerido.", nameof(email));
        if (expiresMinutes < 1 || expiresMinutes > 120) throw new ArgumentOutOfRangeException(nameof(expiresMinutes));

        email = email.Trim();

        string token = Generate6DigitToken();
        byte[] salt = RandomBytes(16);
        byte[] hash = Sha256Bytes(Combine(Encoding.UTF8.GetBytes(token), salt));

        DateTime expiresUtc = DateTime.UtcNow.AddMinutes(expiresMinutes);

        int newId = SpInsertToken(email, hash, salt, expiresUtc, invalidatePrevious);

        // Enviar después de guardar
        SendEmail(email, token, expiresMinutes);

        return newId;
    }

    /// <summary>
    /// Valida el token contra el último activo (no usado y no expirado). Si es correcto, lo marca como usado.
    /// </summary>
    public bool ValidateToken(string email, string token, int maxAttempts = 5)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            return false;

        email = email.Trim();
        token = token.Trim();

        if (!IsSixDigits(token)) return false;

        TokenRow row = SpGetLatestActive(email);
        if (row == null) return false;

        // Control de intentos
        if (maxAttempts > 0 && row.Attempts >= maxAttempts)
            return false;

        byte[] computedHash = Sha256Bytes(Combine(Encoding.UTF8.GetBytes(token), row.Salt));

        if (!FixedTimeEquals(computedHash, row.Hash))
        {
            SpIncrementAttempts(row.Id);
            return false;
        }

        SpMarkUsed(row.Id);
        return true;
    }

    // ---------------------------
    // Stored Procedures
    // ---------------------------

    private int SpInsertToken(string email, byte[] hash, byte[] salt, DateTime expiresUtc, bool invalidatePrevious)
    {
        using (var cn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("dbo.sp_EmailToken_Insert", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 320).Value = email;
            cmd.Parameters.Add("@TokenHash", SqlDbType.VarBinary, 32).Value = hash;
            cmd.Parameters.Add("@TokenSalt", SqlDbType.VarBinary, 16).Value = salt;
            cmd.Parameters.Add("@ExpiresAtUtc", SqlDbType.DateTime2).Value = expiresUtc;
            cmd.Parameters.Add("@InvalidatePrevious", SqlDbType.Bit).Value = invalidatePrevious;

            var pOut = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(pOut);

            cn.Open();
            cmd.ExecuteNonQuery();

            return (pOut.Value == DBNull.Value) ? 0 : Convert.ToInt32(pOut.Value);
        }
    }

    private TokenRow SpGetLatestActive(string email)
    {
        using (var cn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("dbo.sp_EmailToken_GetLatestActive", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 320).Value = email;

            cn.Open();
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return null;

                return new TokenRow
                {
                    Id = Convert.ToInt32(rd["Id"]),
                    Hash = (byte[])rd["TokenHash"],
                    Salt = (byte[])rd["TokenSalt"],
                    Attempts = Convert.ToInt32(rd["Attempts"])
                };
            }
        }
    }

    private void SpMarkUsed(int id)
    {
        using (var cn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("dbo.sp_EmailToken_MarkUsed", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    private void SpIncrementAttempts(int id)
    {
        using (var cn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("dbo.sp_EmailToken_IncrementAttempts", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // ---------------------------
    // Email (MailKit, SSL/TLS 465)
    // ---------------------------

    private void SendEmail(string toEmail, string token, int expiresMinutes)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
            throw new ArgumentException("Email destino requerido.", nameof(toEmail));

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_fromName, _fromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail.Trim()));
        message.Subject = "Tu código de verificación";

        message.Body = new TextPart("plain")
        {
            Text =
                "Tu código de verificación es: " + token + Environment.NewLine +
                "Vence en " + expiresMinutes + " minuto(s)." + Environment.NewLine +
                "Si no solicitaste esto, ignora este correo."
        };

        // MailKit es más robusto que System.Net.Mail.SmtpClient, especialmente con 465 (SSL implícito)
        using (var client = new SmtpClient())
        {
            client.Timeout = 15000;

            client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                // Si no hay errores, OK
                if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;

                // Permitimos SOLO el error de revocación (offline/unknown)
                // y rechazamos cualquier otro (CN mismatch, cadena inválida, etc.)
                if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors && chain != null)
                {
                    bool onlyRevocationIssues = true;

                    foreach (var status in chain.ChainStatus)
                    {
                        var s = status.Status;

                        bool isRevocationProblem =
                            s == X509ChainStatusFlags.RevocationStatusUnknown ||
                            s == X509ChainStatusFlags.OfflineRevocation ||
                            s == X509ChainStatusFlags.Revoked; // <- normalmente NO deberías permitir "Revoked"

                        // Recomendación: NO permitir Revoked.
                        if (s == X509ChainStatusFlags.Revoked)
                            return false;

                        if (!isRevocationProblem && s != X509ChainStatusFlags.NoError)
                        {
                            onlyRevocationIssues = false;
                            break;
                        }
                    }

                    if (onlyRevocationIssues)
                        return true;
                }

                return false;
            };

            client.Connect(_smtpHost, _smtpPort, SecureSocketOptions.SslOnConnect);
            client.Authenticate(_smtpUser, _smtpPass);
            client.Send(message);
            client.Disconnect(true);
        }
    }

    // ---------------------------
    // Helpers / Crypto
    // ---------------------------

    private static string ReadConnFromAppSettings(string key)
    {
        string cs = ConfigurationManager.AppSettings[key];
        if (string.IsNullOrWhiteSpace(cs))
            throw new ConfigurationErrorsException("No existe appSettings key=\"" + key + "\" o está vacía.");

        return cs;
    }

    private static string Generate6DigitToken()
    {
        // 000000 - 999999, seguro
        byte[] b = new byte[4];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(b);
        }

        uint value = BitConverter.ToUInt32(b, 0);
        int code = (int)(value % 1_000_000);
        return code.ToString("D6");
    }

    private static bool IsSixDigits(string token)
    {
        if (token == null || token.Length != 6) return false;
        for (int i = 0; i < 6; i++)
        {
            char c = token[i];
            if (c < '0' || c > '9') return false;
        }
        return true;
    }

    private static byte[] RandomBytes(int size)
    {
        byte[] b = new byte[size];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(b);
        }
        return b;
    }

    private static byte[] Sha256Bytes(byte[] data)
    {
        using (var sha = SHA256.Create())
        {
            return sha.ComputeHash(data);
        }
    }

    private static byte[] Combine(byte[] a, byte[] b)
    {
        byte[] r = new byte[a.Length + b.Length];
        Buffer.BlockCopy(a, 0, r, 0, a.Length);
        Buffer.BlockCopy(b, 0, r, a.Length, b.Length);
        return r;
    }

    private static bool FixedTimeEquals(byte[] a, byte[] b)
    {
        if (a == null || b == null) return false;

        int diff = a.Length ^ b.Length;
        int min = Math.Min(a.Length, b.Length);

        for (int i = 0; i < min; i++)
            diff |= a[i] ^ b[i];

        return diff == 0;
    }

    private sealed class TokenRow
    {
        public int Id;
        public byte[] Hash;
        public byte[] Salt;
        public int Attempts;
    }
}
