using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Operativa;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System.Data;
using System.Text.RegularExpressions;

namespace GPB.Web
{
    public partial class AsignacionMat : PageBase
    {
        #region variblesPrivadas
        
      // DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
        DatosExpedicion laexpedicion = new DatosExpedicion();

        //DatosSAP_D losdatossap = new DatosSAP_D();
        DatosSAP losdatossap = new DatosSAP();
        // DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
        DatosTransportistas lostransportistas = new DatosTransportistas();
        #endregion
        #region propiedades
        public int IDExpedicionseleccionada
        {
            get
            {
                
                if (Session["IDExpedicionseleccionada"] != null)
                {
                    return (int)Session["IDExpedicionseleccionada"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["IDExpedicionseleccionada"] = value;
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
        public List<Transportistas> DTLisTransportistas
        {
            get
            {
                List<Transportistas> dtagencias = new List<Transportistas>();

                if (Session["DTLisTransportistas"] != null )
                {

                    dtagencias = (List<Transportistas>)Session["DTLisTransportistas"];
                    if (dtagencias.Count==0)
                    {
                        dtagencias = lostransportistas.DametransportistasGesagTabla(Expedicionseleccionada.MSEmpresa);
                        Session["DTLisTransportistas"] = dtagencias;
                    }
                }
                else
                {
                    
                    dtagencias = lostransportistas.DametransportistasGesagTabla(Expedicionseleccionada.MSEmpresa);
                    Session["DTLisTransportistas"] = dtagencias;
                }
                return dtagencias;

            }
            set
            {
                Session["DTLisTransportistas"] = value;
            }
        }
       
        public GPB.Negocio.Logistica.Expedicion Expedicionseleccionada
        {
            get
            {
                GPB.Negocio.Logistica.Expedicion expedicionseleccionada=new Expedicion()  ;
                if (this.ViewState["Expedicionseleccionada"] != null)
                {
                    expedicionseleccionada = (GPB.Negocio.Logistica.Expedicion)this.ViewState["Expedicionseleccionada"];
                }
                

                return expedicionseleccionada;

            }
            set
            {
                this.ViewState["Expedicionseleccionada"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            ComprobarEvento(sender, e);

            if (!Page.IsPostBack)
                {
                    Response.Expires = 0;
                
                  //  CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                
                    if (Request.QueryString["idExp"] != null)
                    {
                            IDExpedicionseleccionada =Convert.ToInt32(Request.QueryString["idExp"].ToString());
                            Expedicionseleccionada = laexpedicion.damedatosexpedicionxid(IDExpedicionseleccionada);
                    }
                    rellenadatos();
                CB_Agencia.DataBind();
                }
        }

        private void rellenadatos()
        {
            Txt_expedicion.Text = Expedicionseleccionada.MiNumExpedicion.ToString();
            Txt_destino.Text = Expedicionseleccionada.MsDestino;
            Txt_origen.Text = Expedicionseleccionada.MsOrigen;
            Txt_sociedad.Text = Expedicionseleccionada.MsNombreEmpresa;
            txt_matricula.Text = Expedicionseleccionada.MsMatricula;
            Txt_pesoteorico.Text = Expedicionseleccionada.MdPesoteorico.ToString();
            Txt_Observaciones.Text = Expedicionseleccionada.MsObservacionesCom;
            Txt_Observacioneslog.Text = Expedicionseleccionada.MsObservacionesLog;
            if (UsuarioPagina.CodProveedor == 0)
            {
                CB_Agencia.Value = Expedicionseleccionada.MiNumAgencia.ToString().PadLeft(10, '0');
                CB_Agencia.Visible = true;
                Frm_Asignacion.FindItemOrGroupByName("elidagencia").Visible = true;
                CB_Urgente.Enabled = false;
            }
            else
            {
                CB_Agencia.Value = UsuarioPagina.CodProveedor.ToString().PadLeft(10, '0');
                CB_Agencia.Visible = false;
                Frm_Asignacion.FindItemOrGroupByName("elidagencia").Visible = false;
                CB_Urgente.Enabled = false;
            }
            txt_matricularemolque.Text = Expedicionseleccionada.MsMatriculaRemolque;
            Txt_UnidadTransporte.Text = Expedicionseleccionada.MsUnidadTransporte;
            Txt_CentroCarga.Text = Expedicionseleccionada.MsCentroCarga;
            CB_Urgente.Checked = Expedicionseleccionada.MsUrgente == "X" ? true:false;
            if (Expedicionseleccionada.MdFechaCargaPrevista != Convert.ToDateTime( "01/01/1900"))
            {
                Txt_Fechaprevcarga.Date = Expedicionseleccionada.MdFechaCargaPrevista;
            }
            if (Expedicionseleccionada.MdFechaDescargaPrevista != Convert.ToDateTime("01/01/1900"))
            {
                Txt_Fechaprevdescarga.Date = Expedicionseleccionada.MdFechaDescargaPrevista;
            }
            CB_Transportistas.DataBind();
            CB_Transportistas.Text = Expedicionseleccionada.MsTransportista;
            Txt_numpermisoespecial.Text = Expedicionseleccionada.MsNumeroAutorizacion;
            if(Expedicionseleccionada.MsMatricula!="" && UsuarioPagina.CodProveedor != 0)
            {
                Txt_Fechaprevcarga.Enabled = false;
                Txt_Fechaprevdescarga.Enabled = false;
            }
            else {
                Txt_Fechaprevcarga.Enabled = true;
                Txt_Fechaprevdescarga.Enabled = true;
            }
        }
        private void ComprobarEvento(object sender, EventArgs e)
        {
            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            //CuMensaje.OCultarMensaje();
            switch (nombreEvento)
            {
                case ("seleccionar"):
                    seleccionaragencia(sender, e);
                    break;
                case ("Refrescatransportistas"):
                    CB_Transportistas.DataBind();
                    Pup_AddTransportista.ShowOnPageLoad = false;
                    PUp_VerAgencias.ShowOnPageLoad = false;
                    break;
            }
        }
        private void seleccionaragencia(object sender, EventArgs e)
        {
            List<object> Agencias = Gv_AgenciasAsignadas.GetSelectedFieldValues("AgenciaId");
            if (Agencias[0].ToString() != "No_SAP")
            {
                CB_Agencia.Value = Agencias[0].ToString().PadLeft(10,'0');
            }
            List<object> Matremolque = Gv_AgenciasAsignadas.GetSelectedFieldValues("MatRemolque");
                  txt_matricularemolque.Text = Matremolque[0].ToString();
            List<object> transportista = Gv_AgenciasAsignadas.GetSelectedFieldValues("TransportistaNom");
            //Txt_transportista.Text = transportista[0].ToString();
            CB_Transportistas.Text = transportista[0].ToString();
            PUp_VerAgencias.ShowOnPageLoad = false;

        }

            protected void CargarConfigruacionHead(int codPAgina)
            {
                try
                {
                if (codPAgina != 0)
                {
                    DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                    if (confiPAgina.Rows.Count > 0)
                    {
                        //imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                        //lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                        //lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                    }
                }
                else
                {
                    //header.Visible = false;
                    controles.Visible = true;

                }
                }
                catch (Exception ex)
                {

                    // cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
                }
            }

   

        protected void txt_matricula_TextChanged1(object sender, EventArgs e)
        {
            List<Negocio.WS_GESAG.DatosMatriculas> listadoagencias;
            //  txt_matricula.Text = Regex.Replace(txt_matricula.Text, @"[^\w\s.,!@$%^&*()\-\/]+", "");
            txt_matricula.Text = txt_matricula.Text.Replace(".", "").Replace(",", "").Replace("-","").Replace("/","").Replace("(","").Replace(")","").Replace("|","").Replace("&","").Replace("·","").Replace("@","").Replace("#","").Replace("%","").Replace("$","").Replace("'","").Replace("!","").Replace("¡","").Replace("^","");
            //List<Negocio.WS_GESAG_DES.DatosMatriculas> listadoagencias;
            if (txt_matricula.Text != "")
            {
                listadoagencias = laexpedicion.Dameagenciapormatricula(Expedicionseleccionada.MSEmpresa, txt_matricula.Text);

                if (listadoagencias.Count() > 1)
                {
                    PUp_VerAgencias.ShowOnPageLoad = true;
                }
                else
                {
                    if (listadoagencias.Count() == 1)
                    {
                        if (listadoagencias[0].AgenciaId != "No_SAP")
                        {
                            CB_Agencia.Value = listadoagencias[0].AgenciaId.PadLeft(10, '0');
                        }
                        txt_matricularemolque.Text = listadoagencias[0].MatRemolque;

                        CB_Transportistas.Text = listadoagencias[0].TransportistaNom;
                        if (CB_Transportistas.SelectedIndex == -1)
                        {
                            CB_Transportistas.Text = "-";
                        }
                    }
                }
            }
        }

        protected void Bt_BuscarAgencia_Click(object sender, EventArgs e)
        {


        }

        protected void Gv_AgenciasAsignadas_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void Gv_AgenciasAsignadas_DataBinding(object sender, EventArgs e)
        {
            Gv_AgenciasAsignadas.DataSource = laexpedicion.Dameagenciapormatricula(Expedicionseleccionada.MSEmpresa, txt_matricula.Text);
        }

        

        protected void CB_Agencia_DataBinding(object sender, EventArgs e)
        {
            string error = "";
            try
            {

                //CB_Agencia.DataSource = losdatossap.dameagencias("", false,UsuarioPagina.CodProveedor.ToString(), ref error);
                CB_Agencia.DataSource = DTAgencias;
                CB_Agencia.TextField= "Nombreproveedor";
                CB_Agencia.ValueField = "CodProveedor";
                if (UsuarioPagina.CodProveedor!=0)
                {
                    CB_Agencia.Value = UsuarioPagina.CodProveedor.ToString().PadLeft(10, '0');
                    CB_Agencia.Visible = false;
                    Frm_Asignacion.FindItemOrGroupByName("elidagencia").Visible = false;
                }
                else
                {
                    CB_Agencia.Visible = true;
                    Frm_Asignacion.FindItemOrGroupByName("elidagencia").Visible = true;
                }
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error consultando Agencias" + error, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void btnGuaqrdar_Click(object sender, EventArgs e)
        {
            string numpermiso = Txt_numpermisoespecial.Text.Replace(".", "").Replace(",", "").Replace("/", "-").Replace("-", "").Replace("-", "").Replace("|", "").Replace("&", "").Replace("·", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("$", "").Replace("'", "").Replace("!", "").Replace("¡", "").Replace("^", "");
            
            if (UsuarioPagina.CodProveedor == 0)
            {
                if (txt_matricula.Text != "" && CB_Agencia.SelectedIndex != -1 && Txt_Fechaprevcarga.Date.ToString() != "" && Txt_Fechaprevdescarga.Date.ToString() != "" && CB_Transportistas.SelectedIndex != -1)
                {
                    DataTable dtexpmatricula = laexpedicion.dameexpedicionesmatriculaprovincia(txt_matricula.Text, Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa);
                    if (dtexpmatricula.Rows.Count == 0)
                    {
                        if (Txt_Fechaprevcarga.Date >= DateTime.Today && Txt_Fechaprevdescarga.Date >= DateTime.Today)
                        {
                            string idagencia = CB_Agencia.SelectedItem.Value.ToString();
                            string nombreagencia = CB_Agencia.SelectedItem.Text.ToString();

                            int res = laexpedicion.guardamatriculaGESAG(Expedicionseleccionada.MSEmpresa, Expedicionseleccionada.MiNumExpedicion.ToString(), idagencia, CB_Transportistas.SelectedItem.Value.ToString(), txt_matricula.Text.ToUpper(), txt_matricularemolque.Text.ToUpper(), Txt_Fechaprevdescarga.Date.ToString("yyyy-MM-dd"), Txt_Fechaprevcarga.Date.ToString("yyyy-MM-dd"), numpermiso, UsuarioPagina.UserName);
                            if (res == 0)
                            {
                                laexpedicion.guardamatricula(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, txt_matricula.Text, idagencia,
                                  nombreagencia, CB_Transportistas.SelectedItem.Text, txt_matricularemolque.Text, Txt_Fechaprevcarga.Date.ToString(), Txt_Fechaprevdescarga.Date.ToString(), numpermiso);
                                laexpedicion.guardalog(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, txt_matricula.Text, idagencia, "guarda matricula", UsuarioPagina.UserName);
                                cuInfoMsgbox1.mostrarMensaje("Matricula guardada", Controles.Usuario.InfoMsgBox.tipoMsg.success);
                            }
                            else
                            {
                                if (res == -99)
                                {
                                    laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                               numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                               empresa: Expedicionseleccionada.MSEmpresa,
                                                               estadoBloqueo: 3,
                                                               transportista: Expedicionseleccionada.MsTransportista,
                                                               matricula: Expedicionseleccionada.MsMatricula,
                                                               fechaCargaPrev: Expedicionseleccionada.MdFechaCargaPrevista.ToString(),
                                                               fechaDescPrev: Expedicionseleccionada.MdFechaDescargaPrevista.ToString(),
                                                               matricularemolque: Expedicionseleccionada.MsMatriculaRemolque,
                                                               idagencia: Convert.ToInt32(Expedicionseleccionada.MSEmpresa),
                                                               nombreagencia: Expedicionseleccionada.MsNombreAgencia,
                                                                numautorizacion: Expedicionseleccionada.MsNumeroAutorizacion);
                                    cuInfoMsgbox1.mostrarMensaje("Esta expedicion ya no está disponible", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                                }
                            }
                        }
                        else
                        {
                            cuInfoMsgbox1.mostrarMensaje("Las fechas no pueden ser anteriores al dia de hoy", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                        }
                    }
                    else{
                        cuInfoMsgbox1.mostrarMensaje("No sé puede reservar una expedición mientras haya otra expedición pendiente de entregar", Controles.Usuario.InfoMsgBox.tipoMsg.error);

                    }
                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Debe indicar matrículas y agencia", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                }
            }
            else
            {
                if (txt_matricula.Text != "" && Txt_Fechaprevcarga.Date.ToString() != "" && Txt_Fechaprevdescarga.Date.ToString() != "" && CB_Transportistas.SelectedIndex != -1)
                {
                    DataTable dtexpmatricula = laexpedicion.dameexpedicionesmatriculaprovincia(txt_matricula.Text, Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa);
                    if (dtexpmatricula.Rows.Count == 0)
                    {

                        if (Txt_Fechaprevcarga.Date >= DateTime.Today && Txt_Fechaprevdescarga.Date >= DateTime.Today)
                        {
                            string idagencia = UsuarioPagina.CodProveedor.ToString();
                            string nombreagencia = UsuarioPagina.NombreAgencia.ToString();
                            int res = laexpedicion.guardamatriculaGESAG(Expedicionseleccionada.MSEmpresa, Expedicionseleccionada.MiNumExpedicion.ToString(), idagencia, CB_Transportistas.SelectedItem.Value.ToString(), txt_matricula.Text.ToUpper(), txt_matricularemolque.Text.ToUpper(), Txt_Fechaprevdescarga.Date.ToString("yyyy-MM-dd"), Txt_Fechaprevcarga.Date.ToString("yyyy-MM-dd"), numpermiso, UsuarioPagina.UserName);
                            if (res == 0)
                            {
                                laexpedicion.guardamatricula(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, txt_matricula.Text, UsuarioPagina.CodProveedor.ToString(),
                               UsuarioPagina.NombreAgencia.ToString(), CB_Transportistas.SelectedItem.Text, txt_matricularemolque.Text, Txt_Fechaprevcarga.Date.ToString(), Txt_Fechaprevdescarga.Date.ToString(), numpermiso);
                                laexpedicion.guardalog(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, txt_matricula.Text, idagencia, "guarda matricula", UsuarioPagina.UserName);
                                cuInfoMsgbox1.mostrarMensaje("Matricula guardada", Controles.Usuario.InfoMsgBox.tipoMsg.success);
                            }
                            else
                            {
                                if (res == -99)
                                {

                                    cuInfoMsgbox1.mostrarMensaje("Esta expedicion ya no está disponible", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                                }
                                else
                                {
                                    cuInfoMsgbox1.mostrarMensaje("Error guardando matricula", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                                }
                            }
                        }
                        else
                        {
                            cuInfoMsgbox1.mostrarMensaje("Las fechas no pueden ser anteriores al dia de hoy", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                        }
                    }

                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("No sé puede reservar una expedición mientras haya otra expedición pendiente de entregar", Controles.Usuario.InfoMsgBox.tipoMsg.error);


                    }
                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Debe indicar matrículas y transportista ", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
         
        }
        protected void cuInfoMsgbox1_RespuestaClicked (object sender, EventArgs e)
        {
         
            if (Session["Respuesta"].ToString()=="OK")
            {
                int res= laexpedicion.borrarmatriculaGESAG(Expedicionseleccionada.MSEmpresa, Expedicionseleccionada.MiNumExpedicion.ToString(),UsuarioPagina.UserName);
                if (res == 0)
                {
                    laexpedicion.borrarmatricula(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa);
                    laexpedicion.guardalog(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, Expedicionseleccionada.MsMatricula, Expedicionseleccionada.MiNumAgencia.ToString(), "Borrar matricula", UsuarioPagina.UserName);
                    Session["Respuesta"] = null;
                    cuInfoMsgbox1.mostrarMensaje("Matrícula borrada", Controles.Usuario.InfoMsgBox.tipoMsg.success);
                    rellenadatos();
                }
                else
                {
                    if (res == -99)
                    {
                        cuInfoMsgbox1.mostrarMensaje("Ya no se puede borrar la matrícula", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }
                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("Error Borrando la matrícula", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }
                }
            }
        }
            protected void btnBorrar_Click(object sender, EventArgs e)
        {
            cuInfoMsgbox1.mostrarMensaje("¿Está seguro de borrar la matricula?", Controles.Usuario.InfoMsgBox.tipoMsg.preguntar);
        }

        protected void CB_Transportistas_DataBinding(object sender, EventArgs e)
        {
            try {
                //CB_Transportistas.DataSource = lostransportistas.DameTransportistasGesag(Txt_sociedad.Text);
                CB_Transportistas.DataSource = DTLisTransportistas;
            CB_Transportistas.TextField = "MSNombre";
            CB_Transportistas.ValueField = "MiCodTransportista";
            }
            catch(Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error consultando Transportistas" + ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void BT_AñadirTrans_Click(object sender, EventArgs e)
        {
            string url = "..\\Logistica\\AltaTransportista.aspx?initCod=31";
            Session["Sociedad"]= Expedicionseleccionada.MSEmpresa;
            Pup_AddTransportista.ContentUrl = url;
            Pup_AddTransportista.ShowOnPageLoad = true;
        }

        protected void Txt_Fechaprevcarga_CalendarDayCellPrepared(object sender, DevExpress.Web.CalendarDayCellPreparedEventArgs e)
        {
            if (e.Date < DateTime.Today)
            {
                e.TextControl.Visible = false;
                e.Cell.Attributes["disabled"] = "disable";
                e.Cell.Attributes["style"] = "pointer-events:none";
            }
        }
    }
}