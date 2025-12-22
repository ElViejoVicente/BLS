using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Operativa;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System.Data;
namespace GPB.Web.Logistica
{
    public partial class AltaTransportista : PageBase
    {
        //DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
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

        }

        protected void btnGuaqrdar_Click(object sender, EventArgs e)
        {
           int guardartran= lostransportistas.guardatransportista(sociedad: Sociedad,
                nombre: Txt_nombre.Text.Replace("/", "").Replace("&","").Trim(),
                direccion: txt_Calle.Text.Replace("/","").Trim(),
                poblacion: txt_poblacion.Text.Replace("/", "").Trim(),
                nif: Txt_nifcif.Text.Replace("/", "").Trim(),
                codpostal: txt_codpostal.Text.Replace("/", "").Trim(),
                telefono: txt_telefono.Text.Replace("/", "").Trim(),
                usuario:UsuarioPagina.UserName);
            if (guardartran == 0)
            {
                limpiarcampos();
                cuInfoMsgbox1.mostrarMensaje("Transportista Guardado", Controles.Usuario.InfoMsgBox.tipoMsg.info);
            }
            else
            {

                 cuInfoMsgbox1.mostrarMensaje("Error guardando transportista", Controles.Usuario.InfoMsgBox.tipoMsg.error);
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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarcampos();
        }
    }
}