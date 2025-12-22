using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraScheduler.Native;
using BLS.Negocio.CRUD;
using BLS.Negocio.Inventarios;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Negocio.Reportes;
using BLS.Web.Catalogos;
using BLS.Web.Controles.Servidor;

namespace BLS.Web.Inventarios
{
    public partial class PanelInventario : PageBase

    {

        #region Propiedades

        DatosCrud datosCrud = new DatosCrud();
        DatosInventario datosInventario = new DatosInventario();

        public List<Inventario> lsInventario
        {
            get

            {
                List<Inventario> sseInventario = new List<Inventario>();
                if (this.Session["sseInventario"] != null)
                {
                    sseInventario = (List<Inventario>)this.Session["sseInventario"];
                }

                return sseInventario;
            }
            set
            {
                this.Session["sseInventario"] = value;
            }

        }

        public List<Cat_TipoInventario> catTipoInventario
        {
            get

            {
                List<Cat_TipoInventario> ssecatTipoInventario = new List<Cat_TipoInventario>();
                if (this.Session["ssecatTipoInventario"] != null)
                {
                    ssecatTipoInventario = (List<Cat_TipoInventario>)this.Session["ssecatTipoInventario"];
                }

                return ssecatTipoInventario;
            }
            set
            {
                this.Session["ssecatTipoInventario"] = value;
            }

        }

        public List<Cat_AreaOficina> catAreasOficina
        {
            get

            {
                List<Cat_AreaOficina> sseCat_AreaOficina = new List<Cat_AreaOficina>();
                if (this.Session["sseCat_AreaOficina"] != null)
                {
                    sseCat_AreaOficina = (List<Cat_AreaOficina>)this.Session["sseCat_AreaOficina"];
                }

                return sseCat_AreaOficina;
            }
            set
            {
                this.Session["sseCat_AreaOficina"] = value;
            }

        }




        #endregion

        #region Funciones
        private void DameCatalogos()
        {
            catAreasOficina = datosCrud.ConsultaCatAreaOficina().Where(x => x.Activo == true).ToList();
            catTipoInventario = datosCrud.ConsultaCatTipoInventario().Where(x => x.Activo == true).ToList();

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

        protected void gvInventario_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsInventario;
        }


        protected void gvInventario_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            object tipoInventario = ((ASPxComboBox)gvInventario.FindEditRowCellTemplateControl(
                          gvInventario.Columns["TipoInventario"] as GridViewDataComboBoxColumn,
                          "cbTipoInventario")).Value;

            object areaOficina = ((ASPxComboBox)gvInventario.FindEditRowCellTemplateControl(
                          gvInventario.Columns["AreaOficina"] as GridViewDataComboBoxColumn,
                          "cbAreaOficina")).Value;





            if (tipoInventario == null)
            {
                e.RowError += "El campo tipoInventario Operacion es obligatorio.\n ";
            }

            if (areaOficina == null)
            {
                e.RowError += "El campo areaOficina  es obligatorio.\n ";
            }


            if (e.NewValues["Modelo"] == null)
            {
                e.RowError += "El campo Modelo  es obligatorio.\n ";
            }

            if (e.NewValues["Nombre"] == null)
            {
                e.RowError += "El campo Nombre  es obligatorio.\n ";
            }

            if (e.NewValues["Marca"] == null)
            {
                e.RowError += "El campo Marca  es obligatorio.\n ";
            }

            if (e.NewValues["NumeroSerie"] == null)
            {
                e.RowError += "El campo Numero de serie es obligatorio.\n";
            }

            //if (e.NewValues["Responsable"] == null)
            //{
            //    e.RowError += "El campo Responsable  es obligatorio.\n ";
            //}

            if (e.NewValues["Observaciones"] == null)
            {
                e.RowError += "El campo Observaciones  es obligatorio.\n ";
            }


            if (e.NewValues["FechaAlta"] == null)
            {
                e.RowError += "El campo FechaAlta  es obligatorio.\n ";
            }



            if (e.NewValues["Responsable"] != null)
            {
                if (e.NewValues["FechaAsignacion"] == null)
                {
                    e.RowError += "El campo FechaAsignacion  es obligatorio.\n ";
                }

            }



        }





        protected void gvInventario_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Inventario nuevoObjeto = new Inventario();

            DateTime fechaBaja = Constantes.FechaGlobal;
            DateTime fechaDeAsignacion = Constantes.FechaGlobal;
            String nombreResponsable = string.Empty;


            if (e.NewValues["FechaBaja"] != null)
            {
                fechaBaja = Convert.ToDateTime(e.NewValues["FechaBaja"].ToString());
            }

            if (e.NewValues["FechaAsignacion"] != null)
            {
                fechaDeAsignacion = Convert.ToDateTime(e.NewValues["FechaAsignacion"].ToString());
            }

            if (e.NewValues["Responsable"] != null)
            {
                nombreResponsable = e.NewValues["Responsable"].ToString();
            }



            nuevoObjeto.IdInventario = 0;
            nuevoObjeto.TipoInventario = e.NewValues["TipoInventario"] == null ? "" : e.NewValues["TipoInventario"].ToString();
            nuevoObjeto.Modelo = e.NewValues["Modelo"].ToString();
            nuevoObjeto.Nombre = e.NewValues["Nombre"].ToString();
            nuevoObjeto.Marca = e.NewValues["Marca"].ToString();        
            nuevoObjeto.FechaAlta = Convert.ToDateTime(e.NewValues["FechaAlta"].ToString());
            nuevoObjeto.FechaBaja = fechaBaja;
            nuevoObjeto.ValorCompra = Convert.ToDecimal(e.NewValues["ValorCompra"].ToString());
            nuevoObjeto.AreaOficina = e.NewValues["AreaOficina"] == null ? "" : e.NewValues["AreaOficina"].ToString();
            nuevoObjeto.Responsable = nombreResponsable;
            nuevoObjeto.FechaAsignacion = fechaDeAsignacion;
            nuevoObjeto.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());
            nuevoObjeto.Observaciones = e.NewValues["Observaciones"].ToString();
            nuevoObjeto.NumeroSerie = e.NewValues["NumeroSerie"].ToString();

            lsInventario.Add(nuevoObjeto);

            datosCrud.AltaInventario(nuevoObjeto);


            e.Cancel = true;
            gvInventario.CancelEdit();

            gvInventario.DataBind();

        }

        protected void gvInventario_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DateTime fechaBaja = Constantes.FechaGlobal;
            DateTime fechaDeAsignacion = Constantes.FechaGlobal;
            String nombreResponsable = string.Empty;

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
               gvInventario.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = lsInventario.Where(x => x.IdInventario == Convert.ToInt64(e.Keys[0])).First();


            if (e.NewValues["FechaBaja"] != null)
            {
                fechaBaja = Convert.ToDateTime(e.NewValues["FechaBaja"].ToString());
            }

            if (e.NewValues["FechaAsignacion"] != null)
            {
                fechaDeAsignacion = Convert.ToDateTime(e.NewValues["FechaAsignacion"].ToString());
            }
            if (e.NewValues["Responsable"] != null)
            {
                nombreResponsable = e.NewValues["Responsable"].ToString();
            }

            if (miRegistro != null)
            {

                //miRegistro.IdInventario = 0;
                miRegistro.TipoInventario = e.NewValues["TipoInventario"] == null ? "" : e.NewValues["TipoInventario"].ToString();
                miRegistro.Modelo = e.NewValues["Modelo"].ToString();
                miRegistro.Nombre = e.NewValues["Nombre"].ToString();
                miRegistro.Marca = e.NewValues["Marca"].ToString();
                miRegistro.FechaAlta = Convert.ToDateTime(e.NewValues["FechaAlta"].ToString());
                miRegistro.FechaBaja = fechaBaja;
                miRegistro.ValorCompra = Convert.ToDecimal(e.NewValues["ValorCompra"].ToString());
                miRegistro.AreaOficina = e.NewValues["AreaOficina"] == null ? "" : e.NewValues["AreaOficina"].ToString();
                miRegistro.Responsable = nombreResponsable;
                miRegistro.FechaAsignacion = fechaDeAsignacion;
                miRegistro.Activo = e.NewValues["Activo"] == null ? false : Convert.ToBoolean(e.NewValues["Activo"].ToString());
                miRegistro.Observaciones = e.NewValues["Observaciones"].ToString();
                miRegistro.NumeroSerie = e.NewValues["NumeroSerie"] == null ? "" : e.NewValues["NumeroSerie"].ToString();
            }

            datosCrud.ActualizarInventario(miRegistro);

            e.Cancel = true;
            gvInventario.CancelEdit();

           
        }



        protected void gvInventario_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvInventario_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

            if (e.Parameters.Contains("CargarLista"))
            {

                DateTime dtFechaAltaInventario = Constantes.FechaGlobal;

                if (chkBusquedaCompleta.Checked == false)
                {
                    dtFechaAltaInventario = dtFechaAlta.Date;
                }



                lsInventario = datosInventario.DameListaInventario(fechaInventario: dtFechaAltaInventario, todasLasFechas: chkBusquedaCompleta.Checked, inventarioActivo: chkSoloInventarioActivo.Checked);


                gvInventario.DataBind();


                return;
            }


        }


        #endregion

        protected void cbTipoInventario_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            cb.DataSource = catTipoInventario;
            cb.TextField = "TextoInventario";
            cb.ValueField = "TextoInventario";
            cb.ValueType = typeof(string);

            cb.SelectedIndex = -1;
        }

        protected void cbAreaOficina_Init(object sender, EventArgs e)
        {

            ASPxComboBox cb = (ASPxComboBox)sender;

            cb.DataSource = catAreasOficina;
            cb.TextField = "TextoAreaOficina";
            cb.ValueField = "TextoAreaOficina";
            cb.ValueType = typeof(string);

            cb.SelectedIndex = -1;

        }
    }
}