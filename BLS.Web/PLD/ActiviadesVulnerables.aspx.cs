using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;
using BLS.Negocio.Expediente;
using BLS.Negocio.ORM;
using BLS.Negocio.PLD;
using BLS.Negocio.Reportes;
using BLS.Web.Catalogos;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.PLD
{
    public partial class ActiviadesVulnerables : PageBase
    {
        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();
        DatosPld datosPLD = new DatosPld();


        public List<AVDetectadas> lsAVDetectadas
        {
            get

            {
                List<AVDetectadas> ssAVDetectadas = new List<AVDetectadas>();
                if (this.Session["ssAVDetectadas"] != null)
                {
                    ssAVDetectadas = (List<AVDetectadas>)this.Session["ssAVDetectadas"];
                }

                return ssAVDetectadas;
            }
            set
            {
                this.Session["ssAVDetectadas"] = value;
            }

        }



        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                dtFechaInicio.Date = DateTime.Now.Date.AddDays(-30);
                dtFechaFin.Date = DateTime.Now.Date;

            }
        }

        protected void gvAVDetectadas_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsAVDetectadas;
        }

        protected void gvAVDetectadas_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "CargarRegistros")
            {
                lsAVDetectadas = datosPLD.DameListaAVDetectadas(fechaInicial: dtFechaInicio.Date, fechaFinal: dtFechaFin.Date, todasLasFechas: chkBusquedaCompleta.Checked,SoloAvActivas: chkSoloAvActivas.Checked);// cargamos registros
                gvAVDetectadas.DataBind();
                return;
            }
        }

        protected void gvAVDetectadas_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvAVDetectadas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvAVDetectadas.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = lsAVDetectadas.Where(x => x.IdAV == Convert.ToInt64(e.Keys[0])).First();


            if (miRegistro != null)
            {

                miRegistro.AvActiva = Convert.ToBoolean(e.NewValues["AvActiva"].ToString());
                miRegistro.UsuarioGestionaAviso = UsuarioPagina.usNombre ;
                miRegistro.FolioDeAviso = e.NewValues["FolioDeAviso"].ToString();                
                miRegistro.Observaciones = e.NewValues["Observaciones"].ToString();

            }

            datosCrud.ActualizarAVDetectadas(miRegistro);

            e.Cancel = true;
            gvAVDetectadas.CancelEdit();

        }

        protected void gvAVDetectadas_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (!e.IsNewRow )
            {
                if (Convert.ToBoolean(e.NewValues["AvActiva"].ToString()) == false)
                {
                    if (e.NewValues["FolioDeAviso"] == null | e.NewValues["FolioDeAviso"].ToString().Trim()=="")
                    {
                        e.RowError += "El campo FolioDeAviso es obligatorio si desactivas el Aviso de AV.\n ";
                    }

                    if (e.NewValues["Observaciones"] == null | e.NewValues["Observaciones"].ToString().Trim() == "")
                    {
                        e.RowError += "El campo Observaciones es obligatorio  si desactivas el Aviso de AV.\n ";
                    }



                }
            }
        }

        protected void gvAVDetectadas_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "IdExpediente")
            {

                if (e.CellValue != null)
                {

                    var miExpediente = lsAVDetectadas.Where(x => x.IdAV.ToString() == e.KeyValue.ToString()).FirstOrDefault();

                    if (miExpediente != null)
                    {

                        ASPxImage Campo = (ASPxImage)gvAVDetectadas.FindRowCellTemplateControl(e.VisibleIndex, e.DataColumn, "imgExpedienteAlerta");
                        Campo.Caption = Convert.ToString(e.CellValue);

                        if (miExpediente.AvActiva==false && miExpediente.UsuarioGestionaAviso != "")
                        {
                            Campo.EmptyImage.IconID = "actions_apply_16x16";
                            return;
                        }

                        var diferencia = DateTime.Now.Subtract(miExpediente.FechaIngreso);



                        if (diferencia.Days>=15)
                        {
                            Campo.EmptyImage.IconID = "iconbuilder_security_warningcircled1_svg_16x16";
                        }
                        else
                        {
                            Campo.EmptyImage.IconID = "iconbuilder_security_warning_svg_16x16";
                        }

                        return;

                    }
                }

            }
        }
    }
}