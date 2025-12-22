using Dapper;
using System;
using BLS.Negocio.ORM;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.CRUD
{
    public class DatosCrud
    {

        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];


        #region DatosDocumentos
        public Boolean AltaDatosDocumentos(DatosDocumentos values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosDocumentos_Insert", param: new
                    {
                        values.IdHojaDatos,
                        values.IdVariente,
                        values.TextoVariante,
                        values.TextoFigura,
                        values.IdDoc,
                        values.Observaciones

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosDocumentos_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        #endregion

        #region RecibosDePago
        public Boolean AltaRecibosDePago(RecibosDePago values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_RecibosDePago_Insert", param: new
                    {
                        values.NumRecibo,
                        values.IdHojaDatos,
                        values.CantidadTotal,
                        values.CantidadAbonada,
                        values.Concepto,
                        values.UsuarioRecibe,
                        values.NotaComentario

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_RecibosDePago_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        #endregion

        #region DatosParticipantes


        public DatosParticipantes ConsultaDatosParticipantes(int IdRegistro)
        {
            try
            {
                DatosParticipantes resultado = new DatosParticipantes();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.QuerySingle<DatosParticipantes>
                        (
                        sql: "sp_CRUD_DatosParticipantes_Select", param: new
                        {
                            IdRegistro
                        }, commandType: CommandType.StoredProcedure
                        );
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosParticipantes_Select, detalle: \n" + ex.Message, ex);
            }
        }



        public Boolean AltaDatosParticipantes(DatosParticipantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosParticipantes_Insert", param: new
                    {
                        values.IdHojaDatos,
                        values.FiguraOperacion,
                        values.RolOperacion,
                        values.Nombres,
                        values.ApellidoPaterno,
                        values.ApellidoMaterno,
                        values.FechaNacimiento,
                        values.Sexo,
                        values.Ocupacion,
                        values.EstadoCivil,
                        values.RegimenConyugal,
                        values.SabeLeerEscribir,
                        values.Notas,
                        values.TipoRegimen,

                        values.PaisNacimiento,
                        values.PaisNacionalidad,
                        values.Domicilio,
                        values.NumeroExterior,
                        values.NumeroInterior,
                        values.Colonia,
                        values.Municipio,
                        values.Ciudad,
                        values.Estado,
                        values.PaisDomicilio,
                        values.CP,
                        values.NumeroTefonico,
                        values.CorreoElectronico,
                        values.Curp,
                        values.Rfc,
                        values.NombreIdentificacionID,
                        values.AutoridadEmiteID,
                        values.NumeroSerieID,
                        values.RazonSocial,
                        values.FechaConstitucion,
                        values.PaisRazonSocial,
                        values.ActividadRazonSocial,
                        values.SeValidoEnListaNegra,
                        values.FechaPrimeraValidacion,
                        values.ObsePrimeraValidacion,
                        values.FechaSegundaValicacion,
                        values.ObseSegundaValidacion,
                        values.IdFideicomiso

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosParticipantes_Insert, detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean ActualizaDatosParticipantes(DatosParticipantes values)
        {

            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosParticipantes_Update", param: new
                    {
                        values.IdRegistro,
                        values.IdHojaDatos,

                        values.FiguraOperacion,
                        values.RolOperacion,
                        values.Nombres,
                        values.ApellidoPaterno,
                        values.ApellidoMaterno,
                        values.FechaNacimiento,
                        values.Sexo,
                        values.Ocupacion,
                        values.EstadoCivil,
                        values.RegimenConyugal,
                        values.SabeLeerEscribir,
                        values.Notas,

                        values.TipoRegimen,
                        values.PaisNacimiento,
                        values.PaisNacionalidad,
                        values.Domicilio,
                        values.NumeroExterior,
                        values.NumeroInterior,
                        values.Colonia,
                        values.Municipio,
                        values.Ciudad,
                        values.Estado,
                        values.PaisDomicilio,
                        values.CP,
                        values.NumeroTefonico,
                        values.CorreoElectronico,
                        values.Curp,
                        values.Rfc,
                        values.NombreIdentificacionID,
                        values.AutoridadEmiteID,
                        values.NumeroSerieID,
                        values.RazonSocial,
                        values.FechaConstitucion,
                        values.PaisRazonSocial,
                        values.ActividadRazonSocial,
                        values.SeValidoEnListaNegra,
                        values.FechaPrimeraValidacion,
                        values.ObsePrimeraValidacion,
                        values.FechaSegundaValicacion,
                        values.ObseSegundaValidacion,
                        values.IdFideicomiso

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosParticipantes_Update, detalle: \n" + ex.Message, ex);
            }

        }



        #endregion

        #region DatosVariantes
        public Boolean AltaDatosVariantes(DatosVariantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosVariantes_Insert", param: new
                    {
                        values.IdHojaDatos,
                        values.IdActo,
                        values.IdVariante,
                        values.TextoActo,
                        values.TextoVariante,
                        values.NotasEspeciales,
                        values.Dispocisiones,
                        values.NotasClausulasEspeciales,
                        values.CoApActaNacNum,
                        values.CoApActaNacFecha,
                        values.OtrosNombres,
                        values.NominacionPermisoSE,
                        values.TipoSociedad,
                        values.DatosFaltantes

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosVariantes_Insert, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizarDatosVariantes(DatosVariantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosVariantes_Update", param: new
                    {
                        values.IdRegistro,
                        values.IdHojaDatos,
                        values.IdActo,
                        values.IdVariante,
                        values.TextoActo,
                        values.TextoVariante,
                        values.NotasEspeciales,
                        values.Dispocisiones,
                        values.NotasClausulasEspeciales,
                        values.CoApActaNacNum,
                        values.CoApActaNacFecha,
                        values.OtrosNombres,
                        values.NominacionPermisoSE,
                        values.TipoSociedad,
                        values.DatosFaltantes

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_DatosVariantes_Update, detalle: \n" + ex.Message, ex);
            }
        }

        public DatosVariantes ConsultaDatosVariantes(int IdRegistro)
        {
            try
            {
                DatosVariantes resultado = new DatosVariantes();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosVariantes>
                        (
                        sql: "sp_CRUD_DatosVariantes_Select", param: new
                        {
                            IdRegistro
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosVariantes_Select, detalle: \n" + ex.Message, ex);
            }
        }




        #endregion

        #region HojaDatos
        public Boolean AltaHojaDatos(ref HojaDatos values, int idUsuarioSistema)
        {
            try
            {
                HojaDatos nuevahoja = new HojaDatos();
                using (var db = new SqlConnection(cnn))
                {
                    nuevahoja = db.QuerySingle<HojaDatos>(sql: "sp_CRUD_HojaDatos_Insert", param: new
                    {

                        values.numExpediente,
                        values.NombreAsesor,
                        values.FechaIngreso,
                        values.FechaCompleto,
                        values.IdUsuarioResponsable,
                        values.IdEquipoResponsable,
                        values.NumbreUsuarioTramita,
                        values.NumTelCelular1,
                        values.NumTelCelular2,
                        values.CorreoElectronico,
                        idUsuarioSistema


                    }, commandType: CommandType.StoredProcedure);
                }
                values = nuevahoja;
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_HojaDatos_Insert, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizarHojaDatos(HojaDatos values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_HojaDatos_Update", param: new
                    {
                        values.IdHojaDatos,
                        values.numExpediente,
                        values.NombreAsesor,
                        values.FechaIngreso,
                        values.FechaCompleto,
                        values.IdUsuarioResponsable,
                        values.IdEquipoResponsable,
                        values.NumbreUsuarioTramita,
                        values.NumTelCelular1,
                        values.NumTelCelular2,
                        values.CorreoElectronico

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_HojaDatos_Update, detalle: \n" + ex.Message, ex);
            }
        }


        public HojaDatos ConsultaHojaDatos(int IdHojaDatos)
        {
            try
            {
                HojaDatos resultado = new HojaDatos();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.QuerySingle<HojaDatos>
                        (
                        sql: "sp_CRUD_HojaDatos_Select", param: new
                        {
                            IdHojaDatos
                        }, commandType: CommandType.StoredProcedure
                        );
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_HojaDatos_Select, detalle: \n" + ex.Message, ex);
            }
        }


        #endregion

        #region Cat_DocumentosPorActo
        public List<Cat_DocumentosPorActo> ConsultaCatDocumentosPorActo()
        {
            try
            {
                List<Cat_DocumentosPorActo> resultado = new List<Cat_DocumentosPorActo>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_DocumentosPorActo>(sql: "[sp_CRUD_Cat_DocumentosPorActo_Select]").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar [sp_CRUD_Cat_DocumentosPorActo_Select], detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean AltaCatDocumentosPorActo(Cat_DocumentosPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_DocumentosPorActo_Insert", param: new
                    {
                        values.IdActo,
                        values.IdVariente,
                        values.TextoFigura,
                        values.TextoDocumento,
                        values.CopiaRequerida,
                        values.Descripcion,
                        values.Activo

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_DocumentosPorActo_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarCatDocumentosPorActo(Cat_DocumentosPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_DocumentosPorActo_Update", param: new
                    {
                        values.IdDoc,
                        values.IdActo,
                        values.IdVariente,
                        values.TextoFigura,
                        values.TextoDocumento,
                        values.CopiaRequerida,
                        values.Descripcion,
                        values.Activo

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_DocumentosPorActo_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarCatDocumentosPorActo(Cat_DocumentosPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_DocumentosPorActo_Delete", param: new
                    {
                        values.IdDoc

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_DocumentosPorActo_Delete, detalle: \n" + ex.Message, ex);
            }
        }





        #endregion

        #region Cat_RolParticipantes
        public List<Cat_RolParticipantes> ConsultaCatRolParticipantes()
        {
            try
            {
                List<Cat_RolParticipantes> resultado = new List<Cat_RolParticipantes>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_RolParticipantes>(sql: "[sp_CRUD_Cat_RolParticipantes_Select]").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar [sp_CRUD_Cat_RolParticipantes_Select], detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean AltaCatRolParticipantes(Cat_RolParticipantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_RolParticipantes_Insert", param: new
                    {
                        values.IdActo,
                        values.TextoFigura,
                        values.TextoRol,
                        values.PreguntarSiEsAnafabeta,
                        values.Descripcion,
                        values.Activo,
                        values.RequiereExUnico

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_RolParticipantes_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarCatRolParticipantes(Cat_RolParticipantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_RolParticipantes_Update", param: new
                    {
                        values.IdRol,
                        values.IdActo,
                        values.TextoFigura,
                        values.TextoRol,
                        values.PreguntarSiEsAnafabeta,
                        values.Descripcion,
                        values.Activo,
                        values.RequiereExUnico

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_RolParticipantes_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarCatRolParticipantes(Cat_RolParticipantes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_RolParticipantes_Delete", param: new
                    {
                        values.IdRol

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_RolParticipantes_Delete, detalle: \n" + ex.Message, ex);
            }
        }





        #endregion

        #region Cat_VariantesPorActo
        public List<Cat_VariantesPorActo> ConsultaCatVariantesPorActo()
        {
            try
            {
                List<Cat_VariantesPorActo> resultado = new List<Cat_VariantesPorActo>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_VariantesPorActo>(sql: "sp_CRUD_Cat_VariantesPorActo_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_VariantesPorActo_Select, detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean AltaCatVariantePorActo(Cat_VariantesPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_VariantesPorActo_Insert", param: new
                    {
                        values.IdActo,
                        values.TextoVariante,
                        values.Descripcion,
                        values.Activo,
                        values.RequiereExUnico

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_VariantesPorActo_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarCatVariantePorActo(Cat_VariantesPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_VariantesPorActo_Update", param: new
                    {
                        values.IdVariante,
                        values.IdActo,
                        values.TextoVariante,
                        values.Descripcion,
                        values.Activo,
                        values.RequiereExUnico

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_VariantesPorActo_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarCatVariantePorActo(Cat_VariantesPorActo values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_VariantesPorActo_Delete", param: new
                    {
                        values.IdVariante

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_VariantesPorActo_Delete, detalle: \n" + ex.Message, ex);
            }
        }







        #endregion

        #region Cat_Actos
        public List<Cat_Actos> ConsultaCatActos()
        {
            try
            {
                List<Cat_Actos> resultado = new List<Cat_Actos>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_Actos>(sql: "sp_CRUD_Cat_Actos_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Actos_Select, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean AltaCatActos(Cat_Actos values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Actos_Insert", param: new
                    {
                        values.TextoActo,
                        values.Descripcion,
                        values.Activo,
                        values.AvisoAcVulnerable,
                        values.UmbralAcVulnerable,
                        values.ReqTraslado,
                        values.TapAP,
                        values.TapProyecto,
                        values.TapFirmas,
                        values.TapAD,
                        values.TapEscritura,
                        values.TapEntrega,
                        values.TapContabilidad,
                        values.TapPLD



                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Actos_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarCatActos(Cat_Actos values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Actos_Update", param: new
                    {
                        values.IdActo,
                        values.TextoActo,
                        values.Descripcion,
                        values.Activo,
                        values.AvisoAcVulnerable,
                        values.UmbralAcVulnerable,
                        values.ReqTraslado,
                        values.TapAP,
                        values.TapProyecto,
                        values.TapFirmas,
                        values.TapAD,
                        values.TapEscritura,
                        values.TapEntrega,
                        values.TapContabilidad,
                        values.TapPLD

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Actos_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarCatActos(Cat_Actos values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Actos_Delete", param: new
                    {
                        values.IdActo

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Actos_Delete, detalle: \n" + ex.Message, ex);
            }
        }
        #endregion

        #region Cat_Paises
        public List<Cat_Paises> ConsultaCatPaises()
        {
            try
            {
                List<Cat_Paises> resultado = new List<Cat_Paises>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_Paises>(sql: "sp_CRUD_Cat_Paises_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Paises_Select, detalle: \n" + ex.Message, ex);
            }
        }
        #endregion

        #region Cat_Estatus

        public List<Cat_Estatus> ConsultaCatEstatus()
        {
            try
            {
                List<Cat_Estatus> resultado = new List<Cat_Estatus>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_Estatus>(sql: "sp_CRUD_Cat_Estatus_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Estatus_Select, detalle: \n" + ex.Message, ex);
            }
        }



        #endregion

        #region PerfilesXestatus

        public List<PerfilesXestatus> ConsultaPerfilesXestatus()
        {
            try
            {
                List<PerfilesXestatus> resultado = new List<PerfilesXestatus>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<PerfilesXestatus>(sql: "sp_CRUD_PerfilesXestatus_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_PerfilesXestatus_Select, detalle: \n" + ex.Message, ex);
            }
        }

        #endregion

        #region Cat_Proyectistas

        public List<Cat_Proyectistas> ConsultaCatProyectista()
        {
            try
            {
                List<Cat_Proyectistas> resultado = new List<Cat_Proyectistas>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_Proyectistas>(sql: "sp_CRUD_Cat_Proyectistas_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Proyectistas_Select, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean AltaCatProyectista(Cat_Proyectistas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Proyectistas_Insert", param: new
                    {
                        values.NombreProyectista,
                        values.Activo

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_Proyectistas_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarCatEstatus(Cat_Proyectistas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Proyectistas_Update", param: new
                    {
                        values.idProyectista,
                        values.NombreProyectista,
                        values.Activo

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Proyectistas_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarCatEstatus(Cat_Proyectistas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Proyectistas_Delete", param: new
                    {
                        values.idProyectista

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Proyectistas_Delete, detalle: \n" + ex.Message, ex);
            }
        }


        #endregion

        #region Expedientes

        public Expedientes ConsultaExpediente(string numExp)
        {
            try
            {
                Expedientes resultado = new Expedientes();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Expedientes>
                        (
                        sql: "sp_CRUD_Expedientes_Select", param: new
                        {
                            IdExpediente = numExp
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Expedientes_Select, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean AltaExpediente(Expedientes values)
        {
            try
            {

                using (var db = new SqlConnection(cnn))
                {


                    db.Execute(sql: "sp_CRUD_Expedientes_Insert", param: new
                    {
                        values.IdExpediente,
                        values.IdHojaDatos,
                        values.IdEstatus,
                        values.Otorga,
                        values.AfavorDe,
                        values.UbicacionPredio,
                        values.FechaElaboracion,
                        values.FechaEnvioRPP,
                        values.EsTramitePorSistema,
                        values.FechaPagoBoleta,
                        values.FechaRecibidoRPP,
                        values.NombreProyectista,
                        values.FechaAsignacionProyectista,
                        values.FechaPrevistaTerminoProyectista,
                        values.FechaAvisoPreventivo,
                        values.ISR,
                        values.NotasFirma,
                        values.Escritura,
                        values.Volumen,
                        values.AplicaTraslado,
                        values.FechaRecepcionTerminoEscritura,
                        values.FechaElaboracionDefinitivo,
                        values.FechaEnvioRPPDefinitivo,
                        values.EsTramitePorSistemaDefinitivo,
                        values.FechaPagoBoletaDefinitivo,
                        values.FechaRecibidoRPPDefinitivo,
                        values.FechaRecibioTraslado,
                        values.FechaAsignacionMesa,
                        values.FechaTerminoMesa,
                        values.ObservacionesEngrega,
                        values.RegistroEntrega,
                        values.FechaRegistroEntrega,
                        values.FechaBoletaPagoRegistroEntrega,
                        values.FechaRegresoRegistro,
                        values.FechaSalida,
                        values.ObservacionesTramiteTerminado,
                        values.ValorOperacion,
                        values.ISRcalculado,
                        values.AvaluoCatastral,
                        values.AvaluoFiscal,
                        values.AvaluoComercial,
                        values.ActividadVulnerable,
                        values.FirmaDeTraslado,
                        values.FechaDeOtorgamiento,
                        values.FechaDeAvaluo,
                        values.FechaAutorizacion,
                        values.FechaPagoAvaluo

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Expedientes_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarExpediente(Expedientes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Expedientes_Update", param: new
                    {
                        values.IdExpediente,
                        values.IdHojaDatos,
                        values.IdEstatus,
                        values.Otorga,
                        values.AfavorDe,
                        values.UbicacionPredio,
                        values.FechaElaboracion,
                        values.FechaEnvioRPP,
                        values.EsTramitePorSistema,
                        values.FechaPagoBoleta,
                        values.FechaRecibidoRPP,
                        values.NombreProyectista,
                        values.FechaAsignacionProyectista,
                        values.FechaPrevistaTerminoProyectista,
                        values.FechaAvisoPreventivo,
                        values.ISR,
                        values.NotasFirma,
                        values.Escritura,
                        values.Volumen,
                        values.AplicaTraslado,
                        values.FechaRecepcionTerminoEscritura,
                        values.FechaElaboracionDefinitivo,
                        values.FechaEnvioRPPDefinitivo,
                        values.EsTramitePorSistemaDefinitivo,
                        values.FechaPagoBoletaDefinitivo,
                        values.FechaRecibidoRPPDefinitivo,
                        values.FechaRecibioTraslado,
                        values.FechaAsignacionMesa,
                        values.FechaTerminoMesa,
                        values.ObservacionesEngrega,
                        values.RegistroEntrega,
                        values.FechaRegistroEntrega,
                        values.FechaBoletaPagoRegistroEntrega,
                        values.FechaRegresoRegistro,
                        values.FechaSalida,
                        values.ObservacionesTramiteTerminado,
                        values.ValorOperacion,
                        values.ISRcalculado,
                        values.AvaluoCatastral,
                        values.AvaluoFiscal,
                        values.AvaluoComercial,
                        values.ActividadVulnerable,
                        values.FirmaDeTraslado,
                        values.FechaDeOtorgamiento,
                        values.FechaDeAvaluo,
                        values.FechaAutorizacion,
                        values.FechaPagoAvaluo


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Expedientes_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarExpediente(Expedientes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Expedientes_Delete", param: new
                    {
                        values.IdExpediente

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Expedientes_Delete, detalle: \n" + ex.Message, ex);
            }
        }

        #endregion

        #region Alertas

        public Alertas ConsultaAlertas(string IdAlerta)
        {
            try
            {
                Alertas resultado = new Alertas();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Alertas>
                        (
                        sql: "sp_CRUD_Alertas_Select", param: new
                        {
                            IdAlerta
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Alertas_Select, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean AltaAlertas(Alertas values)
        {
            try
            {

                using (var db = new SqlConnection(cnn))
                {


                    db.Execute(sql: "sp_CRUD_Alertas_Insert", param: new
                    {
                        values.NumExpediente,
                        values.NomUsuarioInformante,
                        values.MensajeAlerta,
                        values.Prioridad


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Alertas_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarAlerta(Alertas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Alertas_Update", param: new
                    {
                        values.IdAlerta,
                        values.MensajeAlerta,
                        values.AlertaActiva,
                        values.NomUsuarioCierra


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Alertas_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarAlerta(Alertas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Alertas_Delete", param: new
                    {
                        values.IdAlerta

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Alertas_Delete, detalle: \n" + ex.Message, ex);
            }
        }



        #endregion

        #region Inventario

        public Inventario ConsultaInventario(int IdInventario)
        {
            try
            {

                Inventario resultado = new Inventario();
                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Inventario>
                        (
                        sql: "sp_CRUD_Inventario_Select", param: new
                        {
                            IdInventario
                        }, commandType: CommandType.StoredProcedure

                        ).FirstOrDefault();
                }
                return resultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Inventario_Select, detalle: \n" + ex.Message, ex);
            }
        }



        public Boolean AltaInventario(Inventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Inventario_Insert", param: new
                    {
                        values.TipoInventario,
                        values.Modelo,
                        values.Nombre,
                        values.Marca,
                        values.FechaAlta,
                        values.FechaBaja,
                        values.ValorCompra,
                        values.AreaOficina,
                        values.Responsable,
                        values.FechaAsignacion,
                        values.Activo,
                        values.Observaciones,
                        values.NumeroSerie,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Inventario_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarInventario(Inventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Inventario_Update", param: new
                    {
                        values.IdInventario,
                        values.TipoInventario,
                        values.Modelo,
                        values.Nombre,
                        values.Marca,
                        values.FechaAlta,
                        values.FechaBaja,
                        values.ValorCompra,
                        values.AreaOficina,
                        values.Responsable,
                        values.FechaAsignacion,
                        values.Activo,
                        values.Observaciones,
                        values.NumeroSerie


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Inventario_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarInventario(Inventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Inventario_Delete", param: new
                    {
                        values.IdInventario

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Inventario_Delete, detalle: \n" + ex.Message, ex);
            }
        }




        #endregion

        #region Cat_TipoInventario

        public List<Cat_TipoInventario> ConsultaCatTipoInventario()
        {
            try
            {
                List<Cat_TipoInventario> resultado = new List<Cat_TipoInventario>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_TipoInventario>(sql: "[sp_CRUD_Cat_TipoInventario_Select]").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar [sp_CRUD_Cat_TipoInventario_Select], detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean AltaCatTipoInventario(Cat_TipoInventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_TipoInventario_Insert", param: new
                    {

                        values.TextoInventario,
                        values.Activo,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_TipoInventario_Insert, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizarCatTipoInventario(Cat_TipoInventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_TipoInventario_Update", param: new
                    {
                        values.idTipoInventario,
                        values.TextoInventario,
                        values.Activo,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_TipoInventario_Update, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean EliminarCatTipoInventario(Cat_TipoInventario values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_TipoInventario_Delete", param: new
                    {
                        values.idTipoInventario

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_TipoInventario_Delete, detalle: \n" + ex.Message, ex);
            }
        }

        #endregion

        #region Cat_AreaOficina

        public List<Cat_AreaOficina> ConsultaCatAreaOficina()
        {
            try
            {
                List<Cat_AreaOficina> resultado = new List<Cat_AreaOficina>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_AreaOficina>(sql: "[sp_CRUD_Cat_AreaOficina_Select]").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar [sp_CRUD_Cat_AreaOficina_Select], detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean AltaCatAreaOficina(Cat_AreaOficina values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_AreaOficina_Insert", param: new
                    {

                        values.TextoAreaOficina,
                        values.Activo,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_AreaOficina_Insert, detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean ActualizarCatAreaOficina(Cat_AreaOficina values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_AreaOficina_Update", param: new
                    {
                        values.IdArea,
                        values.TextoAreaOficina,
                        values.Activo,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_AreaOficina_Update, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean EliminarCatAreaOficina(Cat_AreaOficina values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_AreaOficina_Delete", param: new
                    {
                        values.IdArea

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_AreaOficina_Delete, detalle: \n" + ex.Message, ex);
            }
        }

        #endregion

        #region BitacoraExpediente


        public Boolean AltaBitacoraExpediente(BitacoraExpediente values)
        {
            try
            {

                using (var db = new SqlConnection(cnn))
                {


                    db.Execute(sql: "sp_CRUD_BitacoraExpediente_Insert", param: new
                    {
                        values.UsuarioImplicado,
                        values.IdExpediente,
                        values.NombreCampo,
                        values.ValorOriginal,
                        values.ValorImputado,
                        values.NombreModulo


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_BitacoraExpediente_Insert, detalle: \n" + ex.Message, ex);
            }
        }




        #endregion

        #region AVDetectadas
        public Boolean ActualizarAVDetectadas(AVDetectadas values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_AVDetectadas_Update", param: new
                    {
                        values.IdAV,
                        values.TipoAVDetectada,
                        values.IdExpediente,
                        values.FechaIngreso,
                        values.IdEstatus,
                        values.TextoEstatus,
                        values.TextoActo,
                        values.TextoVariante,
                        values.Escritura,
                        values.Volumen,
                        values.ValorOperacion,
                        values.UmbralAcVulnerable,
                        values.AvActiva,
                        values.UsuarioGestionaAviso,
                        values.FolioDeAviso,
                        values.Observaciones


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_AVDetectadas_Update, detalle: \n" + ex.Message, ex);
            }
        }
        #endregion

        #region DatosAvisoNotarial

        public DatosAvisoNotarial ConsultaDatosAvisoNotarial(string numExp)
        {
            try
            {
                DatosAvisoNotarial resultado = new DatosAvisoNotarial();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<DatosAvisoNotarial>
                        (
                        sql: "sp_CRUD_DatosAvisoNotarial_Select", param: new
                        {
                            IdExpediente = numExp
                        }, commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosAvisoNotarial_Select, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean AltaDatosAvisoNotarial(DatosAvisoNotarial values)
        {
            try
            {

                using (var db = new SqlConnection(cnn))
                {


                    db.Execute(sql: "sp_CRUD_DatosAvisoNotarial_Insert", param: new
                    {
                        values.IdExpediente,
                        values.ClaveCatastral,
                        values.InstitucionPracticoAvaluo,
                        values.NaturalezaActoConceptoAdquisicion,
                        values.DatCatastroSuperficie,
                        values.DatCatastroVendida,
                        values.DatCatastroRestante,
                        values.DatCatastroConstruida,
                        values.DatCatastroPlantas,
                        values.DatDiNoRePuPartida,
                        values.DatDiNoRePuFojas,
                        values.DatDiNoRePuSeccion,
                        values.DatDiNoRePuVolumen,
                        values.DatDiNoRePuDistrito,
                        values.DatDiNoRePuFolioRealElectronico,
                        values.DatDiNoRePuSelloRegistral,
                        values.UbicacionDescripcionDeLosBienes,
                        values.MedidasColindancias,
                        values.ObservacionesAclaraciones,
                        values.ReciboPagoImpuestoPredial,
                        values.FechaUltimoPago,
                        values.UbiPredioCalle,
                        values.UbiPredioNumero,
                        values.UbiPredioColonia,
                        values.UbiPredioEstado,
                        values.UbiPredioMunicipio,
                        values.UbiPredioLocalidad,
                        values.ObservacionesSolicitudPropiedad


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_DatosAvisoNotarial_Insert, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean ActualizarDatosAvisoNotarial(DatosAvisoNotarial values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosAvisoNotarial_Update", param: new
                    {
                        values.IdExpediente,
                        values.ClaveCatastral,
                        values.InstitucionPracticoAvaluo,
                        values.NaturalezaActoConceptoAdquisicion,
                        values.DatCatastroSuperficie,
                        values.DatCatastroVendida,
                        values.DatCatastroRestante,
                        values.DatCatastroConstruida,
                        values.DatCatastroPlantas,
                        values.DatDiNoRePuPartida,
                        values.DatDiNoRePuFojas,
                        values.DatDiNoRePuSeccion,
                        values.DatDiNoRePuVolumen,
                        values.DatDiNoRePuDistrito,
                        values.DatDiNoRePuFolioRealElectronico,
                        values.DatDiNoRePuSelloRegistral,
                        values.UbicacionDescripcionDeLosBienes,
                        values.MedidasColindancias,
                        values.ObservacionesAclaraciones,
                        values.ReciboPagoImpuestoPredial,
                        values.FechaUltimoPago,
                        values.UbiPredioCalle,
                        values.UbiPredioNumero,
                        values.UbiPredioColonia,
                        values.UbiPredioEstado,
                        values.UbiPredioMunicipio,
                        values.UbiPredioLocalidad,
                        values.ObservacionesSolicitudPropiedad



                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_DatosAvisoNotarial_Update, detalle: \n" + ex.Message, ex);
            }
        }
        public Boolean EliminarDatosAvisoNotarial(DatosAvisoNotarial values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_DatosAvisoNotarial_Delete", param: new
                    {
                        values.IdExpediente

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_DatosAvisoNotarial_Delete, detalle: \n" + ex.Message, ex);
            }
        }





        #endregion

        #region Cat_EstadosRepublica

        public List<Cat_EstadosRepublica> ConsultaCatEstadosRepublica()
        {
            try
            {
                List<Cat_EstadosRepublica> resultado = new List<Cat_EstadosRepublica>();

                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_EstadosRepublica>(sql: "sp_CRUD_Cat_EstadosRepublica_Select").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_EstadosRepublica_Select, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean AltaCatEstadosRepublica(Cat_EstadosRepublica values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_EstadosRepublica_Insert", param: new
                    {

                        values.IdEstado,
                        values.TextoEstado,

                    }, commandType: CommandType.StoredProcedure);
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CRUD_Cat_EstadosRepublica_Insert, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizarCatEstadosRepublica(Cat_EstadosRepublica values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_EstadosRepublica_Update", param: new
                    {
                        values.IdEstado,
                        values.TextoEstado,


                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_EstadosRepublica_Update, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean EliminarCatEstadosRepublica(Cat_EstadosRepublica values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_EstadosRepublica_Delete", param: new
                    {
                        values.IdEstado

                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_EstadosRepublica_Delete, detalle: \n" + ex.Message, ex);
            }
        }


        #endregion

        #region Cat_Clientes

        public List<Cat_Clientes> ConsultaCatClientes()
        {
            try
            {
                List<Cat_Clientes> resultado = new List<Cat_Clientes>();
                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<Cat_Clientes>(sql: "[sp_CRUD_Cat_Clientes_Select]").ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar [sp_CRUD_Cat_Clientes_Select], detalle: \n " + ex.Message, ex);
            }
        }

        public Boolean AltaCatClientes(Cat_Clientes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Clientes_Insert", param: new
                    {
                  
                        values.Gestor,
                        values.NumTelefonico,
                        values.CorreoElectronico,
                        values.Observaciones
                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Clientes_Insert, detalle : \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizarCatClientes(Cat_Clientes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Clientes_Update", param: new
                    {
                        values.idCliente,
                        values.Gestor,
                        values.NumTelefonico,
                        values.CorreoElectronico,
                        values.Observaciones
                    }, commandType: CommandType.StoredProcedure);
                }
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Clientes_Update, detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean EliminarCatClientes(Cat_Clientes values)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    db.Execute(sql: "sp_CRUD_Cat_Clientes_Delete", param: new
                    {
                        values.idCliente
                    
                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_CRUD_Cat_Clientes_Delete, detalle: \n" + ex.Message, ex);
            }
        }



        #endregion

    }

}


