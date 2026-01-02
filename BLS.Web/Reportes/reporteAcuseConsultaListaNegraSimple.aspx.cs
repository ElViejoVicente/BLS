using DevExpress.XtraReports.UI;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Reportes
{
    public partial class reporteAcuseConsultaListaNegraSimple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //DatosExpedienteUnico datosExpedienteUnico = new DatosExpedienteUnico();
            //DatosExpedientes datosExpedientes = new DatosExpedientes();

            if (!IsPostBack)
            {


                // datos de la busqueda

                //ListaConsultaBasicaLN sseDetalleBusqueda = new ListaConsultaBasicaLN();
                //sseDetalleBusqueda = (ListaConsultaBasicaLN)this.Session["sseDetalleBusqueda"];


                //List<ListaNegraSAT> infListaNegra = new List<ListaNegraSAT>();
         
                //infListaNegra = datosExpedienteUnico.DameRfcEnListaNegra(RFC: sseDetalleBusqueda.Rfc , NombreUsuarioConsulta: sseDetalleBusqueda.NombreUsuarioConsulta);




                //Negocio.Reportes.dsDetConsListaNegra listaNegraDetalle = new Negocio.Reportes.dsDetConsListaNegra();



                //if (infListaNegra.First().SitucacionContribuyente == "Presunto")
                //{
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Presunto", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalPresun, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDOF);
                //}

                //if (infListaNegra.First().SitucacionContribuyente == "Desvirtuado")
                //{
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Presunto", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalPresun, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDOF);
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Desvirtuado", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalDesvirtuaron, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDesvirtuaronDof);
                //}


                //if (infListaNegra.First().SitucacionContribuyente == "Definitivo")
                //{
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Presunto", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalPresun, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDOF);
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Definitivo", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalDefinitivos, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDefinitivosDof);
                //}


                //if (infListaNegra.First().SitucacionContribuyente == "Sentencia Favorable")
                //{
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Presunto", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalPresun, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalDOF);
                //    listaNegraDetalle.DetalleListaNegra.AddDetalleListaNegraRow(Estatus: "Sentencia Favorable", NumOficioFechaSAT: infListaNegra.First().NumFechaOficioGlobalSentencioFavorable, NumOficioFechaDOF: infListaNegra.First().NumFechaOficioGlobalSentenciaFavorableDof);
                //}







                //XtraReport reporte = new XtraReport();
                //reporte.CreateDocument();
                //XtraAcuseConsultaListaNegra exAcuseListaNegra = new XtraAcuseConsultaListaNegra();



                //if (infListaNegra.Count > 0)
                //{
                //    exAcuseListaNegra.DataSource = listaNegraDetalle;
                //    exAcuseListaNegra.RequestParameters = false;
                //    exAcuseListaNegra.Parameters["NumExpediente"].Value = "----";
                //    exAcuseListaNegra.Parameters["EstatusConsulta"].Value = infListaNegra.First().SitucacionContribuyente;

                //    if (infListaNegra.FirstOrDefault().SitucacionContribuyente == "Busqueda sin resultados.")
                //    {
                //        exAcuseListaNegra.Parameters["TituloResultadoConsulta"].Value = "No se encontraron registro de la persona en Lista Negra";
                //        exAcuseListaNegra.Parameters["Nombre"].Value = sseDetalleBusqueda.Nombres + " " + sseDetalleBusqueda.ApellidoPaterno + " " + sseDetalleBusqueda.ApellidoMaterno;
                //    }
                //    else
                //    {
                //        exAcuseListaNegra.Parameters["TituloResultadoConsulta"].Value = "Persona encontrada en la lista Artículo 69-B del CFF";
                //        exAcuseListaNegra.Parameters["Nombre"].Value = infListaNegra.First().NombreContribuyente;
                //    }


                //    exAcuseListaNegra.Parameters["Folio"].Value = infListaNegra.First().NoFolio;

                //    exAcuseListaNegra.Parameters["Rfc"].Value = infListaNegra.First().RFC;
                //    exAcuseListaNegra.Parameters["FechaDatosLN"].Value = infListaNegra.First().FechaDatos;
                //    exAcuseListaNegra.Parameters["FechaConsulta"].Value = infListaNegra.First().FechaConsulta;
                //    exAcuseListaNegra.CreateDocument();
                //    reporte.Pages.Add(exAcuseListaNegra.Pages[0]);
                //}



                //reportePrinsipalView.OpenReport(reporte);

            }

        }
    }
}