using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmailLogGGB
{
      class Program
    {
         DatosGesag losdatosGesag = new DatosGesag();
        FuncionesNG lasfuncionesng = new FuncionesNG();
        Funciones lasfunciones = new Funciones();
         static void  Main(string[] args)
        {
            DataTable dtexpediciones = new DataTable();
            DataTable dtemails = new DataTable();
            expedicion[] lasexpediciones = new expedicion[0];
            int numagenciaant = 0;
            int numagenciaact = 0;
            int i = 0;
            DataTable dtexpeporagencia = new DataTable();
            string email="";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI11", "2");
            foreach(DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant!=0)
                {
                   
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                        //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "AG SIDERURGICA BALBOA SA");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;

                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length+1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }
                

            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "AG SIDERURGICA BALBOA SA");
            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI14", "2");
            foreach (DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant != 0)
                {
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                        //Funciones.envioemail(fila, email, "ES", "AG FERRO MALLAS SA");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "AG FERRO MALLAS SA");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length + 1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }

            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "AG FERRO MALLAS SA");
            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI22", "2");
            foreach (DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant != 0)
                {
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                      //  Funciones.envioemail(fila, email, "ES", "CORRUGADOS GETAFE, S.L.");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "CORRUGADOS GETAFE, S.L.");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length + 1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }


            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "CORRUGADOS GETAFE, S.L.");
            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI23", "2");
            foreach (DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant != 0)
                {
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                        //Funciones.envioemail(fila, email, "ES", "CORRUGADOS LASAO S.L.U.");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "CORRUGADOS LASAO S.L.U.");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length + 1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }


            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "CORRUGADOS LASAO S.L.U.");
            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI31", "2");
            foreach (DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant != 0)
                {
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                        //Funciones.envioemail(fila, email, "ES", "MARCELIANO MARTIN");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "MARCELIANO MARTIN");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length + 1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }

            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "MARCELIANO MARTIN");

            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";
            dtexpediciones = DatosGesag.ConsultaGenericaGESAC("FI41", "2");
            foreach (DataRow fila in dtexpediciones.Rows)
            {
                numagenciaact = Convert.ToInt32(fila["trans_agencia"]);
                if (numagenciaant != numagenciaact && numagenciaant != 0)
                {
                    dtemails = FuncionesNG.dameemailagencias(Convert.ToInt32(fila["trans_agencia"]), false);
                    foreach (DataRow filaemail in dtemails.Rows)
                    {
                        if (email != "")
                        {
                            email = email + "," + filaemail["usmail"].ToString().Trim();
                        }
                        else
                        {
                            email = filaemail["usmail"].ToString().Trim();
                        }
                    }
                    if (email != "")
                    {
                        //Funciones.envioemail(fila, email, "ES", "ALFONSO GALLARDO SA");
                        Funciones.envioemailagrupado(lasexpediciones, email, "ES", "ALFONSO GALLARDO SA");
                    }
                    numagenciaant = numagenciaact;
                    Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
                    Array.Resize(ref lasexpediciones, 1);
                    i = 0;
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                }
                else
                {
                    Array.Resize(ref lasexpediciones, lasexpediciones.Length + 1);
                    expedicion unaexpedicion = new expedicion();
                    unaexpedicion.numexpedicion = fila["Expedicion"].ToString();
                    unaexpedicion.fechaestcarga = fila["exped_fecestirecogida"].ToString();
                    unaexpedicion.matricula = fila["trans_mat"].ToString();
                    unaexpedicion.poblacioncarga = fila["pob_carga"].ToString();
                    unaexpedicion.centrocarga = fila["Centro_Carga"].ToString();
                    lasexpediciones[i] = unaexpedicion;
                    i = i + 1;
                    numagenciaant = numagenciaact;
                }


            }
            dtemails = FuncionesNG.dameemailagencias(numagenciaant, false);
            foreach (DataRow filaemail in dtemails.Rows)
            {
                if (email != "")
                {
                    email = email + "," + filaemail["usmail"].ToString().Trim();
                }
                else
                {
                    email = filaemail["usmail"].ToString().Trim();
                }
            }
            if (email != "")
            {
                //Funciones.envioemail(fila, email, "ES", "AG SIDERURGICA BALBOA SA");
                Funciones.envioemailagrupado(lasexpediciones, email, "ES", "ALFONSO GALLARDO SA");

            }
            Array.Clear(lasexpediciones, 0, lasexpediciones.Length);
            Array.Resize(ref lasexpediciones, 1);

            numagenciaant = 0;
            i = 0;
            email = "";


        }
    }
}
