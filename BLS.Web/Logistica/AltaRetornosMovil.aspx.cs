using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Web.Controles.Usuario;
using System.Data;

namespace GPB.Web
{
	public partial class AltaRetornosMovil : PageBase
    {
		protected void Page_Load(object sender, EventArgs e)
		{
            //cuInfoMsgboxMovil.mostrarMensaje("Mensaje de prueba", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
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

    }
}