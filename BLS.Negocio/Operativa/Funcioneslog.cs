using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Web;



using System.Data;
using System.Data.Common;



namespace BLS.Negocio.Operativa
{
    public class Funcioneslog
    {
        public string escribeenlog(string texto )
        {
            string fic;
            string nombrefichero;
            string dia;
            string ruta;
            try
            {
                ruta = ConfigurationManager.AppSettings.Get("rutalog");
                //fic = "C:\\logsubcontratos\\";
                dia = DateTime.Now.ToString("ddMMyyyy");
                nombrefichero = "logdetalle_"  + dia + ".txt";

                fic = ruta + nombrefichero;
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
                sw.WriteLine(texto);
                sw.Close();
                return nombrefichero;
            }
            catch (Exception ex)
            {
                return "";

            }
        }
        public string escribeenlogerror(string texto)
        {
            string fic;
            string nombrefichero;
            string dia;
            string ruta;
            try
            {
                ruta = ConfigurationManager.AppSettings.Get("rutalog");
                //fic = "C:\\logsubcontratos\\";
                dia = DateTime.Now.ToString("ddMMyyyy");
                nombrefichero = "logerror_" + dia + ".txt";

                fic = ruta + nombrefichero;
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
                sw.WriteLine(texto);
                sw.Close();
                return nombrefichero;
            }
            catch (Exception ex)
            {
                return "";

            }
        }
        public void Download(string patch)
        {
            System.IO.FileInfo toDownload =
                       new System.IO.FileInfo(patch);

           HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                       "attachment; filename=" + toDownload.Name);
            HttpContext.Current.Response.AddHeader("Content-Length",
                       toDownload.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.WriteFile(patch);
            HttpContext.Current.Response.End();
        }
     
    }
}
