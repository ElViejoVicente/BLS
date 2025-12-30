using BLS.Negocio.CRUD;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Configuracion;
using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Cat_EstadosRepublica> CatEstadosRepublica
        {
            get
            {
                List<Cat_EstadosRepublica> sseCatEstadosRepublica = new List<Cat_EstadosRepublica>();
                if (this.Session["sseCatEstadosRepublica"] != null)
                {
                    sseCatEstadosRepublica = (List<Cat_EstadosRepublica>)this.Session["sseCatEstadosRepublica"];
                }
                return sseCatEstadosRepublica;
            }

            set
            {
                this.Session["sseCatEstadosRepublica"] = value;
            }
        }


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



        private void DameCatalogos()
        {
            CatEstadosRepublica = datoscrud.ConsultaCatEstadosRepublica();

            cbEstadosRepublica.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NuevoCliente = new Clientes();
                NuevoUsuario = new Usuarios();
                ContraseñaValida = false;
                TokenValidado = false;

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
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
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

                    NuevoUsuario.usMail = txtCorreoCliente.Text;


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

                    if (TokenValidado == false)
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "Código inválido o excedió el número de intentos.";
                        plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                        plnPrincipal.JSProperties["cp_swClose"] = "";
                        plnPrincipal.JSProperties["cp_Reload"] = "";
                        return;

                    }

                    // Y MAS validaciones , entonces

                    // sin antes guardar el valos de los campos nuevos en la variable de session 


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
                    NuevoCliente.DomNumeroInt = txtNumeroInterior.Text.Trim();
                    NuevoCliente.DomNumeroExt = txtNumeroExterior.Text.Trim();
                    NuevoCliente.DomCiudad = txtDomCiudad.Text;
                    NuevoCliente.DomEstado = txtDomEstado.Text;
                    NuevoCliente.DomCP = Convert.ToInt32(txtDomCP.Text);
                    NuevoCliente.DomTelefono = txtTelefono.Text;


                    //NuevoUsuario.usCodigo = 0;
                    //NuevoUsuario.usMail 
                    NuevoUsuario.usActivo = true;
                    NuevoUsuario.usPWD = PasswordHasher.HashPassword(txtPassword.Text.Trim());
                    NuevoUsuario.usNombre = NuevoCliente.PrimerNombre + " " + NuevoCliente.AppPaterno + " " + NuevoCliente.AppMaterno;
                    NuevoUsuario.usFecAlta = DateTime.Now;
                    NuevoUsuario.usFecBaja = FechaGlobal;

                    Usuarios nuevoUsuarioTmp = new Usuarios();
                    nuevoUsuarioTmp = NuevoUsuario;



                    if (datoscrud.AltaUsuarios(ref nuevoUsuarioTmp))
                    {
                        if (nuevoUsuarioTmp.usCodigo > 0)
                        {

                            NuevoCliente.idCliente = nuevoUsuarioTmp.usCodigo;

                        }
                        else
                        {
                            plnPrincipal.JSProperties["cp_swMsg"] = "Error al intentar registrar el nuevo usuario, intente de nuevo.";
                            plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;
                            plnPrincipal.JSProperties["cp_swClose"] = "";
                            plnPrincipal.JSProperties["cp_Reload"] = "";
                            return;


                        }

                    }



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





            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void cbPwdSession_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
      
            if (e.Parameter == "1")
            {
                ContraseñaValida = true;
            }
            else
            {
                ContraseñaValida = false;
            }

        }
    }
}
