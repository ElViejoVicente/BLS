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
using DevExpress.Web.Internal;
using DevExpress.XtraEditors.TextEditController.IME;

namespace BLS.Web.Catalogos
{
    public partial class CatVariantesXActo : PageBase
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


        public List<Cat_VariantesPorActo> catVariantesActo
        {
            get
            {
                List<Cat_VariantesPorActo> sseCatVariantesActos = new List<Cat_VariantesPorActo>();
                if (this.Session["sseCatVariantesActosEdicion"] != null)
                {
                    sseCatVariantesActos = (List<Cat_VariantesPorActo>)this.Session["sseCatVariantesActosEdicion"];
                }

                return sseCatVariantesActos;
            }
            set
            {
                this.Session["sseCatVariantesActosEdicion"] = value;
            }
        }




        #endregion


        #region Funciones

        private void DameCatalogos()
        {
            catActos = datosCrud.ConsultaCatActos();
            cbActos.DataBind();
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }

        protected void cbActos_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.TextField = "TextoActo";
            control.ValueField = "IdActo";

            control.DataSource = catActos;
        }

        protected void gvVariantesActo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                ASPxGridView gridView = sender as ASPxGridView;
                string[] parameters = e.Parameters.Split('~');
                string command = parameters[0];
                int idActo = 0;

                if (!(command.Count() >= 2))
                {
                    // error no se tomo correctamente el parseo de paramtros
                    // mstrar en pantalla 

                    return;
                }

                idActo = catActos.Where(x => x.TextoActo.Trim() == parameters[1].ToString().Trim()).FirstOrDefault().IdActo;


                if (command.Contains("CargarRegistros"))
                {

                    catVariantesActo = datosCrud.ConsultaCatVariantesPorActo().Where(x => x.IdActo == idActo).ToList();
                    gvVariantesActo.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvVariantesActo_DataBinding(object sender, EventArgs e) => gvVariantesActo.DataSource = catVariantesActo;


        protected void gvVariantesActo_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cat_VariantesPorActo nuevoRegisto = new Cat_VariantesPorActo();

            nuevoRegisto.IdActo = Convert.ToInt32(cbActos.Value.ToString());
            nuevoRegisto.TextoVariante = e.NewValues["TextoVariante"].ToString();
            nuevoRegisto.Descripcion = e.NewValues["Descripcion"].ToString();
            nuevoRegisto.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
            //nuevoRegisto.RequiereExUnico= Convert.ToBoolean(e.NewValues["RequiereExUnico"].ToString());

            datosCrud.AltaCatVariantePorActo(nuevoRegisto);

            e.Cancel = true;
            gvVariantesActo.CancelEdit();

            gvVariantesActo.JSProperties["cp_Update"] = "OK";

            return;
        }

        protected void gvVariantesActo_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvVariantesActo.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catVariantesActo.Where(x => x.IdVariante == Convert.ToInt64(e.Keys[0])).First();


            if (miRegistro != null)
            {

                miRegistro.TextoVariante = e.NewValues["TextoVariante"].ToString();
                miRegistro.Descripcion = e.NewValues["Descripcion"].ToString();
                miRegistro.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
                //miRegistro.RequiereExUnico= Convert.ToBoolean(e.NewValues["RequiereExUnico"].ToString());

            }

            datosCrud.ActualizarCatVariantePorActo(miRegistro);

            e.Cancel = true;
            gvVariantesActo.CancelEdit();

            DameCatalogos();

        }

        protected void gvVariantesActo_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            if (e.NewValues["TextoVariante"] == null)
            {
                e.RowError += "El campo Variante es obligatorio.\n ";
            }

            if (e.NewValues["Descripcion"] == null)
            {
                e.RowError += "El campo Descripcion es obligatorio.\n ";
            }
        }

        protected void gvVariantesActo_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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