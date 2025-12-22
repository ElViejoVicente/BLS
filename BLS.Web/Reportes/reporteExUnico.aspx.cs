using System;
using DevExpress.XtraReports.UI;
using BLS.Negocio.ExpedienteUnico;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using BLS.Negocio.Expediente;
using BLS.Negocio.ORM;

namespace BLS.Web.Reportes
{
    public partial class reporteExUnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosExpedienteUnico datosExpedienteUnico = new DatosExpedienteUnico();
            DatosExpedientes datosExpedientes = new DatosExpedientes();

            if (!IsPostBack)
            {

                string idRegistroCliente = Server.UrlEncode(Request.QueryString["idRegistro"]);
                ListaExpedienteUnico datosReporte = new ListaExpedienteUnico();

                datosReporte = datosExpedienteUnico.DameExpedienteUnico(int.Parse(idRegistroCliente));

                Negocio.Reportes.dsExpedienteUnico.ExpedienteUnicoDataTable dtExUnico = new Negocio.Reportes.dsExpedienteUnico.ExpedienteUnicoDataTable();

                Negocio.Reportes.dsExpedienteUnico origen = new Negocio.Reportes.dsExpedienteUnico();



                origen.ExpedienteUnico.AddExpedienteUnicoRow(
                        IdExpediente: datosReporte.IdExpediente, IdEstatus: datosReporte.IdEstatus, TextoEstatus: datosReporte.TextoEstatus,
                    TextoActo: datosReporte.TextoEstatus, FechaIngreso: datosReporte.FechaIngreso, TextoVariante: datosReporte.TextoVariante,
                    RequiereExUnico: datosReporte.RequiereExUnico, IdRegistro: datosReporte.IdRegistro, IdHojaDatos: datosReporte.IdHojaDatos,
                    FiguraOperacion: datosReporte.FiguraOperacion, RolOperacion: datosReporte.RolOperacion, Nombres: datosReporte.Nombres,
                    ApellidoPaterno: datosReporte.ApellidoPaterno, ApellidoMaterno: datosReporte.ApellidoMaterno, FechaNacimiento: datosReporte.FechaNacimiento,
                    Sexo: datosReporte.Sexo, Ocupacion: datosReporte.Ocupacion, EstadoCivil: datosReporte.EstadoCivil, RegimenConyugal: datosReporte.RegimenConyugal,
                    SabeLeerEscribir: datosReporte.SabeLeerEscribir, Notas: datosReporte.Notas, TipoRegimen: datosReporte.TipoRegimen,
                    PaisNacimiento: datosReporte.PaisNacimiento, PaisNacionalidad: datosReporte.PaisNacionalidad, Domicilio: datosReporte.Domicilio,
                    NumeroExterior: datosReporte.NumeroExterior, NumeroInterior: datosReporte.NumeroInterior, Colonia: datosReporte.Colonia,
                    Municipio: datosReporte.Municipio, Ciudad: datosReporte.Ciudad, Estado: datosReporte.Estado, PaisDomicilio: datosReporte.PaisDomicilio,
                    CP: datosReporte.CP, NumeroTefonico: datosReporte.NumeroTefonico, CorreoElectronico: datosReporte.CorreoElectronico, Curp: datosReporte.Curp,
                    Rfc: datosReporte.Rfc, NombreIdentificacionID: datosReporte.NombreIdentificacionID, AutoridadEmiteID: datosReporte.AutoridadEmiteID,
                    NumeroSerieID: datosReporte.NumeroSerieID, RazonSocial: datosReporte.RazonSocial, FechaConstitucion: datosReporte.FechaConstitucion,
                    PaisRazonSocial: datosReporte.PaisRazonSocial, ActividadRazonSocial: datosReporte.ActividadRazonSocial, SeValidoEnListaNegra: datosReporte.SeValidoEnListaNegra,
                    FechaPrimeraValidacion: datosReporte.FechaPrimeraValidacion, ObsePrimeraValidacion: datosReporte.ObsePrimeraValidacion,
                    FechaSegundaValicacion: datosReporte.FechaSegundaValicacion, ObseSegundaValidacion: datosReporte.ObseSegundaValidacion, Resumen: datosReporte.Resumen,
                    ResumenIdentificacion: datosReporte.NombreIdentificacionID+","+ datosReporte.AutoridadEmiteID+","+datosReporte.NumeroSerieID,datosReporte.IdFideicomiso
                    );


                Expedientes expedientes = datosExpedientes.ConsultaExpedienteXHojaDatos(datosReporte.IdHojaDatos);

                XtraReport reporte = new XtraReport();
                reporte.CreateDocument();
                XtraExUnicoPersonaFisica exUnicoPerFisica = new XtraExUnicoPersonaFisica();
                XtraExUnicoPersonaMoral exUnicoPerMoral = new XtraExUnicoPersonaMoral();
                XtraExUnicoApoderado exUnicoApoderado = new XtraExUnicoApoderado();
                XtraExUnicoFideicomiso exUnicoFideicomiso = new XtraExUnicoFideicomiso();



                if (datosReporte.TipoRegimen== "Fisica")
                {
                    exUnicoPerFisica.DataSource = origen;
                    exUnicoPerFisica.RequestParameters = false;
                    exUnicoPerFisica.Parameters["ActividadVulnerable"].Value = " "+expedientes.ActividadVulnerable+" ";
                    exUnicoPerFisica.Parameters["Anio"].Value = DateTime.Now.Year;
                    exUnicoPerFisica.Parameters["Asesor"].Value = "";
                    exUnicoPerFisica.Parameters["Dia"].Value = DateTime.Now.Day ;
                    exUnicoPerFisica.Parameters["Mes"].Value = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
                    exUnicoPerFisica.Parameters["NumEscritura"].Value = " "+expedientes.Escritura.ToString()+" ";
                    exUnicoPerFisica.Parameters["Volumen"].Value = " " + expedientes.Volumen.ToString() + " ";
                    exUnicoPerFisica.CreateDocument();
                    reporte.Pages.AddRange(exUnicoPerFisica.Pages);

                }


                if (datosReporte.TipoRegimen == "Moral")
                {
                    exUnicoPerMoral.DataSource = origen;
                    exUnicoPerMoral.RequestParameters = false;
                    exUnicoPerMoral.Parameters["ActividadVulnerable"].Value = " " + expedientes.ActividadVulnerable + " ";
                    exUnicoPerMoral.Parameters["Anio"].Value = DateTime.Now.Year;
                    exUnicoPerMoral.Parameters["Asesor"].Value = "";
                    exUnicoPerMoral.Parameters["Dia"].Value = DateTime.Now.Day;
                    exUnicoPerMoral.Parameters["Mes"].Value = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
                    exUnicoPerMoral.Parameters["NumEscritura"].Value = " " + expedientes.Escritura.ToString() + " ";
                    exUnicoPerMoral.Parameters["Volumen"].Value = " " + expedientes.Volumen.ToString() + " ";
                    exUnicoPerMoral.CreateDocument();
                    reporte.Pages.AddRange(exUnicoPerMoral.Pages);

                }


                if (datosReporte.TipoRegimen == "Apoderado")
                {
                    exUnicoApoderado.DataSource = origen;
                    exUnicoApoderado.RequestParameters = false;
                    exUnicoApoderado.Parameters["ActividadVulnerable"].Value = " " + expedientes.ActividadVulnerable + " ";
                    exUnicoApoderado.Parameters["Anio"].Value = DateTime.Now.Year;
                    exUnicoApoderado.Parameters["Asesor"].Value = "";
                    exUnicoApoderado.Parameters["Dia"].Value = DateTime.Now.Day;
                    exUnicoApoderado.Parameters["Mes"].Value = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
                    exUnicoApoderado.Parameters["NumEscritura"].Value = " " + expedientes.Escritura.ToString() + " ";
                    exUnicoApoderado.Parameters["Volumen"].Value = expedientes.Volumen.ToString();
                    exUnicoApoderado.CreateDocument();
                    reporte.Pages.AddRange(exUnicoApoderado.Pages);

                }

                if (datosReporte.TipoRegimen == "Fideicomiso")
                {
                    exUnicoFideicomiso.DataSource = origen;
                    exUnicoFideicomiso.RequestParameters = false;
                    exUnicoFideicomiso.Parameters["ActividadVulnerable"].Value = " " + expedientes.ActividadVulnerable + " ";
                    exUnicoFideicomiso.Parameters["Anio"].Value = DateTime.Now.Year;
                    exUnicoFideicomiso.Parameters["Asesor"].Value = "";
                    exUnicoFideicomiso.Parameters["Dia"].Value = DateTime.Now.Day;
                    exUnicoFideicomiso.Parameters["Mes"].Value = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
                    exUnicoFideicomiso.Parameters["NumEscritura"].Value = " " + expedientes.Escritura.ToString() + " ";
                    exUnicoFideicomiso.Parameters["Volumen"].Value = expedientes.Volumen.ToString();
                    exUnicoFideicomiso.CreateDocument();
                    reporte.Pages.AddRange(exUnicoFideicomiso.Pages);

                }


                reportePrinsipalView.OpenReport(reporte);

            }

        }
    }
}