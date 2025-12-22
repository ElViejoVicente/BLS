using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;
using System.Configuration;

namespace EmailLogGGB
{
   public  class FuncionesNG
    {
        protected static GenericProvider BaseDatossql = new SqlProvider("Data Source=172.22.24.62;Initial Catalog=GPB;User ID=consultas_local_w; password=Br!3dig?t; Connection Lifetime=3");
        public static DataTable dameemailagencias(int idagencia, Boolean conaviso)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idagencia", SqlDbType.Int), _SqlValue: idagencia),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@conaviso", SqlDbType.Bit), _SqlValue: conaviso)

                };
                 
                dtresultado = BaseDatossql.LoadDataSet("sp_dameemailagencia", parametros).Tables[0];
                return dtresultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_altaSociedad detalle: \n" + ex.Message, ex);
            }

        }
    }
}
