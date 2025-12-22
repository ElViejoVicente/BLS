using DevExpress.Web.Bootstrap.Internal;
using DevExpress.XtraReports.UI;
using BLS.Negocio.CRUD;
using BLS.Negocio.Expediente;
using BLS.Negocio.ExpedienteUnico;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Reportes
{
    public partial class reporteAvisoNotarial : System.Web.UI.Page
    {
        DatosCrud datosCrud = new DatosCrud();
        DatosExpedientes datosExpediente = new DatosExpedientes();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {


                string numExpediente = Server.UrlEncode(Request.QueryString["idExpediente"]);


                // falta consulta de datos para llenar parametros del reporte

                Expedientes RegistroExistente = new Expedientes();
                DatosAvisoNotarial RegistroAvisoNotarial = new DatosAvisoNotarial();
                ListaHojaDatos DetalleExpediente = new ListaHojaDatos();


                RegistroExistente = datosCrud.ConsultaExpediente(numExp: numExpediente);
                RegistroAvisoNotarial = datosCrud.ConsultaDatosAvisoNotarial(numExp: numExpediente);
                DetalleExpediente = datosExpediente.DameHojaDatosDetalle(idHojaDatosdate: RegistroExistente.IdHojaDatos);


                if (RegistroAvisoNotarial==null)
                {
                    throw new Exception("No cuenta con los datos minimos para poder generar el reporte : Aviso Notarial.."); 
                }



                if (RegistroExistente != null && DetalleExpediente != null && RegistroAvisoNotarial != null)
                {
                    XtraReport reporte = new XtraReport();
                    reporte.CreateDocument();

                    XtraAvisoNotarialHoja1 exAvisoHoja1 = new XtraAvisoNotarialHoja1();
                    XtraAvisoNotarialHoja2 exAvisoHoja2 = new XtraAvisoNotarialHoja2();
                    XtraSolicitudPropiedadTerritorial exSolPropedadTerritorial = new XtraSolicitudPropiedadTerritorial();

                    string nombreCompradores = "";
                    string nombreVendedores = "";

                    string domicilioCompradores = "";
                    string domicilioVendedores = "";



                    exAvisoHoja1.RequestParameters = false;
                    exAvisoHoja2.RequestParameters = false;
                    exSolPropedadTerritorial.RequestParameters = false;

                    exAvisoHoja1.Parameters["IdExpediente"].Value = RegistroExistente.IdExpediente;
                    exAvisoHoja1.Parameters["FechaDeOtorgamiento"].Value = RegistroExistente.FechaDeOtorgamiento.ToString("dd/MM/yyyy");
                    exAvisoHoja1.Parameters["Escritura"].Value = RegistroExistente.Escritura;
                    exAvisoHoja1.Parameters["Volumen"].Value = RegistroExistente.Volumen;
                    exAvisoHoja1.Parameters["UbicacionPredio"].Value = RegistroExistente.UbicacionPredio;
                    exAvisoHoja1.Parameters["ValorOperacion"].Value = RegistroExistente.ValorOperacion;
                    //exAvisoHoja1.Parameters["ISRcalculado"].Value = RegistroExistente.ISRcalculado;


                    decimal maxAvaluo = Math.Max(Math.Max(RegistroExistente.AvaluoCatastral, RegistroExistente.AvaluoComercial), RegistroExistente.AvaluoFiscal);

                    exAvisoHoja1.Parameters["ValorAvaluo"].Value = maxAvaluo;
                    exAvisoHoja1.Parameters["FechaDeAvaluo"].Value = RegistroExistente.FechaDeAvaluo.ToString("dd/MM/yyyy"); ;


                    foreach (var item in DetalleExpediente.DetalleParticipantes.Where(x => x.FiguraOperacion == "Otorga o Solicita" && x.RolOperacion.Trim() == "Vendedor (a)")) // vendedor
                    {
                        nombreVendedores = nombreVendedores + " " + item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + Environment.NewLine;

                        domicilioVendedores = domicilioVendedores + " Domicilio: " + item.Domicilio + " Numero Exterior: " + item.NumeroExterior + " Numero Interior: " + item.NumeroInterior + " Colonia: " + item.Colonia + " Municipio: " + item.Municipio + " Estado: " + item.Estado + " Pais: " + item.PaisDomicilio + Environment.NewLine;

                    }

                    if (nombreVendedores.Length > 0)
                    {
                        nombreVendedores = nombreVendedores.Substring(0, nombreVendedores.Length - 1);
                    }

                    if (domicilioVendedores.Length > 0)
                    {
                        domicilioVendedores = domicilioVendedores.Substring(0, domicilioVendedores.Length - 1);
                    }




                    foreach (var item in DetalleExpediente.DetalleParticipantes.Where(x => x.FiguraOperacion == "A favor de" && x.RolOperacion.Trim() == "Comprador (a)")) // comprador
                    {

                        nombreCompradores = nombreCompradores + " " + item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno + Environment.NewLine;

                        domicilioCompradores = domicilioCompradores + " Domicilio: " + item.Domicilio + " Numero Exterior: " + item.NumeroExterior + " Numero Interior: " + item.NumeroInterior + " Colonia: " + item.Colonia + " Municipio: " + item.Municipio + " Estado: " + item.Estado + " Pais: " + item.PaisDomicilio + Environment.NewLine;

                    }

                    if (nombreCompradores.Length > 0)
                    {
                        nombreCompradores = nombreCompradores.Substring(0, nombreCompradores.Length - 1);
                    }
                    if (domicilioCompradores.Length > 0)
                    {

                        domicilioCompradores = domicilioCompradores.Substring(0, domicilioCompradores.Length - 1);
                    }



                    exAvisoHoja1.Parameters["nombreVendedores"].Value = nombreVendedores;
                    exAvisoHoja1.Parameters["nombreCompradores"].Value = nombreCompradores;
                    exAvisoHoja1.Parameters["domicilioVendedores"].Value = domicilioVendedores;
                    exAvisoHoja1.Parameters["domicilioCompradores"].Value = domicilioCompradores;



                    exAvisoHoja1.Parameters["ClaveCatastral"].Value = RegistroAvisoNotarial.ClaveCatastral;
                    exAvisoHoja1.Parameters["InstitucionPracticoAvaluo"].Value = RegistroAvisoNotarial.InstitucionPracticoAvaluo;
                    exAvisoHoja1.Parameters["NaturalezaActoConceptoAdquisicion"].Value = RegistroAvisoNotarial.NaturalezaActoConceptoAdquisicion;
                    exAvisoHoja1.Parameters["DatCatastroSuperficie"].Value = RegistroAvisoNotarial.DatCatastroSuperficie.ToString();
                    exAvisoHoja1.Parameters["DatCatastroVendida"].Value = RegistroAvisoNotarial.DatCatastroVendida.ToString();
                    exAvisoHoja1.Parameters["DatCatastroRestante"].Value = RegistroAvisoNotarial.DatCatastroRestante.ToString();
                    exAvisoHoja1.Parameters["DatCatastroConstruida"].Value = RegistroAvisoNotarial.DatCatastroConstruida.ToString();
                    exAvisoHoja1.Parameters["DatCatastroPlantas"].Value = RegistroAvisoNotarial.DatCatastroPlantas.ToString();


                    exAvisoHoja1.Parameters["DatDiNoRePuPartida"].Value = RegistroAvisoNotarial.DatDiNoRePuPartida;
                    exAvisoHoja1.Parameters["DatDiNoRePuFojas"].Value = RegistroAvisoNotarial.DatDiNoRePuFojas;
                    exAvisoHoja1.Parameters["DatDiNoRePuSeccion"].Value = RegistroAvisoNotarial.DatDiNoRePuSeccion;
                    exAvisoHoja1.Parameters["DatDiNoRePuVolumen"].Value = RegistroAvisoNotarial.DatDiNoRePuVolumen;
                    exAvisoHoja1.Parameters["DatDiNoRePuDistrito"].Value = RegistroAvisoNotarial.DatDiNoRePuDistrito;
                    exAvisoHoja1.Parameters["DatDiNoRePuFolioRealElectronico"].Value = RegistroAvisoNotarial.DatDiNoRePuFolioRealElectronico;
                    exAvisoHoja1.Parameters["DatDiNoRePuSelloRegistral"].Value = RegistroAvisoNotarial.DatDiNoRePuSelloRegistral;



                    exAvisoHoja1.Parameters["UbicacionDescripcionDeLosBienes"].Value = RegistroAvisoNotarial.UbicacionDescripcionDeLosBienes;
                    exAvisoHoja1.Parameters["MedidasColindancias"].Value = RegistroAvisoNotarial.MedidasColindancias;
                    exAvisoHoja1.Parameters["ObservacionesAclaraciones"].Value = RegistroAvisoNotarial.ObservacionesAclaraciones;



                    exAvisoHoja1.Parameters["ReciboPagoImpuestoPredial"].Value = RegistroAvisoNotarial.ReciboPagoImpuestoPredial;
                    exAvisoHoja1.Parameters["FechaUltimoPago"].Value = RegistroAvisoNotarial.FechaUltimoPago.ToString("dd/MM/yyyy"); ;


                    exAvisoHoja1.Parameters["UbiPredioCalle"].Value = RegistroAvisoNotarial.UbiPredioCalle;
                    exAvisoHoja1.Parameters["UbiPredioNumero"].Value = RegistroAvisoNotarial.UbiPredioNumero;
                    exAvisoHoja1.Parameters["UbiPredioColonia"].Value = RegistroAvisoNotarial.UbiPredioColonia;
                    exAvisoHoja1.Parameters["UbiPredioEstado"].Value = RegistroAvisoNotarial.UbiPredioEstado;
                    exAvisoHoja1.Parameters["UbiPredioMunicipio"].Value = RegistroAvisoNotarial.UbiPredioMunicipio;
                    exAvisoHoja1.Parameters["UbiPredioLocalidad"].Value = RegistroAvisoNotarial.UbiPredioLocalidad;
                    exAvisoHoja1.Parameters["ObservacionesSolicitudPropiedad"].Value = RegistroAvisoNotarial.ObservacionesSolicitudPropiedad;


                    exAvisoHoja1.Parameters["AñoActual"].Value = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);

                    exAvisoHoja1.Parameters["FechaCompleta"].Value = "Huamantla Tlaxcala a " + DateTime.Now.Day.ToString() + " de " + DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX")) + " de " + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);


                    exAvisoHoja1.CreateDocument();





                    exAvisoHoja2.Parameters["IdExpediente"].Value = RegistroExistente.IdExpediente;
                    exAvisoHoja2.Parameters["FechaCompleta"].Value = "Huamantla Tlaxcala a " + DateTime.Now.Day.ToString() + " de " + DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX")) + " de " + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
                    exAvisoHoja2.Parameters["ObservacionesAclaraciones"].Value = RegistroAvisoNotarial.ObservacionesAclaraciones;
                    exAvisoHoja2.CreateDocument();





                    exSolPropedadTerritorial.Parameters["nombreVendedores"].Value = nombreVendedores;
                    exSolPropedadTerritorial.Parameters["IdExpediente"].Value = RegistroExistente.IdExpediente;
                    exSolPropedadTerritorial.Parameters["FechaDeOtorgamiento"].Value = RegistroExistente.FechaDeOtorgamiento.ToString("dd/MM/yyyy");
                    exSolPropedadTerritorial.Parameters["Escritura"].Value = RegistroExistente.Escritura;
                    exSolPropedadTerritorial.Parameters["Volumen"].Value = RegistroExistente.Volumen;
                    exSolPropedadTerritorial.Parameters["UbicacionPredio"].Value = RegistroExistente.UbicacionPredio;
                    exSolPropedadTerritorial.Parameters["ValorOperacion"].Value = RegistroExistente.ValorOperacion;
                    exSolPropedadTerritorial.Parameters["ValorAvaluo"].Value = maxAvaluo;
                    exSolPropedadTerritorial.Parameters["FechaDeAvaluo"].Value = RegistroExistente.FechaDeAvaluo.ToString("dd/MM/yyyy");
                    exSolPropedadTerritorial.Parameters["ClaveCatastral"].Value = RegistroAvisoNotarial.ClaveCatastral;
                    exSolPropedadTerritorial.Parameters["InstitucionPracticoAvaluo"].Value = RegistroAvisoNotarial.InstitucionPracticoAvaluo;
                    exSolPropedadTerritorial.Parameters["NaturalezaActoConceptoAdquisicion"].Value = RegistroAvisoNotarial.NaturalezaActoConceptoAdquisicion;
                    exSolPropedadTerritorial.Parameters["DatCatastroSuperficie"].Value = RegistroAvisoNotarial.DatCatastroSuperficie.ToString();
                    exSolPropedadTerritorial.Parameters["DatCatastroVendida"].Value = RegistroAvisoNotarial.DatCatastroVendida.ToString();
                    exSolPropedadTerritorial.Parameters["DatCatastroRestante"].Value = RegistroAvisoNotarial.DatCatastroRestante.ToString();
                    exSolPropedadTerritorial.Parameters["DatCatastroConstruida"].Value = RegistroAvisoNotarial.DatCatastroConstruida.ToString();
                    exSolPropedadTerritorial.Parameters["DatCatastroPlantas"].Value = RegistroAvisoNotarial.DatCatastroPlantas.ToString();
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuPartida"].Value = RegistroAvisoNotarial.DatDiNoRePuPartida;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuFojas"].Value = RegistroAvisoNotarial.DatDiNoRePuFojas;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuSeccion"].Value = RegistroAvisoNotarial.DatDiNoRePuSeccion;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuVolumen"].Value = RegistroAvisoNotarial.DatDiNoRePuVolumen;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuDistrito"].Value = RegistroAvisoNotarial.DatDiNoRePuDistrito;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuFolioRealElectronico"].Value = RegistroAvisoNotarial.DatDiNoRePuFolioRealElectronico;
                    exSolPropedadTerritorial.Parameters["DatDiNoRePuSelloRegistral"].Value = RegistroAvisoNotarial.DatDiNoRePuSelloRegistral;
                    exSolPropedadTerritorial.Parameters["UbicacionDescripcionDeLosBienes"].Value = RegistroAvisoNotarial.UbicacionDescripcionDeLosBienes;
                    exSolPropedadTerritorial.Parameters["MedidasColindancias"].Value = RegistroAvisoNotarial.MedidasColindancias;
                    exSolPropedadTerritorial.Parameters["ObservacionesAclaraciones"].Value = RegistroAvisoNotarial.ObservacionesAclaraciones;
                    exSolPropedadTerritorial.Parameters["ReciboPagoImpuestoPredial"].Value = RegistroAvisoNotarial.ReciboPagoImpuestoPredial;
                    exSolPropedadTerritorial.Parameters["FechaUltimoPago"].Value = RegistroAvisoNotarial.FechaUltimoPago.ToString("dd/MM/yyyy");
                    exSolPropedadTerritorial.Parameters["UbiPredioCalle"].Value = RegistroAvisoNotarial.UbiPredioCalle;
                    exSolPropedadTerritorial.Parameters["UbiPredioNumero"].Value = RegistroAvisoNotarial.UbiPredioNumero;
                    exSolPropedadTerritorial.Parameters["UbiPredioColonia"].Value = RegistroAvisoNotarial.UbiPredioColonia;
                    exSolPropedadTerritorial.Parameters["UbiPredioEstado"].Value = RegistroAvisoNotarial.UbiPredioEstado;
                    exSolPropedadTerritorial.Parameters["UbiPredioMunicipio"].Value = RegistroAvisoNotarial.UbiPredioMunicipio;
                    exSolPropedadTerritorial.Parameters["UbiPredioLocalidad"].Value = RegistroAvisoNotarial.UbiPredioLocalidad;
                    exSolPropedadTerritorial.Parameters["ObservacionesSolicitudPropiedad"].Value = RegistroAvisoNotarial.ObservacionesSolicitudPropiedad;
                    exSolPropedadTerritorial.Parameters["AñoActual"].Value = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
                    exSolPropedadTerritorial.Parameters["FechaCompleta"].Value = "Huamantla Tlaxcala a " + DateTime.Now.Day.ToString() + " de " + DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX")) + " de " + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);


                    exSolPropedadTerritorial.CreateDocument();




                    reporte.Pages.AddRange(exSolPropedadTerritorial.Pages);


                    reporte.Pages.AddRange(exAvisoHoja1.Pages);

                    reporte.Pages.AddRange(exAvisoHoja2.Pages);



                    reportePrinsipalView.OpenReport(reporte);


                }





            }

        }
    }
}