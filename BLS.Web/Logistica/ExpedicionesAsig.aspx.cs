using GPB.Web.Controles.Servidor;
using GPB.Negocio.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Operativa;
using System.Data;
using DevExpress.Web;
using GPB.Negocio.Servicio_SAP;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace GPB.Web
{
    public partial class ExpedicionesAsig : PageBase
    {
        #region variblesPrivadas

        DatosExpedicion laexpedicion = new DatosExpedicion();
     //   DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
        //DatosSAP_D losdatossap = new DatosSAP_D();
        DatosSAP losdatossap = new DatosSAP();
        #endregion
        #region propiedades
        public DataTable DTAgencias
        {
            get
            {
                DataTable dtagencias = new DataTable();

                if (Session["DTAgencias"] != null)
                {

                    dtagencias = (DataTable)Session["DTAgencias"];
                }
                else
                {
                    string error = "";
                    dtagencias = losdatossap.dameagencias("", false, UsuarioPagina.CodProveedor.ToString(), ref error);
                    Session["DTAgencias"] = dtagencias;
                }
                return dtagencias;
            }
            set
            {
                Session["DTAgencias"] = value;
            }
        }
        public DataTable DTAgenciasTodos
        {
            get
            {
                DataTable dtagencias = new DataTable();

                if (Session["DTAgenciasTodos"] != null)
                {

                    dtagencias = (DataTable)Session["DTAgenciasTodos"];
                }
                else
                {
                    string error = "";
                    dtagencias = losdatossap.dameagencias("", true, UsuarioPagina.CodProveedor.ToString(), ref error);
                    Session["DTAgenciasTodos"] = dtagencias;
                }
                return dtagencias;

            }
            set
            {
                Session["DTAgenciasTodos"] = value;
            }
        }
        public Boolean Verretrasados
        {
            get
            {
                Boolean verretrasados = true; ;

                if (Session["Verretrasados"] != null)
                {

                    verretrasados = (Boolean)Session["Verretrasados"];
                }
                else
                {
                  
                    Session["Verretrasados"] = true;
                }
                return verretrasados;

            }
            set
            {
                Session["Verretrasados"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                cbAgencias.DataBind();
                CbEstados.DataBind();
                if (Verretrasados)
                {
                    PU_Expedicionesretrasadas.ShowOnPageLoad = true;
                    Session["Verretrasados"] = false;
                    Verretrasados = false;
                }
                else {
                    PU_Expedicionesretrasadas.ShowOnPageLoad = false;
                }
            
                    }
            ComprobarEventos();
        }
        protected void ComprobarEventos()
        {
            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            //CuMensaje.OCultarMensaje();
            switch (nombreEvento)
            {
                case "Refrescaexpedientes":
                    GV_Expediciones.DataBind();
                    Pup_AsignarAgencias.ShowOnPageLoad = false;
                    PUp_VerAgencias.ShowOnPageLoad = false;
                    PU_Expedicionesretrasadas.ShowOnPageLoad = false;
                    break;

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

        protected void GV_Expediciones_DataBinding(object sender, EventArgs e)
        {
            if (UsuarioPagina.CodProveedor != 0)
            {
                GV_Expediciones.DataSource = laexpedicion.dameexpedicionesporagencia(UsuarioPagina.CodProveedor,0);
            }
            else
            {
                if (cbAgencias.SelectedIndex != -1 && CbEstados.SelectedIndex != -1)
                {
                    GV_Expediciones.DataSource = laexpedicion.dameexpedicionesporagencia(Convert.ToInt32(cbAgencias.SelectedItem.Value), Convert.ToInt32(CbEstados.SelectedItem.Value));
                }
                else
                {
                    GV_Expediciones.DataSource = laexpedicion.dameexpedicionesporagencia(0,-1);
                }
            }
            GV_Expediciones.KeyFieldName = "exId";

        }

        protected void PUp_VerAgencias_Init(object sender, EventArgs e)
        {
          
        }

        protected void Gv_AgenciasAsignadas_DataBinding(object sender, EventArgs e)
        {
            if (HidIdexpedicion.Value != "")
            {
                Gv_AgenciasAsignadas.DataSource = laexpedicion.dameagenciaexpedicion(Convert.ToInt32(HidIdexpedicion.Value), HidEmpresa.Value.ToString());
            }
        }

        protected void PUp_VerAgencias_Load(object sender, EventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }
       

        protected void Gv_AgenciasAsignadas_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void btnVerAgencias_Click(object sender, EventArgs e)

        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
           // GPB.Negocio.Logistica.ExpedicionPte fila = (GPB.Negocio.Logistica.ExpedicionPte)GV_Expediciones.GetRow(currentIndex);
             DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdexpedicion.Value = dt["ExNumexpedicion"].ToString();
            HidEmpresa.Value= dt["ExEmpresa"].ToString();
            PUp_VerAgencias.ShowOnPageLoad = true;

        }
        protected void btnVerAgenciasPup_Click(object sender, EventArgs e)

        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            // GPB.Negocio.Logistica.ExpedicionPte fila = (GPB.Negocio.Logistica.ExpedicionPte)GV_Expediciones.GetRow(currentIndex);
            GPB.Negocio.Logistica.Expedicion fila = (GPB.Negocio.Logistica.Expedicion)Gv_ExpedicionesRetrasadas.GetRow(currentIndex);
            //DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdexpedicion.Value = fila.MiNumExpedicion.ToString();
            HidEmpresa.Value = fila.MSEmpresa;
            PUp_VerAgencias.ShowOnPageLoad = true;

        }

        protected void btnAsignarAgencia_Click(object sender, EventArgs e)
        {

            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            DataRow fila = (DataRow)GV_Expediciones.GetDataRow(currentIndex);
            // DataRow dt = container.Grid.GetDataRow(currentIndex);
          
            HidIdexpedicion.Value = fila["ExNumexpedicion"].ToString();
            HidEmpresa.Value = fila["ExEmpresa"].ToString();
            string url = "..\\Logistica\\AsignacionMat.aspx?initCod=14&idExp=" + fila["exId"].ToString();
            Pup_AsignarAgencias.ContentUrl = url;
            Pup_AsignarAgencias.ShowOnPageLoad = true;
        }
        protected void btnAsignarAgenciaPup_Click(object sender, EventArgs e)
        {

            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            GPB.Negocio.Logistica.Expedicion fila = (GPB.Negocio.Logistica.Expedicion)Gv_ExpedicionesRetrasadas.GetRow(currentIndex);
            //DataRow fila = (DataRow)GV_Expediciones.GetDataRow(currentIndex);
            // DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdexpedicion.Value = fila.MiNumExpedicion.ToString();
            HidEmpresa.Value = fila.MSEmpresa;
            string url = "..\\Logistica\\AsignacionMat.aspx?initCod=14&idExp=" + fila.MiIdExpedicion.ToString();
            Pup_AsignarAgencias.ContentUrl = url;
            Pup_AsignarAgencias.ShowOnPageLoad = true;
        }


        protected void cbAgencias_DataBinding(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                //cbAgencias.DataSource = losdatossap.dameagencias("",true, UsuarioPagina.CodProveedor.ToString(), ref error);
                cbAgencias.DataSource = DTAgenciasTodos;
                cbAgencias.TextField = "Nombreproveedor";
                cbAgencias.ValueField = "CodProveedor";
                cbAgencias.Text = "Todas";
                cbAgencias.SelectedIndex = 0;
              
            }
            catch(Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error consultando Agencias" + error, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void cbAgencias_ValueChanged(object sender, EventArgs e)
        {
            GV_Expediciones.DataBind();
        }

        protected void CbEstados_DataBinding(object sender, EventArgs e)
        {
            string error = "";

            try
            {

                CbEstados.DataSource = laexpedicion.dameestados(true);
                CbEstados.TextField = "Descripcion";
                CbEstados.ValueField = "Estado";
                CbEstados.Text = "Asignada Log";
                CbEstados.Text = "Todos";

            }
            catch(Exception ex)
            {

            }
         }

        protected void CbEstados_ValueChanged(object sender, EventArgs e)
        {
            GV_Expediciones.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GV_Expediciones.DataBind();
        }

        protected void BootstrapGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void Gv_ExpedicionesRetrasadas_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            Gv_ExpedicionesRetrasadas.DataBind();
        }

        protected void Gv_ExpedicionesRetrasadas_DataBinding(object sender, EventArgs e)
        {
            Gv_ExpedicionesRetrasadas.DataSource = laexpedicion.dameexpedicionesretrasadas("", 2);
            Gv_ExpedicionesRetrasadas.KeyFieldName = "MiNumExpedicion";
            
        }

        protected void cb_verretrasadas_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_verretrasadas.Checked)
            {
                PU_Expedicionesretrasadas.ShowOnPageLoad = true;
                cb_verretrasadas.Checked = false;
            }
        }

        protected void BT_Quitartodo_Click(object sender, EventArgs e)
        {
            laexpedicion.QuitaAsignacion(0, Convert.ToInt32(HidIdexpedicion.Value), HidEmpresa.Value.ToString());
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void btn_quitaragencia_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;

            DataRow fila = (DataRow)Gv_AgenciasAsignadas.GetDataRow(currentIndex);
            laexpedicion.QuitaAsignacion(Convert.ToInt32(fila["AeIdAgencia"]), Convert.ToInt32(HidIdexpedicion.Value), HidEmpresa.Value.ToString());
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void GV_Expediciones_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {
            try
            {

                switch (e.Item.Name)
                {
                   
                        
                    case "CustomExportToXLS":
                        ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                        break;
                    case "ExportToXls":
                        ASPxGridViewExporter1.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                        break;

                    default:
                        break;
                }

            }
            
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }
    }
}