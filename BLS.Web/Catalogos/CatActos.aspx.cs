using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;
using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Export;
using BLS.Negocio.Expediente;
using System.Collections;

namespace BLS.Web.Catalogos
{
    public partial class CatActos : PageBase
    {
        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();

        public List<Cat_Actos> catActos
        {
            get

            {
                List<Cat_Actos> sseCatActos = new List<Cat_Actos>();
                if (this.Session["sseCatActosEdicion"] != null)
                {
                    sseCatActos = (List<Cat_Actos>)this.Session["sseCatActosEdicion"];
                }

                return sseCatActos;
            }
            set
            {
                this.Session["sseCatActosEdicion"] = value;
            }

        }

        #endregion


        #region Funciones

        private void DameCatalogos()
        {
            catActos = datosCrud.ConsultaCatActos();
            gvActos.DataBind();
        }


        #endregion


        #region Eventos     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }

        protected void gvActos_DataBinding(object sender, EventArgs e)
        {
            gvActos.DataSource = catActos;
        }

        protected void gvActos_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {


            if (e.NewValues["TextoActo"] == null)
            {
                e.RowError += "El campo Acto es obligatorio.\n ";
            }

            if (e.NewValues["Descripcion"] == null)
            {
                e.RowError += "El campo Descripcion es obligatorio.\n ";
            }

        }

        protected void gvActos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            Cat_Actos nuevoActo = new Cat_Actos();

            nuevoActo.IdActo = 0;
            nuevoActo.TextoActo = e.NewValues["TextoActo"].ToString();
            nuevoActo.Descripcion = e.NewValues["Descripcion"].ToString();
            nuevoActo.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
            nuevoActo.AvisoAcVulnerable= Convert.ToBoolean(e.NewValues["AvisoAcVulnerable"].ToString());
            nuevoActo.UmbralAcVulnerable = Convert.ToDecimal(e.NewValues["UmbralAcVulnerable"].ToString());

            nuevoActo.ReqTraslado = Convert.ToBoolean(e.NewValues["ReqTraslado"].ToString());
            nuevoActo.TapAP = Convert.ToBoolean(e.NewValues["TapAP"].ToString());
            nuevoActo.TapProyecto = Convert.ToBoolean(e.NewValues["TapProyecto"].ToString());        
            nuevoActo.TapFirmas = Convert.ToBoolean(e.NewValues["TapFirmas"].ToString());
            nuevoActo.TapAD= Convert.ToBoolean(e.NewValues["TapAD"].ToString());
            nuevoActo.TapEscritura = Convert.ToBoolean(e.NewValues["TapEscritura"].ToString());
            nuevoActo.TapEntrega = Convert.ToBoolean(e.NewValues["TapEntrega"].ToString());
            nuevoActo.TapContabilidad = Convert.ToBoolean(e.NewValues["TapContabilidad"].ToString());
            nuevoActo.TapPLD= Convert.ToBoolean(e.NewValues["TapPLD"].ToString());


            datosCrud.AltaCatActos(nuevoActo);

            e.Cancel = true;
            gvActos.CancelEdit();

            DameCatalogos();

        }


        protected void gvActos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Boolean existenCambios = false;


            foreach (DictionaryEntry item in e.OldValues)
            {
                if (e.NewValues.Contains(item.Key))
                {

                    if (e.NewValues[item.Key] != null && !e.NewValues[item.Key].Equals(item.Value))
                    {
                        existenCambios = true;
                        break;
                    }
                }
            }

            if (existenCambios == false)
            {
                gvActos.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catActos.Where(x => x.IdActo == Convert.ToInt64(e.Keys[0])).First();


            if (miRegistro != null)
            {

                miRegistro.TextoActo = e.NewValues["TextoActo"].ToString();
                miRegistro.Descripcion = e.NewValues["Descripcion"].ToString();
                miRegistro.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
                miRegistro.AvisoAcVulnerable = Convert.ToBoolean(e.NewValues["AvisoAcVulnerable"].ToString());
                miRegistro.UmbralAcVulnerable = Convert.ToDecimal(e.NewValues["UmbralAcVulnerable"].ToString());

                miRegistro.ReqTraslado = Convert.ToBoolean(e.NewValues["ReqTraslado"].ToString());
                miRegistro.TapAP = Convert.ToBoolean(e.NewValues["TapAP"].ToString());
                miRegistro.TapProyecto = Convert.ToBoolean(e.NewValues["TapProyecto"].ToString());
                miRegistro.TapFirmas = Convert.ToBoolean(e.NewValues["TapFirmas"].ToString());
                miRegistro.TapAD = Convert.ToBoolean(e.NewValues["TapAD"].ToString());
                miRegistro.TapEscritura = Convert.ToBoolean(e.NewValues["TapEscritura"].ToString());
                miRegistro.TapEntrega = Convert.ToBoolean(e.NewValues["TapEntrega"].ToString());
                miRegistro.TapContabilidad = Convert.ToBoolean(e.NewValues["TapContabilidad"].ToString());
                miRegistro.TapPLD = Convert.ToBoolean(e.NewValues["TapPLD"].ToString());
            }

            datosCrud.ActualizarCatActos(miRegistro);

            e.Cancel = true;
            gvActos.CancelEdit();

            DameCatalogos();

        }

        protected void gvActos_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvActos_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters.Contains("CargarRegistros"))
            {
                DameCatalogos();
                return;
            }

        }


        #endregion




    }
}