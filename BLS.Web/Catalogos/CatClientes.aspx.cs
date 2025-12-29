using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;

using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;

namespace BLS.Web.Catalogos
{

    public partial class CatClientes : PageBase
    {


        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();



        public List<Cat_Clientes> ListaClientes
        {
            get => Session["sseCatCliente"] as List<Cat_Clientes> ?? new List<Cat_Clientes>();
            set => Session["sseCatCliente"] = value;
        }




        #endregion

        private void DameCatalogos()
        {
            ListaClientes = datosCrud.ConsultaCatClientes();
            gvClientes.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DameCatalogos();
            }
        }

        protected void gvClientes_DataBinding(object sender, EventArgs e)
        {
            gvClientes.DataSource = ListaClientes;
        }

        protected void gvClientes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                Cat_Clientes nuevoObjeto = new Cat_Clientes();
                nuevoObjeto.Gestor = e.NewValues["Gestor"].ToString();
                nuevoObjeto.NumTelefonico = e.NewValues["NumTelefonico"].ToString();
                nuevoObjeto.CorreoElectronico = e.NewValues["CorreoElectronico"].ToString();
                nuevoObjeto.Observaciones = e.NewValues["Observaciones"].ToString();

                datosCrud.AltaCatClientes(nuevoObjeto);

                e.Cancel = true;
                gvClientes.CancelEdit();

                DameCatalogos();

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gvClientes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                Boolean exitenCambios = false;

                foreach (DictionaryEntry item in e.OldValues)
                {
                    if (e.NewValues.Contains(item.Key))
                    {
                        if (e.NewValues[item.Key] != null && !e.NewValues[item.Key].Equals(item.Value))
                        {

                            exitenCambios = true;
                            break;
                        }
                    }
                }

                if (exitenCambios == false)
                {
                    gvClientes.CancelEdit();
                    e.Cancel = true;
                    return;
                }

                var miRegistro = ListaClientes.Where(x => x.idCliente == Convert.ToInt64(e.Keys[0])).First();

                if (miRegistro != null)
                {
                    miRegistro.Gestor = e.NewValues["Gestor"].ToString();
                    miRegistro.NumTelefonico = e.NewValues["NumTelefonico"].ToString();
                    miRegistro.CorreoElectronico = e.NewValues["CorreoElectronico"].ToString();
                    miRegistro.Observaciones = e.NewValues["Observaciones"].ToString();
                }

                datosCrud.ActualizarCatClientes(miRegistro);

                e.Cancel = true;
                gvClientes.CancelEdit();
                DameCatalogos();

            }
            catch (Exception)
            {

                throw;
            }

  

        }

        protected void gvClientes_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            try
            {
                if (e.NewValues["Gestor"] == null)
                {
                    e.RowError += "El campo Texto Gestor es obligatorio.\n ";
                }

                if (e.NewValues["NumTelefonico"] == null)
                {
                    e.RowError += "El campo Texto Numero Telefonico es obligatorio.\n ";
                }

                if (e.NewValues["CorreoElectronico"] == null)
                {
                    e.RowError += "El campo CorreoElectronico es obligatorio.\n ";
                }

                if (e.NewValues["Observaciones"] == null)
                {
                    e.RowError += "El campo Texto Observaciones es obligatorio.\n ";
                }

            }
            catch (Exception)
            {

                throw;
            }

       
        }

        protected void gvClientes_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvClientes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters.Contains("CargarLista"))
            {
                DameCatalogos();
                return;
            }
        }
    }
}