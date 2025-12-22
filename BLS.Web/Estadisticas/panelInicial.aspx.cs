using DevExpress.Spreadsheet.Charts;
using DevExpress.Utils;
using BLS.Negocio.Estadistica;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Estadisticas
{
    public partial class panelInicial : PageBase
    {
        DatosEstadisticas datosEstadisticas = new DatosEstadisticas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaDatos();


                
            }

        }

        private void CargaDatos()
        {
            // Aquí puedes cargar los datos necesarios para el panel inicial
            // Por ejemplo, cargar estadísticas, gráficos, etc.
            // chartEstadisticaActosSimple.DataSource = ObtenerDatosEstadisticos();
            // chartEstadisticaActosSimple.DataBind();

            chartEstadisticaActosSimple.ToolTipEnabled = DefaultBoolean.True;

            var serie = chartEstadisticaActosSimple.Series[0];

            serie.Points.Clear();

            chartEstadisticaActosSimple.Titles[0].Text = "";

           


            List<ListaEstatusExpedientes> listaEstatusExpedientes = new List<ListaEstatusExpedientes>();

            listaEstatusExpedientes= datosEstadisticas.DameEstatusExpedientesXAnual(DateTime.Now.Year);


            foreach (var item in listaEstatusExpedientes)
            {
                var punto = new DevExpress.XtraCharts.SeriesPoint(item.NombreEstatus , item.NumExpedientes );
                
                serie.Points.Add(punto);
            }




            return;

        }


        protected void chartEstadisticaActosSimple_CustomCallback(object sender, DevExpress.XtraCharts.Web.CustomCallbackEventArgs e)
        {

        }
    }
}