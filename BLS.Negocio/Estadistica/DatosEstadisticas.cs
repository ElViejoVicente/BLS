using Dapper;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Estadistica
{
    public class DatosEstadisticas
    {

        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];

        public List<ListaEstatusExpedientes > DameEstatusExpedientesXAnual(int anioConsulta)
        {
            try
            {
                List<ListaEstatusExpedientes> resultado = new List<ListaEstatusExpedientes>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaEstatusExpedientes>
                        (
                        sql: "sp_EstaditicaEstatusOperativaAnio", param: new
                        {
                            anioConsulta

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_EstaditicaEstatusOperativaAnio , detalle: \n" + ex.Message, ex);
            }
        }


    }
}
