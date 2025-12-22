using GPB.Web.Controles.Servidor;
using GPB.Negocio.Operativa;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;
using GPB.Negocio.ApiGoogle;
using DevExpress.Spreadsheet;
using System.IO;
using DevExpress.Spreadsheet.Export;
using DevExpress.SpreadsheetSource.Implementation;
using System.Configuration;
using DevExpress.XtraReports.UI;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace GPB.Web
{
    public partial class AsignacionExp : PageBase
    {
        #region variblesPrivadas
        //  DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
        DatosExpedicion laexpedicion = new DatosExpedicion();

        //DatosSAP_D losdatossap = new DatosSAP_D();
        DatosSAP losdatossap = new DatosSAP();
        ApiGoogle lafuncionesgoogle = new ApiGoogle();
        Funcioneslog funcioneslog = new Funcioneslog();

        public DataTable DtAsignacion
        {
            get
            {
                DataTable dtasignacion = new DataTable();
                if (ViewState["DtAsignacion"] == null)
                {
                    DataColumn columnaId = new DataColumn("id", typeof(int));
                    DataColumn columnaIdExpedicion = new DataColumn("idexpedicion", typeof(int));
                    DataColumn columnaIdAgencia = new DataColumn("idagencia", typeof(string));
                    DataColumn columnaNombreAgencia = new DataColumn("nombreagencia", typeof(string));
                    DataColumn columnaNumExpedicion = new DataColumn("numexpedicion", typeof(string));
                    DataColumn columnaEmpresaGG = new DataColumn("empresaGG", typeof(string));
                    DataColumn columnaOrigen = new DataColumn("origen", typeof(string));
                    DataColumn columnaDestino = new DataColumn("destino", typeof(string));
                    DataColumn columnalongitud = new DataColumn("longitud", typeof(string));

                    //Cargamos las columnas
                    dtasignacion.Columns.Add(columnaId);
                    dtasignacion.Columns.Add(columnaIdExpedicion);
                    dtasignacion.Columns.Add(columnaIdAgencia);
                    dtasignacion.Columns.Add(columnaNombreAgencia);
                    dtasignacion.Columns.Add(columnaNumExpedicion);
                    dtasignacion.Columns.Add(columnaOrigen);
                    dtasignacion.Columns.Add(columnaDestino);
                    dtasignacion.Columns.Add(columnalongitud);
                    dtasignacion.Columns.Add(columnaEmpresaGG);

                    ViewState.Add("DtAsignacion", dtasignacion);


                    return dtasignacion;
                }
                else
                {
                    return (DataTable)ViewState["DtAsignacion"];

                }
            }
            set
            {
                ViewState.Add("DtAsignacion", value);
            }

        }
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
        #endregion
        protected override PageStatePersister PageStatePersister
        {
            get
            {
                // Unlike as exemplified in the MSDN docs, we cannot simply return a new PageStatePersister
                // every call to this property, as it causes problems
                return new SessionPageStatePersister(this);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComprobarEvento();
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                cbSocieades.DataBind();

                //gv_expediciones2.DataBind();
                // LB_AgenciasSeleccionadas.DataBind();
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
        private void ComprobarEvento()
        {

            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            //CuMensaje.OCultarMensaje();
            switch (nombreEvento)
            {

                //cuando hemos pulsado sobre el botón de estrella
                case ("Refrescaexpedientes"):
                    Comprobarbloqueo();
                    gv_expedicion.DataBind();
                    Pup_AsignarAgencias.ShowOnPageLoad = false;
                    PUp_VerAgencias.ShowOnPageLoad = false;


                    break;


                default:

                    break;
            }


        }
        protected void Comprobarbloqueo()
        {
            if (Session["NumExpediente"] != null)
            {
                Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(Session["NumExpediente"].ToString(), Session["Empresa"].ToString());
                if (selectExp.MiNumAgencia == 0 && selectExp.MsMatricula == "" )
                {
                    laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                                                numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                                                empresa: selectExp.MSEmpresa,
                                                estadoBloqueo: 1,
                                                transportista: "",
                                                matricula: "",
                                                fechaCargaPrev: "",
                                                fechaDescPrev: "",
                                                matricularemolque: "",
                                                idagencia: 0,
                                                nombreagencia: "",
                                                numautorizacion: "");
                }
                Session["NumExpediente"] = null;
            }
        }
        protected void GV_Asignación_DataBinding(object sender, EventArgs e)
        {
            GV_Asignacion.DataSource = this.DtAsignacion;
            GV_Asignacion.KeyFieldName = "id";
        }

        protected void BT_Asignar_Click(object sender, EventArgs e)
        {
            int index;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            //  DataRow datosexpe;
            int Idexpedicion;
            if (gv_expedicion.Selection.Count > 0)
            {
                DtAsignacion.Clear();
                //LB_AgenciasSeleccionadas.SelectAll();
                List<Object> valoreKeySeleccionados = gv_expedicion.GetSelectedFieldValues("NumeroExpedicion");
                foreach (int numexpe in valoreKeySeleccionados)
                {
                    index = gv_expedicion.FindVisibleIndexByKeyValue(numexpe);
                    //DataRow datosexpe = gv_expedicion.GetDataRow(index);
                    GPB.Negocio.Logistica.ExpedicionPte fila = (GPB.Negocio.Logistica.ExpedicionPte)gv_expedicion.GetRow(index);

                    //lafuncionesgoogle.CodificacionGeografica2();
                    laexpedicion.damegeolocalizacionexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, ref latitud, ref longitud, ref dirgeo,ref latorigen,ref longorigen,ref dirorigen);
                    if (latitud != "")
                    {
                        coorlatitud = Convert.ToDecimal(latitud);
                    }
                    if (longitud != "")
                    {
                        coorlongitud = Convert.ToDecimal(longitud);
                    }
                    if (latorigen != "")
                    {
                        coorlatorigen = Convert.ToDecimal(latorigen);
                    }
                    if (longorigen != "")
                    {
                        coorlongorigen = Convert.ToDecimal(longorigen);
                    }
                    Idexpedicion = laexpedicion.Guardaexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, fila.Origen, fila.Destino,
                       "", 0, fila.Longitud.ToString(), fila.Observaciones, fila.FechaCreacion.ToString(),
                       DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", coorlatitud, coorlongitud, dirgeo, fila.CentroCarga,
                       fila.UnidadTransporte,fila.Empresa,fila.Pesoteorico,fila.Provincia,coorlongorigen,coorlatorigen,dirorigen);
                    if (Idexpedicion != 0)
                    {

                        foreach (ListEditItem agenciaselec in LB_Agencias.SelectedItems)
                        {
                            insertafilatabla(Idexpedicion, agenciaselec.Value.ToString(), agenciaselec.Text, fila.NumeroExpedicion.ToString(), fila.Origen, fila.Destino, fila.Longitud.ToString(), fila.Sociedad);
                        }
                    }
                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("No se ha podido guardar la expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }

                }

            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("Debe seleccionar alguna expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
            GV_Asignacion.DataBind();
        }

        protected void gv_expedicion_DataBinding(object sender, EventArgs e)
        {
            List<ExpedicionPte> listadoexpe = new List<ExpedicionPte>();
            List<ExpedicionPte> listaGrid = new List<ExpedicionPte>();

            if (cbSocieades.SelectedIndex >= 0)
            {
                listadoexpe = laexpedicion.DameExpedicionesGesagAsig(cbSocieades.SelectedItem.Value.ToString());


                switch (filtrado.SelectedItem.Value)
                {
                    case "PtoSevilla":


                        listaGrid = listadoexpe.Where(x => x.PtoSevilla == 1).ToList<ExpedicionPte>();
                        break;
                    case "SinPtoSevilla":
                        listaGrid = listadoexpe.Where(x => x.SinPtoSevilla == 1).ToList<ExpedicionPte>();
                        break;
                    case "Internacional":
                        listaGrid = listadoexpe.Where(x => x.Internacional == 1).ToList<ExpedicionPte>();
                        break;
                    case "Todos":
                        listaGrid = listadoexpe;
                        break;
                    default:
                        listaGrid = listadoexpe;
                        break;
                }
                gv_expedicion.DataSource = listaGrid;
            }
            //   gv_expedicion.DataSource = laexpedicion.cargaexpedicionesgesag();
            //  gv_expedicion.KeyFieldName = "NumeroExpedicion";
        }
        private int insertafilatabla(int idexpedicion, string numagencia, string nombreagencia, string numexpedicion, string origen, string destino, string longitud, string empresa)
        {
            DataRow nuevafila = DtAsignacion.NewRow();
            int idasignacion = 0;
            int res = 0;
            try
            {
                idasignacion = (this.DtAsignacion.Rows.Count + 1) * 10;
                int maxpos = Convert.ToInt32(DtAsignacion.AsEnumerable().Max(row => row["id"]));
                idasignacion = maxpos + 10;
                nuevafila["id"] = idasignacion;
                nuevafila["idexpedicion"] = idexpedicion;
                nuevafila["idagencia"] = numagencia;
                nuevafila["nombreagencia"] = nombreagencia;
                nuevafila["numexpedicion"] = numexpedicion;
                nuevafila["origen"] = origen;
                nuevafila["destino"] = destino;
                nuevafila["longitud"] = longitud;
                nuevafila["empresaGG"] = empresa;


                DtAsignacion.Rows.Add(nuevafila);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }

        }








        protected void GV_Asignacion_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            int index;
            DataRow datosexpe;
            int Idexpedicion;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            if (gv_expedicion.Selection.Count > 0)
            {

                List<Object> valoreKeySeleccionados = gv_expedicion.GetSelectedFieldValues("NumExpedicion");
                foreach (string numexpe in valoreKeySeleccionados)
                {

                    index = gv_expedicion.FindVisibleIndexByKeyValue(numexpe);
                    datosexpe = gv_expedicion.GetDataRow(index);
                  
                    laexpedicion.damegeolocalizacionexpedicion(datosexpe["NumExpedicion"].ToString(), datosexpe["Empresa"].ToString(), ref latitud, ref longitud, ref dirgeo, ref latorigen, ref longorigen, ref dirorigen);
                    if (latitud != "")
                    {
                        coorlatitud = Convert.ToDecimal(latitud);
                    }
                    if (longitud != "")
                    {
                        coorlongitud = Convert.ToDecimal(longitud);
                    }
                    if (latorigen != "")
                    {
                        coorlatorigen = Convert.ToDecimal(latorigen);
                    }
                    if (longorigen != "")
                    {
                        coorlongorigen = Convert.ToDecimal(longorigen);
                    }
                 
                    Idexpedicion = laexpedicion.Guardaexpedicion(datosexpe["NumExpedicion"].ToString(), datosexpe["Empresa"].ToString(), datosexpe["Origen"].ToString(), datosexpe["Destino"].ToString(),
                        datosexpe["Cliente"].ToString(), Convert.ToInt32(datosexpe["Numcliente"]), datosexpe["Longitud"].ToString(), datosexpe["ObservacionesCom"].ToString(), datosexpe["Fechacreaexp"].ToString(),
                       DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), datosexpe["ObservacinesLog"].ToString(), coorlatitud, coorlongitud, dirgeo, datosexpe["CentroCarga"].ToString(), datosexpe["UnidadTransporte"].ToString(),
                       datosexpe["ExNombreEmpresa"].ToString(),Convert.ToDecimal(datosexpe["ExPesoteorico"]),datosexpe["ExProvincia"].ToString(), coorlongorigen, coorlatorigen, dirorigen);
                    if (Idexpedicion != 0)
                    {


                        insertafilatabla(Idexpedicion, e.Parameters[0].ToString(), e.Parameters[0].ToString(), datosexpe["NumExpedicion"].ToString(), datosexpe["origen"].ToString(), datosexpe["destino"].ToString(), datosexpe["Longitud"].ToString(), datosexpe["empresa"].ToString());

                    }
                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("No se ha podido guardar la expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }

                }

            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("Debe seleccionar alguna expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
            GV_Asignacion.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idagenciaant = 0;
            int idagenciaact = 0;
            foreach (DataRow fila in DtAsignacion.Rows)
            {
                if (Convert.ToInt32(fila["idagencia"])==115043)
                {
                    int i=0;
                }
                int res = laexpedicion.AsignaExpedicion(Convert.ToInt32(fila["idagencia"]), Convert.ToInt32(fila["idexpedicion"]), fila["nombreagencia"].ToString(),UsuarioPagina.UserName);
               

              //  enviaemailasig(Convert.ToInt32(fila["idagencia"]));
            }
            DataTable dtagenciasasig= DtAsignacion.DefaultView.ToTable(true, "idagencia");
            foreach (DataRow fila in dtagenciasasig.Rows)
            {
                enviaemailasig(Convert.ToInt32(fila["idagencia"]));
            }
            DataTable dtexpasig = DtAsignacion.DefaultView.ToTable(true, "idexpedicion", "numexpedicion", "empresaGG");
            foreach (DataRow fila in dtexpasig.Rows)
            {
                laexpedicion.guardalog(fila["numexpedicion"].ToString(), fila["empresaGG"].ToString(), "", "0", "Asignaciona gencias", UsuarioPagina.UserName);
                laexpedicion.guardafechaasignacion(fila["empresaGG"].ToString(), fila["numexpedicion"].ToString(), DateTime.Now.ToString("yyyy-MM-dd"), UsuarioPagina.UserName);
            }
            DtAsignacion.Clear();
            GV_Asignacion.DataBind();
            gv_expedicion.Selection.UnselectAll();
            LB_Agencias.UnselectAll();
            cuInfoMsgbox1.mostrarMensaje("Asignaciones Guardadas", Controles.Usuario.InfoMsgBox.tipoMsg.info);

        }
        protected void enviaemailasig(int idagencia)
        {
            string email = "";
            DataTable listaemail = new DataTable();
            DatosUsuario losdatousu = new DatosUsuario();
            listaemail = losdatousu.dameemailagencias(idagencia, true);
            foreach (DataRow fila in listaemail.Rows)
            {
                if (email == "")
                {
                    email = fila["usmail"].ToString();
                }
                else
                {
                    email = email + "," + fila["usmail"].ToString();
                }
            }
            if (email != "")
            {
                Negocio.Operativa.Emails.envioemailAsginación(email);
            }

        }

        protected void LB_Agencias_DataBinding(object sender, EventArgs e)
        {
            string error = "";
            DataTable dtfiltrado=new DataTable();
            try
            {
                //LB_Agencias.DataSource = losdatossap.dameagencias("",false, UsuarioPagina.CodProveedor.ToString(), ref error);

                if (CB_Filtros.Text != "Todas")
                {
                    dtfiltrado = DTAgencias.Select("Grupo ='" + CB_Filtros.SelectedItem.Value.ToString() + "'").CopyToDataTable(); ;
                    LB_Agencias.DataSource = dtfiltrado;
                }
                else
                {
                    DataTable dtagenciassinrepe = DTAgencias.DefaultView.ToTable(true, "CodProveedor", "Nombreproveedor");
                    LB_Agencias.DataSource = dtagenciassinrepe;
                }
                //LB_Agencias.DataSource = DTAgencias;
                LB_Agencias.TextField = "Nombreproveedor";
                LB_Agencias.ValueField = "CodProveedor";
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error consultando Agencias" + error, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void Gv_AgenciasAsignadas_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void Gv_AgenciasAsignadas_DataBinding(object sender, EventArgs e)
        {
            if (HidIdexpedicion.Value != "")
            {
                Gv_AgenciasAsignadas.DataSource = laexpedicion.dameagenciaexpedicion(Convert.ToInt32(HidIdexpedicion.Value),HidEmpresa.Value.ToString());

            }
        }
        protected void PUp_VerAgencias_Load(object sender, EventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void gv_expedicion_EditFormLayoutCreated(object sender, ASPxGridViewEditFormLayoutEventArgs e)
        {
            int clave = (int)e.RowKeyValue;
            string comentario;
            comentario = laexpedicion.Dameobservaciones(clave, cbSocieades.SelectedItem.Value.ToString());
            GridViewDataColumn column = gv_expedicion.Columns["ObservacionesLog"] as GridViewDataColumn;




        }

        protected void gv_expedicion_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int clave = (int)e.OldValues["NumeroExpedicion"];
            int index, Idexpedicion;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            string comentario = "";
            string urgente = "";
            if (e.NewValues["ObservacionesLog"] != null)
            {
                comentario = e.NewValues["ObservacionesLog"].ToString();
            }
            if (Convert.ToBoolean(e.NewValues["Urgente"]) == false || (e.NewValues["Urgente"] != null && e.NewValues["Urgente"].ToString() == ""))
            {
                urgente = "";
            }
            else
            {
                urgente = "X";
            }
            index = gv_expedicion.FindVisibleIndexByKeyValue(clave);

            GPB.Negocio.Logistica.ExpedicionPte fila = (GPB.Negocio.Logistica.ExpedicionPte)gv_expedicion.GetRow(index);
            laexpedicion.damegeolocalizacionexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, ref latitud, ref longitud, ref dirgeo, ref latorigen, ref longorigen, ref dirorigen);
            if (latitud != "")
            {
                coorlatitud = Convert.ToDecimal(latitud);
            }
            if (longitud != "")
            {
                coorlongitud = Convert.ToDecimal(longitud);
            }
            if (latorigen != "")
            {
                coorlatorigen = Convert.ToDecimal(latorigen);
            }
            if (longorigen != "")
            {
                coorlongorigen = Convert.ToDecimal(longorigen);
            }
            Idexpedicion = laexpedicion.Guardaexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, fila.Origen, fila.Destino,
               "", 0, fila.Longitud.ToString(), fila.Observaciones, fila.FechaCreacion.ToString(),
               DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", coorlatitud, coorlongitud, dirgeo, fila.CentroCarga,
               fila.UnidadTransporte, fila.Empresa, fila.Pesoteorico, fila.Provincia, coorlongorigen, coorlatorigen, dirorigen);
            
          
            laexpedicion.guardaobservaciones(clave, comentario, urgente);
            if (urgente=="X")
            {
                laexpedicion.guardaurgente(fila.Sociedad, fila.NumeroExpedicion.ToString(), UsuarioPagina.UserName);
            }
            ASPxGridView g = sender as ASPxGridView;
            e.Cancel = true;
            g.CancelEdit();
            g.DataBind();
        }

        protected void gv_expedicion_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            int clave = (int)e.KeyValue;
            if (e.Column.FieldName == "ObservacionesLog")
            {
                ASPxMemo observa = e.Editor as ASPxMemo;

                observa.Text =  laexpedicion.Dameobservaciones(clave, cbSocieades.SelectedItem.Value.ToString());
                observa.ReadOnly = false;
            }
            //if (e.Column.FieldName == "Urgente")
            //{
            //    ASPxCheckBox urgente = e.Editor as ASPxCheckBox;

            //    if (laexpedicion.Dameurgente(clave, cbSocieades.SelectedItem.Value.ToString()) == "X")
            //    {
            //        urgente.Checked = true;

            //    }
            //    urgente.ReadOnly = false;

            //}


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LB_Agencias.DataBind();
            //GV_agencias.DataBind();
            gv_expedicion.DataBind();
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

        protected void Bt_Asignarmatricula_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            Negocio.Logistica.ExpedicionPte fila = (Negocio.Logistica.ExpedicionPte)gv_expedicion.GetRow(currentIndex);
            // DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdexpedicion.Value = fila.NumeroExpedicion.ToString();
            HidEmpresa.Value = fila.Sociedad.ToString();
            string url = "..\\Logistica\\AsignacionMat.aspx?initCod=14&idExp=" +fila.NumeroExpedicion;
            Pup_AsignarAgencias.ContentUrl = url;
            Pup_AsignarAgencias.ShowOnPageLoad = true;
        }

        protected void btnVerAgencias_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;

            Negocio.Logistica.ExpedicionPte fila = (Negocio.Logistica.ExpedicionPte)gv_expedicion.GetRow(currentIndex);

            // DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdexpedicion.Value = fila.NumeroExpedicion.ToString();
            HidEmpresa.Value = fila.Sociedad.ToString();
            PUp_VerAgencias.ShowOnPageLoad = true;
        }

        protected void btnAsignarAgencia_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            Negocio.Logistica.ExpedicionPte fila = (Negocio.Logistica.ExpedicionPte)gv_expedicion.GetRow(currentIndex);
            // DataRow dt = container.Grid.GetDataRow(currentIndex);
            laexpedicion.damegeolocalizacionexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, ref latitud, ref longitud, ref dirgeo, ref latorigen, ref longorigen, ref dirorigen);
            if (latitud != "")
            {
                coorlatitud = Convert.ToDecimal(latitud);
            }
            if (longitud != "")
            {
                coorlongitud = Convert.ToDecimal(longitud);
            }
            if (latorigen != "")
            {
                coorlatorigen = Convert.ToDecimal(latorigen);
            }
            if (longorigen != "")
            {
                coorlongorigen = Convert.ToDecimal(longorigen);
            }
           int Idexpedicion = laexpedicion.Guardaexpedicion(fila.NumeroExpedicion.ToString(), fila.Sociedad, fila.Origen, fila.Destino,
               "", 0, fila.Longitud.ToString(), fila.Observaciones, fila.FechaCreacion.ToString(),
               DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", coorlatitud, coorlongitud, dirgeo, fila.CentroCarga,
               fila.UnidadTransporte, fila.Empresa, fila.Pesoteorico, fila.Provincia, coorlongorigen, coorlatorigen, dirorigen);

            
            HidIdexpedicion.Value = fila.NumeroExpedicion.ToString();
            HidEmpresa.Value = fila.Sociedad.ToString();
            Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(fila.NumeroExpedicion.ToString(),fila.Sociedad);

            if (selectExp.MiEstado < 2)
            {


                laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                                                numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                                                empresa: selectExp.MSEmpresa,
                                                estadoBloqueo: 1,
                                                transportista: "",
                                                matricula: "",
                                                fechaCargaPrev: "",
                                                fechaDescPrev: "",
                                                matricularemolque: "",
                                                idagencia: 0,
                                                nombreagencia: "",
                                                 numautorizacion: "");
                string url = "..\\Logistica\\AsignacionMat.aspx?initCod=14&idExp=" + Idexpedicion.ToString();
                Session["NumExpediente"] = selectExp.MiNumExpedicion.ToString();
                Session["Empresa"] = selectExp.MSEmpresa.ToString();
                Pup_AsignarAgencias.ContentUrl = url;
                Pup_AsignarAgencias.ShowOnPageLoad = true;
            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("La expedición ya fue solicitada por otra agencia, selecciona otra.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                gv_expedicion.DataBind();

            }
        }

        //protected void gv_expediciones2_DataBinding(object sender, EventArgs e)
        //{
        //    if (cbSocieades.SelectedIndex >= 0)
        //    {
        //        gv_expediciones2.DataSource = laexpedicion.DameExpedicionesGesagAsig(cbSocieades.SelectedItem.Value.ToString());
        //    }
        //}

        protected void gv_expediciones2_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            int clave = (int)e.KeyValue;
            if (e.Column.FieldName == "ObservacionesLog")
            {
                ASPxMemo observa = e.Editor as ASPxMemo;

                observa.Text = laexpedicion.Dameobservaciones(clave, cbSocieades.SelectedItem.Value.ToString());
                observa.ReadOnly = false;
            }
            //if (e.Column.FieldName == "Urgente")
            //{
            //    ASPxCheckBox urgente = e.Editor as ASPxCheckBox;

            //    if (laexpedicion.Dameurgente(clave, cbSocieades.SelectedItem.Value.ToString()) == "X")
            //    {
            //        urgente.Checked = true;
            //        urgente.ReadOnly = false;
            //    }

            //}
        }

        protected void cbSocieades_ValueChanged(object sender, EventArgs e)
        {
            gv_expedicion.DataBind();
        }


        protected void filtrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv_expedicion.DataBind();
        }

        protected void BT_Quitartodo_Click(object sender, EventArgs e)
        {
            laexpedicion.QuitaAsignacion(0, Convert.ToInt32(HidIdexpedicion.Value),HidEmpresa.Value.ToString());
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
        public void importagencias()
        {
            Workbook wb = new Workbook();
         string   rutalog = ConfigurationManager.AppSettings.Get("rutalog");
          string  ruta = rutalog + "Agencias.xlsx";
            wb.Worksheets[0].Import(DTAgencias, true, 0, 0);
            //using (FileStream stream = new FileStream(ruta,
            //          FileMode.Create, FileAccess.ReadWrite))
            //{
            //    wb.SaveDocument(stream, DocumentFormat.Xlsx);
            //}
            // Descarga(rutalog+"\\" + "Agencias.xlsx");
            HttpResponse response = Response;

            //Prepare the response

            response.ClearHeaders();
            response.ClearContent();
            response.Clear();
            response.Buffer = true;

            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=Agencias.xlsx");

            //Flush the workbook to the Response.OutputStream
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveDocument(MyMemoryStream, DocumentFormat.Xlsx);

                MyMemoryStream.WriteTo(response.OutputStream);
                MyMemoryStream.Close();
            }

            Response.End();
        }

        protected void BT_Export_Click(object sender, EventArgs e)
        {
           // DevExpress.XtraPrinting.XlsExportOptions options = new XlsExportOptions();
           // options.SheetName = "Agencias";
           // exportGrid.WriteXlsToResponse(options);
           //// exportGrid.ExportedRowType = GridViewExportedRowType.All;
            
           //// exportGrid.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
              importagencias();
        }
        protected void Descarga(string ruta)
        {

            try
            {
                System.IO.FileInfo toDownload =
                           new System.IO.FileInfo(ruta);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition",
                           "attachment; filename=" + toDownload.Name);
                HttpContext.Current.Response.AddHeader("Content-Length",
                           toDownload.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(ruta);
                HttpContext.Current.Response.Flush();
                //HttpContext.Current.Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch(Exception ex)
            {

            }
        }

        protected void CB_Filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_Agencias.DataBind();
        }
    }
}