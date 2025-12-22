using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler.Rendering;
using DevExpress.Web.Bootstrap;
using BLS.Negocio.ExpedienteUnico;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;

namespace BLS.Web.ExpedienteUnico
{
    public partial class ConsultaSimpleListaNegra : PageBase
    {
        #region Propiedades

        public ListaConsultaBasicaLN DetalleBusqueda
        {
            get

            {
                ListaConsultaBasicaLN sseDetalleBusqueda = new ListaConsultaBasicaLN();
                if (this.Session["sseDetalleBusqueda"] != null)
                {
                    sseDetalleBusqueda = (ListaConsultaBasicaLN)this.Session["sseDetalleBusqueda"];
                }

                return sseDetalleBusqueda;
            }
            set
            {
                this.Session["sseDetalleBusqueda"] = value;
            }

        }

        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            dtFechaNacimiento.Value = DateTime.Now.AddYears(-18);
            DetalleBusqueda = new ListaConsultaBasicaLN();
        }

        protected void pnBusquedaListaNegra_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.ToString() == "Busqueda")
            {

                DetalleBusqueda = new ListaConsultaBasicaLN();

                DetalleBusqueda.Nombres = txtNombre.Text.Trim();
                DetalleBusqueda.ApellidoPaterno=txtApellidoPaterno.Text.Trim();
                DetalleBusqueda.ApellidoMaterno=txtApellidoMaterno.Text.Trim();
                DetalleBusqueda.Sexo=chkSexo.SelectedItem.Value.ToString();
                DetalleBusqueda.FechaNacimiento = dtFechaNacimiento.Date;
                DetalleBusqueda.Rfc = txtRFC.Text.Trim().ToUpper();
                DetalleBusqueda.TipoRegimen=chkTipoPersona.SelectedItem.Value.ToString().ToUpper();
                DetalleBusqueda.RazonSocial=txtNombreSociedad.Text.Trim();
                DetalleBusqueda.NombreUsuarioConsulta = UsuarioPagina.Nombre;

              //  Response.Write("<script> window.open('" + "www.google.com" + "','_blank'); </script>");

                return;

            }

        }

        #endregion



    }


}