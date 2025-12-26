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

namespace BLS.Web.ExpedientesTramites
{
    public partial class HojaDeDatos : PageBase
    {

        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();
        DatosExpedientes datosExpediente = new DatosExpedientes();


        public List<Cat_DocumentosPorActo> catDocumentoOtorgaSolicita
        {
            get

            {
                List<Cat_DocumentosPorActo> sseCatDocumentoOtorgaSolicita = new List<Cat_DocumentosPorActo>();
                if (this.Session["sseCatDocumentoOtorgaSolicita"] != null)
                {
                    sseCatDocumentoOtorgaSolicita = (List<Cat_DocumentosPorActo>)this.Session["sseCatDocumentoOtorgaSolicita"];
                }

                return sseCatDocumentoOtorgaSolicita;
            }
            set
            {
                this.Session["sseCatDocumentoOtorgaSolicita"] = value;
            }

        }

        public List<Cat_DocumentosPorActo> catDocumentoAfavorDe
        {
            get

            {
                List<Cat_DocumentosPorActo> sseCatDocumentoAfavorDe = new List<Cat_DocumentosPorActo>();
                if (this.Session["sseCatDocumentoAfavorDe"] != null)
                {
                    sseCatDocumentoAfavorDe = (List<Cat_DocumentosPorActo>)this.Session["sseCatDocumentoAfavorDe"];
                }

                return sseCatDocumentoAfavorDe;
            }
            set
            {
                this.Session["sseCatDocumentoAfavorDe"] = value;
            }

        }

        public List<Cat_Actos> catActos
        {
            get

            {
                List<Cat_Actos> sseCatActos = new List<Cat_Actos>();
                if (this.Session["sseCatActos"] != null)
                {
                    sseCatActos = (List<Cat_Actos>)this.Session["sseCatActos"];
                }

                return sseCatActos;
            }
            set
            {
                this.Session["sseCatActos"] = value;
            }

        }

        public List<Cat_VariantesPorActo> catVarientesPorActo
        {
            get

            {
                List<Cat_VariantesPorActo> ssecatVarientesPorActo = new List<Cat_VariantesPorActo>();
                if (this.Session["ssecatVarientesPorActo"] != null)
                {
                    ssecatVarientesPorActo = (List<Cat_VariantesPorActo>)this.Session["ssecatVarientesPorActo"];
                }

                return ssecatVarientesPorActo;
            }
            set
            {
                this.Session["ssecatVarientesPorActo"] = value;
            }

        }

        public List<Cat_RolParticipantes> catRolParticipantesOtorgaSolicita
        {
            get

            {
                List<Cat_RolParticipantes> ssecaRolParticipantesOS = new List<Cat_RolParticipantes>();
                if (this.Session["ssecaRolParticipantesOS"] != null)
                {
                    ssecaRolParticipantesOS = (List<Cat_RolParticipantes>)this.Session["ssecaRolParticipantesOS"];
                }

                return ssecaRolParticipantesOS;
            }
            set
            {
                this.Session["ssecaRolParticipantesOS"] = value;
            }

        }

        public List<Cat_RolParticipantes> catRolParticipantesAfavorDe
        {
            get

            {
                List<Cat_RolParticipantes> ssecatRolParticipantesAfavorDeOS = new List<Cat_RolParticipantes>();
                if (this.Session["ssecatRolParticipantesAfavorDeOS"] != null)
                {
                    ssecatRolParticipantesAfavorDeOS = (List<Cat_RolParticipantes>)this.Session["ssecatRolParticipantesAfavorDeOS"];
                }

                return ssecatRolParticipantesAfavorDeOS;
            }
            set
            {
                this.Session["ssecatRolParticipantesAfavorDeOS"] = value;
            }

        }


        public List<DatosParticipantes> lsOtorgaSolicitante
        {
            get

            {
                List<DatosParticipantes> sselsOtorgaOsolicitante = new List<DatosParticipantes>();
                if (this.Session["sselsOtorgaOsolicitante"] != null)
                {
                    sselsOtorgaOsolicitante = (List<DatosParticipantes>)this.Session["sselsOtorgaOsolicitante"];
                }

                return sselsOtorgaOsolicitante;
            }
            set
            {
                this.Session["sselsOtorgaOsolicitante"] = value;
            }

        }

        public List<DatosParticipantes> lsAfavorDE
        {
            get

            {
                List<DatosParticipantes> sselsAfavorDE = new List<DatosParticipantes>();
                if (this.Session["sselsAfavorDE"] != null)
                {
                    sselsAfavorDE = (List<DatosParticipantes>)this.Session["sselsAfavorDE"];
                }

                return sselsAfavorDE;
            }
            set
            {
                this.Session["sselsAfavorDE"] = value;
            }

        }

        public string OtorgaSolicitanteSeleccion
        {
            get

            {
                string ssOtorgaSolicitanteSeleccion = "";
                if (this.Session["ssOtorgaSolicitanteSeleccion"] != null)
                {
                    ssOtorgaSolicitanteSeleccion = Session["ssOtorgaSolicitanteSeleccion"].ToString();
                }

                return ssOtorgaSolicitanteSeleccion;
            }
            set
            {
                this.Session["ssOtorgaSolicitanteSeleccion"] = value;
            }

        }

        public string AfavorDESeleccion
        {
            get

            {
                string ssAfavorDESeleccion = "";
                if (this.Session["ssAfavorDESeleccion"] != null)
                {
                    ssAfavorDESeleccion = Session["ssAfavorDESeleccion"].ToString();
                }

                return ssAfavorDESeleccion;
            }
            set
            {
                this.Session["ssAfavorDESeleccion"] = value;
            }

        }

        public object[] docSelecOtorgaSol
        {
            get

            {
                object[] ssdocSelecOtorgaSol = null;
                if (this.Session["ssdocSelecOtorgaSol"] != null)
                {
                    ssdocSelecOtorgaSol = (object[])Session["ssdocSelecOtorgaSol"];
                }

                return ssdocSelecOtorgaSol;
            }
            set
            {
                this.Session["ssdocSelecOtorgaSol"] = value;
            }

        }


        public object[] docAfavorDe
        {
            get

            {
                object[] ssdocAfavorDe = null;
                if (this.Session["ssdocAfavorDe"] != null)
                {
                    ssdocAfavorDe = (object[])Session["ssdocAfavorDe"];
                }

                return ssdocAfavorDe;
            }
            set
            {
                this.Session["ssdocAfavorDe"] = value;
            }

        }



        public List<ListaHojaDatos> lsHojaDatos
        {
            get

            {
                List<ListaHojaDatos> sselsHojaDatos = new List<ListaHojaDatos>();
                if (this.Session["sselsHojaDatos"] != null)
                {
                    sselsHojaDatos = (List<ListaHojaDatos>)this.Session["sselsHojaDatos"];
                }

                return sselsHojaDatos;
            }
            set
            {
                this.Session["sselsHojaDatos"] = value;
            }

        }

        public Boolean EsNuevaHojaDatos
        {
            get

            {
                Boolean ssEsNuevaHojaDatos = false;
                if (this.Session["ssEsNuevaHojaDatos"] != null)
                {
                    ssEsNuevaHojaDatos = (Boolean)Session["ssEsNuevaHojaDatos"];
                }

                return ssEsNuevaHojaDatos;
            }
            set
            {
                this.Session["ssEsNuevaHojaDatos"] = value;
            }

        }


        public HojaDatos hojaDatosSeleccionada
        {
            get

            {
                HojaDatos sshojaDatosSeleccionada = null;
                if (this.Session["sshojaDatosSeleccionada"] != null)
                {
                    sshojaDatosSeleccionada = (HojaDatos)Session["sshojaDatosSeleccionada"];
                }

                return sshojaDatosSeleccionada;
            }
            set
            {
                this.Session["sshojaDatosSeleccionada"] = value;
            }

        }

        public DatosVariantes varienteSeleccionada
        {
            get

            {
                DatosVariantes ssvarienteSeleccionada = null;
                if (this.Session["ssvarienteSeleccionada"] != null)
                {
                    ssvarienteSeleccionada = (DatosVariantes)Session["ssvarienteSeleccionada"];
                }

                return ssvarienteSeleccionada;
            }
            set
            {
                this.Session["ssvarienteSeleccionada"] = value;
            }

        }


        public Expedientes ExpedienteSeleccionado
        {
            get

            {
                Expedientes ssExpedienteSeleccionado = null;
                if (this.Session["ssExpedienteSeleccionado"] != null)
                {
                    ssExpedienteSeleccionado = (Expedientes)Session["ssExpedienteSeleccionado"];
                }

                return ssExpedienteSeleccionado;
            }
            set
            {
                this.Session["ssExpedienteSeleccionado"] = value;
            }

        }

        #endregion


        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                HidDocumentoSelect.Add("OtorgaSolicita", "");
                HidDocumentoSelect.Add("AfavorDe", "");

                dtFechaInicio.Date = DateTime.Now.Date.AddDays(-30);
                dtFechaFin.Date = DateTime.Now.Date;

                dtFechaIngreso.Date = DateTime.Now;
                txtNombreAsesor.Text = UsuarioPagina.usNombre;
                DameCatalogos();

            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            // cbVarienteNuevo.DataBind();
            //  lbDocumentacionOtorgaSolicita.DataBind();
            // lbDocumentacionAfavorDe.DataBind();
        }




        protected void gvHojaDatos_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsHojaDatos;
        }

        protected void gvHojaDatos_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "CargarRegistros")
            {
                lsHojaDatos = datosExpediente.DameListaHojaDatos(fechaInicial: dtFechaInicio.Date, fechaFinal: dtFechaFin.Date, todasLasFechas: chkBusquedaCompleta.Checked).OrderByDescending(x => x.FechaIngreso).ToList();// cargamos registros
                gvHojaDatos.DataBind();
                return;
            }
        }

        protected void gvHojaDatos_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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



        protected void ppEditarHojaDatos_WindowCallback1(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {

        }

        protected void ppNuevaHojaDatos_WindowCallback1(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            if (e.Parameter == "NuevaHojaDatos")
            {
                EsNuevaHojaDatos = true;

                lsOtorgaSolicitante = new List<DatosParticipantes>();
                lsAfavorDE = new List<DatosParticipantes>();
                OtorgaSolicitanteSeleccion = "";
                AfavorDESeleccion = "";
                gvOtorgaSolicita.DataBind();
                gvaFavorDe.DataBind();
                cbActosNuevo.SelectedIndex = -1;
                cbVarienteNuevo.SelectedIndex = -1;
                txtReciboPagoIni.Text = "";
                txtClienteTramita.Text = "";
                txtNumCelular.Text = "";
                txtCorreoElectronico.Text = "";
                return;
            }


            if (e.Parameter.Contains("EditarHojaDatos"))
            {

                EsNuevaHojaDatos = false;

                // limpieza
                catDocumentoOtorgaSolicita = new List<Cat_DocumentosPorActo>();
                catDocumentoAfavorDe = new List<Cat_DocumentosPorActo>();
                lsOtorgaSolicitante = new List<DatosParticipantes>();

                hojaDatosSeleccionada = null;
                varienteSeleccionada = null;
                ExpedienteSeleccionado = null;


                docSelecOtorgaSol = null;
                docAfavorDe = null;


                lsAfavorDE = new List<DatosParticipantes>();
                OtorgaSolicitanteSeleccion = "";
                AfavorDESeleccion = "";
                gvOtorgaSolicita.DataBind();
                gvaFavorDe.DataBind();


                int idHojaDatosSelect = Convert.ToInt32(e.Parameter.Split('~')[1].ToString());

                //buscamos el registro en el listado  lsHojaDatos

                ListaHojaDatos hojaSeleccionada = lsHojaDatos.Where(x => x.IdHojaDatos == idHojaDatosSelect).FirstOrDefault();

                if (hojaSeleccionada != null)
                {

                    hojaDatosSeleccionada = hojaSeleccionada.DetalleHojaDatos;
                    varienteSeleccionada = hojaSeleccionada.DetalleVariante;
                    ExpedienteSeleccionado = hojaSeleccionada.DetalleExpediente;

                    // empezamos a cargar los registros  en el control

                    // Cargamos los datos generales
                    dtFechaIngreso.Date = hojaSeleccionada.FechaIngreso;
                    if (hojaSeleccionada.DetalleRecibosPago.Exists(x => x.Concepto == "Recibo Inicial Expediente"))
                    {
                        txtReciboPagoIni.Text = hojaSeleccionada.DetalleRecibosPago.Where(x => x.Concepto == "Recibo Inicial Expediente").First().NumRecibo;
                    }

                    txtClienteTramita.Text = hojaSeleccionada.NumbreUsuarioTramita;
                    txtNumCelular.Text = hojaSeleccionada.NumTelCelular1;
                    txtCorreoElectronico.Text = hojaSeleccionada.CorreoElectronico;





                    // se carga el acto selccionado
                    cbActosNuevo.Text = hojaSeleccionada.TextoActo;
                    cbActosNuevo.SelectedIndex = catActos.FindIndex(w => w.TextoActo == hojaSeleccionada.TextoActo);

                    catVarientesPorActo = catVarientesPorActo = datosCrud.ConsultaCatVariantesPorActo().Where(x=> x.Activo==true).ToList();


                    // se carga la variante seleccionada
                    if (catVarientesPorActo.Count > 0)
                    {
                        catVarientesPorActo = catVarientesPorActo.Where(x => x.IdActo.ToString() == cbActosNuevo.Value.ToString()).ToList();
                        cbVarienteNuevo.DataBind();
                    }

                    cbVarienteNuevo.Text = hojaSeleccionada.TextoVariante;
                    cbVarienteNuevo.SelectedIndex = catVarientesPorActo.FindIndex(w => w.TextoVariante == hojaSeleccionada.TextoVariante);


                    // se cargan los tipos de roles por acto

                    catRolParticipantesOtorgaSolicita = datosCrud.ConsultaCatRolParticipantes();
                    catRolParticipantesAfavorDe = datosCrud.ConsultaCatRolParticipantes();

                    if (catRolParticipantesOtorgaSolicita.Count > 0)
                    {
                        catRolParticipantesOtorgaSolicita = catRolParticipantesOtorgaSolicita.Where(x => x.IdActo.ToString() == cbActosNuevo.Value.ToString() && x.TextoFigura == "Otorga o Solicita").ToList();
                    }


                    if (catRolParticipantesAfavorDe.Count > 0)
                    {
                        catRolParticipantesAfavorDe = catRolParticipantesAfavorDe.Where(x => x.IdActo.ToString() == cbActosNuevo.Value.ToString() && x.TextoFigura == "A favor de").ToList();
                    }

                    //se cargam los tipos de documentos por variante

                    catDocumentoOtorgaSolicita = datosCrud.ConsultaCatDocumentosPorActo();
                    catDocumentoAfavorDe = datosCrud.ConsultaCatDocumentosPorActo();


                    if (cbActosNuevo.Value.ToString() != null && catDocumentoOtorgaSolicita.Count > 0)
                    {
                        catDocumentoOtorgaSolicita = catDocumentoOtorgaSolicita.Where(x => x.IdActo.ToString() == cbActosNuevo.Value.ToString() &
                                                                                      x.IdVariente.ToString() == cbVarienteNuevo.Value.ToString() &
                                                                                      x.TextoFigura == "Otorga o Solicita").ToList();
                    }

                    if (cbActosNuevo.Value.ToString() != null && catDocumentoAfavorDe.Count > 0)
                    {
                        catDocumentoAfavorDe = catDocumentoAfavorDe.Where(x => x.IdActo.ToString() == cbActosNuevo.Value.ToString() &
                                                                          x.IdVariente.ToString() == cbVarienteNuevo.Value.ToString() &
                                                                          x.TextoFigura == "A favor de").ToList();
                    }


                    lbDocumentacionOtorgaSolicita.DataBind();
                    lbDocumentacionAfavorDe.DataBind();

                    //HidDocumentoSelect["AfavorDe"] = "";
                    //HidDocumentoSelect["OtorgaSolicita"] = "";

                    //string docSelecOtorgaSol = "";
                    //string docAfavorDe = "";

                    //HidDocumentoSelect.Set("AfavorDe", "");
                    //HidDocumentoSelect.Set("OtorgaSolicita", "");

                    docAfavorDe = new object[hojaSeleccionada.DetalleDocumentosAfavorDe.Count];
                    int contador = 0;

                    foreach (var doc in hojaSeleccionada.DetalleDocumentosAfavorDe)
                    {
                      
                        if (lbDocumentacionAfavorDe.Items.FindByText(doc.TextoDocumento)!=null)
                        {
                            lbDocumentacionAfavorDe.Items.FindByText(doc.TextoDocumento).Selected = true;
                        }
                        docAfavorDe[contador] = doc.IdDoc;
                        contador++;
                    }

                    //if (docAfavorDe.Length>1)
                    //{
                    //    docAfavorDe = docAfavorDe.Substring(0, docAfavorDe.ToString().Length - 1);
                    //}

                    docSelecOtorgaSol = new object[hojaSeleccionada.DetalleDocumentosOtorgSolicita.Count];
                    contador = 0;
                    foreach (var doc in hojaSeleccionada.DetalleDocumentosOtorgSolicita)
                    {
                       // lbDocumentacionOtorgaSolicita.Items.FindByText(doc.TextoDocumento).Selected = true;

                        if (lbDocumentacionOtorgaSolicita.Items.FindByText(doc.TextoDocumento)!= null)
                        {
                            lbDocumentacionOtorgaSolicita.Items.FindByText(doc.TextoDocumento).Selected = true;
                        }


                        //docSelecOtorgaSol = docSelecOtorgaSol + doc.IdDoc.ToString() + ",";
                        docSelecOtorgaSol[contador] = doc.IdDoc;
                        contador++;
                    }
                    //if (docSelecOtorgaSol.Length>1)
                    //{
                    //    docSelecOtorgaSol = docSelecOtorgaSol.Substring(0, docSelecOtorgaSol.ToString().Length - 1);
                    //}

                    HidDocumentoSelect.Set("AfavorDe", docAfavorDe);
                    HidDocumentoSelect.Set("OtorgaSolicita", docSelecOtorgaSol);




                    //cargamos los datos de las personas involucradas 

                    lsOtorgaSolicitante = hojaSeleccionada.DetalleParticipantes.Where(x => x.FiguraOperacion == "Otorga o Solicita").ToList();
                    lsAfavorDE = hojaSeleccionada.DetalleParticipantes.Where(x => x.FiguraOperacion == "A favor de").ToList();

                    gvaFavorDe.DataBind();
                    gvOtorgaSolicita.DataBind();


                }


                return;
            }


            if (e.Parameter.Contains("CargarDocXvariantes"))
            {
                string idVariante = e.Parameter.Split('~')[1].ToString();
                var idActo = cbActosNuevo.Value;


                catDocumentoOtorgaSolicita = datosCrud.ConsultaCatDocumentosPorActo().Where(x=> x.Activo==true).ToList();

                catDocumentoAfavorDe = datosCrud.ConsultaCatDocumentosPorActo().Where(x => x.Activo == true).ToList();


                if (idActo != null && catDocumentoOtorgaSolicita.Count > 0)
                {
                    catDocumentoOtorgaSolicita = catDocumentoOtorgaSolicita.Where(x => x.IdActo.ToString() == idActo.ToString() &
                                                                                  x.IdVariente.ToString() == idVariante.ToString() &
                                                                                  x.TextoFigura == "Otorga o Solicita").ToList();
                }

                if (idActo != null && catDocumentoAfavorDe.Count > 0)
                {
                    catDocumentoAfavorDe = catDocumentoAfavorDe.Where(x => x.IdActo.ToString() == idActo.ToString() &
                                                                      x.IdVariente.ToString() == idVariante.ToString() &
                                                                      x.TextoFigura == "A favor de").ToList();
                }



                lbDocumentacionOtorgaSolicita.DataBind();
                lbDocumentacionAfavorDe.DataBind();



                return;

            }

            if (e.Parameter.Contains("CargarVariantes"))
            {
                string idActo = e.Parameter.Split('~')[1].ToString();


                catDocumentoOtorgaSolicita = new List<Cat_DocumentosPorActo>();
                catDocumentoAfavorDe = new List<Cat_DocumentosPorActo>();

                lbDocumentacionOtorgaSolicita.DataBind();
                lbDocumentacionAfavorDe.DataBind();

                catVarientesPorActo = catVarientesPorActo = datosCrud.ConsultaCatVariantesPorActo().Where(x => x.Activo == true).ToList(); 

                catRolParticipantesOtorgaSolicita = datosCrud.ConsultaCatRolParticipantes().Where(x => x.Activo == true).ToList(); 

                catRolParticipantesAfavorDe = datosCrud.ConsultaCatRolParticipantes().Where(x => x.Activo == true).ToList(); 





                if (catVarientesPorActo.Count > 0)
                {
                    catVarientesPorActo = catVarientesPorActo.Where(x => x.IdActo.ToString() == idActo).ToList();
                }

                if (catRolParticipantesOtorgaSolicita.Count > 0)
                {
                    catRolParticipantesOtorgaSolicita = catRolParticipantesOtorgaSolicita.Where(x => x.IdActo.ToString() == idActo && x.TextoFigura == "Otorga o Solicita").ToList();
                }


                if (catRolParticipantesAfavorDe.Count > 0)
                {
                    catRolParticipantesAfavorDe = catRolParticipantesAfavorDe.Where(x => x.IdActo.ToString() == idActo && x.TextoFigura == "A favor de").ToList();
                }


                cbVarienteNuevo.SelectedIndex = -1;
                cbVarienteNuevo.DataBind();



                return;
            }

            if (e.Parameter.Contains("guardar"))
            {

                if (EsNuevaHojaDatos)
                {
                    GuardaNuevoHojaDatos();
                }
                else
                {
                    ModificarHojaDatos();
                }

                return;
            }


        }


        private void ModificarHojaDatos()
        {
            Boolean existeError = false;


            DatosDocumentos nuevahojaDocumentos = new DatosDocumentos();
            RecibosDePago nuevaHojaReciboPago = new RecibosDePago();


            hojaDatosSeleccionada.NombreAsesor = txtNombreAsesor.Text;
            hojaDatosSeleccionada.NumbreUsuarioTramita = txtClienteTramita.Text;
            hojaDatosSeleccionada.NumTelCelular1 = txtNumCelular.Text;
            hojaDatosSeleccionada.CorreoElectronico = txtCorreoElectronico.Text;

            if (datosCrud.ActualizarHojaDatos(hojaDatosSeleccionada))
            {

                //modificamos los datos de la variantes varienteSeleccionada
                if (!datosCrud.ActualizarDatosVariantes(varienteSeleccionada))
                {
                    existeError = true;
                }

                //borramos los datos relacionados a esa hoja de datos en la base para insertarlos los nuevos valores

                // borrarParticipantes
                //borrarDocumentos
                //borrarReciboPago inicial



                if (datosExpediente.BorraDatosParticipantesDocumentos(hojaDatosSeleccionada.IdHojaDatos))
                {

                }

                // guardamos a los participantes del acto
                foreach (var item in lsOtorgaSolicitante)
                {
                    item.IdHojaDatos = hojaDatosSeleccionada.IdHojaDatos;

                    if (!datosCrud.AltaDatosParticipantes(item))
                    {
                        existeError = true;
                    }
                }

                foreach (var item in lsAfavorDE)
                {
                    item.IdHojaDatos = hojaDatosSeleccionada.IdHojaDatos;

                    if (!datosCrud.AltaDatosParticipantes(item))
                    {
                        existeError = true;
                    }
                }

                // se rellenan  la lista de documento para proceder al guardado

                if (HidDocumentoSelect["OtorgaSolicita"].ToString() == "")
                {
                    HidDocumentoSelect.Set("OtorgaSolicita", docSelecOtorgaSol);

                }



                if (HidDocumentoSelect["AfavorDe"].ToString() == "")
                {
                    HidDocumentoSelect.Set("AfavorDe", docAfavorDe);
                }





                object itemsOS = HidDocumentoSelect["OtorgaSolicita"];

                if (itemsOS.ToString() != "")
                {
                    foreach (var item in (Object[])itemsOS)
                    {
                        nuevahojaDocumentos = new DatosDocumentos();
                        nuevahojaDocumentos.IdHojaDatos = hojaDatosSeleccionada.IdHojaDatos;
                        nuevahojaDocumentos.IdVariente = varienteSeleccionada.IdVariante;
                        nuevahojaDocumentos.TextoVariante = varienteSeleccionada.TextoVariante;
                        nuevahojaDocumentos.TextoFigura = "Otorga o Solicita";
                        nuevahojaDocumentos.IdDoc = Convert.ToInt32(item);
                        nuevahojaDocumentos.Observaciones = "";

                        datosCrud.AltaDatosDocumentos(nuevahojaDocumentos);

                    }
                }

                object itemsFv = HidDocumentoSelect["AfavorDe"];
                if (itemsFv.ToString() != "")
                {
                    foreach (var item in (Object[])itemsFv)
                    {
                        nuevahojaDocumentos = new DatosDocumentos();
                        nuevahojaDocumentos.IdHojaDatos = hojaDatosSeleccionada.IdHojaDatos;
                        nuevahojaDocumentos.IdVariente = varienteSeleccionada.IdVariante;
                        nuevahojaDocumentos.TextoVariante = varienteSeleccionada.TextoVariante;
                        nuevahojaDocumentos.TextoFigura = "A favor de";
                        nuevahojaDocumentos.IdDoc = Convert.ToInt32(item);
                        nuevahojaDocumentos.Observaciones = "";

                        datosCrud.AltaDatosDocumentos(nuevahojaDocumentos);
                    }
                }



                // se registra el primer recibo de pago

                nuevaHojaReciboPago.IdHojaDatos = hojaDatosSeleccionada.IdHojaDatos;
                nuevaHojaReciboPago.NumRecibo = txtReciboPagoIni.Text;
                nuevaHojaReciboPago.CantidadTotal = 0;
                nuevaHojaReciboPago.CantidadAbonada = 0;
                nuevaHojaReciboPago.Concepto = "Recibo Inicial Expediente";
                nuevaHojaReciboPago.UsuarioRecibe = "No Definido";
                nuevaHojaReciboPago.NotaComentario = "Recibo no controlado por sistema.";

                if (!datosCrud.AltaRecibosDePago(nuevaHojaReciboPago))
                {
                    existeError = true;
                }


                //se actuliza los datos del expediente

                ExpedienteSeleccionado.Otorga = "";
                foreach (var item in lsOtorgaSolicitante)
                {
                    ExpedienteSeleccionado.Otorga += item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + " / ";
                }
                ExpedienteSeleccionado.AfavorDe = "";
                foreach (var item in lsAfavorDE)
                {
                    ExpedienteSeleccionado.AfavorDe += item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + " / ";
                }


                if (!datosCrud.ActualizarExpediente(ExpedienteSeleccionado))
                {
                    existeError = true;
                }


            }



            if (!existeError)
            {


                ppNuevaHojaDatos.JSProperties["cp_swMsg"] = "Datos del expediente: " + hojaDatosSeleccionada.numExpediente + " Actualizados.!";
                ppNuevaHojaDatos.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
                return;
            }
            else
            {
                ppNuevaHojaDatos.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar modificat el registro.";
                ppNuevaHojaDatos.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;
                return;
            }


        }


        private void GuardaNuevoHojaDatos()
        {
            Boolean existeError = false;

            // guardamos en base de datos la HojaDatos ,  DatosParticipantes , DatosDocumentos
            // ademas se crea el numero de expediente en la tabla  Expedientes con los datos del solicitante y ortorgante 
            // tambien hay que crear la ruta de carpeta

            // 1- se guarda la hoja de datos

            HojaDatos nuevaHoja = new HojaDatos();
            DatosVariantes nuevaHojaComplemento = new DatosVariantes();
            DatosDocumentos nuevahojaDocumentos = new DatosDocumentos();
            RecibosDePago nuevaHojaReciboPago = new RecibosDePago();
            Expedientes nuevoExpediente = new Expedientes();

            nuevaHoja.IdHojaDatos = 0;
            nuevaHoja.FechaIngreso = dtFechaIngreso.Date;
            nuevaHoja.NombreAsesor = txtNombreAsesor.Text;
            nuevaHoja.NumbreUsuarioTramita = txtClienteTramita.Text;
            nuevaHoja.NumTelCelular1 = txtNumCelular.Text;
            nuevaHoja.CorreoElectronico = txtCorreoElectronico.Text;

            if (datosCrud.AltaHojaDatos(ref nuevaHoja,UsuarioPagina.usCodigo))
            {
                nuevaHojaComplemento.IdHojaDatos = nuevaHoja.IdHojaDatos;
                nuevaHojaComplemento.IdActo = cbActosNuevo.Value == null ? 0 : Convert.ToInt32(cbActosNuevo.Value);
                nuevaHojaComplemento.IdVariante = cbVarienteNuevo.Value == null ? 0 : Convert.ToInt32(cbVarienteNuevo.Value);
                nuevaHojaComplemento.TextoActo = cbActosNuevo.Text == null ? "" : cbActosNuevo.Text;
                nuevaHojaComplemento.TextoVariante = cbVarienteNuevo.Text == null ? "" : cbVarienteNuevo.Text;
                // se guardan los datos extras de al hoja 

                if (!datosCrud.AltaDatosVariantes(nuevaHojaComplemento))
                {
                    existeError = true;
                }


                // guardamos a los participantes del acto
                foreach (var item in lsOtorgaSolicitante)
                {
                    item.IdHojaDatos = nuevaHoja.IdHojaDatos;

                    if (!datosCrud.AltaDatosParticipantes(item))
                    {
                        existeError = true;
                    }
                }

                foreach (var item in lsAfavorDE)
                {
                    item.IdHojaDatos = nuevaHoja.IdHojaDatos;

                    if (!datosCrud.AltaDatosParticipantes(item))
                    {
                        existeError = true;
                    }
                }

                // se rellenan  la lista de documento para proceder al guardado




                object itemsOS = HidDocumentoSelect["OtorgaSolicita"];
                if (itemsOS.ToString() != null && !string.IsNullOrEmpty(itemsOS.ToString()))
                {
                    foreach (var item in (Object[])itemsOS)
                    {
                        nuevahojaDocumentos = new DatosDocumentos();
                        nuevahojaDocumentos.IdHojaDatos = nuevaHoja.IdHojaDatos;
                        nuevahojaDocumentos.IdVariente = nuevaHojaComplemento.IdVariante;
                        nuevahojaDocumentos.TextoVariante = nuevaHojaComplemento.TextoVariante;
                        nuevahojaDocumentos.TextoFigura = "Otorga o Solicita";
                        nuevahojaDocumentos.IdDoc = Convert.ToInt32(item);
                        nuevahojaDocumentos.Observaciones = "";

                        datosCrud.AltaDatosDocumentos(nuevahojaDocumentos);

                    }

                }

                object itemsFv = HidDocumentoSelect["AfavorDe"];

                if (itemsFv.ToString() != "" && !string.IsNullOrEmpty(itemsFv.ToString()))
                {
                    foreach (var item in (Object[])itemsFv)
                    {
                        nuevahojaDocumentos = new DatosDocumentos();
                        nuevahojaDocumentos.IdHojaDatos = nuevaHoja.IdHojaDatos;
                        nuevahojaDocumentos.IdVariente = nuevaHojaComplemento.IdVariante;
                        nuevahojaDocumentos.TextoVariante = nuevaHojaComplemento.TextoVariante;
                        nuevahojaDocumentos.TextoFigura = "A favor de";
                        nuevahojaDocumentos.IdDoc = Convert.ToInt32(item);
                        nuevahojaDocumentos.Observaciones = "";

                        datosCrud.AltaDatosDocumentos(nuevahojaDocumentos);
                    }

                }




                // se registra el primer recibo de pago

                nuevaHojaReciboPago.IdHojaDatos = nuevaHoja.IdHojaDatos;
                nuevaHojaReciboPago.NumRecibo = txtReciboPagoIni.Text;
                nuevaHojaReciboPago.CantidadTotal = 0;
                nuevaHojaReciboPago.CantidadAbonada = 0;
                nuevaHojaReciboPago.Concepto = "Recibo Inicial Expediente";
                nuevaHojaReciboPago.UsuarioRecibe = "No Definido";
                nuevaHojaReciboPago.NotaComentario = "Recibo no controlado por sistema.";

                if (!datosCrud.AltaRecibosDePago(nuevaHojaReciboPago))
                {
                    existeError = true;
                }


                //se crear el registro del expediente

                nuevoExpediente.IdExpediente = nuevaHoja.numExpediente;
                nuevoExpediente.IdHojaDatos = nuevaHoja.IdHojaDatos;
                nuevoExpediente.IdEstatus = "EX1";
                //nuevoExpediente.FechaElaboracion = nuevaHoja.FechaIngreso;


                foreach (var item in lsOtorgaSolicitante)
                {
                    nuevoExpediente.Otorga += item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + " / ";
                }

                foreach (var item in lsAfavorDE)
                {
                    nuevoExpediente.AfavorDe += item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + " / ";
                }


                if (!datosCrud.AltaExpediente(nuevoExpediente))
                {
                    existeError = true;
                }



                //  se crean las carpetas necesarias para el expediente


                string directorioVirtual = "~/GNArchivosRoot";
                string directorioFisico = MapPath(directorioVirtual);




                string rutaFisicaCalculada = Path.Combine(directorioFisico, nuevaHoja.numExpediente);

                if (!Directory.Exists(rutaFisicaCalculada))
                {
                    Directory.CreateDirectory(rutaFisicaCalculada);

                    if (Directory.Exists(rutaFisicaCalculada))
                    {
                        string carpetaAvisos = Path.Combine(rutaFisicaCalculada, "Avisos");
                        string carpetaFirmados = Path.Combine(rutaFisicaCalculada, "Firmados");
                        string carpetaPendientesFirma = Path.Combine(rutaFisicaCalculada, "PedientesFirma");
                        string carpetaProyecto = Path.Combine(rutaFisicaCalculada, "Proyecto");
                        string carpetaDocumentos = Path.Combine(rutaFisicaCalculada, "Documentos");

                        Directory.CreateDirectory(carpetaAvisos);

                        Directory.CreateDirectory(carpetaFirmados);

                        Directory.CreateDirectory(carpetaPendientesFirma);

                        Directory.CreateDirectory(carpetaProyecto);

                        Directory.CreateDirectory(carpetaDocumentos);




                    }

                }


            }


            if (!existeError)
            {


                ppNuevaHojaDatos.JSProperties["cp_swMsg"] = "Nuevo expediente: " + nuevaHoja.numExpediente + " listo.!";
                ppNuevaHojaDatos.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
                return;
            }
            else
            {
                ppNuevaHojaDatos.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar guardar el registro.";
                ppNuevaHojaDatos.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;
                return;
            }
        }

        protected void gvOtorgaSolicita_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsOtorgaSolicitante;
        }



        protected void cbActosNuevo_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.ValueField = "IdActo";
            control.TextField = "TextoActo";
            control.DataSource = catActos;
        }

        protected void cbVarienteNuevo_DataBinding(object sender, EventArgs e)
        {
            {
                ASPxComboBox control = (ASPxComboBox)sender;

                control.ValueField = "IdVariante";
                control.TextField = "TextoVariante";
                control.DataSource = catVarientesPorActo;
            }
            #endregion
        }
        #region Funciones

        private void DameCatalogos()
        {
            catActos = datosCrud.ConsultaCatActos().Where(x=> x.Activo==true).ToList();
            cbActosNuevo.DataBind();

        }




        #endregion

        protected void cbRolOtorgaSolicita_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            cb.DataSource = catRolParticipantesOtorgaSolicita;
            cb.TextField = "TextoRol";
            cb.ValueField = "TextoRol";
            cb.ValueType = typeof(string);

            cb.SelectedIndex = -1;
        }

        protected void cbAnafabetaOtorgaSolicita_Callback(object sender, CallbackEventArgsBase e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            Cat_RolParticipantes rol = catRolParticipantesOtorgaSolicita.Where(x => x.TextoRol.ToString() == e.Parameter).FirstOrDefault();

            if (!rol.PreguntarSiEsAnafabeta)
            {
                cb.Value = "No Aplica";
                cb.Text = "No Aplica";
            }
            else
            {
                cb.Value = "Si";
                cb.Text = "Si";
            }



        }

        protected void gvOtorgaSolicita_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            object rolOperacion = ((ASPxComboBox)gvOtorgaSolicita.FindEditRowCellTemplateControl(
                  gvOtorgaSolicita.Columns["RolOperacion"] as GridViewDataComboBoxColumn,
                  "cbRolOtorgaSolicita")).Value;

            object sexo = ((ASPxComboBox)gvOtorgaSolicita.FindEditRowCellTemplateControl(
                gvOtorgaSolicita.Columns["Sexo"] as GridViewDataComboBoxColumn,
                "cbSexoOtorgaSolicita")).Value;

            object estadoCivil = ((ASPxComboBox)gvOtorgaSolicita.FindEditRowCellTemplateControl(
                gvOtorgaSolicita.Columns["EstadoCivil"] as GridViewDataComboBoxColumn,
                "cbEstadoCivilOtorgaSolicita")).Value;

            object RegimenConyugal = ((ASPxComboBox)gvOtorgaSolicita.FindEditRowCellTemplateControl(
                gvOtorgaSolicita.Columns["RegimenConyugal"] as GridViewDataComboBoxColumn,
                "cbRegimenConyugalOtorgaSolicita")).Value;


            if (rolOperacion == null)
            {
                e.RowError += "El campo Rol Operacion es obligatorio.\n ";
            }

            if (sexo == null)
            {
                e.RowError += "El campo sexo  es obligatorio.\n ";
            }

            if (e.NewValues["FechaNacimiento"] == null)
            {
                e.RowError += "El fecha nacimiento es obligatorio.\n ";
            }

            if (estadoCivil == null)
            {
                e.RowError += "El campo estado civil Operacion es obligatorio.\n ";
            }
            if (RegimenConyugal == null)
            {
                e.RowError += "El campo Regimen conyugal Operacion es obligatorio.\n ";
            }

            if (e.NewValues["Nombres"] == null)
            {
                e.RowError += "El campo Nombre es obligatorio.\n ";
            }

            if (e.NewValues["ApellidoPaterno"] == null)
            {
                e.RowError += "El campo Apellido Paterno es obligatorio.\n ";
            }

            if (e.NewValues["ApellidoMaterno"] == null)
            {
                e.RowError += "El campo Apellido Materno es obligatorio.\n ";
            }


        }



        protected void cbSexoOtorgaSolicita_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbEstadoCivilOtorgaSolicita_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbRegimenConyugalOtorgaSolicita_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }



        protected void gvOtorgaSolicita_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            DatosParticipantes datos = new DatosParticipantes();
            datos.IdRegistro = lsOtorgaSolicitante.Count + 1;
            datos.IdHojaDatos = 0;
            datos.FiguraOperacion = "Otorga o Solicita";
            datos.RolOperacion = e.NewValues["RolOperacion"].ToString();
            datos.TipoRegimen = e.NewValues["TipoRegimen"] == null ? "" : e.NewValues["TipoRegimen"].ToString();
            datos.Nombres = e.NewValues["Nombres"].ToString();
            datos.ApellidoPaterno = e.NewValues["ApellidoPaterno"].ToString();
            datos.ApellidoMaterno = e.NewValues["ApellidoMaterno"].ToString();
            datos.Sexo = e.NewValues["Sexo"].ToString();
            datos.FechaNacimiento = Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString());
            datos.Ocupacion = e.NewValues["Ocupacion"] == null ? "" : e.NewValues["Ocupacion"].ToString();
            datos.EstadoCivil = e.NewValues["EstadoCivil"].ToString();
            datos.RegimenConyugal = e.NewValues["RegimenConyugal"].ToString();
            datos.SabeLeerEscribir = e.NewValues["SabeLeerEscribir"].ToString();
            datos.Notas = e.NewValues["Notas"] == null ? "" : e.NewValues["Notas"].ToString();

            lsOtorgaSolicitante.Add(datos);

            e.Cancel = true;
            gvOtorgaSolicita.CancelEdit();

            gvOtorgaSolicita.DataBind();

        }

        protected void gvaFavorDe_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsAfavorDE;
        }

        protected void gvaFavorDe_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            object rolOperacion = ((ASPxComboBox)gvaFavorDe.FindEditRowCellTemplateControl(
                    gvaFavorDe.Columns["RolOperacion"] as GridViewDataComboBoxColumn,
                    "cbRolAfavorDe")).Value;

            object sexo = ((ASPxComboBox)gvaFavorDe.FindEditRowCellTemplateControl(
                gvaFavorDe.Columns["Sexo"] as GridViewDataComboBoxColumn,
                "cbSexoAfavorDe")).Value;

            object estadoCivil = ((ASPxComboBox)gvaFavorDe.FindEditRowCellTemplateControl(
                gvaFavorDe.Columns["EstadoCivil"] as GridViewDataComboBoxColumn,
                "cbEstadoCivilAfavorDe")).Value;

            object RegimenConyugal = ((ASPxComboBox)gvaFavorDe.FindEditRowCellTemplateControl(
                gvaFavorDe.Columns["RegimenConyugal"] as GridViewDataComboBoxColumn,
                "cbRegimenConyugalAfavorDe")).Value;


            if (rolOperacion == null)
            {
                e.RowError += "El campo Rol Operacion es obligatorio.\n ";
            }

            if (sexo == null)
            {
                e.RowError += "El campo sexo  es obligatorio.\n ";
            }

            if (e.NewValues["FechaNacimiento"] == null)
            {
                e.RowError += "El fecha nacimiento es obligatorio.\n ";
            }

            if (estadoCivil == null)
            {
                e.RowError += "El campo estado civil Operacion es obligatorio.\n ";
            }
            if (RegimenConyugal == null)
            {
                e.RowError += "El campo Regimen conyugal Operacion es obligatorio.\n ";
            }

            if (e.NewValues["Nombres"] == null)
            {
                e.RowError += "El campo Nombre es obligatorio.\n ";
            }

            if (e.NewValues["ApellidoPaterno"] == null)
            {
                e.RowError += "El campo Apellido Paterno es obligatorio.\n ";
            }

            if (e.NewValues["ApellidoMaterno"] == null)
            {
                e.RowError += "El campo Apellido Materno es obligatorio.\n ";
            }


        }

        protected void gvaFavorDe_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            DatosParticipantes datos = new DatosParticipantes();
            datos.IdRegistro = lsAfavorDE.Count + 1;
            datos.IdHojaDatos = 0;
            datos.FiguraOperacion = "A favor de";
            datos.RolOperacion = e.NewValues["RolOperacion"].ToString();
            datos.TipoRegimen = e.NewValues["TipoRegimen"] == null ? "" : e.NewValues["TipoRegimen"].ToString();
            datos.Nombres = e.NewValues["Nombres"].ToString();
            datos.ApellidoPaterno = e.NewValues["ApellidoPaterno"].ToString();
            datos.ApellidoMaterno = e.NewValues["ApellidoMaterno"].ToString();
            datos.Sexo = e.NewValues["Sexo"].ToString();
            datos.FechaNacimiento = Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString());
            datos.Ocupacion = e.NewValues["Ocupacion"] == null ? "" : e.NewValues["Ocupacion"].ToString();
            datos.EstadoCivil = e.NewValues["EstadoCivil"].ToString();
            datos.RegimenConyugal = e.NewValues["RegimenConyugal"].ToString();
            datos.SabeLeerEscribir = e.NewValues["SabeLeerEscribir"].ToString();
            datos.Notas = e.NewValues["Notas"] == null ? "" : e.NewValues["Notas"].ToString();

            lsAfavorDE.Add(datos);

            e.Cancel = true;
            gvaFavorDe.CancelEdit();

            gvaFavorDe.DataBind();
        }

        protected void gvOtorgaSolicita_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

            var participanteBorrar = lsOtorgaSolicitante.Where(x => x.IdRegistro == Convert.ToInt32(e.Keys[0])).FirstOrDefault();

            lsOtorgaSolicitante.Remove(participanteBorrar);
            e.Cancel = true;
            gvOtorgaSolicita.CancelEdit();
            gvOtorgaSolicita.DataBind();


        }

        protected void gvaFavorDe_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var participanteBorrar = lsAfavorDE.Where(x => x.IdRegistro == Convert.ToInt32(e.Keys[0])).FirstOrDefault();

            lsAfavorDE.Remove(participanteBorrar);
            e.Cancel = true;
            gvaFavorDe.CancelEdit();
            gvaFavorDe.DataBind();
        }

        protected void cbRolAfavorDe_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            cb.DataSource = catRolParticipantesAfavorDe;
            cb.TextField = "TextoRol";
            cb.ValueField = "TextoRol";
            cb.ValueType = typeof(string);

            cb.SelectedIndex = -1;
        }

        protected void cbSexoAfavorDe_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbEstadoCivilAfavorDe_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbRegimenConyugalAfavorDe_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbAnafabetaAFavorDe_Callback(object sender, CallbackEventArgsBase e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            Cat_RolParticipantes rol = catRolParticipantesAfavorDe.Where(x => x.TextoRol.ToString() == e.Parameter).FirstOrDefault();

            if (!rol.PreguntarSiEsAnafabeta)
            {
                cb.Value = "No Aplica";
                cb.Text = "No Aplica";
            }
            else
            {
                cb.Value = "Si";
                cb.Text = "Si";
            }
        }

        protected void lbDocumentacionOtorgaSolicita_DataBinding(object sender, EventArgs e)
        {
            ASPxListBox control = (ASPxListBox)sender;


            control.DataSource = catDocumentoOtorgaSolicita; ;
            control.TextField = "TextoDocumento";
            control.ValueField = "IdDoc";

            cbVarienteNuevo.DataBind();
        }

        protected void lbDocumentacionAfavorDe_DataBinding(object sender, EventArgs e)
        {
            ASPxListBox control = (ASPxListBox)sender;


            control.DataSource = catDocumentoAfavorDe; ;
            control.TextField = "TextoDocumento";
            control.ValueField = "IdDoc";

            cbVarienteNuevo.DataBind();
        }

        protected void gvOtorgaSolictaDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            List<DatosParticipantes> detalle = new List<DatosParticipantes>();
            string numHojaDatos = detailGrid.GetMasterRowKeyValue().ToString();


            ListaHojaDatos registroHojaDatos = lsHojaDatos.Where(x => x.IdHojaDatos.ToString() == numHojaDatos).FirstOrDefault();

            if (registroHojaDatos != null)
            {
                detalle = registroHojaDatos.DetalleParticipantes.Where(x => x.FiguraOperacion == "Otorga o Solicita").ToList();
            }


            detailGrid.DataSource = detalle;
        }

        protected void gvAfavorDeDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            List<DatosParticipantes> detalle = new List<DatosParticipantes>();
            string numHojaDatos = detailGrid.GetMasterRowKeyValue().ToString();


            ListaHojaDatos registroHojaDatos = lsHojaDatos.Where(x => x.IdHojaDatos.ToString() == numHojaDatos).FirstOrDefault();

            if (registroHojaDatos != null)
            {
                detalle = registroHojaDatos.DetalleParticipantes.Where(x => x.FiguraOperacion == "A favor de").ToList();
            }


            detailGrid.DataSource = detalle;
        }

        protected void gvHojaDatos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {

        }

        protected void gvOtorgaSolicita_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            Boolean existenCambios = false;


            foreach (DictionaryEntry item in e.OldValues)
            {
                if (e.NewValues.Contains(item.Key))
                {
                  
                    if (e.NewValues[item.Key]!=null && !e.NewValues[item.Key].Equals(item.Value))
                    {
                        existenCambios = true;
                        break;
                    }
                }
            }

            if (existenCambios == false)
            {
                gvOtorgaSolicita.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = lsOtorgaSolicitante.Where(x => x.IdRegistro == Convert.ToInt64(e.Keys[0])).First();

            if (miRegistro != null)
            {

                //miRegistro.FiguraOperacion = "Otorga o Solicita";
                miRegistro.RolOperacion = e.NewValues["RolOperacion"].ToString();
                miRegistro.TipoRegimen = e.NewValues["TipoRegimen"] == null ? "" : e.NewValues["TipoRegimen"].ToString();
                miRegistro.Nombres = e.NewValues["Nombres"].ToString();
                miRegistro.ApellidoPaterno = e.NewValues["ApellidoPaterno"].ToString();
                miRegistro.ApellidoMaterno = e.NewValues["ApellidoMaterno"].ToString();
                miRegistro.Sexo = e.NewValues["Sexo"].ToString();
                miRegistro.FechaNacimiento = Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString());
                miRegistro.Ocupacion = e.NewValues["Ocupacion"] == null ? "" : e.NewValues["Ocupacion"].ToString();
                miRegistro.EstadoCivil = e.NewValues["EstadoCivil"].ToString();
                miRegistro.RegimenConyugal = e.NewValues["RegimenConyugal"].ToString();
                miRegistro.SabeLeerEscribir = e.NewValues["SabeLeerEscribir"].ToString();
                miRegistro.Notas = e.NewValues["Notas"] == null ? "" : e.NewValues["Notas"].ToString();

            }


            gvOtorgaSolicita.CancelEdit();
            e.Cancel = true;
            gvOtorgaSolicita.DataBind();


        }

        protected void gvaFavorDe_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                gvaFavorDe.CancelEdit();
                e.Cancel = true;
                return;
            }

            var miRegistro = lsAfavorDE.Where(x => x.IdRegistro == Convert.ToInt64(e.Keys[0])).First();

            if (miRegistro != null)
            {

               // miRegistro.FiguraOperacion = "A favor de";
                miRegistro.RolOperacion = e.NewValues["RolOperacion"].ToString();
                miRegistro.TipoRegimen = e.NewValues["TipoRegimen"] == null ? "" : e.NewValues["TipoRegimen"].ToString();
                miRegistro.Nombres = e.NewValues["Nombres"].ToString();
                miRegistro.ApellidoPaterno = e.NewValues["ApellidoPaterno"].ToString();
                miRegistro.ApellidoMaterno = e.NewValues["ApellidoMaterno"].ToString();
                miRegistro.Sexo = e.NewValues["Sexo"].ToString();
                miRegistro.FechaNacimiento = Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString());
                miRegistro.Ocupacion = e.NewValues["Ocupacion"] == null ? "" : e.NewValues["Ocupacion"].ToString();
                miRegistro.EstadoCivil = e.NewValues["EstadoCivil"].ToString();
                miRegistro.RegimenConyugal = e.NewValues["RegimenConyugal"].ToString();
                miRegistro.SabeLeerEscribir = e.NewValues["SabeLeerEscribir"].ToString();
                miRegistro.Notas = e.NewValues["Notas"] == null ? "" : e.NewValues["Notas"].ToString();

            }


            gvaFavorDe.CancelEdit();
            e.Cancel = true;
            gvaFavorDe.DataBind();

        }

        protected void cbTipoRegimen_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }
    }
}