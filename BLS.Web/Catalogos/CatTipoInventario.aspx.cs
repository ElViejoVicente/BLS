using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;
using BLS.Negocio.Inventarios;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;
namespace BLS.Web.Catalogos
{
    public partial class CatTipoInventario : PageBase
    {



        #region Propiedades

        DatosCrud datosCrud = new DatosCrud();
        public List<Cat_TipoInventario> catTipoInventario
        {
            get

            {
                List<Cat_TipoInventario> sseTipoInventario = new List<Cat_TipoInventario>();
                if (this.Session["sseTipoInventario"] != null)
                {
                    sseTipoInventario = (List<Cat_TipoInventario>)this.Session["sseTipoInventario"];
                }

                return sseTipoInventario;
            }
            set
            {
                this.Session["sseTipoInventario"] = value;
            }

        }


        #endregion

        private void DameCatalogos()
        {
            catTipoInventario = datosCrud.ConsultaCatTipoInventario();
            gvTipoInventario.DataBind();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }

        protected void gvTipoInventario_DataBinding(object sender, EventArgs e)
        {
            gvTipoInventario.DataSource = catTipoInventario;
        }

        protected void gvTipoInventario_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cat_TipoInventario nuevoObjeto = new Cat_TipoInventario();

            nuevoObjeto.TextoInventario = e.NewValues["TextoInventario"].ToString();
            nuevoObjeto.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());


            datosCrud.AltaCatTipoInventario(nuevoObjeto);

            e.Cancel = true;
            gvTipoInventario.CancelEdit();

            DameCatalogos();
        }

        protected void gvTipoInventario_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvTipoInventario.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catTipoInventario.Where(x => x.idTipoInventario == Convert.ToInt64(e.Keys[0])).First();


            if (miRegistro != null)
            {

                miRegistro.TextoInventario = e.NewValues["TextoInventario"].ToString();
                miRegistro.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());

            }

            datosCrud.ActualizarCatTipoInventario(miRegistro);

            e.Cancel = true;
            gvTipoInventario.CancelEdit();

            DameCatalogos();
        }

        protected void gvTipoInventario_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["TextoInventario"] == null)
            {
                e.RowError += "El campo TextoInventario es obligatorio.\n ";
            }
        }

        protected void gvTipoInventario_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {

                case "CustomExportToXLS":
                    gridExporter.WriteXlsToResponse(new XlsExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                case "CustomExportToXLSX":
                    gridExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;

                default:
                    break;
            }
        }

        protected void gvTipoInventario_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters.Contains("CargarLista"))
            {
                DameCatalogos();
                return;
            }
        }
    }
}