using BLS.Negocio.CRUD;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Configuracion;
using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BLS.Negocio.Operativa.Constantes;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace BLS.Web.RegistroClientes
{
    public partial class AltaNuevoCliente : System.Web.UI.Page
    {
        #region Propiedades

        DatosCrud datoscrud = new DatosCrud();


        public bool ContraseñaValida
        {
            get => (Session["ssContraseñaValida"] as bool?) ?? false;
            set => Session["ssContraseñaValida"] = value;
        }

        // inicializar la clase para envio de tokens por email

        public bool TokenValidado
        {
            get => (Session["ssTokenValidado"] as bool?) ?? false;
            set => Session["ssTokenValidado"] = value;
        }



        public EmailTokenService _tokenService
        {
            get => Session["ss_tokenService"] as EmailTokenService ?? new EmailTokenService();
            set => Session["ss_tokenService"] = value;
        }


        public Clientes NuevoCliente
        {
            get => Session["ssNuevoClienteSBL"] as Clientes ?? new Clientes();
            set => Session["ssNuevoClienteSBL"] = value;
        }

        public Usuarios NuevoUsuario
        {
            get => Session["ssNuevoUsuarioSBL"] as Usuarios ?? new Usuarios();
            set => Session["ssNuevoUsuarioSBL"] = value;
        }


        #endregion





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NuevoCliente = new Clientes();
                NuevoUsuario = new Usuarios();



                var smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtp.host"] ?? "mail.consultoria-it.com";
                var smtpPort = int.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.port"], out var p) ? p : 465;
                var smtpUser = System.Configuration.ConfigurationManager.AppSettings["smtp.user"] ?? "no-responder@consultoria-it.com";
                var smtpPass = System.Configuration.ConfigurationManager.AppSettings["smtp.pass"] ?? "inteldx486mail";
                var smtpSsl = bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["smtp.ssl"], out var s) ? s : true;
                var fromEmail = System.Configuration.ConfigurationManager.AppSettings["smtp.from"] ?? smtpUser;
                var fromName = System.Configuration.ConfigurationManager.AppSettings["smtp.fromname"] ?? "Soporte";

                _tokenService = new EmailTokenService(smtpHost, smtpPort, smtpUser, smtpPass, smtpSsl, fromEmail, fromName);


            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {


            lblErrorTerminos.Visible = false;

            // Validar Términos y Política
            if (!frmAltaCliente_E3.Checked || !frmAltaCliente_E3.Checked)
            {
                lblErrorTerminos.Text = "Debes aceptar los Términos y Condiciones y la Política de Privacidad.";
                lblErrorTerminos.Visible = true;
                return;
            }



            //pnlRegistro.ClientVisible = false;

          
        }


        private void OcultarControlesValidacion()
        {
            btnEnviarCodVerificiacionEmail.ClientVisible = !TokenValidado;
            txtCodVerificacionEmail.ClientEnabled = !TokenValidado;
            txtCorreoCliente.ClientEnabled = !TokenValidado;
            btnValidarCodigoNewCliente.ClientVisible = !TokenValidado;

        }

        protected void plnPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            {
                OcultarControlesValidacion();



                if (e.Parameter.Contains("ValidarCodigoNewCliente"))

                { 
                    string tokenRecivido = txtCodVerificacionEmail.Text.Trim();


                    bool valid = _tokenService.ValidateToken(NuevoUsuario.usMail, tokenRecivido);

                    if (valid)
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "Código validado correctamente..";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success ;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        TokenValidado = true;
                   
                    }
                    else
                    {

                        plnPrincipal.JSProperties["cp_swMsg"] = "Código inválido o excedió el número de intentos.";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        TokenValidado = false;

                        return;

                    }




                    OcultarControlesValidacion();

                        return;
                }

                if (e.Parameter.Contains("EnviarCodigoValidacionEmail"))
                {




                    //  en datos sencibles hacer una copia del mismo en una propiedad;

                    NuevoUsuario.usMail  = txtCorreoCliente.Text;


                    int id = _tokenService.GenerateStoreAndSendToken(NuevoUsuario.usMail, expiresMinutes: 10);



                    plnPrincipal.JSProperties["cp_swMsg"] = "Se envió un código al correo. Revise su bandeja (incluida la carpeta de spam o correo no deseado).";
                    plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.info;
                    plnPrincipal.JSProperties["cp_swClose"] = "";
                    plnPrincipal.JSProperties["cp_Reload"] = "";

                    return;
                }


                if (e.Parameter.Contains("GuardarDatosIniciales"))
                {
                    if (ContraseñaValida == false)
                    {

                        plnPrincipal.JSProperties["cp_swMsg"] = "No se ha establecido correctamente la contraseña";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        return;
                    }

                    if (TokenValidado ==false)
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "Código inválido o excedió el número de intentos.";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        return;

                    }

                    // Y MAS validaciones , entonces

                    // sin antes guardar el valos de los campos nuevos en la variable de session 


                    var hastPwd  = 


                    NuevoUsuario.usCodigo = 0;
                    //NuevoUsuario.usMail 
                    NuevoUsuario.usActivo = true;
                    NuevoUsuario.usPWD = PasswordHasher.HashPassword(txtPassword.Text.Trim());
                    NuevoUsuario.usNombre = NuevoCliente.PrimerNombre + " " + NuevoCliente.AppPaterno + " " + NuevoCliente.AppMaterno;
                    NuevoUsuario.usFecAlta = DateTime.Now;
                    NuevoUsuario.usFecBaja = FechaGlobal;

                    if (datoscrud.AltaUsuarios(NuevoUsuario))
                    {
                        if (NuevoUsuario.usCodigo>0)
                        {

                            NuevoCliente.idCliente=NuevoUsuario.usCodigo;

                        }
                        else
                        {
                            plnPrincipal.JSProperties["cp_swMsg"] = "Error al intentar registrar el nuevo usuario, intente de nuevo.";
                            plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error ;
                            plnPrincipal.JSProperties["cp_swClose"] = "";
                            plnPrincipal.JSProperties["cp_Reload"] = "";
                            return;


                        }

                    }

                    NuevoCliente.Activo = false;
                    NuevoCliente.FechaRegistro = DateTime.Now;
                    NuevoCliente.PrimerNombre = txtPrimerNombre.Text;
                    NuevoCliente.SegunoNombre = txtSegundoNombre.Text;
                    NuevoCliente.AppPaterno = txtAppPaterno.Text;
                    NuevoCliente.AppMaterno = txtAppMaterno.Text;
                    NuevoCliente.FechaNacimiento = DateTime.Now;
                    NuevoCliente.NombreNegocio = txtDespachoConsultoria.Text;
                    NuevoCliente.RFC = txtRFC.Text;
                    NuevoCliente.DomCalle = txtDomicilio.Text;
                    NuevoCliente.DomNumeroInt = "";
                    NuevoCliente.DomNumeroExt = "";
                    NuevoCliente.DomCiudad = txtDomCiudad.Text;
                    NuevoCliente.DomEstado = txtDomEstado.Text;
                    NuevoCliente.DomCP = int.MaxValue;
                    NuevoCliente.DomTelefono = txtTelefono.Text;


                    if (!datoscrud.AltaClientes(NuevoCliente))
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "Error al intentar registrar el nuevo cliente, intente de nuevo.";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        return;

                    }


                    plnPrincipal.JSProperties["cp_swMsg"] = "Tu cuenta se ha creado correctamente. Ya puedes iniciar sesión y comenzar a usar el sistema.\r\n¡Bienvenido/a!";
                    plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
                    plnPrincipal.JSProperties["cp_swClose"] = "";
                    plnPrincipal.JSProperties["cp_Reload"] = "";


                    Session["usuario"] = null;

                    Response.Redirect("login.aspx");



                    return;
                }

                if (e.Parameter.Contains("ValidadContraseña"))
                {
                    string password = txtPassword.Text;
                    string confirmPassword = txtConfirPassword.Text;

                    // 2️ Coincidencia
                    if (password != confirmPassword)
                    {
                        lblErrorPassword.Text = "Las contraseñas no coinciden.";
                        lblErrorPassword.Visible = true;
                        return;
                    }
                    else
                    {
                        lblErrorPassword.Visible = false;
                    }


                    // 3️ Longitud mínima
                    if (password.Length < 8)
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "La contraseña debe tener al menos 8 caracteres.";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";

                        //lblErrorTerminos.Text = "";
                        //lblErrorTerminos.Visible = true;
                        return;
                    }

                    // 4️ Reglas de seguridad
                    if (!Regex.IsMatch(password, @"[A-Z]"))
                    {
                        lblErrorTerminos.Text = "La contraseña debe contener al menos una letra mayúscula.";
                        lblErrorTerminos.Visible = true;
                        return;
                    }

                    if (!Regex.IsMatch(password, @"[a-z]"))
                    {
                        lblErrorTerminos.Text = "La contraseña debe contener al menos una letra minúscula.";
                        lblErrorTerminos.Visible = true;
                        return;
                    }

                    if (!Regex.IsMatch(password, @"\d"))
                    {
                        lblErrorTerminos.Text = "La contraseña debe contener al menos un número.";
                        lblErrorTerminos.Visible = true;
                        return;
                    }

                    if (!Regex.IsMatch(password, @"[\W_]"))
                    {
                        lblErrorTerminos.Text = "La contraseña debe contener al menos un símbolo.";
                        lblErrorTerminos.Visible = true;
                        return;
                    }

                    ContraseñaValida = true;

                    return;
                }



            }
            catch (Exception)
            {

                throw;
            }

        }



  
    }
}
