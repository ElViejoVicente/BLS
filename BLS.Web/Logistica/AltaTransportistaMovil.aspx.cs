using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Web.Controles.Usuario;
using System.Data;
using GPB.Negocio.Logistica;

namespace GPB.Web.Logistica
{
	public partial class AltaTransportistaMovil : PageBase
    {
       // DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
        DatosTransportistas lostransportistas = new DatosTransportistas();

        #region propiedades

        public string Sociedad
        {
            get
            {

                if (Session["Sociedad"] != null)
                {
                    return (string)Session["Sociedad"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["IDExpedicionseleccionada"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
		{
            //cuInfoMsgboxMovil.mostrarMensaje("Mensaje de prueba", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.info);
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                lblNombrePagina.Text = "Transportista Nuevo";
            }
        }

        protected void CargarConfigruacionHead(int codPagina)
        {
            try
            {
                DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPagina);
                if (confiPAgina.Rows.Count > 0)
                {
                    imgLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIco"].ToString();
                    lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                    lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                }
            }
            catch (Exception ex)
            {

                // cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarExpedicion(); ", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int guardartran = lostransportistas.guardatransportista(sociedad: Sociedad,
                nombre: Txt_nombre.Text,
                direccion: txt_Calle.Text,
                poblacion: txt_poblacion.Text,
                nif: Txt_nifcif.Text,
                codpostal: txt_codpostal.Text,
                telefono: txt_telefono.Text,
                usuario:UsuarioPagina.UserName);
            if (guardartran == 0)
            {
                //limpiarcampos();
                cuInfoMsgboxMovil.mostrarMensaje("Transportista Guardado", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.info);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarExpedicion(); ", true);
            }
            else
            {

                cuInfoMsgboxMovil.mostrarMensaje("Error guardando transportista", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }
        }
        private void limpiarcampos()
        {
            Txt_nombre.Text = "";
            txt_Calle.Text = "";
            txt_poblacion.Text = "";
            Txt_nifcif.Text = "";
            txt_codpostal.Text = "";
            txt_telefono.Text = "";



        }
    }
}