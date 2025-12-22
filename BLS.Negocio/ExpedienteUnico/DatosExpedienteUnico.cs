using Dapper;
using Microsoft.Exchange.WebServices.Data;
using BLS.Negocio.CRUD;
using BLS.Negocio.Expediente;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ExpedienteUnico
{
    public class DatosExpedienteUnico
    {
        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];
        DatosCrud datosCrud = new DatosCrud();

        public List<ListaExpedienteUnico> DameListaExpedienteUnico(DateTime fechaInicial, DateTime fechaFinal, Boolean todasLasFechas)
        {
            try
            {
                List<ListaExpedienteUnico> resultado = new List<ListaExpedienteUnico>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaExpedienteUnico>
                        (
                        sql: "sp_DameExUnicoPorFecha", param: new
                        {
                            fechaInicial,
                            fechaFinal,
                            todasLasFechas

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameExUnicoPorFecha , detalle: \n" + ex.Message, ex);
            }
        }


        public List<ListaNegraSAT> DameRfcEnListaNegra(string RFC, string NombreUsuarioConsulta)
        {
            try
            {
                List<ListaNegraSAT> resultado = new List<ListaNegraSAT>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaNegraSAT>
                        (
                        sql: "sp_DameRFCEnListaNegra", param: new
                        {
                            RFC,
                            NombreUsuarioConsulta              

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameRFCEnListaNegra , detalle: \n" + ex.Message, ex);
            }

        }

        public ListaExpedienteUnico DameExpedienteUnico(int IdRegistroCliente)
        {
            try
            {
                ListaExpedienteUnico resultado = new ListaExpedienteUnico();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.QuerySingle<ListaExpedienteUnico>
                        (
                        sql: "sp_DameExUnicoPorId", param: new
                        {
                            IdRegistroCliente             

                        }, commandType: CommandType.StoredProcedure
                        );
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameExUnicoPorId , detalle: \n" + ex.Message, ex);
            }
        }
    }
}
