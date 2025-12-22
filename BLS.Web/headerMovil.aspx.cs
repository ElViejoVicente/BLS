using BLS.Negocio.Operativa;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace BLS.Web
{
	public partial class headerMovil : PageBase
    {
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;

                //if (Session["usuario"] == null)
                //{
                //   Response.Redirect("login.aspx");
                //}

                obtieneDatosUsuario();

            }
        }
        private void obtieneDatosUsuario()
        {
            try
            {
               // string strHora = DateTime.Now.ToString("HH:mm:ss");
                lblNomUsuario.Text = ((Usuario)Session["usuario"]).Nombre;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}