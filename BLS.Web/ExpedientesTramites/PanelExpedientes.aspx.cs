using DevExpress.CodeParser;
using DevExpress.Export;
using DevExpress.Utils.Extensions;
using DevExpress.Web;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraPrinting;
using DevExpress.XtraSpreadsheet.Import.OpenXml;
using BLS.Negocio.CRUD;
using BLS.Negocio.Expediente;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;

using BLS.Web.Controles.Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BLS.Web.ExpedientesTramites
{
    public partial class PanelExpedientes : PageBase
    {

        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();
        //DatosUsuario datosUsuario = new DatosUsuario();
        DatosExpedientes datosExpediente = new DatosExpedientes();
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

        public List<PerfilesXestatus> lsPerfilesXestatus
        {
            get

            {
                List<PerfilesXestatus> ssPerfilesXestatus = new List<PerfilesXestatus>();
                if (this.Session["ssPerfilesXestatus"] != null)
                {
                    ssPerfilesXestatus = (List<PerfilesXestatus>)this.Session["ssPerfilesXestatus"];
                }

                return ssPerfilesXestatus;
            }
            set
            {
                this.Session["ssPerfilesXestatus"] = value;
            }

        }

        public List<Cat_Estatus> catEstatus
        {
            get

            {
                List<Cat_Estatus> sseCatEstatus = new List<Cat_Estatus>();
                if (this.Session["sseCatEstatus"] != null)
                {
                    sseCatEstatus = (List<Cat_Estatus>)this.Session["sseCatEstatus"];
                }

                return sseCatEstatus;
            }
            set
            {
                this.Session["sseCatEstatus"] = value;
            }

        }

        public List<Cat_Estatus> catEstatusFull
        {
            get

            {
                List<Cat_Estatus> sseCatEstatusFull = new List<Cat_Estatus>();
                if (this.Session["sseCatEstatusFull"] != null)
                {
                    sseCatEstatusFull = (List<Cat_Estatus>)this.Session["sseCatEstatusFull"];
                }

                return sseCatEstatusFull;
            }
            set
            {
                this.Session["sseCatEstatusFull"] = value;
            }

        }


        public List<Usuarios> catProyectistas
        {
            get

            {
                List<Usuarios> sseCatProyectistas = new List<Usuarios>();
                if (this.Session["sseCatProyectistas"] != null)
                {
                    sseCatProyectistas = (List<Usuarios>)this.Session["sseCatProyectistas"];
                }

                return sseCatProyectistas;
            }
            set
            {
                this.Session["sseCatProyectistas"] = value;
            }

        }


        public List<ListaExpedientes> lsExpediente
        {
            get

            {
                List<ListaExpedientes> sseListaExpediente = new List<ListaExpedientes>();
                if (this.Session["sseListaExpediente"] != null)
                {
                    sseListaExpediente = (List<ListaExpedientes>)this.Session["sseListaExpediente"];
                }

                return sseListaExpediente;
            }
            set
            {
                this.Session["sseListaExpediente"] = value;
            }

        }

        public List<Alertas> lsAlertas
        {
            get

            {
                List<Alertas> sseListaAlertas = new List<Alertas>();
                if (this.Session["sseListaAlertas"] != null)
                {
                    sseListaAlertas = (List<Alertas>)this.Session["sseListaAlertas"];
                }

                return sseListaAlertas;
            }
            set
            {
                this.Session["sseListaAlertas"] = value;
            }

        }


        public Expedientes RegistroExistente
        {
            get

            {
                Expedientes ssRegistroExistente = new Expedientes();
                if (this.Session["ssRegistroExistente"] != null)
                {
                    ssRegistroExistente = (Expedientes)this.Session["ssRegistroExistente"];
                }

                return ssRegistroExistente;
            }
            set
            {
                this.Session["ssRegistroExistente"] = value;
            }

        }


        public DatosAvisoNotarial RegistroAvisoNotarial
        {
            get

            {
                DatosAvisoNotarial ssRegistroAvisoNotarial = new DatosAvisoNotarial();
                if (this.Session["ssRegistroAvisoNotarial"] != null)
                {
                    ssRegistroAvisoNotarial = (DatosAvisoNotarial)this.Session["ssRegistroAvisoNotarial"];
                }

                return ssRegistroAvisoNotarial;
            }
            set
            {
                this.Session["ssRegistroAvisoNotarial"] = value;
            }

        }




        public string rutaArchivosRoot
        {
            get

            {
                string ssRutaArchivosRoot = "";
                if (this.Session["ssRutaArchivosRoot"] != null)
                {
                    ssRutaArchivosRoot = this.Session["ssRutaArchivosRoot"].ToString();
                }

                return ssRutaArchivosRoot;
            }
            set
            {
                this.Session["ssRutaArchivosRoot"] = value;
            }

        }

        public string NumExpSelccionadoAlerta
        {
            get

            {
                string ssNumExpSelccionadoAlerta = "";
                if (this.Session["ssNumExpSelccionadoAlerta"] != null)
                {
                    ssNumExpSelccionadoAlerta = this.Session["ssNumExpSelccionadoAlerta"].ToString();
                }

                return ssNumExpSelccionadoAlerta;
            }
            set
            {
                this.Session["ssNumExpSelccionadoAlerta"] = value;
            }

        }
        public string NumExpSelccionadoCambioEstatus
        {
            get

            {
                string ssNumExpSelccionadoCambioEstatus = "";
                if (this.Session["ssNumExpSelccionadoCambioEstatus"] != null)
                {
                    ssNumExpSelccionadoCambioEstatus = this.Session["ssNumExpSelccionadoCambioEstatus"].ToString();
                }

                return ssNumExpSelccionadoCambioEstatus;
            }
            set
            {
                this.Session["ssNumExpSelccionadoCambioEstatus"] = value;
            }

        }




        #endregion

        #region Funciones
        private void DameCatalogos()

        {
            try
            {

                catEstatus = datosCrud.ConsultaCatEstatus();
                catEstatusFull = datosCrud.ConsultaCatEstatus();

                catActos = datosCrud.ConsultaCatActos();
                catProyectistas = datosCrud.ConsultaUsuario();
                lsPerfilesXestatus = datosCrud.ConsultaPerfilesXestatus();

                if (lsPerfilesXestatus.Count > 0)
                {

                    var estatusPermitidos = (from dato in catEstatus where lsPerfilesXestatus.Exists(p => p.esIdEstatus == dato.IdEstatus && p.esIdPerfil == UsuarioPagina.Perfil) select dato).ToList();
                    catEstatus = estatusPermitidos;
                }


                //cbActosNuevo.DataBind();
                cbPRfnProyectista.DataBind();
                trlEstatusExpedientes.DataBind();

                MostrarCampoPorPerfil(UsuarioPagina.NombrePerfil);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void MostrarCampoPorPerfil(string nombrePerfil)
        {

            frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = false;


            frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = false;

            frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = false;


            frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = false;

            frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = false;

            frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = false;

            frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("PRfnValorOperacion").ClientVisible = false;



            frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = false;


            frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = false;

            frmExpedienteExistente.FindItemByFieldName("FIfnFirmaTraslado").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("FIfnFEchaOtorgamiento").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("EnfnFechaAutorizacion").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = false;
            frmExpedienteExistente.FindItemByFieldName("ConFechaPagoAvaluo").ClientVisible = false;





            switch (nombrePerfil)
            {
                case "Consultoria-IT":

                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("FIfnFirmaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFEchaOtorgamiento").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaAutorizacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnValorOperacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaPagoAvaluo").ClientVisible = true;


                    break;
                case "Dirección":


                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = true;



                    frmExpedienteExistente.FindItemByFieldName("FIfnFirmaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFEchaOtorgamiento").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaAutorizacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnValorOperacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaPagoAvaluo").ClientVisible = true;


                    break;
                case "Datos":
                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;


                    //frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = true;


                    break;

                case "Mesas":

                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnISR").ClientVisible = true;

                    //Firmas
                    frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    //Aviso definitivo
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    //Escrituracion
                    //frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;



                    frmExpedienteExistente.FindItemByFieldName("FIfnFEchaOtorgamiento").ClientVisible = true;


                    break;

                case "Capturista":

                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnISR").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;
                    break;

                case "Contabilidad":


                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;



                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;



                    frmExpedienteExistente.FindItemByFieldName("PRfnValorOperacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaPagoAvaluo").ClientVisible = true;

                    break;


                case "Entregas":


                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("PRfnISR").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    //frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;

                    break;
                case "Coordinacion":


                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = true;

                    break;

                case "Gerente Creditos":


                    frmExpedienteExistente.FindItemByFieldName("ExfnNumeroExpediente").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnOtorga").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EXfnAfavorde").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnOperacionProyectada").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ExfnUbicacionPredio").ClientVisible = true;
                    // frmExpedienteExistente.FindItemByFieldName("ExfnDocumentosFaltantes").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("APfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaEnvioAlRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("APfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PRfnProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAsignacionProyectista").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaPrevistaTermino").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnFechaAvisoPreventivo").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("FIfnNotasFirmas").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumEscritura").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnNumVolumen").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnAplicaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFechaRecepcionTerminoEscritura").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaElaboracion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaEnvioRPP").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnEsTramitePorSistema").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaPagoBoleta").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaRecibido").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EsfnRecibioTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaAsignacionMesa").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("AdfnFechaTerminoTramite").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesEntrega").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnRegistroSolicitado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaBoletaPago").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaRegresoRegistro").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaSalida").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnObservacionesSobreTramiteTerminado").ClientVisible = true;


                    frmExpedienteExistente.FindItemByFieldName("ContISR").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContISRCalculado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoCatastral").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoFiscal").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ContAvaluoComercial").ClientVisible = true;

                    frmExpedienteExistente.FindItemByFieldName("PldActVulnerable").ClientVisible = true;



                    frmExpedienteExistente.FindItemByFieldName("FIfnFirmaTraslado").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("FIfnFEchaOtorgamiento").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("EnfnFechaAutorizacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("PRfnValorOperacion").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaDeAvaluo").ClientVisible = true;
                    frmExpedienteExistente.FindItemByFieldName("ConFechaPagoAvaluo").ClientVisible = true;


                    break;
            }
        }
        #endregion


        #region Eventos




        protected void Page_Init(object sender, EventArgs e)
        {
            //try
            //{
            //    if (rutaArchivosRoot != "")
            //    {
            //        ASPxFileManager1.Settings.RootFolder = rutaArchivosRoot;

            //        ASPxFileManager1.Refresh();

            //        var rootFolder = GetRootFolder(ASPxFileManager1.SelectedFolder);

            //        ApplyRules(rootFolder);

            //    }

            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}


        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                dtFechaInicio.Date = DateTime.Now.Date.AddDays(-15);
                dtFechaFin.Date = DateTime.Now.Date;
                DameCatalogos();
            }
        }

        protected void gvExpedientes_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsExpediente;
        }

        protected void gvExpedientes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //ASPxGridView control = (ASPxGridView)sender;
            if (e.Parameters == "CargarRegistros")
            {
                if (UsuarioPagina.NombrePerfil == "Mesas") //2024-03-17 si el perfil es de mesas entonces solo mostramos lo registros del usuario 
                {
                    lsExpediente = datosExpediente.DameListaExpediente(fechaInicial: dtFechaInicio.Date, fechaFinal: dtFechaFin.Date, idUsuario: UsuarioPagina.usCodigo, todasLasFechas: chkBusquedaCompleta.Checked).OrderByDescending(x => x.FechaIngreso).ToList();// cargamos registros
                }
                else
                {
                    lsExpediente = datosExpediente.DameListaExpediente(fechaInicial: dtFechaInicio.Date, fechaFinal: dtFechaFin.Date, idUsuario: 0, todasLasFechas: chkBusquedaCompleta.Checked).OrderByDescending(x => x.FechaIngreso).ToList();// cargamos todos los registros
                }


                // 2024-06-22 filtramos por registros alertados

                if (chkVerExpAlertaActiva.Checked)
                {
                    lsExpediente = lsExpediente.Where(x => x.AlertaActiva == true).ToList();
                }


                if (chkVerExpAlertaNoActiva.Checked)
                {
                    lsExpediente = lsExpediente.Where(x => x.ExistenAlertas == true).ToList();
                }


                if (chkEsActoVulnerable.Checked)

                {
                    lsExpediente= lsExpediente.Where(x => x.EsActoVulnerable == true).ToList();
                }



                gvExpedientes.DataBind();
                return;
            }

            if (e.Parameters == "AsignarRutaExpediente")
            {

                ASPxGridView control = (ASPxGridView)sender;
                if (control.Selection.Count > 0)
                {
                    var datosExpediente = control.GetSelectedFieldValues("IdExpediente");
                    string numeroExpediente = datosExpediente[0].ToString().Replace("/", "-");
                    rutaArchivosRoot = "~/GNArchivosRoot/" + numeroExpediente;
                    //  ASPxFileManager1.Settings.RootFolder = rutaArchivosRoot;
                    //fmArchivosControl.Refresh();

                }
                return;
            }

        }

        protected void gvExpedientes_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
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

        protected void gvExpedientes_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "IdExpediente")
            {

                if (e.CellValue != null)
                {

                    var miExpediente = lsExpediente.Where(x => x.IdExpediente == e.KeyValue.ToString()).FirstOrDefault();

                    if (miExpediente != null)
                    {

                        ASPxImage Campo = (ASPxImage)gvExpedientes.FindRowCellTemplateControl(e.VisibleIndex, e.DataColumn, "imgExpedienteAlerta");
                        Campo.Caption = Convert.ToString(e.CellValue);

                        if (miExpediente.AlertaActiva)
                        {
                            Campo.EmptyImage.IconID = "status_warning_16x16";

                        }
                        else if (miExpediente.ExistenAlertas)
                        {
                            Campo.EmptyImage.IconID = "status_warning_svg_gray_16x16";
                        }


                        if (miExpediente.EsActoVulnerable)
                        {
                            e.Cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#ff6961");
                        
                        }


                    }


                    //ocultar el tag que corresponda

                    ASPxPageControl TabControl = (ASPxPageControl)gvExpedientes.FindDetailRowTemplateControl(e.VisibleIndex, "pageControl");
                    if (TabControl != null)
                    {

                        // optenemos el tipo de acto vs el catalogo para tener del detalle

                        var tipoActo = catActos.Where(x => x.TextoActo == miExpediente.TextoActo).FirstOrDefault();
                        if (tipoActo != null)
                        {
                            TabControl.TabPages.FindByName("TapAP").ClientVisible = tipoActo.TapAP;
                            TabControl.TabPages.FindByName("TapProyecto").ClientVisible = tipoActo.TapProyecto;
                            TabControl.TabPages.FindByName("TapFirmas").ClientVisible = tipoActo.TapFirmas;
                            TabControl.TabPages.FindByName("TapAD").ClientVisible = tipoActo.TapAD;
                            TabControl.TabPages.FindByName("TapEscritura").ClientVisible = tipoActo.TapEscritura;
                            TabControl.TabPages.FindByName("TapEntrega").ClientVisible = tipoActo.TapEntrega;
                            TabControl.TabPages.FindByName("TapContabilidad").ClientVisible = tipoActo.TapContabilidad;
                            TabControl.TabPages.FindByName("TapPLD").ClientVisible = tipoActo.TapPLD;
                        }



                    }



                }

                return;
            }




        }

        //protected void ppOrdenNuevoExpediente_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        //{
        //    if (e.Parameter == "NuevoExpediente")
        //    {
        //        dtFechaIngresoNuevo.Date = DateTime.Now;
        //        return;

        //    }

        //    if (e.Parameter == "guardar")
        //    {
        //        Expedientes nuevoRegistro = new Expedientes();
        //        nuevoRegistro.IdExpediente = "";
        //        nuevoRegistro.numReciboPago = txtNumReciboNuevo.Text;
        //        nuevoRegistro.numReciboPago2 = "";

        //        nuevoRegistro.FechaIngreso = dtFechaIngresoNuevo.Date;
        //        nuevoRegistro.IdActo = Convert.ToInt32(cbActosNuevo.Value.ToString());
        //        nuevoRegistro.Otorga = txtOtorgaNuevo.Text;
        //        nuevoRegistro.AfavorDe = txtAfavorDeNuevo.Text;
        //        nuevoRegistro.OperacionProyectada = txtOperacionProyectadaNuevo.Text;
        //        nuevoRegistro.UbicacionPredio = txtUbicacionPredioNuevo.Text;
        //        nuevoRegistro.Faltantes = txtDocumentoFaltantesNuevo.Text;

        //        if (string.IsNullOrEmpty(txtDocumentoFaltantesNuevo.Text))
        //        {
        //            nuevoRegistro.IdEstatus = "EX1";
        //        }
        //        else
        //        {
        //            nuevoRegistro.IdEstatus = "EX2";
        //        }



        //        if (datosCrud.AltaExpediente(nuevoRegistro))
        //        {

        //            // 2024-01-22 creamos la carpetas necesarias para la gestion del expediente.



        //            string directorioVirtual = "~/GNArchivosRoot";
        //            string directorioFisico = MapPath(directorioVirtual);




        //            string rutaFisicaCalculada = Path.Combine(directorioFisico, nuevoRegistro.IdExpediente);

        //            if (!Directory.Exists(rutaFisicaCalculada))
        //            {
        //                Directory.CreateDirectory(rutaFisicaCalculada);

        //                if (Directory.Exists(rutaFisicaCalculada))
        //                {
        //                    string carpetaAvisos = Path.Combine(rutaFisicaCalculada, "Avisos");
        //                    string carpetaFirmados = Path.Combine(rutaFisicaCalculada, "Firmados");
        //                    string carpetaPendientesFirma = Path.Combine(rutaFisicaCalculada, "PedientesFirma");
        //                    string carpetaProyecto = Path.Combine(rutaFisicaCalculada, "Proyecto");
        //                    string carpetaDocumentos = Path.Combine(rutaFisicaCalculada, "Documentos");

        //                    Directory.CreateDirectory(carpetaAvisos);

        //                    Directory.CreateDirectory(carpetaFirmados);

        //                    Directory.CreateDirectory(carpetaPendientesFirma);

        //                    Directory.CreateDirectory(carpetaProyecto);

        //                    Directory.CreateDirectory(carpetaDocumentos);




        //                }

        //            }


        //            ppOrdenNuevoExpediente.JSProperties["cp_swMsg"] = "Nuevo expediente: " + nuevoRegistro.IdExpediente + " listo.!";
        //            ppOrdenNuevoExpediente.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;
        //            return;
        //        }
        //        else
        //        {

        //            ppOrdenNuevoExpediente.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar guardar el registro.";
        //            ppOrdenNuevoExpediente.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;
        //            return;
        //        }



        //    }

        //}

        //protected void cbActosNuevo_DataBinding(object sender, EventArgs e)
        //{
        //    ASPxComboBox control = (ASPxComboBox)sender;

        //    control.ValueField = "IdActo";
        //    control.TextField = "TextoActo";
        //    control.DataSource = catActos;
        //}

        protected void gvAvisoPreventivo_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;

        }


        protected void gvProyecto_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }



        protected void gvFirmas_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }



        protected void gvAvisoDefinitivo_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }



        protected void gvEscrituracion_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }



        protected void gvEntregas_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }
        protected void gvContabilidad_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }

        protected void gvPld_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            string numExpediente = detailGrid.GetMasterRowKeyValue().ToString();
            var result = lsExpediente.Where(x => x.IdExpediente == numExpediente).ToList();
            detailGrid.DataSource = result;
        }

        protected void ppCambiarEstatus_WindowCallback(object source, PopupWindowCallbackArgs e)
        {
            if (e.Parameter.Contains("CargarEstados"))
            {

                string numExpedinte = e.Parameter.Split('~')[1].ToString();

                NumExpSelccionadoCambioEstatus = e.Parameter.Split('~')[1].ToString();

                txtProyecSelecEstatus.Text = numExpedinte;

                //trlEstatusExpedientes.DataSource = catEstatus;

                trlEstatusExpedientes.DataBind();
                trlEstatusExpedientes.ExpandAll();
                // rbEstados.DataBind();
                return;

            }
            if (e.Parameter.Contains("guardar"))
            {
                var EstadoSelec = e.Parameter.Split('~')[1].ToString();

                RegistroExistente = new Expedientes();

                string numExpediente = NumExpSelccionadoCambioEstatus; //txtProyecSelecEstatus.Text;//gvExpedientes.GetSelectedFieldValues("IdExpediente")[0].ToString();

                RegistroExistente = datosCrud.ConsultaExpediente(numExp: numExpediente);

                RegistroExistente.IdEstatus = EstadoSelec;


                if (datosCrud.ActualizarExpediente(RegistroExistente))
                {
                    gvExpedientes.SearchPanelFilter = "";
                    ppCambiarEstatus.JSProperties["cp_swMsg"] = "Estatus Modificado!";
                    ppCambiarEstatus.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;

                }
                else
                {

                    ppCambiarEstatus.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar Modificar el Estatus.";
                    ppCambiarEstatus.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;

                }

                return;
            }

        }
        protected void ppAlertasExpediente_WindowCallback(object source, PopupWindowCallbackArgs e)
        {
            if (e.Parameter.Contains("CargarRegistros"))
            {
                RegistroExistente = new Expedientes();
                string numExpediente = e.Parameter.Split('~')[1].ToString();
                NumExpSelccionadoAlerta = numExpediente;
                RegistroExistente = datosCrud.ConsultaExpediente(numExp: numExpediente);



                // consultamos las alertas por expediente 

                lsAlertas = datosExpediente.DameAlertasPorExpediente(NumExpSelccionadoAlerta).OrderByDescending(x => x.IdAlerta).ToList();

                if (RegistroExistente != null)
                {
                    //Expediente 
                    txtNumExpedienteAlert.Text = RegistroExistente.IdExpediente;
                    txtExfnOtorgaAlert.Text = RegistroExistente.Otorga;
                    txtEXfnAfavordeAlert.Text = RegistroExistente.AfavorDe;

                    //cargar registro de alertas de BD
                }

                gvAlertas.DataBind();
            }
        }

        protected void gvAlertas_DataBinding(object sender, EventArgs e)
        {
            gvAlertas.DataSource = lsAlertas;
        }


        protected void ppEditarExpediente_WindowCallback(object source, PopupWindowCallbackArgs e)
        {
            if (e.Parameter.Contains("CargarRegistros"))
            {
                RegistroExistente = new Expedientes();


                string numExpediente = e.Parameter.Split('~')[1].ToString();

                RegistroExistente = datosCrud.ConsultaExpediente(numExp: numExpediente);


                if (RegistroExistente != null)
                {

                    // cargamos los campos en el form layaout

                    //2025-02-03 se ocultan las secciones que no estan activas en el catalogo




                    var miExpediente = lsExpediente.Where(x => x.IdExpediente == RegistroExistente.IdExpediente).FirstOrDefault();

                    var tipoActo = catActos.Where(x => x.TextoActo == miExpediente.TextoActo).FirstOrDefault();


                    if (tipoActo != null)
                    {
                        frmExpedienteExistente.FindItemOrGroupByName("TapAP").ClientVisible = tipoActo.TapAP;
                        frmExpedienteExistente.FindItemOrGroupByName("TapProyecto").ClientVisible = tipoActo.TapProyecto;
                        frmExpedienteExistente.FindItemOrGroupByName("TapFirmas").ClientVisible = tipoActo.TapFirmas;
                        frmExpedienteExistente.FindItemOrGroupByName("TapEscritura").ClientVisible = tipoActo.TapEscritura;
                        frmExpedienteExistente.FindItemOrGroupByName("TapAD").ClientVisible = tipoActo.TapAD;
                        frmExpedienteExistente.FindItemOrGroupByName("TapEntrega").ClientVisible = tipoActo.TapEntrega;
                        frmExpedienteExistente.FindItemOrGroupByName("TapContabilidad").ClientVisible = tipoActo.TapContabilidad;
                        frmExpedienteExistente.FindItemOrGroupByName("TapPLD").ClientVisible = tipoActo.TapPLD;


                    }






                    //Expediente 
                    txtNumExpediente.Text = RegistroExistente.IdExpediente;

                    txtExfnOtorga.Text = RegistroExistente.Otorga;
                    txtEXfnAfavorde.Text = RegistroExistente.AfavorDe;
                    txtExfnUbicacionPredio.Text = RegistroExistente.UbicacionPredio;

                    //Aviso preventivo
                    dtAPfnFechaElaboracion.Date = RegistroExistente.FechaElaboracion;
                    dtAPfnFechaEnvioAlRPP.Date = RegistroExistente.FechaEnvioRPP;
                    chkAPfnEsTramitePorSistema.Checked = RegistroExistente.EsTramitePorSistema;
                    dtAPfnFechaPagoBoleta.Date = RegistroExistente.FechaPagoBoleta;
                    dtAPfnFechaRecibido.Date = RegistroExistente.FechaRecibidoRPP;

                    //Proyecto
                    cbPRfnProyectista.Value = RegistroExistente.NombreProyectista;
                    cbPRfnProyectista.SelectedIndex = catProyectistas.FindIndex(w => w.usNombre  == RegistroExistente.NombreProyectista);

                    dtPRfnFechaAsignacionProyectista.Date = RegistroExistente.FechaAsignacionProyectista;
                    dtPRfnFechaPrevistaTermino.Date = RegistroExistente.FechaPrevistaTerminoProyectista;
                    dtPRfnFechaAvisoPreventivo.Date = RegistroExistente.FechaAvisoPreventivo;



                    //Firmas
                    txtFIfnNotasFirmas.Text = RegistroExistente.NotasFirma;
                    txtFIfnNumEscritura.Value = RegistroExistente.Escritura;
                    txtFIfnNumVolumen.Value = RegistroExistente.Volumen;
                    chkFIfnAplicaTraslado.Checked = RegistroExistente.AplicaTraslado;
                    dtFIfnFechaRecepcionTerminoEscritura.Date = RegistroExistente.FechaRecepcionTerminoEscritura;
                    dtFirmaTraslado.Value = RegistroExistente.FirmaDeTraslado;
                    fnFechaOtorgamiento.Value = RegistroExistente.FechaDeOtorgamiento;

                    //Aviso definitivo
                    dtAdfnFechaElaboracion.Date = RegistroExistente.FechaElaboracionDefinitivo;
                    dtAdfnFechaEnvioRPP.Date = RegistroExistente.FechaEnvioRPPDefinitivo;
                    chkAdfnEsTramitePorSistema.Checked = RegistroExistente.EsTramitePorSistemaDefinitivo;
                    dtAdfnFechaPagoBoleta.Date = RegistroExistente.FechaPagoBoletaDefinitivo;
                    dtAdfnFechaRecibido.Date = RegistroExistente.FechaRecibidoRPPDefinitivo;

                    //Escrituracion 
                    dtEsfnRecibioTraslado.Date = RegistroExistente.FechaRecibioTraslado;
                    dtAdfnFechaAsignacionMesa.Date = RegistroExistente.FechaAsignacionMesa;
                    dtAdfnFechaTerminoTramite.Date = RegistroExistente.FechaTerminoMesa;
                    dtFechaAutorizacion.Value = RegistroExistente.FechaAutorizacion;

                    //Entregas
                    txtEnfnObservacionesEntrega.Text = RegistroExistente.ObservacionesEngrega;
                    chkEnfnRegistroSolicitado.Checked = RegistroExistente.RegistroEntrega;
                    dtEnfnFechaRegistro.Date = RegistroExistente.FechaRegistroEntrega;
                    dtEnfnFechaBoletaPago.Date = RegistroExistente.FechaBoletaPagoRegistroEntrega;
                    dtEnfnFechaRegresoRegistro.Date = RegistroExistente.FechaRegresoRegistro;
                    dtEnfnFechaSalida.Date = RegistroExistente.FechaSalida;
                    txtEnfnObservacionesSobreTramiteTerminado.Text = RegistroExistente.ObservacionesTramiteTerminado;


                    //Contabilidad

                    txtContISR.Value = RegistroExistente.ISR;
                    txtContISRCalculado.Value = RegistroExistente.ISRcalculado;
                    txtContAvaluoCatastral.Value = RegistroExistente.AvaluoCatastral;
                    txtContAvaluoComercial.Value = RegistroExistente.AvaluoComercial;
                    txtContAvaluoFiscal.Value = RegistroExistente.AvaluoFiscal;
                    txtPRfnValorOperacion.Value = RegistroExistente.ValorOperacion;
                    fnFechaAvaluo.Value = RegistroExistente.FechaDeAvaluo;
                    fnFechaPagoAvaluo.Value = RegistroExistente.FechaPagoAvaluo;




                    //PLD

                    txtPldActividadVulnerable.Value = RegistroExistente.ActividadVulnerable;


                }


                return;
            }

            if (e.Parameter == "guardarCambios")
            {
                if (RegistroExistente != null)
                {


                    //2024-10-01 Vh Listado de reglas a considerar antes del guardado

                    // 1.0 si el expediente es >= Estado EN1 no se permite el guardado por ningun perfil que no sea direccion o coordinacion.


                    if (UsuarioPagina.NombrePerfil.Trim() == "Mesas")
                    {
                        // determinamos el valos del estado EN1
                        var ValorEnI = catEstatusFull.Where(x => x.IdEstatus == "EN1").First();

                        //determinamos el valor del estatus del proyecto

                        var ValorExpediente = catEstatusFull.Where(x => x.IdEstatus == RegistroExistente.IdEstatus).First();

                        if (ValorExpediente.Orden >= ValorEnI.Orden)
                        {
                            // no se permite ser moficado por el perfil
                            ppEditarExpediente.JSProperties["cp_swMsg"] = "El expediente se encuentra en un estatus: " + ValorExpediente.TextoEstatus.Trim() +
                                                                          " No es permitido realizar modificaciones con tu perfil";
                            ppEditarExpediente.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning;
                            return;

                        }


                    }

                    //2025-01-20 bitacora de cambios
                    // registro de cambios OJo tratar de mantener el orden de campos y el mismo numero de registros

                    #region Validacion de Cambios LOG

                    BitacoraExpediente logCambios = new BitacoraExpediente();

                    logCambios.UsuarioImplicado = UsuarioPagina.usNombre ;
                    logCambios.IdExpediente = RegistroExistente.IdExpediente;
                    logCambios.NombreModulo = "Expediente";


                    if (RegistroExistente.Otorga != txtExfnOtorga.Text)
                    {
                        logCambios.NombreCampo = "Ortorga";
                        logCambios.ValorOriginal = RegistroExistente.Otorga;
                        logCambios.ValorImputado = txtExfnOtorga.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.UbicacionPredio != txtExfnUbicacionPredio.Text)
                    {
                        logCambios.NombreCampo = "Ubicacion de predio";
                        logCambios.ValorOriginal = RegistroExistente.UbicacionPredio;
                        logCambios.ValorImputado = txtExfnUbicacionPredio.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }


                    //Aviso preventivo

                    if (RegistroExistente.FechaElaboracion != dtAPfnFechaElaboracion.Date)
                    {
                        logCambios.NombreCampo = "Aviso preventivo-Elaboracion";
                        logCambios.ValorOriginal = RegistroExistente.FechaElaboracion.ToString();
                        logCambios.ValorImputado = dtAPfnFechaElaboracion.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaEnvioRPP != dtAPfnFechaEnvioAlRPP.Date)
                    {
                        logCambios.NombreCampo = "Aviso preventivo-Envio al R.P.P.";
                        logCambios.ValorOriginal = RegistroExistente.FechaEnvioRPP.ToString();
                        logCambios.ValorImputado = dtAPfnFechaEnvioAlRPP.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.EsTramitePorSistema != chkAPfnEsTramitePorSistema.Checked)
                    {
                        logCambios.NombreCampo = "Aviso preventivo-Es tramite por sistema";
                        logCambios.ValorOriginal = RegistroExistente.EsTramitePorSistema.ToString();
                        logCambios.ValorImputado = chkAPfnEsTramitePorSistema.Checked.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaPagoBoleta != dtAPfnFechaPagoBoleta.Date)
                    {
                        logCambios.NombreCampo = "Aviso preventivo-Pago de la boleta";
                        logCambios.ValorOriginal = RegistroExistente.FechaPagoBoleta.ToString();
                        logCambios.ValorImputado = dtAPfnFechaPagoBoleta.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaRecibidoRPP != dtAPfnFechaRecibido.Date)
                    {
                        logCambios.NombreCampo = "Aviso preventivo-Recibido";
                        logCambios.ValorOriginal = RegistroExistente.FechaRecibidoRPP.ToString();
                        logCambios.ValorImputado = dtAPfnFechaRecibido.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }



                    //Proyecto

                    if (RegistroExistente.NombreProyectista != (cbPRfnProyectista.Value == null ? "" : cbPRfnProyectista.Value.ToString()))
                    {
                        logCambios.NombreCampo = "Proyecto-Proyectista";
                        logCambios.ValorOriginal = RegistroExistente.NombreProyectista;
                        logCambios.ValorImputado = (cbPRfnProyectista.Value == null ? "" : cbPRfnProyectista.Value.ToString());
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaAsignacionProyectista != dtPRfnFechaAsignacionProyectista.Date)
                    {
                        logCambios.NombreCampo = "Proyecto-Asignacion";
                        logCambios.ValorOriginal = RegistroExistente.FechaAsignacionProyectista.ToString();
                        logCambios.ValorImputado = dtPRfnFechaAsignacionProyectista.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);

                    }
                    if (RegistroExistente.FechaPrevistaTerminoProyectista != dtPRfnFechaPrevistaTermino.Date)
                    {
                        logCambios.NombreCampo = "Proyecto-Prevision de termino";
                        logCambios.ValorOriginal = RegistroExistente.FechaPrevistaTerminoProyectista.ToString();
                        logCambios.ValorImputado = dtPRfnFechaPrevistaTermino.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaAvisoPreventivo != dtPRfnFechaAvisoPreventivo.Date)
                    {
                        logCambios.NombreCampo = "Proyecto-Aviso Preventivo";
                        logCambios.ValorOriginal = RegistroExistente.FechaAvisoPreventivo.ToString();
                        logCambios.ValorImputado = dtPRfnFechaAvisoPreventivo.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }




                    //Firmas

                    if (RegistroExistente.NotasFirma != txtFIfnNotasFirmas.Text)
                    {
                        logCambios.NombreCampo = "Firmas-Notas";
                        logCambios.ValorOriginal = RegistroExistente.NotasFirma;
                        logCambios.ValorImputado = txtFIfnNotasFirmas.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.Escritura != (txtFIfnNumEscritura.Value == null ? 0 : Convert.ToInt32(txtFIfnNumEscritura.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Firmas-Num Escritura";
                        logCambios.ValorOriginal = RegistroExistente.Escritura.ToString();
                        logCambios.ValorImputado = (txtFIfnNumEscritura.Value == null ? 0 : Convert.ToInt32(txtFIfnNumEscritura.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.Volumen != (txtFIfnNumVolumen.Value == null ? 0 : Convert.ToInt32(txtFIfnNumVolumen.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Firmas-Num Volumen";
                        logCambios.ValorOriginal = RegistroExistente.Volumen.ToString();
                        logCambios.ValorImputado = (txtFIfnNumVolumen.Value == null ? 0 : Convert.ToInt32(txtFIfnNumVolumen.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.AplicaTraslado != chkFIfnAplicaTraslado.Checked)
                    {
                        logCambios.NombreCampo = "Firmas-Aplica traslado";
                        logCambios.ValorOriginal = RegistroExistente.AplicaTraslado.ToString();
                        logCambios.ValorImputado = chkFIfnAplicaTraslado.Checked.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaRecepcionTerminoEscritura != dtFIfnFechaRecepcionTerminoEscritura.Date)
                    {
                        logCambios.NombreCampo = "Firmas-Recepcion para termino escritura";
                        logCambios.ValorOriginal = RegistroExistente.FechaRecepcionTerminoEscritura.ToString();
                        logCambios.ValorImputado = dtFIfnFechaRecepcionTerminoEscritura.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.FirmaDeTraslado != dtFirmaTraslado.Date)
                    {
                        logCambios.NombreCampo = "Firmas-Firma Traslado";
                        logCambios.ValorOriginal = RegistroExistente.FirmaDeTraslado.ToString();
                        logCambios.ValorImputado = dtFirmaTraslado.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.FechaDeOtorgamiento != fnFechaOtorgamiento.Date)
                    {
                        logCambios.NombreCampo = "Firmas-Fecha Otorgamiento";
                        logCambios.ValorOriginal = RegistroExistente.FechaDeOtorgamiento.ToString();
                        logCambios.ValorImputado = fnFechaOtorgamiento.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }




                    //Aviso definitivo

                    if (RegistroExistente.FechaElaboracionDefinitivo != dtAdfnFechaElaboracion.Date)
                    {
                        logCambios.NombreCampo = "Aviso definitivo-Elaboracion";
                        logCambios.ValorOriginal = RegistroExistente.FechaElaboracionDefinitivo.ToString();
                        logCambios.ValorImputado = dtAdfnFechaElaboracion.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaEnvioRPPDefinitivo != dtAdfnFechaEnvioRPP.Date)
                    {
                        logCambios.NombreCampo = "Aviso definitivo-Envio R.P.P.";
                        logCambios.ValorOriginal = RegistroExistente.FechaEnvioRPPDefinitivo.ToString();
                        logCambios.ValorImputado = dtAdfnFechaEnvioRPP.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.EsTramitePorSistemaDefinitivo != chkAdfnEsTramitePorSistema.Checked)
                    {
                        logCambios.NombreCampo = "Aviso definitivo-Tramite por sistema";
                        logCambios.ValorOriginal = RegistroExistente.EsTramitePorSistemaDefinitivo.ToString();
                        logCambios.ValorImputado = chkAdfnEsTramitePorSistema.Checked.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaPagoBoletaDefinitivo != dtAdfnFechaPagoBoleta.Date)
                    {
                        logCambios.NombreCampo = "Aviso definitivo-Pago boleta";
                        logCambios.ValorOriginal = RegistroExistente.FechaPagoBoletaDefinitivo.ToString();
                        logCambios.ValorImputado = dtAdfnFechaPagoBoleta.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaRecibidoRPPDefinitivo != dtAdfnFechaRecibido.Date)
                    {
                        logCambios.NombreCampo = "Aviso definitivo-Recibido";
                        logCambios.ValorOriginal = RegistroExistente.FechaRecibidoRPPDefinitivo.ToString();
                        logCambios.ValorImputado = dtAdfnFechaRecibido.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }



                    //Escrituracion 

                    if (RegistroExistente.FechaRecibioTraslado != dtEsfnRecibioTraslado.Date)
                    {
                        logCambios.NombreCampo = "Escrituracion-Recibio traslado";
                        logCambios.ValorOriginal = RegistroExistente.FechaRecibioTraslado.ToString();
                        logCambios.ValorImputado = dtEsfnRecibioTraslado.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaAsignacionMesa != dtAdfnFechaAsignacionMesa.Date)
                    {
                        logCambios.NombreCampo = "Escrituracion-Asignacion a mesa";
                        logCambios.ValorOriginal = RegistroExistente.FechaAsignacionMesa.ToString();
                        logCambios.ValorImputado = dtAdfnFechaAsignacionMesa.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaTerminoMesa != dtAdfnFechaTerminoTramite.Date)
                    {
                        logCambios.NombreCampo = "Escrituracion-Termino del tramite";
                        logCambios.ValorOriginal = RegistroExistente.FechaTerminoMesa.ToString();
                        logCambios.ValorImputado = dtAdfnFechaTerminoTramite.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaAutorizacion != dtFechaAutorizacion.Date)
                    {
                        logCambios.NombreCampo = "Escrituracion-Fecha de Autorizacion";
                        logCambios.ValorOriginal = RegistroExistente.FechaAutorizacion.ToString();
                        logCambios.ValorImputado = dtFechaAutorizacion.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }


                    //Entregas


                    if (RegistroExistente.ObservacionesEngrega != txtEnfnObservacionesEntrega.Text)
                    {
                        logCambios.NombreCampo = "Entregas-Observaciones";
                        logCambios.ValorOriginal = RegistroExistente.ObservacionesEngrega;
                        logCambios.ValorImputado = txtEnfnObservacionesEntrega.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.RegistroEntrega != chkEnfnRegistroSolicitado.Checked)
                    {
                        logCambios.NombreCampo = "Entregas-¿Requiere Registro?";
                        logCambios.ValorOriginal = RegistroExistente.RegistroEntrega.ToString();
                        logCambios.ValorImputado = chkEnfnRegistroSolicitado.Checked.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaRegistroEntrega != dtEnfnFechaRegistro.Date)
                    {
                        logCambios.NombreCampo = "Entregas-Registro";
                        logCambios.ValorOriginal = RegistroExistente.FechaRegistroEntrega.ToString();
                        logCambios.ValorImputado = dtEnfnFechaRegistro.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaBoletaPagoRegistroEntrega != dtEnfnFechaBoletaPago.Date)
                    {
                        logCambios.NombreCampo = "Entregas-Boleta Pago";
                        logCambios.ValorOriginal = RegistroExistente.FechaBoletaPagoRegistroEntrega.ToString();
                        logCambios.ValorImputado = dtEnfnFechaBoletaPago.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaRegresoRegistro != dtEnfnFechaRegresoRegistro.Date)
                    {
                        logCambios.NombreCampo = "Entregas-Regreso registro";
                        logCambios.ValorOriginal = RegistroExistente.FechaRegresoRegistro.ToString();
                        logCambios.ValorImputado = dtEnfnFechaRegresoRegistro.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.FechaSalida != dtEnfnFechaSalida.Date)
                    {
                        logCambios.NombreCampo = "Entregas-Salida";
                        logCambios.ValorOriginal = RegistroExistente.FechaSalida.ToString();
                        logCambios.ValorImputado = dtEnfnFechaSalida.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.ObservacionesTramiteTerminado != txtEnfnObservacionesSobreTramiteTerminado.Text)
                    {
                        logCambios.NombreCampo = "Entregas-Observaciones del tramite terminado";
                        logCambios.ValorOriginal = RegistroExistente.ObservacionesTramiteTerminado;
                        logCambios.ValorImputado = txtEnfnObservacionesSobreTramiteTerminado.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }



                    //Contabilidad 

                    if (RegistroExistente.ISR != (txtContISR.Value == null ? 0 : Convert.ToDecimal(txtContISR.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-I.S.R.";
                        logCambios.ValorOriginal = RegistroExistente.ISR.ToString();
                        logCambios.ValorImputado = (txtContISR.Value == null ? 0 : Convert.ToDecimal(txtContISR.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.ISRcalculado != (txtContISRCalculado.Value == null ? 0 : Convert.ToDecimal(txtContISRCalculado.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-I.S.R. Calculado";
                        logCambios.ValorOriginal = RegistroExistente.ISRcalculado.ToString();
                        logCambios.ValorImputado = (txtContISRCalculado.Value == null ? 0 : Convert.ToDecimal(txtContISRCalculado.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.AvaluoCatastral != (txtContAvaluoCatastral.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoCatastral.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-Avaluo Catastral";
                        logCambios.ValorOriginal = RegistroExistente.AvaluoCatastral.ToString();
                        logCambios.ValorImputado = (txtContAvaluoCatastral.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoCatastral.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.AvaluoFiscal != (txtContAvaluoFiscal.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoFiscal.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-Avaluo Fiscal";
                        logCambios.ValorOriginal = RegistroExistente.AvaluoFiscal.ToString();
                        logCambios.ValorImputado = (txtContAvaluoFiscal.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoFiscal.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }
                    if (RegistroExistente.AvaluoComercial != (txtContAvaluoComercial.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoComercial.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-Avaluo Comercial";
                        logCambios.ValorOriginal = RegistroExistente.AvaluoComercial.ToString();
                        logCambios.ValorImputado = (txtContAvaluoComercial.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoComercial.Value.ToString())).ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.ValorOperacion != (txtPRfnValorOperacion.Value == null ? 0 : Convert.ToDecimal(txtPRfnValorOperacion.Value.ToString())))
                    {
                        logCambios.NombreCampo = "Contabilidad-Valor Operacion";
                        logCambios.ValorOriginal = RegistroExistente.ValorOperacion.ToString();
                        logCambios.ValorImputado = (txtPRfnValorOperacion.Value == null ? "" : txtPRfnValorOperacion.Value.ToString());
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.FechaDeAvaluo != fnFechaAvaluo.Date)
                    {
                        logCambios.NombreCampo = "Contabilidad-Fecha de Avaluo";
                        logCambios.ValorOriginal = RegistroExistente.FechaDeAvaluo.ToString();
                        logCambios.ValorImputado = fnFechaAvaluo.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    if (RegistroExistente.FechaPagoAvaluo != fnFechaPagoAvaluo.Date)
                    {
                        logCambios.NombreCampo = "Contabilidad-Fecha pago Avaluo";
                        logCambios.ValorOriginal = RegistroExistente.FechaPagoAvaluo.ToString();
                        logCambios.ValorImputado = fnFechaPagoAvaluo.Date.ToString();
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    //PLD


                    if (RegistroExistente.ActividadVulnerable != txtPldActividadVulnerable.Text)
                    {
                        logCambios.NombreCampo = "PLD-Actividad Vulnerable";
                        logCambios.ValorOriginal = RegistroExistente.ActividadVulnerable;
                        logCambios.ValorImputado = txtPldActividadVulnerable.Text;
                        datosCrud.AltaBitacoraExpediente(logCambios);
                    }

                    // guardar  bitacora de cambios






                    #endregion



                    RegistroExistente.Otorga = txtExfnOtorga.Text;
                    RegistroExistente.AfavorDe = txtEXfnAfavorde.Text;

                    RegistroExistente.UbicacionPredio = txtExfnUbicacionPredio.Text;


                    //Aviso preventivo
                    RegistroExistente.FechaElaboracion = dtAPfnFechaElaboracion.Date;
                    RegistroExistente.FechaEnvioRPP = dtAPfnFechaEnvioAlRPP.Date;
                    RegistroExistente.EsTramitePorSistema = chkAPfnEsTramitePorSistema.Checked;
                    RegistroExistente.FechaPagoBoleta = dtAPfnFechaPagoBoleta.Date;
                    RegistroExistente.FechaRecibidoRPP = dtAPfnFechaRecibido.Date;

                    //Proyecto
                    RegistroExistente.NombreProyectista = cbPRfnProyectista.Value == null ? "" : cbPRfnProyectista.Value.ToString();
                    RegistroExistente.FechaAsignacionProyectista = dtPRfnFechaAsignacionProyectista.Date;
                    RegistroExistente.FechaPrevistaTerminoProyectista = dtPRfnFechaPrevistaTermino.Date;
                    RegistroExistente.FechaAvisoPreventivo = dtPRfnFechaAvisoPreventivo.Date;


                    //Firmas
                    RegistroExistente.NotasFirma = txtFIfnNotasFirmas.Text;
                    RegistroExistente.Escritura = txtFIfnNumEscritura.Value == null ? 0 : Convert.ToInt32(txtFIfnNumEscritura.Value.ToString()); // validar nulos
                    RegistroExistente.Volumen = txtFIfnNumVolumen.Value == null ? 0 : Convert.ToInt32(txtFIfnNumVolumen.Value.ToString());
                    RegistroExistente.AplicaTraslado = chkFIfnAplicaTraslado.Checked;
                    RegistroExistente.FechaRecepcionTerminoEscritura = dtFIfnFechaRecepcionTerminoEscritura.Date;
                    RegistroExistente.FirmaDeTraslado = dtFirmaTraslado.Date;
                    RegistroExistente.FechaDeOtorgamiento = fnFechaOtorgamiento.Date;


                    //Aviso definitivo
                    RegistroExistente.FechaElaboracionDefinitivo = dtAdfnFechaElaboracion.Date;
                    RegistroExistente.FechaEnvioRPPDefinitivo = dtAdfnFechaEnvioRPP.Date;
                    RegistroExistente.EsTramitePorSistemaDefinitivo = chkAdfnEsTramitePorSistema.Checked;
                    RegistroExistente.FechaPagoBoletaDefinitivo = dtAdfnFechaPagoBoleta.Date;
                    RegistroExistente.FechaRecibidoRPPDefinitivo = dtAdfnFechaRecibido.Date;

                    //Escrituracion 
                    RegistroExistente.FechaRecibioTraslado = dtEsfnRecibioTraslado.Date;
                    RegistroExistente.FechaAsignacionMesa = dtAdfnFechaAsignacionMesa.Date;
                    RegistroExistente.FechaTerminoMesa = dtAdfnFechaTerminoTramite.Date;
                    RegistroExistente.FechaAutorizacion = dtFechaAutorizacion.Date;

                    //Entregas
                    RegistroExistente.ObservacionesEngrega = txtEnfnObservacionesEntrega.Text;
                    RegistroExistente.RegistroEntrega = chkEnfnRegistroSolicitado.Checked;
                    RegistroExistente.FechaRegistroEntrega = dtEnfnFechaRegistro.Date;
                    RegistroExistente.FechaBoletaPagoRegistroEntrega = dtEnfnFechaBoletaPago.Date;
                    RegistroExistente.FechaRegresoRegistro = dtEnfnFechaRegresoRegistro.Date;
                    RegistroExistente.FechaSalida = dtEnfnFechaSalida.Date;
                    RegistroExistente.ObservacionesTramiteTerminado = txtEnfnObservacionesSobreTramiteTerminado.Text;


                    //Contabilidad 
                    RegistroExistente.ISR = txtContISR.Value == null ? 0 : Convert.ToDecimal(txtContISR.Value.ToString());
                    RegistroExistente.ISRcalculado = txtContISRCalculado.Value == null ? 0 : Convert.ToDecimal(txtContISRCalculado.Value.ToString());
                    RegistroExistente.AvaluoCatastral = txtContAvaluoCatastral.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoCatastral.Value.ToString());
                    RegistroExistente.AvaluoFiscal = txtContAvaluoFiscal.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoFiscal.Value.ToString());
                    RegistroExistente.AvaluoComercial = txtContAvaluoComercial.Value == null ? 0 : Convert.ToDecimal(txtContAvaluoComercial.Value.ToString());
                    RegistroExistente.ValorOperacion = txtPRfnValorOperacion.Value == null ? 0 : Convert.ToDecimal(txtPRfnValorOperacion.Value.ToString());
                    RegistroExistente.FechaDeAvaluo = fnFechaAvaluo.Date;
                    RegistroExistente.FechaPagoAvaluo = fnFechaPagoAvaluo.Date;

                    //PLD

                    RegistroExistente.ActividadVulnerable = txtPldActividadVulnerable.Text;

                    if (datosCrud.ActualizarExpediente(RegistroExistente))
                    {
                        ppEditarExpediente.JSProperties["cp_swMsg"] = "Registro Modificado!";
                        ppEditarExpediente.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;

                    }
                    else
                    {

                        ppEditarExpediente.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar Modificar el registro.";
                        ppEditarExpediente.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;

                    }

                }
                return;
            }
        }

        protected void trlEstatusExpedientes_DataBinding(object sender, EventArgs e)
        {
            trlEstatusExpedientes.DataSource = catEstatus.OrderBy(x => x.Orden);
            trlEstatusExpedientes.ExpandAll();
        }



        protected void cbExfnActo_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.ValueField = "IdActo";
            control.TextField = "TextoActo";
            control.DataSource = catActos;
        }

        protected void cbPRfnProyectista_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox control = (ASPxComboBox)sender;

            control.ValueField = "usNombre";
            control.TextField = "usNombre";
            control.DataSource = catProyectistas;

        }
        void ApplyRules(FileManagerFolder folder)
        {
            FileManagerFolder[] folders = folder.GetFolders();



            for (int i = 0; i < folders.Length; i++)
            {
                FileManagerFolderAccessRule folderEditingRule = new FileManagerFolderAccessRule(folders[i].RelativeName);
                folderEditingRule.Edit = Rights.Deny;
                FileManagerFolderAccessRule folderContentEditingRule = new FileManagerFolderAccessRule(folders[i].RelativeName);
                folderContentEditingRule.EditContents = Rights.Allow;

                //ASPxFileManager1.SettingsPermissions.AccessRules.Add(folderEditingRule);
                //ASPxFileManager1.SettingsPermissions.AccessRules.Add(folderContentEditingRule);

                ApplyRules(folders[i]);
            }
        }

        FileManagerFolder root = null;
        FileManagerFolder GetRootFolder(FileManagerFolder folder)
        {


            if (folder.Parent == null)
            {
                root = folder;
            }
            else
            {
                GetRootFolder(folder.Parent);
            }

            return root;
        }


        protected void ppArchivos_WindowCallback(object source, PopupWindowCallbackArgs e)
        {

        }

        protected void fmArchivosControl_CustomThumbnail(object source, FileManagerThumbnailCreateEventArgs e)
        {
            if (e.File == null)
            {
                return;
            }

            switch (((FileManagerFile)e.Item).Extension)
            {
                case ".pdf":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/application-pdf-2.ico";
                    break;
                case ".doc":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-document.ico";
                    break;
                case ".docx":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-document.ico";
                    break;
                case ".xlsx":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-spreadsheet.ico";
                    break;
                case ".xls":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-spreadsheet.ico";
                    break;
                case ".png":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".txt":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/text-x-generic.ico";
                    break;
                case ".rtf":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".gif":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".jpeg":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".jpg":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
            }
        }

        protected void gvAlertas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Alertas nuevaAlerta = new Alertas();
            nuevaAlerta.IdAlerta = 0;
            nuevaAlerta.NumExpediente = NumExpSelccionadoAlerta;
            nuevaAlerta.FechaAlta = DateTime.Now;
            nuevaAlerta.AlertaActiva = true;
            nuevaAlerta.NomUsuarioInformante = UsuarioPagina.usNombre ;
            nuevaAlerta.MensajeAlerta = e.NewValues["MensajeAlerta"].ToString();
            nuevaAlerta.Prioridad = "";



            // guardamos en BD

            datosCrud.AltaAlertas(nuevaAlerta);

            lsAlertas = datosExpediente.DameAlertasPorExpediente(NumExpSelccionadoAlerta).OrderByDescending(x => x.IdAlerta).ToList();


            // actualiozamos el control 

            e.Cancel = true;
            gvAlertas.CancelEdit();

            gvAlertas.DataBind();
        }


        protected void gvAlertas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //Validar si existen cambios de lo contrario no es necesario actulizar nada
            Boolean existenCambios = false;

            foreach (DictionaryEntry item in e.OldValues)
            {
                if (e.NewValues.Contains(item.Key))
                {
                    if (e.NewValues[item.Key] != null && !e.NewValues[item.Key].Equals(item.Value))
                    {
                        existenCambios = true;
                    }
                }
            }

            if (existenCambios == false)
            {
                e.Cancel = true;
                return;
            }


            var miAlerta = lsAlertas.Where(x => x.IdAlerta == int.Parse(e.Keys[0].ToString())).First();

            if (miAlerta != null)
            {
                miAlerta.MensajeAlerta = e.NewValues["MensajeAlerta"].ToString();
                miAlerta.AlertaActiva = Convert.ToBoolean(e.NewValues["AlertaActiva"].ToString());

                if (miAlerta.AlertaActiva == false)
                {
                    miAlerta.NomUsuarioCierra = UsuarioPagina.usNombre;
                }

            }

            datosCrud.ActualizarAlerta(miAlerta);


            lsAlertas = datosExpediente.DameAlertasPorExpediente(NumExpSelccionadoAlerta).OrderByDescending(x => x.IdAlerta).ToList();


            // actualiozamos el control 

            e.Cancel = true;
            gvAlertas.CancelEdit();

            gvAlertas.DataBind();


        }


        #endregion

        protected void ppEditarAvisoNotarial_WindowCallback(object source, PopupWindowCallbackArgs e)
        {
          

            if (e.Parameter.Contains("CargarRegistros"))
            {
                RegistroExistente = new Expedientes();
                RegistroAvisoNotarial = new DatosAvisoNotarial();

                ListaHojaDatos DetalleExpediente = new ListaHojaDatos();


                string numExpediente = e.Parameter.Split('~')[1].ToString();

                RegistroExistente = datosCrud.ConsultaExpediente(numExp: numExpediente);
                RegistroAvisoNotarial = datosCrud.ConsultaDatosAvisoNotarial(numExp: numExpediente);
                DetalleExpediente = datosExpediente.DameHojaDatosDetalle(idHojaDatosdate: RegistroExistente.IdHojaDatos);

                // validamos si es un acto valido para aviso


                if (DetalleExpediente.ReqTraslado==false)
                {

                    ppEditarAvisoNotarial.JSProperties["cp_swMsg"] = "Este Expediente/Acto no está habilitado para poder generar Avisos, contacta  a tu coordinador , para resolver tus dudas.";
                    ppEditarAvisoNotarial.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.warning ;
                        return;
                }


                dtAnFechaUltimoPago.Date = DateTime.Now;
                txtAnNaturalezaActoAdquisicion.Text = DetalleExpediente.TextoActo;

                if (RegistroExistente != null && DetalleExpediente != null)
                {




                    // carga de registros de Expediente

                    txtAnFolioSistena.Text = RegistroExistente.IdExpediente;
                    dtAnFechaOtorgamiento.Date = RegistroExistente.FechaDeOtorgamiento;
                    txtAnEscritura.Text = RegistroExistente.Escritura.ToString();
                    txtAnEscrituraVolumen.Text = RegistroExistente.Volumen.ToString();
                    txtAnUbicacion.Text = RegistroExistente.UbicacionPredio.ToString();
                    txtAnValorOperacionFiscal.Text = RegistroExistente.ValorOperacion.ToString();

                   


                    decimal maxAvaluo = Math.Max(Math.Max(RegistroExistente.AvaluoCatastral, RegistroExistente.AvaluoComercial), RegistroExistente.AvaluoFiscal);

                    string nombreCompradores = "";
                    string nombreVendedores = "";

                    string domicilioCompradores = "";
                    string domicilioVendedores = "";

                    txtAnValorAvaluo.Text = maxAvaluo.ToString();
                    dtAnFechaAvaluo.Date = RegistroExistente.FechaDeAvaluo;





                    foreach (var item in DetalleExpediente.DetalleParticipantes.Where(x => x.FiguraOperacion == "Otorga o Solicita" && x.RolOperacion.Trim() == "Vendedor (a)")) // vendedor
                    {
                        nombreVendedores = nombreVendedores + " " + item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + Environment.NewLine;

                        domicilioVendedores = domicilioVendedores + " Domicilio: " + item.Domicilio + " Numero Exterior: " + item.NumeroExterior + " Numero Interior: " + item.NumeroInterior + " Colonia: " + item.Colonia + " Municipio: " + item.Municipio + " Estado: " + item.Estado + " Pais: " + item.PaisDomicilio + Environment.NewLine;

                    }

                    if (nombreVendedores.Length>0)
                    {
                        nombreVendedores = nombreVendedores.Substring(0, nombreVendedores.Length - 1);
                    }

                    if (domicilioVendedores.Length>0)
                    {
                        domicilioVendedores = domicilioVendedores.Substring(0, domicilioVendedores.Length - 1);
                    }

     


                    foreach (var item in DetalleExpediente.DetalleParticipantes.Where(x => x.FiguraOperacion == "A favor de" && x.RolOperacion.Trim() == "Comprador (a)")) // comprador
                    {

                        nombreCompradores = nombreCompradores + " " + item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + Environment.NewLine;

                        domicilioCompradores = domicilioCompradores + " Domicilio: " + item.Domicilio + " Numero Exterior: " + item.NumeroExterior + " Numero Interior: " + item.NumeroInterior + " Colonia: " + item.Colonia + " Municipio: " + item.Municipio + " Estado: " + item.Estado + " Pais: " + item.PaisDomicilio + Environment.NewLine;

                    }

                    if (nombreCompradores.Length>0)
                    {
                        nombreCompradores = nombreCompradores.Substring(0, nombreCompradores.Length - 1);
                    }
                    if (domicilioCompradores.Length > 0)
                    {

                        domicilioCompradores = domicilioCompradores.Substring(0, domicilioCompradores.Length - 1);
                    }





                    txtAnContraVendedores.Text = nombreVendedores;
                    txtAnContraCompradores.Text = nombreCompradores;

                    txtAnDomiciVededores.Text = domicilioVendedores;
                    txtAnDomiciCompradores.Text = domicilioCompradores;




                    //carga datos de Aviso

                    txtAnClaveCatrastal.Text = RegistroAvisoNotarial.ClaveCatastral;
                    txtAnInstitucionPracticoAvaluo.Text = RegistroAvisoNotarial.InstitucionPracticoAvaluo;
                    txtAnNaturalezaActoAdquisicion.Text = RegistroAvisoNotarial.NaturalezaActoConceptoAdquisicion;
                    txtAnSuperficie.Text = RegistroAvisoNotarial.DatCatastroSuperficie.ToString();
                    txtAnVendida.Text = RegistroAvisoNotarial.DatCatastroVendida.ToString();
                    txtAnRestante.Text = RegistroAvisoNotarial.DatCatastroRestante.ToString();
                    txtAnConstruida.Text = RegistroAvisoNotarial.DatCatastroConstruida.ToString();
                    txtAnPlantas.Text = RegistroAvisoNotarial.DatCatastroPlantas.ToString();


                    txtAnPartida.Text = RegistroAvisoNotarial.DatDiNoRePuPartida;
                    txtAnFojas.Text = RegistroAvisoNotarial.DatDiNoRePuFojas;
                    txtAnSeccion.Text = RegistroAvisoNotarial.DatDiNoRePuSeccion;
                    txtAnVolumen.Text = RegistroAvisoNotarial.DatDiNoRePuVolumen;
                    txtAnDistrito.Text = RegistroAvisoNotarial.DatDiNoRePuDistrito;
                    txtAnFolioRealElectronico.Text = RegistroAvisoNotarial.DatDiNoRePuFolioRealElectronico;
                    txtAnSelloRegistral.Text = RegistroAvisoNotarial.DatDiNoRePuSelloRegistral;



                    txtAnUbicacionDescripcionBienes.Text = RegistroAvisoNotarial.UbicacionDescripcionDeLosBienes;
                    txtAnMedidasColindancias.Text = RegistroAvisoNotarial.MedidasColindancias;
                    txtAnObservacionesAclaraciones.Text = RegistroAvisoNotarial.ObservacionesAclaraciones;



                    txtAnReciboPagoImpuestaPre.Text = RegistroAvisoNotarial.ReciboPagoImpuestoPredial;

                    // Validar si FechaUltimoPago es una fecha válida, si no, asignar la fecha de hoy
                    if (RegistroAvisoNotarial.FechaUltimoPago == DateTime.MinValue || RegistroAvisoNotarial.FechaUltimoPago == default(DateTime))
                    {
                        dtAnFechaUltimoPago.Date = DateTime.Now;
                    }
                    else
                    {
                        dtAnFechaUltimoPago.Date = RegistroAvisoNotarial.FechaUltimoPago;
                    }


                    txtAnUbiCalle.Text = RegistroAvisoNotarial.UbiPredioCalle;
                    txtAnUbiNumero.Text = RegistroAvisoNotarial.UbiPredioNumero;
                    txtAnUbiColonia.Text = RegistroAvisoNotarial.UbiPredioColonia;
                    txtAnUbiEstado.Text = RegistroAvisoNotarial.UbiPredioEstado;
                    txtAnUbiMunicipio.Text = RegistroAvisoNotarial.UbiPredioMunicipio;
                    txtAnUbiLocalidad.Text = RegistroAvisoNotarial.UbiPredioLocalidad;
                    txtAnUbiObservaciones.Text = RegistroAvisoNotarial.ObservacionesSolicitudPropiedad;




                }






                return;
            }

            if (e.Parameter.Contains("guardarCambios"))
            {

                string numExpediente = e.Parameter.Split('~')[1].ToString();

                if (RegistroAvisoNotarial != null)
                {
                    RegistroAvisoNotarial = new DatosAvisoNotarial();

                    RegistroAvisoNotarial.ClaveCatastral = txtAnClaveCatrastal.Text;
                    RegistroAvisoNotarial.InstitucionPracticoAvaluo = txtAnInstitucionPracticoAvaluo.Text;
                    RegistroAvisoNotarial.NaturalezaActoConceptoAdquisicion = txtAnNaturalezaActoAdquisicion.Text;
                    RegistroAvisoNotarial.DatCatastroSuperficie = string.IsNullOrWhiteSpace(txtAnSuperficie.Text) ? 0 : Convert.ToDecimal(txtAnSuperficie.Text);
                    RegistroAvisoNotarial.DatCatastroVendida = string.IsNullOrWhiteSpace(txtAnVendida.Text) ? 0 : Convert.ToDecimal(txtAnVendida.Text);
                    RegistroAvisoNotarial.DatCatastroRestante = string.IsNullOrWhiteSpace(txtAnRestante.Text) ? 0 : Convert.ToDecimal(txtAnRestante.Text);
                    RegistroAvisoNotarial.DatCatastroConstruida = string.IsNullOrWhiteSpace(txtAnConstruida.Text) ? 0 : Convert.ToDecimal(txtAnConstruida.Text);
                    RegistroAvisoNotarial.DatCatastroPlantas = string.IsNullOrWhiteSpace(txtAnPlantas.Text) ? 0 : Convert.ToDecimal(txtAnPlantas.Text);

                    RegistroAvisoNotarial.DatDiNoRePuPartida = txtAnPartida.Text;
                    RegistroAvisoNotarial.DatDiNoRePuFojas = txtAnFojas.Text;
                    RegistroAvisoNotarial.DatDiNoRePuSeccion = txtAnSeccion.Text;
                    RegistroAvisoNotarial.DatDiNoRePuVolumen = txtAnVolumen.Text;
                    RegistroAvisoNotarial.DatDiNoRePuDistrito = txtAnDistrito.Text;
                    RegistroAvisoNotarial.DatDiNoRePuFolioRealElectronico = txtAnFolioRealElectronico.Text;
                    RegistroAvisoNotarial.DatDiNoRePuSelloRegistral = txtAnSelloRegistral.Text;

                    RegistroAvisoNotarial.UbicacionDescripcionDeLosBienes = txtAnUbicacionDescripcionBienes.Text;
                    RegistroAvisoNotarial.MedidasColindancias = txtAnMedidasColindancias.Text;
                    RegistroAvisoNotarial.ObservacionesAclaraciones = txtAnObservacionesAclaraciones.Text;

                    RegistroAvisoNotarial.ReciboPagoImpuestoPredial = txtAnReciboPagoImpuestaPre.Text;
                    RegistroAvisoNotarial.FechaUltimoPago = dtAnFechaUltimoPago.Date;

                    RegistroAvisoNotarial.UbiPredioCalle = txtAnUbiCalle.Text;
                    RegistroAvisoNotarial.UbiPredioNumero = txtAnUbiNumero.Text;
                    RegistroAvisoNotarial.UbiPredioColonia = txtAnUbiColonia.Text;
                    RegistroAvisoNotarial.UbiPredioEstado = txtAnUbiEstado.Text;
                    RegistroAvisoNotarial.UbiPredioMunicipio = txtAnUbiMunicipio.Text;
                    RegistroAvisoNotarial.UbiPredioLocalidad = txtAnUbiLocalidad.Text;
                    RegistroAvisoNotarial.ObservacionesSolicitudPropiedad = txtAnUbiObservaciones.Text;


                }

                // Guardar Cambios


                if (RegistroAvisoNotarial.IdExpediente!="")
                {

                    if (datosCrud.ActualizarDatosAvisoNotarial(RegistroAvisoNotarial))
                    {
                        ppEditarAvisoNotarial.JSProperties["cp_swMsg"] = "Registro Modificado!";
                        ppEditarAvisoNotarial.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;

                    }
                    else
                    {

                        ppEditarAvisoNotarial.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar Modificar el registro.";
                        ppEditarAvisoNotarial.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;

                    }

                }
                else
                {



                    RegistroAvisoNotarial.IdExpediente = numExpediente;





                    if (datosCrud.AltaDatosAvisoNotarial(RegistroAvisoNotarial))
                    {
                        ppEditarAvisoNotarial.JSProperties["cp_swMsg"] = "Datos del Aviso actualizados..!";
                        ppEditarAvisoNotarial.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.success;

                    }
                    else
                    {

                        ppEditarAvisoNotarial.JSProperties["cp_swMsg"] = "Ocurrio un error al intentar Modificar el registro.";
                        ppEditarAvisoNotarial.JSProperties["cp_swType"] = Controles.Usuario.InfoMsgBox.tipoMsg.error;

                    }

                }





                return;








            }

        }
    }
}