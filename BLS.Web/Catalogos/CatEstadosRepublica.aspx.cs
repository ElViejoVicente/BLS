using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;
using BLS.Negocio.ORM;

namespace BLS.Web.Catalogos
{
    public partial class CatEstadosRepublica : System.Web.UI.Page
    {

        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();
        public List<Cat_EstadosRepublica> catEstadosRepublica
        {
            get

            {
                List<Cat_EstadosRepublica> sseEstadosRepublica = new List<Cat_EstadosRepublica>();
                if (this.Session["sseEstadosRepublica"] != null)
                {
                    sseEstadosRepublica = (List<Cat_EstadosRepublica>)this.Session["sseEstadosRepublica"];
                }

                return sseEstadosRepublica;
            }
            set
            {
                this.Session["sseEstadosRepublica"] = value;
            }

        }

        #endregion
        private void DameCatalogos()
        {
            catEstadosRepublica = datosCrud.ConsultaCatEstadosRepublica();
            gvEstadosRepublica.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }

        protected void gvEstadosRepublica_DataBinding(object sender, EventArgs e)
        {
            gvEstadosRepublica.DataSource = catEstadosRepublica;
        }

        protected void gvEstadosRepublica_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cat_EstadosRepublica nuevoObjeto = new Cat_EstadosRepublica();

           nuevoObjeto.IdEstado = Convert.ToInt32( e.NewValues["IdEstado"].ToString());
            nuevoObjeto.TextoEstado = e.NewValues["TextoEstado"].ToString();


            datosCrud.AltaCatEstadosRepublica(nuevoObjeto);

            e.Cancel = true;
            gvEstadosRepublica.CancelEdit();

            DameCatalogos();
        }

        protected void gvEstadosRepublica_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvEstadosRepublica.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catEstadosRepublica.Where(x => x.IdEstado == Convert.ToInt32(e.Keys[0].ToString())).FirstOrDefault();


            if (miRegistro != null)
            {

                miRegistro.IdEstado= Convert.ToInt32(e.NewValues["IdEstado"].ToString());
                miRegistro.TextoEstado = e.NewValues["TextoEstado"].ToString();

            }

            datosCrud.ActualizarCatEstadosRepublica(miRegistro);

            e.Cancel = true;
            gvEstadosRepublica.CancelEdit();

            DameCatalogos();
        }

        protected void gvEstadosRepublica_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["TextoInventario"] == null)
            {
                e.RowError += "El campo TextoEstado es obligatorio.\n ";
            }
        }

        protected void gvEstadosRepublica_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvEstadosRepublica_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters.Contains("CargarLista"))
            {
                DameCatalogos();
                return;
            }
        }
    }
}