using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Operativa;
using System.Data;

namespace GPB.Web
{
    public partial class DetalleExp : PageBase
    {
        #region variblesPrivadas
        DatosUsuario datosUsuario = new DatosUsuario();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

                

                if (!Page.IsPostBack)
                {
                    Response.Expires = 0;
                    CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
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
           
        }
}