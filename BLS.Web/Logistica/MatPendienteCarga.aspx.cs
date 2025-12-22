using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Logistica;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace GPB.Web.Logistica
{
    public partial class MatPendienteCarga : PageBase
    {
        #region variblesPrivadas
        DatosLogistica datosLogistica = new DatosLogistica();
      //  DatosLogistica_D datosLogistica = new DatosLogistica_D();
        #endregion
        #region propiedades


        public List<Negocio.WS_GESAG.MaterialPendienteCarga> ListaPteCarga
        {
            get
            {
                List<Negocio.WS_GESAG.MaterialPendienteCarga> dtPteCarga = new List<Negocio.WS_GESAG.MaterialPendienteCarga>();
                if (this.ViewState["dtPteCarga"] != null)
                {
                    dtPteCarga = (List<Negocio.WS_GESAG.MaterialPendienteCarga>)ViewState["dtPteCarga"];
                }
                return dtPteCarga;
            }
            set
            {
                this.ViewState["dtPteCarga"] = value;
            }
        }
        //public List<Negocio.WS_GESAG_DES.MaterialPendienteCarga> ListaPteCarga
        //{
        //    get
        //    {
        //        List<Negocio.WS_GESAG.MaterialPendienteCarga> dtPteCarga = new List<Negocio.WS_GESAG.MaterialPendienteCarga>();
        //        //List<Negocio.WS_GESAG_DES.MaterialPendienteCarga> dtPteCarga = new List<Negocio.WS_GESAG_DES.MaterialPendienteCarga>();
        //        if (this.ViewState["dtPteCarga"] != null)
        //        {
        //            dtPteCarga = (List<Negocio.WS_GESAG.MaterialPendienteCarga>)ViewState["dtPteCarga"];
        //            //dtPteCarga = (List<Negocio.WS_GESAG_DES.MaterialPendienteCarga>)ViewState["dtPteCarga"];
        //        }
        //        return dtPteCarga;
        //    }
        //    set
        //    {
        //        this.ViewState["dtPteCarga"] = value;
        //    }
        //}

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                // inicializar  fechas              
                cbSocieades.DataBind();               
            }

        }

        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                if (confiPAgina.Rows.Count > 0)
                {
                    imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                    lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                    lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                }
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void cbSocieades_DataBinding(object sender, EventArgs e)
        {
            try
            {
                cbSocieades.DataSource = SociedadesPermitidas;
                cbSocieades.TextField = "Nombre";
                cbSocieades.ValueField = "codSociedad";
                if (SociedadesPermitidas.Count > 0)
                {
                    cbSocieades.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvPendientesCarga_DataBinding(object sender, EventArgs e)
        {
            try
            {
                gvPendientesCarga.DataSource = ListaPteCarga;

            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaPteCarga = datosLogistica.ListaCargasPendientes(sociedad: cbSocieades.Value.ToString());

                if (ListaPteCarga.Count>0)
                {
                    gvPendientesCarga.Visible = true;
                    gvPendientesCarga.DataBind();
                }
                else
                {
                    gvPendientesCarga.Visible = false;
                    cuInfoMsgbox1.mostrarMensaje("No existen datos para el rango seleccionado", Controles.Usuario.InfoMsgBox.tipoMsg.info);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaPteCarga.Count > 0)
                {
                    ASPxGridViewExporter1.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                }

            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }
    }
}