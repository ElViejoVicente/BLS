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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;


namespace BLS.Web.RegistroClientes
{
    public partial class demoBS : System.Web.UI.Page
    {
        #region Propiedades
        private Boolean ContraseñaValida = false;

        // inicializar la clase para envio de tokens por email

        EmailTokenService svc = new EmailTokenService(
                                smtpHost: "mail.consultoria-it.com",
                                smtpPort: 465,
                                smtpUser: "no-responder@consultoria-it.com",
                                smtpPass: "inteldx486mail",
                                smtpEnableSsl: true,
                                fromEmail: "manueldesion22@gmail.com",
                                fromName: "Verificacion Cuenta BLS"
                            );

        #endregion


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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NuevoCliente = new Clientes();
                NuevoUsuario = new Usuarios();

            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {


            lblErrorTerminos.Visible = false;

            // Validar Términos y Política
            if (!frmAltaCliente_E3.Checked || !frmAltaCliente_E4.Checked)
            {
                lblErrorTerminos.Text = "Debes aceptar los Términos y Condiciones y la Política de Privacidad.";
                lblErrorTerminos.Visible = true;
                return;
            }



            pnlRegistro.ClientVisible = false;

            pnlPaquete.ClientVisible = true;
        }

        protected void btnGratis_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("4 Pruebas Gratis", 0);
        }

        protected void btn20_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("20 Créditos", 100);
        }

        protected void btn50_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("50 Créditos", 200);
        }

        protected void btn100_Click(object sender, EventArgs e)
        {
            SeleccionarPaquete("100 Créditos", 400);
        }

        private void SeleccionarPaquete(string nombre, int precio)
        {
            // Guardar temporalmente
            Session["PaqueteNombre"] = nombre;
            Session["PaquetePrecio"] = precio;

            // Mostrar resumen
            lblPlan.Text = nombre;
            lblPrecio.Text = precio.ToString();

            pnlPaquete.Visible = false;
            pnlResumen.Visible = true;
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            pnlResumen.Visible = false;
            pnlPaquete.Visible = true;

        }

        protected void plnPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            {
                if (e.Parameter.Contains("EnviarCodigoValidacionEmail"))
                {

                    int id = svc.GenerateStoreAndSendToken(txtCorreoCliente.Text, expiresMinutes: 10);



                    frmAltaCliente.FindItemByFieldName("ValidarCodVerificiacionEmail").ClientVisible = true;
                    frmAltaCliente.FindItemByFieldName("CodVerificacionEmail").ClientVisible = true;


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
                    NuevoCliente.DomCiudad = txtDomCiudad.Text;
                    NuevoCliente.DomEstado = txtDomEstado.Text;
                    NuevoCliente.DomCP = int.MaxValue;
                    NuevoCliente.DomTelefono = txtTelefono.Text;

                    //..




                    //NuevoUsuario.Id = 0;
                    //NuevoUsuario.UserName = "esto seria el correo ya validado";
                    //NuevoUsuario.Contraseña = "la contaseña encriptada";
                    //NuevoUsuario.Nombre = NuevoCliente.PrimerNombre + " " + NuevoCliente.AppPaterno + " " + NuevoCliente.AppMaterno;
                    //NuevoUsuario.FechaAlta = DateTime.Now;
                    //NuevoUsuario.Mail = "esto seria el correo ya validado";
                    //NuevoUsuario.EsProyectista = false;
                    //NuevoUsuario.EsCreditos = false;








                    pnlRegistro.ClientVisible = false;

                    pnlPaquete.ClientVisible = true;




                    return;
                }

                if (e.Parameter.Contains("ValidadContraseña"))
                {
                    string password = txtPassword.Text;
                    string confirmPassword = txtConfirPassword.Text;

                    // 2️ Coincidencia
                    if (password != confirmPassword)
                    {
                        lblErrorTerminos.Text = "Las contraseñas no coinciden.";
                        lblErrorTerminos.Visible = true;
                        return;
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