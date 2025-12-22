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
using System.Windows.Forms;

namespace BLS.Web.Catalogos
{
    public partial class CatDocumentosXVariante : PageBase
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


        public List<Cat_DocumentosPorActo> catDocumentosXVariante
        {
            get
            {
                List<Cat_DocumentosPorActo> ssecatDocumentosXVariante = new List<Cat_DocumentosPorActo>();
                if (this.Session["ssecatDocumentosXVariante"] != null)
                {
                    ssecatDocumentosXVariante = (List<Cat_DocumentosPorActo>)this.Session["ssecatDocumentosXVariante"];
                }

                return ssecatDocumentosXVariante;
            }
            set
            {
                this.Session["ssecatDocumentosXVariante"] = value;
            }
        }

        #endregion


        #region Funciones

        private void DameCatalogos()
        {
            catActos = datosCrud.ConsultaCatActos();
            // catVariantesActo = datosCrud.ConsultaCatVariantesPorActo();

            cbActos.DataBind();
            //cbVarientes.DataBind ();
        }


        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }


        }

        protected void cbActos_SelectedIndexChanged(object sender, EventArgs e)
        {

            catVariantesActo.Clear(); //= new List<Cat_VariantesPorActo>();
            catDocumentosXVariante.Clear();

            cbVarientes.DataBind();
            cbVarientes.SelectedIndex = -1;
            gvDocumentosXvariente.DataBind();



            int idActo = Convert.ToInt32(cbActos.Value.ToString());

            catVariantesActo = datosCrud.ConsultaCatVariantesPorActo().Where(x => x.IdActo == idActo).ToList();
            cbVarientes.DataBind();
           
            cbVarientes.ClientEnabled = true;

        }

        protected void cbActos_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.TextField = "TextoActo";
            control.ValueField = "IdActo";

            control.DataSource = catActos;

        }

        protected void cbVarientes_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.TextField = "TextoVariante";
            control.ValueField = "IdVariante";

            control.DataSource = catVariantesActo;
        }

        protected void gvDocumentosXvariente_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                ASPxGridView gridView = sender as ASPxGridView;
                string[] parameters = e.Parameters.Split('~');
                string command = parameters[0];
                int idActo = 0;
                int idVariante = 0;

                if (!(command.Count() >= 2))
                {
                    // error no se tomo correctamente el parseo de paramtros
                    // mstrar en pantalla 

                    return;
                }

                idActo = catActos.Where(x => x.TextoActo.Trim() == parameters[1].ToString().Trim()).FirstOrDefault().IdActo;
                idVariante = catVariantesActo.Where(x => x.TextoVariante.Trim() == parameters[2].ToString().Trim()).FirstOrDefault().IdVariante;

                if (command.Contains("CargarRegistros"))
                {

                    catDocumentosXVariante = datosCrud.ConsultaCatDocumentosPorActo().Where(x => x.IdActo == idActo && x.IdVariente == idVariante).ToList();
                    gvDocumentosXvariente.DataBind();             


                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        protected void gvDocumentosXvariente_DataBinding(object sender, EventArgs e) => gvDocumentosXvariente.DataSource = catDocumentosXVariante;
       

        protected void gvDocumentosXvariente_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            Cat_DocumentosPorActo nuevoRegisto = new Cat_DocumentosPorActo();

            nuevoRegisto.IdActo = Convert.ToInt32(cbActos.Value.ToString());
            nuevoRegisto.IdVariente = Convert.ToInt32(cbVarientes.Value.ToString());
            nuevoRegisto.TextoFigura = e.NewValues["TextoFigura"].ToString();
            nuevoRegisto.TextoDocumento = e.NewValues["TextoDocumento"].ToString();
            nuevoRegisto.Descripcion = e.NewValues["Descripcion"].ToString();
            nuevoRegisto.CopiaRequerida = Convert.ToBoolean(e.NewValues["CopiaRequerida"].ToString());
            nuevoRegisto.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());

            datosCrud.AltaCatDocumentosPorActo(nuevoRegisto);

            e.Cancel = true;
            gvDocumentosXvariente.CancelEdit();

            gvDocumentosXvariente.JSProperties["cp_Update"] = "OK";

            return;

        }

        protected void gvDocumentosXvariente_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvDocumentosXvariente.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catDocumentosXVariante.Where(x => x.IdDoc == Convert.ToInt64(e.Keys[0])).First();

            if (miRegistro != null)
            {


                miRegistro.TextoFigura = e.NewValues["TextoFigura"].ToString();
                miRegistro.TextoDocumento = e.NewValues["TextoDocumento"].ToString();
                miRegistro.Descripcion = e.NewValues["Descripcion"].ToString();
                miRegistro.CopiaRequerida = Convert.ToBoolean(e.NewValues["CopiaRequerida"].ToString());
                miRegistro.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());

            }

            datosCrud.ActualizarCatDocumentosPorActo(miRegistro);

            e.Cancel = true;
            gvDocumentosXvariente.CancelEdit();

            DameCatalogos();

        }

        protected void gvDocumentosXvariente_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["TextoFigura"] == null)
            {
                e.RowError += "El campo Rol es obligatorio.\n ";
            }

            if (e.NewValues["TextoDocumento"] == null)
            {
                e.RowError += "El campo Documento es obligatorio.\n ";
            }

            if (e.NewValues["Descripcion"] == null)
            {
                e.RowError += "El campo Descripcion es obligatorio.\n ";
            }

        }

        protected void gvDocumentosXvariente_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvDocumentosXvariente_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var miRegistro = catDocumentosXVariante.Where(x => x.IdDoc == Convert.ToInt64(e.Keys[0])).First();

            datosCrud.EliminarCatDocumentosPorActo(miRegistro);

            e.Cancel = true;
            gvDocumentosXvariente.CancelEdit();

            gvDocumentosXvariente.JSProperties["cp_Update"] = "OK";
           
        }
    }
}