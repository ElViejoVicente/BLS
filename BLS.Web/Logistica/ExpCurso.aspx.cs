using GPB.Web.Controles.Servidor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GPB.Negocio.Logistica;

namespace GPB.Web
{
    public partial class ExpCurso : PageBase
    {
        #region variblesPrivadas

          DatosExpedicion laexpedicion = new DatosExpedicion();
       // DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                GV_Expediciones.DataBind();
            }
        }
        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                if (confiPAgina.Rows.Count > 0)
                {
                    imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                    lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                    lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                }
            }
            catch (Exception ex)
            {

                // cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void GV_Expediciones_DataBinding(object sender, EventArgs e)
        {
            GV_Expediciones.DataSource = laexpedicion.dameexpedicionesencurso(UsuarioPagina.CodProveedor);
        }

        //protected void cbSocieades_DataBinding(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cbSocieades.DataSource = SociedadesPermitidas;
        //        cbSocieades.TextField = "Nombre";
        //        cbSocieades.ValueField = "codSociedad";
        //        if (SociedadesPermitidas.Count > 0)
        //        {
        //            cbSocieades.SelectedIndex = 0;
                
        //        }
                


        //    }
        //    catch (Exception ex)
        //    {
        //        cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
        //    }
        //}

        protected void cbSocieades_ValueChanged(object sender, EventArgs e)
        {
            GV_Expediciones.DataBind();
        }
    }
}