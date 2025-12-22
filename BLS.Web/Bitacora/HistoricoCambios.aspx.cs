using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.Bitacora;
using BLS.Negocio.Expediente;
using BLS.Negocio.ORM;
using BLS.Negocio.Reportes;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Bitacora
{
    public partial class HistoricoCambios : PageBase
    {
        #region Propiedades

        DatosBitacora datosExpedientes = new DatosBitacora();

        public List<BitacoraExpediente> lsBitacoraExpedientes
        {
            get

            {
                List<BitacoraExpediente> ssBitacoraExpediente = new List<BitacoraExpediente>();
                if (this.Session["ssBitacoraExpediente"] != null)
                {
                    ssBitacoraExpediente = (List<BitacoraExpediente>)this.Session["ssBitacoraExpediente"];
                }

                return ssBitacoraExpediente;
            }
            set
            {
                this.Session["ssBitacoraExpediente"] = value;
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {         

            }
        }

        protected void gvHistoricoCambios_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsBitacoraExpedientes;

        }

        protected void gvHistoricoCambios_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "CargarRegistros")
            {
                lsBitacoraExpedientes = datosExpedientes.DameBitacoraPorExpediente(NumExpediente: txtNumExpdiente.Text).ToList();// cargamos registros
                gvHistoricoCambios.DataBind();
                return;
            }
        }

        protected void gvHistoricoCambios_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {

                case "CustomExportToXLS":
                    ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "CustomExportToXLSX":
                    ASPxGridViewExporter1.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;

                default:
                    break;
            }
        }

   
    }
}