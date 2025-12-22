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

namespace BLS.Negocio.Inventarios
{
    public class DatosInventario
    {

        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];



        public List<Inventario> DameListaInventario(DateTime fechaInventario, Boolean todasLasFechas, Boolean inventarioActivo)
        {
            try
            {
                List<Inventario> resultado = new List<Inventario>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Inventario>(sql: "sp_DameListaInventario", param: new
                    {
                        fechaInventario,
                        todasLasFechas,
                        inventarioActivo
                    }, commandType: CommandType.StoredProcedure
                    ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameListaInventario, detalle: \n" + ex.Message, ex);
            }
        }



    }
}
