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
	public partial class RetornoMovil : PageBase
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

        protected void chkMisRet_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkRetEntragada_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Gv_retornos_desk_DataBinding(object sender, EventArgs e)
        {

        }

        protected void Gv_retornos_desk_DataBound(object sender, EventArgs e)
        {

        }

        protected void Gv_Retornos_DataBinding(object sender, EventArgs e)
        {

        }

        protected void Gv_Retornos_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnAsignarAgencia_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalleExp_Click(object sender, EventArgs e)
        {

        }

        protected void btnMarcarEntrega_Click(object sender, EventArgs e)
        {

        }

        protected void btnAsignarAgencia_Click1(object sender, EventArgs e)
        {

        }
    }
}