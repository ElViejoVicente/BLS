using DevExpress.XtraReports.UI;
using BLS.Negocio.Expediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using DevExpress.DataAccess.ObjectBinding;

namespace BLS.Web.Reportes
{
    public partial class reporteHojaDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosExpedientes datosExpediente = new DatosExpedientes();


            if (!Page.IsPostBack)
            {
                string idHojaDatos = Server.UrlEncode(Request.QueryString["idHojaDatos"]);
                string numReciboPagoIni = "";

                //consultamos los datos de la hoja de datos para tenerlos en la memoria del reporte.
                ListaHojaDatos datosReporte = new ListaHojaDatos();


                datosReporte = datosExpediente.DameHojaDatosDetalle(Convert.ToInt32(idHojaDatos));

                if (datosReporte.DetalleRecibosPago.Where(x => x.Concepto == "Recibo Inicial Expediente")!=null)
                {
                    if (datosReporte.DetalleRecibosPago.Where(x => x.Concepto == "Recibo Inicial Expediente").ToList().Count>0)
                    {
                        numReciboPagoIni = datosReporte.DetalleRecibosPago.Where(x => x.Concepto == "Recibo Inicial Expediente").FirstOrDefault().NumRecibo;
                    }
                }


                // se rellenan los abjetos a el dataSet


                //Negocio.Reportes.dsHojaDatos.HojaDatosDataTable dtHojaDatos =
                //    new Negocio.Reportes.dsHojaDatos.HojaDatosDataTable();

                Negocio.Reportes.dsHojaDatos origen = new Negocio.Reportes.dsHojaDatos();

                origen.HojaDatos.AddHojaDatosRow(datosReporte.IdEstatus, datosReporte.TextoEstatus, datosReporte.IdHojaDatos, datosReporte.numExpediente,
                    datosReporte.NombreAsesor, datosReporte.FechaIngreso, datosReporte.FechaCompleto, datosReporte.IdUsuarioResponsable, datosReporte.IdEquipoResponsable,
                    datosReporte.NumbreUsuarioTramita, datosReporte.NumTelCelular1, datosReporte.NumTelCelular2, datosReporte.CorreoElectronico, datosReporte.TextoActo,
                    datosReporte.TextoVariante, datosReporte.Otorga, datosReporte.AfavorDe, numReciboPagoIni);


                // se rellenan los dt de los prticipantes
                foreach (var item in datosReporte.DetalleParticipantes.Where(x=> x.FiguraOperacion== "Otorga o Solicita").ToList())
                {
                    origen.DatosParticipantesOtorga.AddDatosParticipantesOtorgaRow(item.IdRegistro, item.IdHojaDatos, item.FiguraOperacion, item.RolOperacion,
                        item.Nombres, item.ApellidoPaterno, item.ApellidoMaterno, item.FechaNacimiento, item.Sexo, item.Ocupacion, item.EstadoCivil,
                        item.RegimenConyugal, item.SabeLeerEscribir, item.Notas);
                }

                foreach (var item in datosReporte.DetalleParticipantes.Where(x => x.FiguraOperacion == "A favor de").ToList())
                {
                    origen.DatosParticipantesAfavorDe.AddDatosParticipantesAfavorDeRow(item.IdRegistro, item.IdHojaDatos, item.FiguraOperacion, item.RolOperacion,
                     item.Nombres, item.ApellidoPaterno, item.ApellidoMaterno, item.FechaNacimiento, item.Sexo, item.Ocupacion, item.EstadoCivil,
                     item.RegimenConyugal, item.SabeLeerEscribir, item.Notas);
                }


                // se rellenando los DT de los documentos


                foreach (var item in datosReporte.DetalleDocumentosOtorgSolicita)
                {
                    origen.DatosDocumentosOtorga.AddDatosDocumentosOtorgaRow(item.IdRegistro, item.IdHojaDatos, item.IdVariente, item.TextoVariante,
                        item.TextoFigura, item.IdDoc, item.TextoDocumento, item.Observaciones);

                }


                foreach (var item in datosReporte.DetalleDocumentosAfavorDe)
                {

                    origen.DatosDocumentosAfavorDe.AddDatosDocumentosAfavorDeRow(item.IdRegistro, item.IdHojaDatos, item.IdVariente, item.TextoVariante,
                        item.TextoFigura, item.IdDoc, item.TextoDocumento, item.Observaciones);

                }




                XtraReport report = new XtraReport();
                report.CreateDocument();
                XtraHojaDatos hojaDatos = new XtraHojaDatos();
                XtraHojaDatosSoloOtorga hojaDatosSinAfavor = new XtraHojaDatosSoloOtorga();
                XtraHojaDatosSoloFavorDe hojaDatosSinOtorga = new XtraHojaDatosSoloFavorDe();


                XtraTraslados traslados = new XtraTraslados();
                XtraTrasladosSoloOtorga trasladosSinAfavor = new XtraTrasladosSoloOtorga();
                XtraTrasladosSoloFavorDe trasladosSinOtorga = new XtraTrasladosSoloFavorDe();


                if (origen.DatosParticipantesAfavorDe.Count==0 & origen.DatosDocumentosAfavorDe.Count ==0)
                {
                    hojaDatosSinAfavor.DataSource = origen;
                    hojaDatosSinAfavor.RequestParameters = false;
                    hojaDatosSinAfavor.CreateDocument();

                    report.Pages.AddRange(hojaDatosSinAfavor.Pages);

                    if (datosReporte.ReqTraslado)
                    {
                        trasladosSinAfavor.DataSource = origen;
                        trasladosSinAfavor.RequestParameters = false;
                        trasladosSinAfavor.CreateDocument();

                        report.Pages.AddRange(trasladosSinAfavor.Pages);
                    }


                }
                else if (origen.DatosParticipantesOtorga.Count == 0 & origen.DatosDocumentosOtorga.Count==0  )
                {
                    hojaDatosSinOtorga.DataSource = origen;
                    hojaDatosSinOtorga.RequestParameters = false;
                    hojaDatosSinOtorga.CreateDocument();

                    report.Pages.AddRange(hojaDatosSinOtorga.Pages);

                    if (datosReporte.ReqTraslado)
                    {
                        trasladosSinOtorga.DataSource = origen;
                        trasladosSinOtorga.RequestParameters = false;
                        trasladosSinOtorga.CreateDocument();

                        report.Pages.AddRange(trasladosSinOtorga.Pages);

                    }



    
          
                }
                else
                {

                    hojaDatos.DataSource = origen;
                    hojaDatos.RequestParameters = false;
                    hojaDatos.CreateDocument();

                    report.Pages.AddRange(hojaDatos.Pages);


                    if (datosReporte.ReqTraslado)
                    {

                        traslados.DataSource = origen;
                        traslados.RequestParameters = false;
                        traslados.CreateDocument();
                        report.Pages.AddRange(traslados.Pages);
                    }







                }


                reportePrinsipalView.OpenReport(report);
            }
        }
    }
}