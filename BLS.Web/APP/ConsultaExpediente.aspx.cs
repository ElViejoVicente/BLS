using System;
using System.Text;
using System.Web.UI;
using DevExpress.Web;
using BLS.Negocio.APP;

namespace BLS.Web.APP
{
    public partial class ConsultaExpediente : System.Web.UI.Page
    {

        protected void cpConsultaFolio_Callback(object sender, CallbackEventArgsBase e)
        {
            string mensajeRespuesta = string.Empty;
            try
            {
                string folio = e.Parameter?.Trim() ?? "";

                DatosAPP datosApp = new DatosAPP();

                var resultadoConsulta = datosApp.ConsultaMiFolio(folio);

                if (resultadoConsulta != null)
                {
                    // Extraer valores de forma segura
                    string fecha = Convert.ToString(resultadoConsulta.FechaUltimoTratamiento);
                    string estatusId = Convert.ToString(resultadoConsulta.IdEstatus);
                    string descripcion = Convert.ToString(resultadoConsulta.Descripcion);

                    // Construir mensaje con saltos de línea e iconos
                    var sb = new StringBuilder();
                    sb.AppendLine($"📅 Fecha de último tratamiento: {fecha}");
                    sb.AppendLine($"✅ Estatus (ID): {estatusId}");
                    sb.AppendLine($"📝 Descripción: {descripcion}");
                    sb.AppendLine();
                    sb.AppendLine("ℹ️ Si necesita más detalles, contacte al área correspondiente.");

                    mensajeRespuesta = sb.ToString();
                }
                else
                {
                    // Mensaje cuando no se encuentra el folio
                    mensajeRespuesta = $"❗ No se encontró información para el folio '{folio}'.{Environment.NewLine}Por favor verifique el número e inténtelo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                // Mensaje amistoso en caso de error
                mensajeRespuesta = $"❗ Ocurrió un error al consultar el folio. {Environment.NewLine}Por favor intente de nuevo más tarde.";
                // Loguear la excepción en el sistema de logging si existe (no mostrado aquí).
            }

            // Asignar resultado al control de interfaz (usa saltos de línea)
            txtEstatusFolio.Text = mensajeRespuesta;
        }
    }
}