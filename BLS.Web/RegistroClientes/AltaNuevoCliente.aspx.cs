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



        public List<Cat_CodigosPostales> CatCodigosPotales
        {
            get => Session["sseCatCodigosPotales"] as List<Cat_CodigosPostales> ?? new List<Cat_CodigosPostales>();
            set => Session["sseCatCodigosPotales"] = value;
        }


        public string IdEstadoRepublicaSelect
        {
            get => (Session["ssIdEstadoRepublicaSelect"] as string) ?? "";
            set => Session["ssIdEstadoRepublicaSelect"] = value;
        }
        public string IdMunicipioSelect
        {
            get => (Session["ssIdMunicipioSelect"] as string) ?? "";
            set => Session["ssIdMunicipioSelect"] = value;
        }

        public string NombreAsentamientoSelect
        {
            get => (Session["ssNombreAsentamientoSelect"] as string) ?? "";
            set => Session["ssNombreAsentamientoSelect"] = value;
        }

        public string CPSelect
        {
            get => (Session["ssCPSelect"] as string) ?? "";
            set => Session["ssCPSelect"] = value;
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



        //public List<Cat_estados>  CatEstadosRepublica
        //{
        //    get => Session["ssCatEstadosRepublica"] as List<Cat_estados> (() )?? new List<Cat_estados>();
        //    set => Session["ssCatEstadosRepublica"] = value;
        //}

        #endregion



        private void DameCatalogos()
        {
            CatCodigosPotales = datoscrud.ConsultaCatCodigosPostales();



            cmbEstado.DataBind();
            cmbCiudad.DataBind();
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NuevoCliente = new Clientes();
                NuevoUsuario = new Usuarios();
                ContraseñaValida = false;
                TokenValidado = false;
                IdEstadoRepublicaSelect = "";
                IdMunicipioSelect = "";
                NombreAsentamientoSelect = "";
                CPSelect = "";

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


                    if (IdEstadoRepublicaSelect=="" || IdMunicipioSelect =="" || NombreAsentamientoSelect=="" || CPSelect=="")  // valida que todas las variables tenga datos 
                    {
                        plnPrincipal.JSProperties["cp_swMsg"] = "Error el procesar los codigos de minucipios / intente de nuevo";
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
                    NuevoCliente.DomAsentamiento = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect &&
                                                                           x.c_mnpio == IdMunicipioSelect && x.d_asenta== NombreAsentamientoSelect).FirstOrDefault().d_asenta;
                    NuevoCliente.DomCiudad = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect && x.c_mnpio== IdMunicipioSelect).FirstOrDefault().D_mnpio;
                    NuevoCliente.DomEstado = CatCodigosPotales.Where(x => x.c_estado == IdEstadoRepublicaSelect).FirstOrDefault().d_estado;
                    NuevoCliente.DomCP = Convert.ToInt32(CPSelect);
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

        protected void cmbCiudad_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            // filtrar ciudades por estado seleccionado
            IdMunicipioSelect = e.Parameter; 

            foreach (var item in CatCodigosPotales.Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim() && x.c_mnpio.Trim() == IdMunicipioSelect).ToList())
            {
                cmbCiudad.Items.Add(item.d_asenta.Trim(), item.Indice.ToString());

            }

            //cmbCiudad.DataBind();
        }


        protected void cmbCodigoPostal_Callback1(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {


            if (e.Parameter.Contains("Carga"))
            {
                NombreAsentamientoSelect = e.Parameter.Split('~')[1].ToString();


                foreach (var item in CatCodigosPotales.Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim() && x.c_mnpio.Trim() == IdMunicipioSelect && x.d_asenta == NombreAsentamientoSelect).ToList())
                {
                    cmbCodigoPostal.Items.Add( item.d_codigo.ToString(), item.d_codigo.ToString());

                }

                //if (cmbCodigoPostal.Items.Count > 0)
                //{
                //    cmbCodigoPostal.SelectedIndex = 0;
                //    CPSelect = cmbCodigoPostal.Items[0].Text;
                //}

                return;

            }

            //if (e.Parameter.Contains("Seleccion"))
            //{
            //    CPSelect = e.Parameter.Split('~')[1].ToString();

               
            //    foreach (var item in CatCodigosPotales.Where(x => x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim() && x.c_mnpio.Trim() == IdMunicipioSelect && x.d_asenta == NombreAsentamientoSelect).ToList())
            //    {
            //        cmbCodigoPostal.Items.Add(item.d_codigo.ToString(), item.d_codigo.ToString());

            //    }

            //    cmbCodigoPostal.Text = CPSelect;
            //    cmbCodigoPostal.SelectedIndex = CatCodigosPotales.FindIndex( w=> w.d_codigo== CPSelect);

            //    return;
            //}


     

            

        }

        protected void cmbMunicipio_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            IdEstadoRepublicaSelect = e.Parameter;

            IdMunicipioSelect = "";
            NombreAsentamientoSelect = "";
            CPSelect = "";


            var ListaXMunicipio = CatCodigosPotales.Where(x=> x.c_estado.Trim() == IdEstadoRepublicaSelect.Trim()).GroupBy(x => new
            {
                D_mnpio = x.D_mnpio.Trim(),
                c_mnpio = x.c_mnpio.Trim()
            }).Select(g => new { g.Key.D_mnpio, g.Key.c_mnpio }).OrderBy(x => x.c_mnpio).ToList();




            foreach (var item in ListaXMunicipio)
            {
                cmbMunicipio.Items.Add(item.D_mnpio.Trim(), item.c_mnpio.ToString());
               
            }
        }
    }
}
