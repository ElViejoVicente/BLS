using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BLS.Negocio.Bitacora
{
    public class DatosBitacora
    {
        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];


        public List<BitacoraExpediente> DameBitacoraPorExpediente(string NumExpediente)
        {
            try
            {
                List<BitacoraExpediente> resultado = new List<BitacoraExpediente>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<BitacoraExpediente>
                        (
                        sql: "sp_DameBitacoraPorExpdiente", param: new
                        {
                            NumExpediente

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameBitacoraPorExpdiente, detalle: \n" + ex.Message, ex);
            }

        }
    }
}
