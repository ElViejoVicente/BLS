
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.APP
{
    public  class DatosAPP
    {


        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];



        public ListaConsultaFolio ConsultaMiFolio(string NumExpediente)
        {
            try
            {
                ListaConsultaFolio resultado = new ListaConsultaFolio();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaConsultaFolio>
                        (
                        sql: "sp_APP_ConsultaExpedienteXfolio", param: new
                        {
                            NumExpediente
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_APP_ConsultaExpedienteXfolio, detalle: \n" + ex.Message, ex);
            }
        }


    }
}
