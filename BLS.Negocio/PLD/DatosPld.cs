using BLS.Negocio.Expediente;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLS.Negocio.ORM;
using Dapper;

namespace BLS.Negocio.PLD
{
    public  class DatosPld
    {
        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];

        public List<AVDetectadas> DameListaAVDetectadas(DateTime fechaInicial, DateTime fechaFinal, Boolean todasLasFechas, Boolean SoloAvActivas)
        {
            try
            {
                List<AVDetectadas> resultado = new List<AVDetectadas>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<AVDetectadas>
                        (
                        sql: "sp_DameActiVulnerablesPorFecha", param: new
                        {
                            fechaInicial,
                            fechaFinal,                            
                            todasLasFechas,
                            SoloAvActivas


                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameActiVulnerablesPorFecha , detalle: \n" + ex.Message, ex);
            }
        }

    }
}
