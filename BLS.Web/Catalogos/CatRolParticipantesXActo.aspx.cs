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
    public partial class CatRolParticipantesXActo : PageBase
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


        public List<Cat_RolParticipantes> catRolParticipantes
        {
            get
            {
                List<Cat_RolParticipantes> sseCatRolParticipantes = new List<Cat_RolParticipantes>();
                if (this.Session["sseCatRolParticipantes"] != null)
                {
                    sseCatRolParticipantes = (List<Cat_RolParticipantes>)this.Session["sseCatRolParticipantes"];
                }

                return sseCatRolParticipantes;
            }
            set
            {
                this.Session["sseCatRolParticipantes"] = value;
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

        protected void gvRolXActo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
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

                    catRolParticipantes = datosCrud.ConsultaCatRolParticipantes().Where(x => x.IdActo == idActo).ToList();
                    gvRolXActo.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvRolXActo_DataBinding(object sender, EventArgs e) => gvRolXActo.DataSource = catRolParticipantes;


        protected void gvRolXActo_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cat_RolParticipantes nuevoRegisto = new Cat_RolParticipantes();

            nuevoRegisto.IdActo = Convert.ToInt32(cbActos.Value.ToString());
            nuevoRegisto.TextoFigura = e.NewValues["TextoFigura"].ToString();
            nuevoRegisto.TextoRol = e.NewValues["TextoRol"].ToString();
            nuevoRegisto.Descripcion = e.NewValues["Descripcion"].ToString().Trim();
            nuevoRegisto.PreguntarSiEsAnafabeta = Convert.ToBoolean(e.NewValues["PreguntarSiEsAnafabeta"].ToString());
            nuevoRegisto.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
            nuevoRegisto.RequiereExUnico= Convert.ToBoolean(e.NewValues["RequiereExUnico"].ToString());

            datosCrud.AltaCatRolParticipantes(nuevoRegisto);

            e.Cancel = true;
            gvRolXActo.CancelEdit();
            gvRolXActo.JSProperties["cp_Update"] = "OK";

            return;

        }

        protected void gvRolXActo_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvRolXActo.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = catRolParticipantes.Where(x => x.IdRol == Convert.ToInt64(e.Keys[0])).First();

            if (miRegistro != null)
            {

          
                miRegistro.TextoFigura = e.NewValues["TextoFigura"].ToString();
                miRegistro.TextoRol = e.NewValues["TextoRol"].ToString();
                miRegistro.Descripcion = e.NewValues["Descripcion"].ToString();
                miRegistro.PreguntarSiEsAnafabeta = Convert.ToBoolean(e.NewValues["PreguntarSiEsAnafabeta"].ToString());
                miRegistro.Activo = Convert.ToBoolean(e.NewValues["Activo"].ToString());
                miRegistro.RequiereExUnico = Convert.ToBoolean(e.NewValues["RequiereExUnico"].ToString());

            }

            datosCrud.ActualizarCatRolParticipantes(miRegistro);

            e.Cancel = true;
            gvRolXActo.CancelEdit();

            DameCatalogos();


        }

        protected void gvRolXActo_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            if (e.NewValues["TextoFigura"] == null)
            {
                e.RowError += "El campo Rol es obligatorio.\n ";
            }

            if (e.NewValues["TextoRol"] == null)
            {
                e.RowError += "El campo Nombre rol es obligatorio.\n ";
            }

            if (e.NewValues["Descripcion"] == null)
            {
                e.RowError += "El campo Descripcion es obligatorio.\n ";
            }


        }

        protected void gvRolXActo_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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