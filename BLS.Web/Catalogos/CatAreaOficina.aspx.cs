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
    public partial class CatAreaOficina : PageBase

    {
        #region Propiedades


        DatosCrud datosCrud = new DatosCrud();
        public List<Cat_AreaOficina> catAreaOficina
        {
            get

            {
                List<Cat_AreaOficina> sseAreaOficina= new List<Cat_AreaOficina>();
                if (this.Session["sseAreaOficina"] != null)
                {
                    sseAreaOficina = (List<Cat_AreaOficina>)this.Session["sseAreaOficina"];
                }

                return sseAreaOficina;
            }
            set
            {
                this.Session["sseAreaOficina"] = value;
            }

        }


        #endregion

        private void DameCatalogos()
        {
            catAreaOficina = datosCrud.ConsultaCatAreaOficina();
            gvArea.DataBind();
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }
        protected void gvArea_DataBinding(object sender, EventArgs e)
        {
            gvArea.DataSource = catAreaOficina;
        }

        protected void gvArea_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cat_AreaOficina nuevoObjeto = new Cat_AreaOficina();

            nuevoObjeto.TextoAreaOficina = e.NewValues["TextoAreaOficina"].ToString();
            nuevoObjeto.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());


            datosCrud.AltaCatAreaOficina(nuevoObjeto);

            e.Cancel = true;
            gvArea.CancelEdit();

            DameCatalogos();
        }

        protected void gvArea_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvArea.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catAreaOficina.Where(x => x.IdArea == Convert.ToInt64(e.Keys[0])).First();


            if (miRegistro != null)
            {

                miRegistro.TextoAreaOficina = e.NewValues["TextoAreaOficina"].ToString();
                miRegistro.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());
                
            }

            datosCrud.ActualizarCatAreaOficina(miRegistro);

            e.Cancel = true;
            gvArea.CancelEdit();

            DameCatalogos();

        }

        protected void gvArea_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {


            if (e.NewValues["TextoAreaOficina"] == null)
            {
                e.RowError += "El campo TextoAreaOficina es obligatorio.\n ";
            }

        }

        protected void gvArea_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvArea_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

            if (e.Parameters.Contains("CargarLista"))
            {
                DameCatalogos();
                return;
            }

        }






}

}

