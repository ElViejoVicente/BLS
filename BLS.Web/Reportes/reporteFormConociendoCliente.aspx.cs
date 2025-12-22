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
    public partial class reporteFormConociendoCliente : System.Web.UI.Page
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


                XtraReport reporte = new XtraReport();
                reporte.CreateDocument();

                XtraFormConocCliente exFormConocimientoCliente = new XtraFormConocCliente();

                exFormConocimientoCliente.RequestParameters = false;

                exFormConocimientoCliente.Parameters["ApellidoPaterno"].Value = datosReporte.ApellidoPaterno;
                exFormConocimientoCliente.Parameters["ApellidoMaterno"].Value = datosReporte.ApellidoMaterno;
                exFormConocimientoCliente.Parameters["Nombres"].Value = datosReporte.Nombres;
                exFormConocimientoCliente.Parameters["FechaNacimiento"].Value = datosReporte.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                exFormConocimientoCliente.Parameters["PaisNacimiento"].Value = datosReporte.PaisNacimiento;
                exFormConocimientoCliente.Parameters["PaisNacionalidad"].Value = datosReporte.PaisNacionalidad;
                exFormConocimientoCliente.Parameters["Ocupacion"].Value = datosReporte.Ocupacion;
                exFormConocimientoCliente.Parameters["SabeLeerEscribir"].Value = datosReporte.SabeLeerEscribir;
                exFormConocimientoCliente.Parameters["Domicilio"].Value = datosReporte.Domicilio;
                exFormConocimientoCliente.Parameters["NumeroExterior"].Value = datosReporte.NumeroExterior;
                exFormConocimientoCliente.Parameters["NumeroInterior"].Value = datosReporte.NumeroInterior;
                exFormConocimientoCliente.Parameters["Colonia"].Value = datosReporte.Colonia;
                exFormConocimientoCliente.Parameters["Municipio"].Value = datosReporte.Municipio;
                exFormConocimientoCliente.Parameters["Ciudad"].Value = datosReporte.Ciudad;
                exFormConocimientoCliente.Parameters["Estado"].Value = datosReporte.Estado;
                exFormConocimientoCliente.Parameters["CP"].Value = datosReporte.CP;
                exFormConocimientoCliente.Parameters["PaisDomicilio"].Value = datosReporte.PaisDomicilio;
                exFormConocimientoCliente.Parameters["FechaAplicacion"].Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture).ToLower();
                exFormConocimientoCliente.Parameters["NumExpediente"].Value= datosReporte.IdExpediente.ToString();


                exFormConocimientoCliente.CreateDocument();
                reporte.Pages.AddRange(exFormConocimientoCliente.Pages);

                reportePrinsipalView2.OpenReport(reporte);

            }

        }
    }
}