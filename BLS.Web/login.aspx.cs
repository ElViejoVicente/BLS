using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLS.Negocio.CRUD;

namespace BLS.Web
{
    public partial class Login : PageBase
    {
        private UsuariosEXT user = null;
        private List<Sociedad> ListaSociedades = null;
        private List<SociedadXUsuario> ListaSociedadesAutorizadas = null;
        // token service instance - read SMTP settings from web.config appSettings or use defaults
        private EmailTokenService _tokenService;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["usuario"] = null;
                Session["listaSociedades"] = null;
                Session["sociedadesXusuario"] = null;
                if (!Page.IsPostBack)
                {
                    Response.Expires = 0;






                }
                txtUsername.Focus();

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        protected void BT_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    //ventana de error por que no estan los campos rellenado
                    cuInfoMsgbox1.mostrarMensaje("Todos los campos son requeridos", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    return;
                }

                user = datosUsuario.DameDatosUsuario(txtUsername.Text.Trim());
                if (user == null)
                {
                    //ventana de error por que no existe el usuario
                    cuInfoMsgbox1.mostrarMensaje("Usuario no existe, porfavor verifique.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                if (user.usActivo == false)
                {
                    //ventana de error por que el usuario esta dado de baja
                    cuInfoMsgbox1.mostrarMensaje("Usuario dado de baja.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    return;

                }


                if (PasswordHasher.VerifyPassword(txtPassword.Text.Trim(), user.usPWD))
                {

                    // despues de la validacion de contraseña consultamos las socieades permitidas para este usuario.
                    Session["usuario"] = user;
                      
                    Response.Redirect("index.aspx");


                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Usuario/Contraseña incorrectos.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    //ventana de error por usuario o cony¡traseña no validos
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void cuInfoMsgbox1_RespuestaClicked(object sender, EventArgs e)
        {
            string u = "";
        }

        // Handler to open popup from ASPX button - simply show popup client side via server
        protected void btnRecuperarContreseña_Click(object sender, EventArgs e)
        {
            // show popup control
            ppcRecuperar.ShowOnPageLoad = true;
        }

        protected void btnEnviarToken_Click(object sender, EventArgs e)
        {
            try
            {

                var smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtp.host"] ?? "mail.consultoria-it.com";
                var smtpPort = int.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.port"], out var p) ? p : 465;
                var smtpUser = System.Configuration.ConfigurationManager.AppSettings["smtp.user"] ?? "no-responder@consultoria-it.com";
                var smtpPass = System.Configuration.ConfigurationManager.AppSettings["smtp.pass"] ?? "inteldx486mail";
                var smtpSsl = bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.ssl"], out var s) ? s : true;
                var fromEmail = System.Configuration.ConfigurationManager.AppSettings["smtp.from"] ?? smtpUser;
                var fromName = System.Configuration.ConfigurationManager.AppSettings["smtp.fromname"] ?? "Soporte";
                _tokenService = new EmailTokenService(smtpHost, smtpPort, smtpUser, smtpPass, smtpSsl, fromEmail, fromName);


                string email = txtRecovEmail.Text?.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    // show message inside popup label instead of cuInfoMsgbox1
                    lblRecovMsg.CssClass = "text-danger";
                    lblRecovMsg.Text = "Ingrese el correo electrónico.";
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                // verify user exists
                var usuario = new DatosCrud().ConsultaUsuario();
                // DatosCrud.ConsultaUsuario() returns list of usuarios when called without param; but easier: use DatosUsuario.DameDatosUsuario
                var usuarioExt = datosUsuario.DameDatosUsuario(email);
                if (usuarioExt == null)
                {
                    lblRecovMsg.CssClass = "text-danger";
                    lblRecovMsg.Text = "No existe un usuario con ese correo.";
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                // generate, store and send token using EmailTokenService
                int id = _tokenService.GenerateStoreAndSendToken(email, expiresMinutes: 10, invalidatePrevious: true);

                // enable token and password fields in popup
                txtRecovToken.Enabled = true;
                txtRecovNewPassword.Enabled = true;
                txtRecovConfirmPassword.Enabled = true;
                btnApplyNewPassword.Enabled = true;

                ppcRecuperar.ShowOnPageLoad = true;

                lblRecovMsg.CssClass = "text-success";
                lblRecovMsg.Text = "Se envió un código al correo. Revise su bandeja (incluida la carpeta de spam o " +
                                      "correo no deseado).";

            }
            catch (Exception ex)
            {
                lblRecovMsg.CssClass = "text-danger";
                lblRecovMsg.Text = "Error enviando el correo: " + ex.Message;
                ppcRecuperar.ShowOnPageLoad = true;
            }
        }

        protected void btnApplyNewPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtRecovEmail.Text?.Trim();
                string token = txtRecovToken.Text?.Trim();
                string newPwd = txtRecovNewPassword.Text ?? "";
                string confirm = txtRecovConfirmPassword.Text ?? "";

                var smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtp.host"] ?? "mail.consultoria-it.com";
                var smtpPort = int.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.port"], out var p) ? p : 465;
                var smtpUser = System.Configuration.ConfigurationManager.AppSettings["smtp.user"] ?? "no-responder@consultoria-it.com";
                var smtpPass = System.Configuration.ConfigurationManager.AppSettings["smtp.pass"] ?? "inteldx486mail";
                var smtpSsl = bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.ssl"], out var s) ? s : true;
                var fromEmail = System.Configuration.ConfigurationManager.AppSettings["smtp.from"] ?? smtpUser;
                var fromName = System.Configuration.ConfigurationManager.AppSettings["smtp.fromname"] ?? "Soporte";
                _tokenService = new EmailTokenService(smtpHost, smtpPort, smtpUser, smtpPass, smtpSsl, fromEmail, fromName);

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                {
                    cuInfoMsgbox1.mostrarMensaje("Correo y código son requeridos.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                if (newPwd.Length < 8 || newPwd == "12345678" || newPwd == "87654321")
                {
                    cuInfoMsgbox1.mostrarMensaje("La contraseña no cumple los niveles de seguridad. Introduzca una contraseña con al menos 8 carácteres", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                if (newPwd != confirm)
                {
                    cuInfoMsgbox1.mostrarMensaje("Las contraseñas no coinciden.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                // validate token
                bool valid = _tokenService.ValidateToken(email, token);
                if (!valid)
                {
                    cuInfoMsgbox1.mostrarMensaje("Código inválido o excedió el número de intentos.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                // get usuario and update password hash using PasswordHasher and DatosCrud
                DatosCrud crud = new DatosCrud();
                var usuario = crud.ConsultaUsuario().FirstOrDefault(u => string.Equals(u.usMail, email, StringComparison.OrdinalIgnoreCase));
                if (usuario == null)
                {
                    cuInfoMsgbox1.mostrarMensaje("Usuario no encontrado.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    ppcRecuperar.ShowOnPageLoad = true;
                    return;
                }

                usuario.usPWD = PasswordHasher.HashPassword(newPwd.Trim());
                bool ok = crud.ActualizarUsuarios(usuario);
                if (ok)
                {
                    cuInfoMsgbox1.mostrarMensaje("Contraseña actualizada correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.info);
                    // close popup
                    ppcRecuperar.ShowOnPageLoad = false;
                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Error actualizando la contraseña.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    ppcRecuperar.ShowOnPageLoad = true;
                }

            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error: " + ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
                ppcRecuperar.ShowOnPageLoad = true;
            }
        }

    }
}