using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using Dapper;
using Newtonsoft.Json.Linq;
using SGN.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BLS.Negocio.Operativa
{
    public class DatosUsuario
    {
        protected GenericProvider BaseDatossql = new SqlProvider(ConfigurationManager.AppSettings["sqlConn.ConnectionString"]);

        protected String cnn = ConfigurationManager.AppSettings["sqlConn.ConnectionString"];

        public UsuariosEXT DameDatosUsuario(string usMail)
        {
            try
            {
                UsuariosEXT resultado = new UsuariosEXT();
                using (var db = new SqlConnection(cnn))
                {
                    resultado = db.Query<UsuariosEXT>(
                        sql: "sp_DameDatosUsuarioPorCorreo",
                        param: new { usMail },
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_DameDatosUsuarioPorCorreo, detalle: \n" + ex.Message, ex);
            }
        }



        public List<PerfilXOperaciones> DameAccionesPermitidas(long Idusuario)
        {
            try
            {
                DataTable dtresultado;
                List<PerfilXOperaciones> miListaOperacionesXPefil = new List<PerfilXOperaciones>();
                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idUsuario", SqlDbType.BigInt), _SqlValue: Idusuario)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_dameOperacionXPerfil", parametros).Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaOperacionesXPefil;
                }

                miListaOperacionesXPefil = (from elemento in dtresultado.AsEnumerable()
                                            select new PerfilXOperaciones
                                            {
                                                IdOperacion = Convert.ToInt32(elemento["opId"]),
                                                IdModulo = Convert.ToInt32(elemento["opIdModulo"]),
                                                OperacionDesc = elemento["opDesc"].ToString(),
                                                OperacionNombre = elemento["opNombreCorto"].ToString(),
                                                OperacionActiva = Convert.ToBoolean(elemento["opActiva"].ToString()),
                                                OperacionTrans = elemento["opTrans"].ToString(),
                                                Creado = true
                                            }).ToList();

                return miListaOperacionesXPefil;


            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameModulosXPerfil detalle: \n" + ex.Message, ex);
            }
        }
        public DataTable ObtenNodosMenu(int parent, long codUsuario, bool vertodo = false)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@piParent", SqlDbType.Int), _SqlValue: parent),
                 new SqlParamTranfer( _SqlParameter: new SqlParameter("@piUser", SqlDbType.BigInt), _SqlValue: codUsuario),
                 new SqlParamTranfer( _SqlParameter: new SqlParameter("@piTodo", SqlDbType.Bit), _SqlValue: vertodo),


                };

                dtresultado = BaseDatossql.LoadDataSet("sp_dameDatosMenu", parametros).Tables[0];

                return dtresultado;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_dameDatosMenu detalle: \n" + ex.Message, ex);
            }

        }

        public DataTable DameConfiguracionPagina(int codiPagina)
        {
            try
            {
                DataTable dtresultado;
                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idModulo", SqlDbType.Int), _SqlValue: codiPagina)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_dameConfigModulo", parametros).Tables[0];

                return dtresultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameConfigModulo detalle: \n" + ex.Message, ex);
            }
        }



        public List<Perfil> DamePerfiles()
        {
            try
            {
                DataTable dtresultado;
                List<Perfil> miListaPerfil = new List<Perfil>();
                dtresultado = BaseDatossql.LoadDataSet("sp_damePerfiles").Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaPerfil;
                }


                miListaPerfil = (from elemento in dtresultado.AsEnumerable()
                                 select new Perfil
                                 {
                                     Id = Convert.ToInt32(elemento["pfId"]),
                                     Nombre = elemento["pfNombre"].ToString().Trim(),
                                     Desc = elemento["pfDesc"].ToString().Trim(),
                                     Activo = Convert.ToBoolean(elemento["pfActivo"]),
                                     Creado = true
                                 }).ToList();
                return miListaPerfil;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_damePerfiles detalle: \n" + ex.Message, ex);
            }
        }


        public List<PerfilXModulo> DameModulosPerfil(int idPerfil)
        {
            try
            {
                DataTable dtresultado;
                List<PerfilXModulo> miListaModulosxPerfil = new List<PerfilXModulo>();


                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idPerfil", SqlDbType.Int), _SqlValue: idPerfil)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_dameModulosXPerfil", parametros).Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaModulosxPerfil;
                }


                miListaModulosxPerfil = (from elemento in dtresultado.AsEnumerable()
                                         select new PerfilXModulo
                                         {
                                             IdPerfil = Convert.ToInt32(elemento["fiIdPerfil"]),
                                             IdModulo = Convert.ToInt32(elemento["fiIdcModulo"]),
                                             Creado = true
                                         }).ToList();
                return miListaModulosxPerfil;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameModulosXPerfil detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean NuevoPerfil(string Nombre, string descripcion, Boolean isActivo)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Nombre", SqlDbType.VarChar), _SqlValue: Nombre),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Desc", SqlDbType.VarChar), _SqlValue: descripcion),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Activo", SqlDbType.Bit), _SqlValue:isActivo)
                };


                dtresultado = BaseDatossql.LoadDataSet("sp_altaPerfil", parametros).Tables[0];

                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_altaPerfil detalle: la operacion de insercion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_altaPerfil detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean ActualizaPerfil(Perfil perfil)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@IdPerfil", SqlDbType.VarChar), _SqlValue: perfil.Id),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Nombre", SqlDbType.VarChar), _SqlValue: perfil.Nombre),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Descripcion", SqlDbType.VarChar), _SqlValue: perfil.Desc),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Activo", SqlDbType.Bit), _SqlValue:perfil.Activo)
                };


                dtresultado = BaseDatossql.LoadDataSet("sp_actualizaPerfil", parametros).Tables[0];

                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_actualizaPerfil detalle: la operacion de actulizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_actualizaPerfil detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean ActualizaModulo(PerfilXModulo perfilModulo, int operacion)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idPefil", SqlDbType.Int), _SqlValue: perfilModulo.IdPerfil),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idModulo", SqlDbType.Int), _SqlValue: perfilModulo.IdModulo),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@operacion", SqlDbType.Int), _SqlValue:operacion)
                };
                dtresultado = BaseDatossql.LoadDataSet("sp_modificarModulo", parametros).Tables[0];

                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_modificarModulo detalle: la operacion de actualizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_modificarModulo detalle: \n" + ex.Message, ex);
            }
        }


        public List<PerfilesXUsuario> DamePerfilesUsuario(int idUsuario)
        {
            try
            {
                DataTable dtresultado;
                List<PerfilesXUsuario> miListaPerfilesUsuario = new List<PerfilesXUsuario>();


                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idUsuario", SqlDbType.Int), _SqlValue: idUsuario)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_damePerfilesxUsuario", parametros).Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaPerfilesUsuario;
                }


                miListaPerfilesUsuario = (from elemento in dtresultado.AsEnumerable()
                                          select new PerfilesXUsuario
                                          {
                                              IdPerfil = Convert.ToInt32(elemento["puPerfil"]),
                                              IdUsuario = Convert.ToInt32(elemento["puUsuario"]),
                                              Creado = true
                                          }).ToList();
                return miListaPerfilesUsuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_damePerfilesxUsuario detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean ActualizaPerfilesUsuario(int idUsuario, int idPerfil, int operacion)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idUsuario", SqlDbType.Int), _SqlValue: idUsuario),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idPefil", SqlDbType.Int), _SqlValue: idPerfil),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@operacion", SqlDbType.Int), _SqlValue:operacion)
                };
                dtresultado = BaseDatossql.LoadDataSet("sp_actualizaPerfUsuario", parametros).Tables[0];

                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_actualizaPerfUsuario detalle: la operacion de actualizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_actualizaPerfUsuario detalle: \n" + ex.Message, ex);
            }
        }


        public List<Modulo> DameDatosModulos()
        {
            try
            {
                DataTable dtresultado;
                List<Modulo> miListaModulos = new List<Modulo>();
                dtresultado = BaseDatossql.LoadDataSet("sp_dameTodosModulos").Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaModulos;
                }


                miListaModulos = (from elemento in dtresultado.AsEnumerable()
                                  select new Modulo
                                  {
                                      IdModulo = Convert.ToInt32(elemento["fiIdModulo"]),
                                      Descripcion = elemento["fcDescModulo"].ToString().Trim(),
                                      DescripcioLarga = elemento["fcDesModuloLargo"].ToString().Trim(),
                                      URL = elemento["fcURL"].ToString().Trim(),
                                      ParentID = elemento["fiParentId"] != DBNull.Value ? Convert.ToInt32(elemento["fiParentId"]) : 0,
                                      UrlICon = elemento["fiUrlIco"].ToString().Trim(),
                                      UrlIConLarge = elemento["fiUrlIcoLarge"].ToString().Trim(),
                                      Orden = Convert.ToInt32(elemento["fiOrden"]),
                                      Version = elemento["fiVersion"].ToString().Trim(),
                                      Comentarios = elemento["fiComentarios"].ToString().Trim(),
                                      Creado = true
                                  }).ToList();
                return miListaModulos;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameTodosModulos detalle: \n" + ex.Message, ex);
            }
        }




        public Boolean ActualizarDatosModulo(Modulo miModulo)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@IdModulo", SqlDbType.Int), _SqlValue: miModulo.IdModulo),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@DescModulo", SqlDbType.VarChar), _SqlValue: miModulo.Descripcion),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@DesModuloLargo", SqlDbType.VarChar), _SqlValue: miModulo.DescripcioLarga),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@URL", SqlDbType.VarChar), _SqlValue: miModulo.URL),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@ParentId", SqlDbType.Int), _SqlValue: miModulo.ParentID),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@UrlIco", SqlDbType.VarChar), _SqlValue: miModulo.UrlICon),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@UrlIcoLarge", SqlDbType.VarChar), _SqlValue: miModulo.UrlIConLarge),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Orden", SqlDbType.Int), _SqlValue: miModulo.Orden),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Version", SqlDbType.VarChar), _SqlValue: miModulo.Version),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Comentarios", SqlDbType.VarChar), _SqlValue: miModulo.Comentarios)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_actualizaDatosModulo", parametros).Tables[0];


                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_actualizaDatosModulo detalle: la operacion de actulizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_actualizaDatosModulo detalle: \n" + ex.Message, ex);
            }
        }



        public Boolean AltaModulo(Modulo miModulo)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@DescModulo", SqlDbType.VarChar), _SqlValue: miModulo.Descripcion),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@DesModuloLargo", SqlDbType.VarChar), _SqlValue: miModulo.DescripcioLarga),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@URL", SqlDbType.VarChar), _SqlValue: miModulo.URL),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@ParentId", SqlDbType.Int), _SqlValue: miModulo.ParentID),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@UrlIco", SqlDbType.VarChar), _SqlValue: miModulo.UrlICon),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@UrlIcoLarge", SqlDbType.VarChar), _SqlValue: miModulo.UrlIConLarge),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Orden", SqlDbType.Int), _SqlValue: miModulo.Orden),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Version", SqlDbType.VarChar), _SqlValue: miModulo.Version),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Comentarios", SqlDbType.VarChar), _SqlValue: miModulo.Comentarios)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_AltaNuevoModulo", parametros).Tables[0];


                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_AltaNuevoModulo detalle: la operacion de actulizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_AltaNuevoModulo detalle: \n" + ex.Message, ex);
            }
        }


        public List<Sociedad> DameDatosSociedades()
        {
            try
            {
                DataTable dtresultado;
                List<Sociedad> miListaSociedades = new List<Sociedad>();
                dtresultado = BaseDatossql.LoadDataSet("sp_dameTodasSociedades").Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaSociedades;
                }


                miListaSociedades = (from elemento in dtresultado.AsEnumerable()
                                     select new Sociedad
                                     {
                                         IdCodigo = Convert.ToInt32(elemento["scCodigo"]),
                                         Nombre = elemento["scNombre"].ToString().Trim(),
                                         codSociedad = elemento["scSociedad"].ToString().Trim(),
                                         SociedadSAP = Convert.ToInt32(elemento["scSociedadSAP"]),
                                         DiasLaborales = Convert.ToInt32(elemento["scDiasLaborales"]),
                                         Creado = true
                                     }).ToList();
                return miListaSociedades;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameTodasSociedades detalle: \n" + ex.Message, ex);
            }
        }


        public List<SociedadXUsuario> DameSociedadesUsuario(long idUsuario)
        {
            try
            {
                DataTable dtresultado;
                List<SociedadXUsuario> miListaSociedadUsuario = new List<SociedadXUsuario>();


                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idUsuario", SqlDbType.BigInt), _SqlValue: idUsuario)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_dameSociedadesUsuario", parametros).Tables[0];

                if (dtresultado.Rows.Count == 0)
                {
                    return miListaSociedadUsuario;
                }


                miListaSociedadUsuario = (from elemento in dtresultado.AsEnumerable()
                                          select new SociedadXUsuario
                                          {
                                              suUsuario = Convert.ToInt64(elemento["suUsuario"]),
                                              suSociedad = Convert.ToInt32(elemento["suSociedad"]),
                                              suPorDefecto = Convert.ToBoolean(elemento["suPorDefecto"]),
                                              Creado = true
                                          }).ToList();
                return miListaSociedadUsuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_dameSociedadesUsuario detalle: \n" + ex.Message, ex);
            }
        }

        public Boolean ActualizaSociedadesUsuario(int idUsuario, int idSociedad, int porDefecto, int operacion)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idUsuario", SqlDbType.Int), _SqlValue: idUsuario),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@idSociedad", SqlDbType.Int), _SqlValue: idSociedad),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@porDefecto", SqlDbType.Int), _SqlValue: porDefecto),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@operacion", SqlDbType.Int), _SqlValue:operacion)
                };
                dtresultado = BaseDatossql.LoadDataSet("sp_actualizaSociedadUsuario", parametros).Tables[0];

                if ((int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1) || (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 0))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_actualizaSociedadUsuario detalle: la operacion de actualizacion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_actualizaSociedadUsuario detalle: \n" + ex.Message, ex);
            }
        }


        public Boolean NuevaSociedad(string Nombre, string CodSociedad, int SociedadSAP, int DiasLaborales)
        {
            try
            {
                DataTable dtresultado;

                List<SqlParamTranfer> parametros = new List<SqlParamTranfer>
                {
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@Nombre", SqlDbType.VarChar), _SqlValue: Nombre),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@scSociedad", SqlDbType.VarChar), _SqlValue: CodSociedad),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@scSociedadSAP", SqlDbType.Int), _SqlValue:SociedadSAP),
                new SqlParamTranfer( _SqlParameter: new SqlParameter("@scDiasLaborales", SqlDbType.Int), _SqlValue:DiasLaborales)
                };

                dtresultado = BaseDatossql.LoadDataSet("sp_altaSociedad", parametros).Tables[0];

                if (int.Parse(dtresultado.Rows[0]["RES"].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error en sp_altaSociedad detalle: la operacion de insercion retorno @@rowcount =0");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_altaSociedad detalle: \n" + ex.Message, ex);
            }
        }




    }
}
