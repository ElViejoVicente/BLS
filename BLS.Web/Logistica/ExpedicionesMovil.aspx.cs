using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Web.Controles.Usuario;
using System.Data;
using GPB.Negocio.Logistica;
using static GPB.Web.Controles.Usuario.InfoMsgBoxMovil;
using DevExpress.Web;

namespace GPB.Web
{
    public partial class ExpedicionesMovil : PageBase
    {
        #region variblesPrivadas
       DatosExpedicion laexpedicion = new DatosExpedicion();
       // DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
      //  Boolean isMovil = false;
        DatosTransportistas lostransportistas = new DatosTransportistas();

        //  DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
        #endregion

        #region propiedades
        public Boolean isMovil
        {
            get
            {
                Boolean ismovil=false;
                if (this.ViewState["isMovil"] != null)
                {
                    ismovil = (Boolean)this.ViewState["isMovil"];
                }


                return ismovil;

            }
            set
            {
                this.ViewState["isMovil"] = value;
            }
        }
        public int AccionSeleccionada
        {
            get
            {

                if (Session["AccionSeleccionada"] != null)
                {
                    return (int)Session["AccionSeleccionada"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["AccionSeleccionada"] = value;
            }
        }

        public GPB.Negocio.Logistica.Expedicion Expedicionseleccionada
        {
            get
            {
                GPB.Negocio.Logistica.Expedicion expedicionseleccionada = new Expedicion();
                // if (this.ViewState["Expedicionseleccionada"] != null)
                if (Session["Expedicionseleccionada"] != null)
                {
                    //expedicionseleccionada = (GPB.Negocio.Logistica.Expedicion)this.ViewState["Expedicionseleccionada"];
                    expedicionseleccionada = (GPB.Negocio.Logistica.Expedicion)Session["Expedicionseleccionada"];
                }

                return expedicionseleccionada;

            }
            set
            {
                //this.ViewState["Expedicionseleccionada"] = value;
                Session["Expedicionseleccionada"] = value;
            }
        }

        public List<Expedicion> listaExpediciones
        {
            get
            {
                List<Expedicion> listaExpediciones = new List<Expedicion>();
                // if (this.ViewState["Expedicionseleccionada"] != null)
                if (Session["listaExpediciones"] != null)
                {
                    //expedicionseleccionada = (GPB.Negocio.Logistica.Expedicion)this.ViewState["Expedicionseleccionada"];
                    listaExpediciones = (List<Expedicion>)Session["listaExpediciones"];
                }

                return listaExpediciones;
            }
            set
            {
                //this.ViewState["Expedicionseleccionada"] = value;
                Session["listaExpediciones"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            
            ComprobarEvento();
            if (!IsPostBack)
            { 
                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                    strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                    strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                    strUserAgent.Contains("palm"))
                    {
                        isMovil = true;
                        Gv_expedicion_desk.Visible = false;
                        Gv_Expediciones.DataBind();
                    }
                    else{
                        Gv_Expediciones.Visible = false;
                        Gv_expedicion_desk.DataBind();
                            Gv_expedicion_desk.Selection.SelectRow(0);
                        
                    }
                   
                }

                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));


                //Gv_Expediciones.Selection.SelectRow(0);
            }
            else
            {
                //if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                //  strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                //  strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                //  strUserAgent.Contains("palm"))
                //{
                //    isMovil = true;
                //}

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
                    Gv_expedicion_desk.DataBind();
                    Pup_AsignarMatricula.ShowOnPageLoad = false;
                    
                    


                    break;


                default:

                    break;
            }


        }
        protected void Comprobarbloqueo()
        {
            if(Session["NumExpediente"]!=null)
            {
                Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(Session["NumExpediente"].ToString(),Session["Empresa"].ToString());
                if (selectExp.MiNumAgencia==0 &&selectExp.MsMatricula=="")
                {
                    laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                                                numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                                                empresa: selectExp.MSEmpresa,
                                                estadoBloqueo: 1,
                                                transportista: "",
                                                matricula: "",
                                                fechaCargaPrev: "",
                                                fechaDescPrev: "",
                                                matricularemolque:"",
                                                idagencia:0,
                                                nombreagencia:"",
                                                 numautorizacion:"");
                }
              
            }
        }
        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                if (confiPAgina.Rows.Count > 0)
                {
                    imgLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                    lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                    lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                }
            }
            catch (Exception ex)
            {
                cuInfoMsgboxMovil.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }
        }

        protected void Gv_Expediciones_DataBinding(object sender, EventArgs e)
        {
            try
            {
                int filtroStatus;
                listaExpediciones.Clear();
                List<Expedicion> listaGrid = new List<Expedicion>();

                if (chkMisExp.Checked == false)
                {
                    filtroStatus = 1;
                    listaExpediciones = laexpedicion.dameexpedicionesporagenciaList(UsuarioPagina.CodProveedor,1);
                    listaGrid = listaExpediciones.Where(x => x.MiEstado == filtroStatus).ToList<Expedicion>();
                    listaGrid = listaGrid.Where(x => (x.MiestadoGesag>11||x.MiestadoGesag==0)  ).ToList<Expedicion>();
                    
                }
                else
                {
                    listaExpediciones = laexpedicion.dameexpedicionesporagenciaListasignadas(UsuarioPagina.CodProveedor,3);
                    filtroStatus = 3;
                    listaGrid = listaExpediciones.Where(x => x.MiEstado == filtroStatus).ToList<Expedicion>();
                    listaGrid = listaGrid.Where(x => (x.MiestadoGesag != 2 )).ToList<Expedicion>();
                }

                if (chkExpEntragada.Checked == true)
                {
                    listaExpediciones = laexpedicion.dameexpedicionesporagenciaListasignadas(UsuarioPagina.CodProveedor,4);
                    filtroStatus = 4;
                    listaGrid = listaExpediciones.Where(x => x.MiEstado == filtroStatus).ToList<Expedicion>();
                }

                

                
                if (isMovil) { 
                    Gv_Expediciones.DataSource = listaGrid;
                    Gv_Expediciones.KeyFieldName = "MiIdExpedicion";
                }
                else
                {
                    Gv_expedicion_desk.DataSource = listaGrid;
                    Gv_expedicion_desk.KeyFieldName = "MiIdExpedicion";
                    
                }

            }
            catch (Exception ex)
            {
                cuInfoMsgboxMovil.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }

        }

        protected void btnAsignarAgencia_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxButton btn = (ASPxButton)sender;
                Expedicion fila;
             

                
                //List<object> numsExpediciones = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                List<object> numsExpediciones = new List<object>();
                List<object> idsExpediciones = new List<object>();
                string idexpedicion = "";
                if (isMovil)
                {
                    CardViewDataItemTemplateContainer row2 = (CardViewDataItemTemplateContainer)btn.NamingContainer;
                    CardViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as CardViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    // numsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiNumExpedicion");
                    //idsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiIdExpedicion");
                    //fila = (DataRow)Gv_Expediciones.GetDataRow(currentIndex);
                    fila = (Expedicion)Gv_Expediciones.GetRow(currentIndex);
                    //List<object> numsExpediciones2 = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                }
                else
                {
                    GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                    GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    fila = (Expedicion)Gv_expedicion_desk.GetRow(currentIndex);
                    //numsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiNumExpedicion");
                    //idsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiIdExpedicion");
                }
                // String numExpedicion = numsExpediciones[0].ToString();
                String numExpedicion = fila.MiNumExpedicion.ToString(); ;
                //if (idsExpediciones.Count > 0)
                //{
                //     idexpedicion = idsExpediciones[0].ToString();
                //}
                idexpedicion = fila.MiIdExpedicion.ToString();
                Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(numExpedicion,fila.MSEmpresa);

                if (selectExp.MiEstado == 1 || selectExp.MiEstado == 3) 
                {
                    AccionSeleccionada = 1;
                    Expedicionseleccionada = selectExp;
                    if (selectExp.MiEstado == 1)
                    {
                        laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                                                        numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                                                        empresa: selectExp.MSEmpresa,
                                                        estadoBloqueo: 2,
                                                        transportista: "",
                                                        matricula: "",
                                                        fechaCargaPrev: "",
                                                        fechaDescPrev: "",
                                                        matricularemolque: "",
                                                        idagencia: 0,
                                                        nombreagencia: "",
                                                         numautorizacion: "");
                    }
                    if(isMovil)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "AsignarExpedicion(); ", true);
                    else
                    {
                        // rellenadatosDesktop();
                        ////laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                        //                           numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                        //                           empresa: selectExp.MSEmpresa,
                        //                           estadoBloqueo: 2,
                        //                           transportista: "",
                        //                           matricula: "",
                        //                           fechaCargaPrev: "",
                        //                           fechaDescPrev: "",
                        //                            matricularemolque: "",
                        //                            idagencia: 0,
                        //                            nombreagencia: "",
                        //                             numautorizacion:"");
                        Session["IdExpediente"]= idexpedicion.ToString();
                        Session["NumExpediente"] = selectExp.MiNumExpedicion.ToString();
                        Session["Empresa"] = selectExp.MSEmpresa.ToString();
                        Session["DTLisTransportistas"] = null;
                        string url = "..\\Logistica\\AsignacionMat.aspx?initCod=14&idExp=" + idexpedicion.ToString();
                        Pup_AsignarMatricula.ContentUrl = url;
                        Pup_AsignarMatricula.ShowOnPageLoad = true;
                      
                    }
                }
                else
                {
                    if (selectExp.MiestadoGesag < 11)
                    {
                        cuInfoMsgboxMovil.mostrarMensaje("la expedición ya no se puede modificar.", tipoMsg.error);
                    }
                    else
                    {
                        cuInfoMsgboxMovil.mostrarMensaje("la expedición ya fue solicitada por otra agencia, selecciona otra.", tipoMsg.error);
                    }
                    if (isMovil)
                        Gv_Expediciones.DataBind();
                    else
                        Gv_expedicion_desk.DataBind();
                }
            }
            catch (Exception ex)
            {
                cuInfoMsgboxMovil.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }
        }


        private void rellenadatosDesktop()
        {
            Txt_expedicion.Text = Expedicionseleccionada.MiNumExpedicion.ToString();
            Txt_destino.Text = Expedicionseleccionada.MsDestino;
            Txt_origen.Text = Expedicionseleccionada.MsOrigen;
            Txt_sociedad.Text = Expedicionseleccionada.MSEmpresa;
            txt_matricula.Text = Expedicionseleccionada.MsMatricula;
            Txt_Observaciones.Text = Expedicionseleccionada.MsObservacionesCom.ToString();
            Txt_ObservacionesLog.Text = Expedicionseleccionada.MsObservacionesLog.ToString();
            Txt_centrocarga.Text = Expedicionseleccionada.MsCentroCarga.ToString();
            Txt_unidadtransporte.Text = Expedicionseleccionada.MsUnidadTransporte.ToString();
            txt_matricularemolque.Text = Expedicionseleccionada.MsMatriculaRemolque;
            CB_Urgente.Checked = Expedicionseleccionada.MsUrgente == "X" ? true : false;
            CB_Transportistas.DataBind();
            if (AccionSeleccionada == 1)
            {
                lblCapturar.Visible = true;
            }
            else if (AccionSeleccionada == 2)
            {
                lblCapturar.Visible = false;
                CB_Transportistas.Text = Expedicionseleccionada.MsTransportista;
                Txt_numpermisoespecial.Text = Expedicionseleccionada.MsNumeroAutorizacion;
                txt_matricula.Text = Expedicionseleccionada.MsMatricula;
                Txt_Fechaprevcarga.Date = Expedicionseleccionada.MdFechaCargaPrevista;
                Txt_Fechaprevdescarga.Date = Expedicionseleccionada.MdFechaDescargaPrevista;
                CB_Transportistas.Enabled = false;
                txt_matricula.Enabled = false;
                txt_matricularemolque.Enabled = false;
                btnGuardar.Text = "Regresar";
                //btnCancel.Visible = false;
            }
        }
        private void rellenadatosPopUp()
        {
            Txt_expedicion.Text = Expedicionseleccionada.MiNumExpedicion.ToString();
            Txt_destino.Text = Expedicionseleccionada.MsDestino;
            Txt_origen.Text = Expedicionseleccionada.MsOrigen;
            Txt_sociedad.Text = Expedicionseleccionada.MSEmpresa;
           
            Txt_Observaciones.Text = Expedicionseleccionada.MsObservacionesCom.ToString();
            Txt_ObservacionesLog.Text = Expedicionseleccionada.MsObservacionesLog.ToString();
            Txt_centrocarga.Text = Expedicionseleccionada.MsCentroCarga.ToString();
            Txt_unidadtransporte.Text = Expedicionseleccionada.MsUnidadTransporte.ToString();
           
            CB_Urgente.Checked = Expedicionseleccionada.MsUrgente == "X" ? true : false;
            CB_Transportistas.DataBind();
           
        }
        protected void btnGuaqrdar_Click(object sender, EventArgs e)
        {

            if (AccionSeleccionada == 1)
            {
                if (txt_matricula.Text != "")
                {
                    cuInfoMsgboxMovil.mostrarMensaje("Expedición y Matricula guardada", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.success);
                }
                else
                {
                    cuInfoMsgboxMovil.mostrarMensaje("Debe indicar matrícula y agencia", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
                }
            }
            else if (AccionSeleccionada == 2)
            {
                PUp_Detalle.ShowOnPageLoad = false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AccionSeleccionada == 1)
            {
                if (CB_Transportistas.Text != "" && txt_matricula.Text != "")
                {
                    laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                 numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                 empresa: Expedicionseleccionada.MSEmpresa,
                                                 estadoBloqueo: 3,
                                                 transportista: CB_Transportistas.Text,
                                                 matricula: txt_matricula.Text,
                                                 fechaCargaPrev: Txt_Fechaprevcarga.Text, 
                                                 fechaDescPrev:Txt_Fechaprevdescarga.Text,
                                                  matricularemolque: txt_matricularemolque.Text,
                                                    idagencia: UsuarioPagina.CodProveedor,
                                                    nombreagencia: UsuarioPagina.NombreAgencia,
                                                     numautorizacion:Txt_numpermisoespecial.Text);

                    cuInfoMsgboxMovil.mostrarMensaje("Expedición y Matricula guardada", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.success);
                    PUp_Detalle.ShowOnPageLoad = false;
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarAsignacion(); ", true);
                }
                else
                {
                    cuInfoMsgboxMovil.mostrarMensaje("Debe indicar matrícula y transportista", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
                }
            }
            else if (AccionSeleccionada == 2)
            {
                PUp_Detalle.ShowOnPageLoad = false;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (chkMisExp.Checked == false && chkExpEntragada.Checked== false){
           
                laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                  numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                  empresa: Expedicionseleccionada.MSEmpresa,
                                                  estadoBloqueo: 1,
                                                  transportista: "",
                                                  matricula: "",
                                                  fechaCargaPrev:"",
                                                  fechaDescPrev:"",
                                                   matricularemolque: "",
                                                    idagencia: 0,
                                                    nombreagencia: "",
                                                    numautorizacion:"");
            }
            PUp_Detalle.ShowOnPageLoad = false;
        }
        protected void txt_matricula_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                List<Negocio.WS_GESAG.DatosMatriculas> listadoagencias;
              // List<Negocio.WS_GESAG_DES.DatosMatriculas> listadoagencias;
                rellenadatosPopUp();
                listadoagencias = laexpedicion.Dameagenciapormatricula(Expedicionseleccionada.MSEmpresa, txt_matricula.Text);


                if (listadoagencias.Count() >0)
                {
                    txt_matricularemolque.Text = listadoagencias[0].MatRemolque;
                    CB_Transportistas.Text = listadoagencias[0].TransportistaNom;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void PUp_Detalle_WindowCallback(object source, EventArgs e)
        {
            try
            {
                laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                  numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                  empresa: Expedicionseleccionada.MSEmpresa,
                                                  estadoBloqueo: 1,
                                                  transportista: "",
                                                  matricula: "",
                                                  fechaCargaPrev:"",
                                                  fechaDescPrev:"",
                                                   matricularemolque: "",
                                                    idagencia: 0,
                                                    nombreagencia: "",
                                                    numautorizacion:"");
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void PUp_Detalle_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void chkMisExp_CheckedChanged(object sender, EventArgs e)
        {
            chkExpEntragada.Checked = false;
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                strUserAgent.Contains("palm"))
                {
                    Gv_Expediciones.DataBind();
                }
                else
                {
                    Gv_expedicion_desk.DataBind();
                    Gv_expedicion_desk.Selection.SelectRow(0);
                }
            }

            //        if (isMovil)
            //    Gv_Expediciones.DataBind();
            //else { 
            //    Gv_expedicion_desk.DataBind();
            //    Gv_expedicion_desk.Selection.SelectRow(0);
            //}
        }

        protected void chkExpEntragada_CheckedChanged(object sender, EventArgs e)
        {
            chkMisExp.Checked = false;
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                strUserAgent.Contains("palm"))
                {
                    Gv_Expediciones.DataBind();
                }
                else
                {
                    Gv_expedicion_desk.DataBind();
                    Gv_expedicion_desk.Selection.SelectRow(0);
                }
            }


            //        if (isMovil)
            //    Gv_Expediciones.DataBind();
            //else
            //{
            //    Gv_expedicion_desk.DataBind();
            //    Gv_expedicion_desk.Selection.SelectRow(0);
            //}
        }
        protected void Gv_Expediciones_DataBound(object sender, EventArgs e)
        {
            try
            {
                //ASPxGridView grid = (ASPxGridView)sender;
                if (isMovil) { 
                    ASPxCardView grid = (ASPxCardView)sender;
                    configuracionColumnsCard(grid);
                }
                else
                {
                    
                    ASPxGridView grid = (ASPxGridView)sender;
                    //BootstrapCardView grid = (BootstrapCardView)sender;
                    configuracionColumnsGrid(grid);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void configuracionColumnsCard(ASPxCardView grid) {

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (i == grid.Columns.Count - 3)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = true;
                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }

                }

                if (i == grid.Columns.Count - 2 )
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;
                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = true;
                    }

                }
                if ( i == grid.Columns.Count - 1)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;
                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }

                }
            }
        }


        private void configuracionColumnsGrid(ASPxGridView grid)
        {

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (i == grid.Columns.Count - 5)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;

                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }

                }
                if (i == grid.Columns.Count - 4)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;

                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }

                }
                if (i == grid.Columns.Count - 3)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = true;

                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }

                }

                if (i == grid.Columns.Count - 2 )
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;
                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = true;
                    }
                }
                if ( i == grid.Columns.Count - 1)
                {
                    if (chkMisExp.Checked == false)
                    {
                        grid.Columns[i].Visible = false;
                    }
                    else
                    {
                        grid.Columns[i].Visible = true;
                    }

                    if (chkExpEntragada.Checked == true)
                    {

                        grid.Columns[i].Visible = false;
                    }
                }
            }
        }

        protected void btnDetalleExp_Click(object sender, EventArgs e)
        {
            try
            {
                //List<object> numsExpediciones = new List<object>();
                //if (isMovil)
                //     numsExpediciones = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                //else
                //     numsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiNumExpedicion");

                //String numExpedicion = numsExpediciones[0].ToString();
                ASPxButton btn = (ASPxButton)sender;
                Expedicion fila;



                //List<object> numsExpediciones = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                List<object> numsExpediciones = new List<object>();
                List<object> idsExpediciones = new List<object>();
                string idexpedicion = "";
                if (isMovil)
                {
                    CardViewDataItemTemplateContainer row2 = (CardViewDataItemTemplateContainer)btn.NamingContainer;
                    CardViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as CardViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    // numsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiNumExpedicion");
                    //idsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiIdExpedicion");
                    //fila = (DataRow)Gv_Expediciones.GetDataRow(currentIndex);
                    fila = (Expedicion)Gv_Expediciones.GetRow(currentIndex);
                    //List<object> numsExpediciones2 = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                }
                else
                {
                    GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                    GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    fila = (Expedicion)Gv_expedicion_desk.GetRow(currentIndex);
                    //numsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiNumExpedicion");
                    //idsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiIdExpedicion");
                }
                // String numExpedicion = numsExpediciones[0].ToString();
                String numExpedicion = fila.MiNumExpedicion.ToString(); ;
                //if (idsExpediciones.Count > 0)
                //{
                //     idexpedicion = idsExpediciones[0].ToString();
                //}
                idexpedicion = fila.MiIdExpedicion.ToString();
                Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(numExpedicion,fila.MSEmpresa);
                AccionSeleccionada = 2;
                Expedicionseleccionada = selectExp;

                if (isMovil)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "AsignarExpedicion(); ", true);
                else
                {
                    rellenadatosDesktop();
                    PUp_Detalle.ShowOnPageLoad = true;
                } 
            }
            catch (Exception ex)
            {
                cuInfoMsgboxMovil.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }
        }

        protected void btnMarcarEntrega_Click(object sender, EventArgs e)
        {

            try
            {
                ASPxButton btn = (ASPxButton)sender;
                Expedicion fila;
                //List<object> numsExpediciones = new List<object>();
                //if (isMovil)
                //{
                //    numsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiNumExpedicion");
                //    //List<object> numsExpediciones2 = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                //}
                //else
                //{
                //    numsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiNumExpedicion");
                //}

                //String numExpedicion = numsExpediciones[0].ToString();
                List<object> numsExpediciones = new List<object>();
                List<object> idsExpediciones = new List<object>();
                string idexpedicion = "";
                if (isMovil)
                {
                    CardViewDataItemTemplateContainer row2 = (CardViewDataItemTemplateContainer)btn.NamingContainer;
                    CardViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as CardViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    // numsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiNumExpedicion");
                    //idsExpediciones = Gv_Expediciones.GetFilteredSelectedValues("MiIdExpedicion");
                    //fila = (DataRow)Gv_Expediciones.GetDataRow(currentIndex);
                    fila = (Expedicion)Gv_Expediciones.GetRow(currentIndex);
                    //List<object> numsExpediciones2 = Gv_Expediciones.GetSelectedFieldValues("MiNumExpedicion");
                }
                else
                {
                    GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                    GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
                    int currentIndex = container.VisibleIndex;
                    fila = (Expedicion)Gv_expedicion_desk.GetRow(currentIndex);
                    //numsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiNumExpedicion");
                    //idsExpediciones = Gv_expedicion_desk.GetSelectedFieldValues("MiIdExpedicion");
                }
                // String numExpedicion = numsExpediciones[0].ToString();
                String numExpedicion = fila.MiNumExpedicion.ToString(); ;
                //if (idsExpediciones.Count > 0)
                //{
                //     idexpedicion = idsExpediciones[0].ToString();
                //}
                idexpedicion = fila.MiIdExpedicion.ToString();
                Expedicion selectExp = laexpedicion.damedatosexpedicionxnum(numExpedicion,fila.MSEmpresa);

                if (selectExp.MiEstado == 3 && selectExp.MiestadoGesag<9)
                {
                    AccionSeleccionada = 1;
                    Expedicionseleccionada = selectExp;

                    laexpedicion.bloqueaExpedicion(idExpedicion: selectExp.MiIdExpedicion,
                                                    numnexpedicion: selectExp.MiNumExpedicion.ToString(),
                                                    empresa: selectExp.MSEmpresa,
                                                    estadoBloqueo: 4,
                                                    transportista: selectExp.MsTransportista,
                                                    matricula: selectExp.MsMatricula,
                                                    fechaCargaPrev:selectExp.MdFechaCargaPrevista.ToString(),
                                                    fechaDescPrev: selectExp.MdFechaDescargaPrevista.ToString(),
                                                    matricularemolque: selectExp.MsMatriculaRemolque,
                                                    idagencia: UsuarioPagina.CodProveedor,
                                                    nombreagencia: UsuarioPagina.NombreAgencia,
                                                    numautorizacion:selectExp.MsNumeroAutorizacion);

                    if (isMovil){ 
                        cuInfoMsgboxMovil.mostrarMensaje("la expedición fue actualizada correctamente.", tipoMsg.success);
                        Gv_Expediciones.DataBind();
                    }
                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("la expedición fue actualizada correctamente.", InfoMsgBox.tipoMsg.success);
                        Gv_expedicion_desk.DataBind();
                    }

                    //cuInfoMsgboxMovil.mostrarMensaje("la expedición ya fue solicitada por otra agencia, favor de elegir otra nuevamente.", tipoMsg.error);
                    //Gv_Expediciones.DataBind();
                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "mensaje(); ", true);





                    //if (isMovil)
                    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "AsignarExpedicion(); ", true);
                    //else
                    //{
                    //    rellenadatosDesktop();
                    //    PUp_Detalle.ShowOnPageLoad = true;
                    //}

                }
                else
                {
                    cuInfoMsgboxMovil.mostrarMensaje("El estado de esta expedición no permite marcarse como entregado", tipoMsg.error);
                    Gv_Expediciones.DataBind();
                }
            }catch (Exception)
            {

                throw;
            }
        }

        protected void CB_Transportistas_DataBinding(object sender, EventArgs e)
        {
            CB_Transportistas.DataSource = lostransportistas.DameTransportistasGesag(Txt_sociedad.Text);
            CB_Transportistas.TextField = "Nombre";
            CB_Transportistas.ValueField = "CodTransportista";
        }


    }
}