using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EmailLogGGB
{
    public class DatosGesag
    {
        private static WebClient wsProxy = new WebClient();
        public static DataTable ConsultaGenericaGESAC(string sociedad, string idConsulta)
        {
            DataTable miResultadoG = new DataTable();
            try
            {
               
                var resultadoRes = wsProxy.DownloadString((new Uri("http://wsgesag-p.clgrupoindustrial.com/WsGesag.svc/DameConsultaGenericaGESAC/" + sociedad + "/" + idConsulta)));
                Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(resultadoRes));
                miResultadoG.ReadXml(stream);
                DataRow[] dataRows = miResultadoG.Select().OrderBy(u => u["trans_agencia"]).ToArray();
                if (dataRows.Count() > 0)
                {
                    DataTable dt = dataRows.CopyToDataTable();
                    return dt;
                }
                else
                {
                    return miResultadoG;
                }
            }
            catch (Exception ex)
            {

                return miResultadoG;
            }

        }
    }
}
