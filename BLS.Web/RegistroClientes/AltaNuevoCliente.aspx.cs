using BLS.Negocio.CRUD;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Negocio.RegistroClientes;
using BLS.Web.Configuracion;
using DevExpress.CodeParser;
using DevExpress.XtraRichEdit.Import.OpenXml;
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



        public List<Cat_CodigosPostales> CatCodigosPotales
        {
            get => Session["sseCatCodigosPotales"] as List<Cat_CodigosPostales> ?? new List<Cat_CodigosPostales>();
            set => Session["sseCatCodigosPotales"] = value;
        }


        //public List<CodigosMunicipios> CatCodigosPotalesXEstado
        //{
        //    get => Session["sseCatCodigosPotalesXEstado"] as List<CodigosMunicipios> ?? new List<CodigosMunicipios>();
        //    set => Session["sseCatCodigosPotalesXEstado"] = value;
        //}
        public List<CodigosMunicipios> CatCodigosPotalesXEstadoMunicipio
        {
            get => Session["sseCatCodigosPotalesXEstadoMunicipio"] as List<CodigosMunicipios> ?? new List<CodigosMunicipios>();
            set => Session["sseCatCodigosPotalesXEstadoMunicipio"] = value;
        }

        public List<CodigosAsentamientos> CatCodigosPotalesXEstadoMunicipioAsentamiento
        {
            get => Session["ssCatCodigosPotalesXEstadoMunicipioAsentamiento"] as List<CodigosAsentamientos> ?? new List<CodigosAsentamientos>();
            set => Session["ssCatCodigosPotalesXEstadoMunicipioAsentamiento"] = value;
        }

        public List<CodigosPostales> CatCodigosPotalesXEstadoMunicipioAsentamientoCP
        {
            get => Session["ssCatCodigosPotalesXEstadoMunicipioAsentamientoCP"] as List<CodigosPostales> ?? new List<CodigosPostales>();
            set => Session["ssCatCodigosPotalesXEstadoMunicipioAsentamientoCP"] = value;
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
            CatCodigosPotales = datoscrud.ConsultaCatCodigosPostales();



            cmbEstado.DataBind();
            cmbMunicipio.DataBind();
            cmbCiudad.DataBind();
            cmbCodigoPostal.DataBind();

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

                DameCatalogos();



                /// aqui se llena CatEstadosRepublica    = DA

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


                    //if (IdEstadoRepublicaSelect == "" || IdMunicipioSelect == "" || NombreAsentamientoSelect == "" || CPSelect == "")  // valida que todas las variables tenga datos 
                    //{
                    //    plnPrincipal.JSProperties["cp_swMsg"] = "Error el procesar los codigos de minucipios / intente de nuevo";
                    //    plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                    //    plnPrincipal.JSProperties["cp_swClose"] = "";
                    //    plnPrincipal.JSProperties["cp_Reload"] = "";
                    //    return;
                    //}

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
                    //NuevoCliente.DomAsentamiento = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect &&
                    //                                                       x.c_mnpio == IdMunicipioSelect && x.d_asenta == NombreAsentamientoSelect).FirstOrDefault().d_asenta;
                    //NuevoCliente.DomCiudad = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect && x.c_mnpio == IdMunicipioSelect).FirstOrDefault().D_mnpio;
                    //NuevoCliente.DomEstado = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect).FirstOrDefault().d_estado;
                    //NuevoCliente.DomCP = Convert.ToInt32(CPSelect);
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


                    plnPrincipal.JSProperties["cp_swMsg"] = "Tu cuenta se ha creado correctamente. Ya puedes iniciar sesión y comenzar a usar el sistema. Bienvenido.!";
                    plnPrincipal.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
                    plnPrincipal.JSProperties["cp_swClose"] = "";
                    plnPrincipal.JSProperties["cp_Reload"] = "";
                    plnPrincipal.JSProperties["cp_RedirectUrl"] = "../login.aspx";


                    Session["usuario"] = null;

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

        protected void cmbEstado_DataBinding(object sender, EventArgs e)
        {
            cmbEstado.TextField = "d_estado";
            cmbEstado.ValueField = "c_estado";

            cmbEstado.DataSource = CatCodigosPotales.GroupBy(x => new
            {
                d_estado = x.d_estado.Trim(),
                c_estado = x.c_estado.Trim()
            }).Select(g => new { g.Key.d_estado, g.Key.c_estado }).OrderBy(x => x.d_estado).ToList();



        }



        protected void cmbMunicipio_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var IdEstadoRepublicaSelect = e.Parameter;



            CatCodigosPotalesXEstadoMunicipio = CatCodigosPotales.Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim()).GroupBy(x => new 
            {
                D_mnpio = x.D_mnpio.Trim(),
                c_mnpio = x.c_mnpio.Trim()
            }).Select(g => new CodigosMunicipios { D_mnpio= g.Key.D_mnpio, c_mnpio=g.Key.c_mnpio }).OrderBy(x => x.c_mnpio).ToList();


            cmbMunicipio.TextField = "D_mnpio";
            cmbMunicipio.ValueField = "c_mnpio";

            cmbMunicipio.DataSource = CatCodigosPotalesXEstadoMunicipio;


            cmbMunicipio.DataBind();


        }




        protected void cmbMunicipio_DataBinding1(object sender, EventArgs e)
        {

            cmbMunicipio.TextField = "D_mnpio";
            cmbMunicipio.ValueField = "c_mnpio";

            cmbMunicipio.DataSource = CatCodigosPotalesXEstadoMunicipio;
        }


        protected void cmbCiudad_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            // filtrar ciudades por estado seleccionado
            var IdMunicipioSelect = e.Parameter;
            var IdEstadoRepublicaSelect = cmbEstado.Value.ToString();


            CatCodigosPotalesXEstadoMunicipioAsentamiento = CatCodigosPotales
                .Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim()
                         && x.c_mnpio.Trim() == IdMunicipioSelect)
                .Select(x => new CodigosAsentamientos
                {
                    d_asenta = x.d_asenta,
                    Indice = x.Indice.ToString()
                })
                .ToList();

            cmbCiudad.TextField = "d_asenta";
            cmbCiudad.ValueField = "Indice";
            cmbCiudad.DataSource = CatCodigosPotalesXEstadoMunicipioAsentamiento;


            cmbCiudad.DataBind();

            //cmbCiudad.DataBind();
        }




        protected void cmbCiudad_DataBinding1(object sender, EventArgs e)
        {
            cmbCiudad.TextField = "d_asenta";
            cmbCiudad.ValueField = "Indice";
            cmbCiudad.DataSource = CatCodigosPotalesXEstadoMunicipioAsentamiento;
        }




        protected void cmbCodigoPostal_Callback1(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var NombreAsentamientoSelect = e.Parameter.Split('~')[0].ToString();

            var IdEstadoRepublicaSelect = cmbEstado.Value.ToString();
            var IdMunicipioSelect = cmbMunicipio.Value.ToString();


            CatCodigosPotalesXEstadoMunicipioAsentamientoCP = CatCodigosPotales.Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim() &&
            x.c_mnpio.Trim() == IdMunicipioSelect && x.d_asenta == NombreAsentamientoSelect).ToList().Select (x=> new CodigosPostales { d_codigo = x.d_codigo }).ToList();

            cmbCodigoPostal.DataBind();

            return;

        }

        protected void cmbCodigoPostal_DataBinding1(object sender, EventArgs e)
        {
            cmbCodigoPostal.TextField = "d_codigo";
            cmbCodigoPostal.ValueField = "d_codigo";

            cmbCodigoPostal.DataSource = CatCodigosPotalesXEstadoMunicipioAsentamientoCP;
        }

    }
}
