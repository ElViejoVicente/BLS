using Dapper;
using Microsoft.Exchange.WebServices.Data;
using BLS.Negocio.CRUD;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Expediente
{
    public class DatosExpedientes
    {
        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];
        DatosCrud datosCrud = new DatosCrud();


        public List<Alertas> DameAlertasPorExpediente(string NumExpediente)
        {
            try
            {
                List<Alertas> resultado = new List<Alertas>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Alertas>
                        (
                        sql: "sp_DameAlertaPorExpediente", param: new
                        {
                            NumExpediente

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameAlertaPorExpediente , detalle: \n" + ex.Message, ex);
            }
        }


        public List<ListaHojaDatos> DameListaHojaDatos(DateTime fechaInicial, DateTime fechaFinal, Boolean todasLasFechas)
        {
            try
            {

                List<ListaHojaDatos> resultado = new List<ListaHojaDatos>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaHojaDatos>
                        (

                        sql: "sp_DameHojaDatosPorFecha", param: new
                        {
                            fechaInicial,
                            fechaFinal,
                            todasLasFechas

                        }, commandType: CommandType.StoredProcedure


                        ).ToList();
                }

                if (resultado.Count > 0)
                {



                    foreach (var item in resultado)
                    {
                        // consultamos los datos DatosVariantes

                        item.DetalleHojaDatos = datosCrud.ConsultaHojaDatos(item.IdHojaDatos);

                        item.DetalleVariante = ConsultaDatosVariantesXHojaDatos(item.IdHojaDatos);

                        item.DetalleExpediente = ConsultaExpedienteXHojaDatos(item.IdHojaDatos);

                        item.DetalleParticipantes = DameListaParticipantes(item.IdHojaDatos);

                        item.DetalleDocumentos = DameListaDocumentos(item.IdHojaDatos);

                        item.DetalleDocumentosOtorgSolicita = DameListaDocumentos(item.IdHojaDatos, "Otorga o Solicita");

                        item.DetalleDocumentosAfavorDe = DameListaDocumentos(item.IdHojaDatos, "A favor de");

                        item.DetalleRecibosPago = DameRecibosDePago(item.IdHojaDatos);


                    }
                }

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameHojaDatosPorFecha , detalle: \n" + ex.Message, ex);
            }
        }



        public DatosVariantes ConsultaDatosVariantesXHojaDatos(int IdRegistro)
        {
            try
            {
                DatosVariantes resultado = new DatosVariantes();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosVariantes>
                        (
                        sql: "sp_DameDatosVariantesXHojaDatos", param: new
                        {
                            IdRegistro
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameDatosVariantesXHojaDatos, detalle: \n" + ex.Message, ex);
            }
        }

        public Expedientes ConsultaExpedienteXHojaDatos(int IdRegistro)
        {
            try
            {
                Expedientes resultado = new Expedientes();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Expedientes>
                        (
                        sql: "sp_DameExpedienteXHojaDatos ", param: new
                        {
                            IdRegistro
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameExpedienteXHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }




        public ListaHojaDatos DameHojaDatosDetalle(int idHojaDatosdate)
        {
            try
            {

                ListaHojaDatos resultado = new ListaHojaDatos();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.QuerySingle<ListaHojaDatos>
                        (
                         sql: "sp_DameHojaDatosPorID", param: new
                         {
                             idHojaDatosdate
                        
                         }, commandType: CommandType.StoredProcedure
                        );
                }

                if (resultado != null)
                {


                    // consultamos los datos DatosVariantes

                    resultado.DetalleHojaDatos = datosCrud.ConsultaHojaDatos(resultado.IdHojaDatos);

                    resultado.DetalleVariante = ConsultaDatosVariantesXHojaDatos(resultado.IdHojaDatos);

                    resultado.DetalleExpediente = ConsultaExpedienteXHojaDatos(resultado.IdHojaDatos);

                    resultado.DetalleParticipantes = DameListaParticipantes(resultado.IdHojaDatos);

                    resultado.DetalleDocumentos = DameListaDocumentos(resultado.IdHojaDatos);

                    resultado.DetalleDocumentosOtorgSolicita = DameListaDocumentos(resultado.IdHojaDatos, "Otorga o Solicita");

                    resultado.DetalleDocumentosAfavorDe = DameListaDocumentos(resultado.IdHojaDatos, "A favor de");

                    resultado.DetalleRecibosPago = DameRecibosDePago(resultado.IdHojaDatos);

                }

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameHojaDatosPorID , detalle: \n" + ex.Message, ex);
            }
        }



        public List<DatosVariantes> DameDatosVariantes(int idHojaDatos)
        {
            try
            {
                List<DatosVariantes> resultado = new List<DatosVariantes>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosVariantes>
                        (
                        sql: "sp_DameDatosVariantesporHojaDatos", param: new
                        {
                            idHojaDatos

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameDatosVariantesporHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean BorraDatosParticipantesDocumentos(int idHojaDatos)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_BorraDatosParticipantesPorIdHojaDatos", param: new
                    {
                        idHojaDatos

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_BorraDatosParticipantesPorIdHojaDatos, detalle: \n" + ex.Message, ex);
            }
        }




        public List<RecibosDePago> DameRecibosDePago(int idHojaDatos)
        {
            try
            {
                List<RecibosDePago> resultado = new List<RecibosDePago>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<RecibosDePago>
                        (
                        sql: "sp_DameRecibosDePagoPorHojaDatos", param: new
                        {
                            idHojaDatos

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameRecibosDePagoPorHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }

        public List<DatosDocumentos> DameListaDocumentos(int idHojaDatos, string textoFigura)
        {
            try
            {
                List<DatosDocumentos> resultado = new List<DatosDocumentos>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosDocumentos>
                        (
                        sql: "sp_DameDatosDocumentosPorHojaDatos", param: new
                        {
                            idHojaDatos

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }

                if (resultado.Count > 0)
                {
                    resultado = resultado.Where(x => x.TextoFigura == textoFigura).ToList();
                }

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameDatosDocumentosPorHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }


        public List<DatosDocumentos> DameListaDocumentos(int idHojaDatos)
        {
            try
            {
                List<DatosDocumentos> resultado = new List<DatosDocumentos>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosDocumentos>
                        (
                        sql: "sp_DameDatosDocumentosPorHojaDatos", param: new
                        {
                            idHojaDatos

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameDatosDocumentosPorHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }


        public List<DatosParticipantes> DameListaParticipantes(int idHojaDatos)
        {
            try
            {
                List<DatosParticipantes> resultado = new List<DatosParticipantes>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosParticipantes>
                        (
                        sql: "sp_DameDatosParticipantesporHojaDatos", param: new
                        {
                            idHojaDatos

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameDatosParticipantesporHojaDatos , detalle: \n" + ex.Message, ex);
            }
        }

        public List<ListaExpedientes> DameListaExpediente(DateTime fechaInicial, DateTime fechaFinal,  long idUsuario, Boolean todasLasFechas)
        {
            try
            {
                List<ListaExpedientes> resultado = new List<ListaExpedientes>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<ListaExpedientes>
                        (
                        sql: "sp_DameExpedientePorFecha", param: new
                        {
                            fechaInicial,
                            fechaFinal,
                            idUsuario,
                            todasLasFechas,
                            

                        }, commandType: CommandType.StoredProcedure
                        ).ToList();
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_DameExpedientePorFecha , detalle: \n" + ex.Message, ex);
            }
        }


    }
}
