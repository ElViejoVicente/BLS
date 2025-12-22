using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System.Diagnostics;

namespace GPB.Web.Logistica
{
    public partial class DetalleExpedicion : PageBase
    {

        #region variblesPrivadas
        #region propiedades
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
        public List<Transportistas> DTLisTransportistas
        {
            get
            {
                List<Transportistas> dtagencias = new List<Transportistas>();

                if (Session["DTLisTransportistas"] != null)
                {

                    dtagencias = (List<Transportistas>)Session["DTLisTransportistas"];
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

        //public GPB.Negocio.Logistica.Expedicion Expedicionseleccionada
        //{
        //    get
        //    {
        //        GPB.Negocio.Logistica.Expedicion expedicionseleccionada = new Expedicion();
        //        if (this.ViewState["Expedicionseleccionada"] != null)
        //        {
        //            expedicionseleccionada = (GPB.Negocio.Logistica.Expedicion)this.ViewState["Expedicionseleccionada"];
        //        }


        //        return expedicionseleccionada;

        //    }
        //    set
        //    {
        //        this.ViewState["Expedicionseleccionada"] = value;
        //    }
        //}
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
        #endregion


       // DatosExpedicion_D laexpedicion = new DatosExpedicion_D();
        DatosExpedicion laexpedicion = new DatosExpedicion();

        //DatosSAP_D losdatossap = new DatosSAP_D();
        DatosSAP losdatossap = new DatosSAP();
        DatosTransportistas lostransportistas = new DatosTransportistas();
       // DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["actualizatrans"] != null)
            {
                CB_Transportistas.DataBind();
            }
                if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                lblNombrePagina.Text = "Detalle de expedición y asignación de matricula.";
                rellenadatos();

            }
        }

        private void rellenadatos()
        { 
            Txt_expedicion.Text = Expedicionseleccionada.MiNumExpedicion.ToString();
            Txt_destino.Text = Expedicionseleccionada.MsDestino;
            Txt_origen.Text = Expedicionseleccionada.MsOrigen;
            Txt_sociedad.Text = Expedicionseleccionada.MsNombreEmpresa;
            Txt_Pesoteorico.Text = Expedicionseleccionada.MdPesoteorico.ToString();
            txt_matricula.Text = Expedicionseleccionada.MsMatricula;
            Observaciones.Text = Expedicionseleccionada.MsObservacionesCom.ToString();
            txt_matricularemolque.Text = Expedicionseleccionada.MsMatriculaRemolque;
            Txt_CentroCarga.Text = Expedicionseleccionada.MsCentroCarga;
            Txt_UnidadTransporte.Text = Expedicionseleccionada.MsUnidadTransporte;
            CB_Urgente.Checked = Expedicionseleccionada.MsUrgente == "X" ? true : false;
            ObservacionesLog.Text = Expedicionseleccionada.MsObservacionesLog;
            
            CB_Transportistas.DataBind();
            CB_Transportistas.Text = Expedicionseleccionada.MsTransportista;
            if (Expedicionseleccionada.MdFechaCargaPrevista != Convert.ToDateTime("01/01/1900"))
            {
                Txt_Fechaprevcarga.Date = Expedicionseleccionada.MdFechaCargaPrevista;
            }
            if (Expedicionseleccionada.MdFechaDescargaPrevista != Convert.ToDateTime("01/01/1900"))
            {
                Txt_Fechaprevdescarga.Date = Expedicionseleccionada.MdFechaDescargaPrevista;
            }
            
            Txt_numpermisoespecial.Text = Expedicionseleccionada.MsNumeroAutorizacion;
            if (AccionSeleccionada==1)
            {
                lblCapturar.Visible = true;
                if (txt_matricula.Text!="" && UsuarioPagina.CodProveedor!=0)
                {
                    Txt_Fechaprevcarga.Enabled = false;
                    Txt_Fechaprevdescarga.Enabled = false;
                }
            }
            else if (AccionSeleccionada == 2)
            {
                lblCapturar.Visible = false;
                //CB_Transportistas.Text = Expedicionseleccionada.MsTransportista;
                //txt_matricula.Text = Expedicionseleccionada.MsMatricula;
                //Txt_Fechaprevcarga.Date = Expedicionseleccionada.MdFechaCargaPrevista;
                //Txt_Fechaprevdescarga.Date = Expedicionseleccionada.MdFechaDescargaPrevista;
                //Txt_numpermisoespecial.Text = Expedicionseleccionada.MsNumeroAutorizacion;
                CB_Transportistas.Enabled = false;
                txt_matricula.Enabled = false;
                txt_matricularemolque.Enabled = false;
                CB_Urgente.Enabled = false;
                Txt_Fechaprevcarga.Enabled = false;
                Txt_Fechaprevdescarga.Enabled = false;
                Frm_Asignacion.FindItemOrGroupByName("AddTrans").Visible = false;
                btnGuardar.Text = "Regresar";
                btnCancel.Visible = false;
            }
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
            }else if (AccionSeleccionada == 2)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarAsignacion(); ", true);
            } 
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string numpermiso = Txt_numpermisoespecial.Text.Replace(".", "").Replace(",", "").Replace("/", "-").Replace("(", "-").Replace(")", "-").Replace("|", "").Replace("&", "").Replace("·", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("$", "").Replace("'", "").Replace("!", "").Replace("¡", "").Replace("^", "");
            if (AccionSeleccionada == 1)
            {
                if (CB_Transportistas.SelectedIndex != -1 && txt_matricula.Text!= "")
                {
                    int res = laexpedicion.guardamatriculaGESAG(sociedad: Expedicionseleccionada.MSEmpresa,
                                                      expedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                      idagencia: UsuarioPagina.CodProveedor.ToString(),
                                                      idtransportista: CB_Transportistas.SelectedItem.Value.ToString(),
                                                      matricula: txt_matricula.Text,
                                                      matricularemolque: txt_matricularemolque.Text,
                                                      fechaestentrega: Txt_Fechaprevdescarga.Date.ToString("yyyy-MM-dd"),
                                                      fechaestrecogida: Txt_Fechaprevcarga.Date.ToString("yyyy-MM-dd"),
                                                      numauto: numpermiso,
                                                      usuario:UsuarioPagina.UserName);
                    if (res == 0)
                    {
                        laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                 numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                 empresa: Expedicionseleccionada.MSEmpresa,
                                                 estadoBloqueo: 3,
                                                 transportista: CB_Transportistas.Text,
                                                 matricula: txt_matricula.Text,
                                                 fechaCargaPrev: Txt_Fechaprevcarga.Text,
                                                 fechaDescPrev: Txt_Fechaprevdescarga.Text,
                                                 matricularemolque: txt_matricularemolque.Text,
                                                 idagencia: UsuarioPagina.CodProveedor,
                                                 nombreagencia: UsuarioPagina.NombreAgencia,
                                                  numautorizacion: numpermiso);
                        laexpedicion.guardalog(Expedicionseleccionada.MiNumExpedicion.ToString(), Expedicionseleccionada.MSEmpresa, txt_matricula.Text, UsuarioPagina.CodProveedor.ToString(), "guarda matricula", UsuarioPagina.UserName);
                        cuInfoMsgboxMovil.mostrarMensaje("Expedición y Matricula guardada", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.success);
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarAsignacion(); ", true);
                    }
                    else
                    {
                        if (res == -99)
                        {

                            cuInfoMsgboxMovil.mostrarMensaje("Esta expedición ya no está disponible", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
                        }
                        else
                        {
                            cuInfoMsgboxMovil.mostrarMensaje("Error guardando matricula", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
                        }
                    }
                }
                else
                {
                    cuInfoMsgboxMovil.mostrarMensaje("Debe indicar matrícula y agencia", Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
                }
            }
            else if (AccionSeleccionada == 2)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarAsignacion(); ", true);
            }

           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            laexpedicion.bloqueaExpedicion(idExpedicion: Expedicionseleccionada.MiIdExpedicion,
                                                  numnexpedicion: Expedicionseleccionada.MiNumExpedicion.ToString(),
                                                  empresa: Expedicionseleccionada.MSEmpresa,
                                                  estadoBloqueo: 1,
                                                  transportista: "",
                                                  matricula: "",
                                                  fechaCargaPrev:"",
                                                  fechaDescPrev:"",
                                                  matricularemolque:"",
                                                  idagencia:0,
                                                  nombreagencia:"",
                                                   numautorizacion:""
                                                );
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "regresarAsignacion(); ", true);
        }


        protected void txt_matricula_TextChanged1(object sender, EventArgs e)
        {
            txt_matricula.Text = txt_matricula.Text.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("|", "").Replace("&", "").Replace("·", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("$", "").Replace("'", "").Replace("!", "").Replace("¡", "").Replace("^", "");
            try
            {
                if (txt_matricula.Text != "")
                {
                    List<Negocio.WS_GESAG.DatosMatriculas> listadoagencias;
                    //List<Negocio.WS_GESAG_DES.DatosMatriculas> listadoagencias;
                    listadoagencias = laexpedicion.Dameagenciapormatricula(Txt_sociedad.Text, txt_matricula.Text);

                    if (listadoagencias.Count() == 1)
                    {
                        txt_matricularemolque.Text = listadoagencias[0].MatRemolque;
                        CB_Transportistas.Text = listadoagencias[0].TransportistaNom;
                    }
                }
            }catch (Exception)
            {

                throw;
            }
        }

       

        protected void CB_Transportistas_DataBinding(object sender, EventArgs e)
        {
            try
            {
                //CB_Transportistas.DataSource = lostransportistas.DameTransportistasGesag(Txt_sociedad.Text);
                CB_Transportistas.DataSource = DTLisTransportistas;
                CB_Transportistas.TextField = "MSNombre";
                CB_Transportistas.ValueField = "MiCodTransportista";
            }
            catch (Exception ex)
            {
                cuInfoMsgboxMovil.mostrarMensaje("Error consultando Transportistas" + ex.Message, Controles.Usuario.InfoMsgBoxMovil.tipoMsg.error);
            }
        }

        protected void BT_AñadirTrans_Click(object sender, EventArgs e)
        {
            Session["Sociedad"] = Txt_sociedad.Text;
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "AltaTransportista(); ", true);
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

        protected void Txt_Fechaprevdescarga_CalendarDayCellPrepared(object sender, DevExpress.Web.CalendarDayCellPreparedEventArgs e)
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