using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;            // 128-bit
        private const int KeySize = 32;             // 256-bit
        private const int DefaultIterations = 200000;

        /// <summary>
        /// Genera un hash PBKDF2 (HMACSHA256) con salt aleatoria.
        /// Retorna un string para guardar en BD.
        /// Formato: PBKDF2$SHA256$iteraciones$saltB64$hashB64
        /// </summary>
        public static string HashPassword(string password, int iterations = DefaultIterations)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (iterations < 50000) throw new ArgumentOutOfRangeException(nameof(iterations), "Iteraciones demasiado bajas.");

            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(KeySize);
            }

            string saltB64 = Convert.ToBase64String(salt);
            string hashB64 = Convert.ToBase64String(hash);

            return $"PBKDF2$SHA256${iterations}${saltB64}${hashB64}";
        }

        /// <summary>
        /// Verifica si el password coincide con el hash guardado.
        /// Retorna true/false.
        /// </summary>
        public static bool VerifyPassword(string password, string stored)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(stored)) return false;

            // Esperamos: PBKDF2$SHA256$iterations$salt$hash
            string[] parts = stored.Split('$');
            if (parts.Length != 5) return false;

            if (!string.Equals(parts[0], "PBKDF2", StringComparison.Ordinal)) return false;
            if (!string.Equals(parts[1], "SHA256", StringComparison.Ordinal)) return false;

            int iterations;
            if (!int.TryParse(parts[2], out iterations) || iterations <= 0) return false;

            byte[] salt;
            byte[] expectedHash;
            try
            {
                salt = Convert.FromBase64String(parts[3]);
                expectedHash = Convert.FromBase64String(parts[4]);
            }
            catch
            {
                return false;
            }

            byte[] actualHash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                actualHash = pbkdf2.GetBytes(expectedHash.Length);
            }

            return FixedTimeEquals(actualHash, expectedHash);
        }

        /// <summary>
        /// Comparación en tiempo constante (para evitar timing attacks).
        /// </summary>
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;

            int diff = a.Length ^ b.Length;
            int min = Math.Min(a.Length, b.Length);

            for (int i = 0; i < min; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }

    }
}
