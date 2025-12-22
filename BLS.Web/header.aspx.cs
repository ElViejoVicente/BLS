using BLS.Negocio.Operativa;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web
{
    public partial class header : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                Response.Expires = 0;




                obtieneDatosUsuario();

            }

        }

        private void obtieneDatosUsuario()
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    string strHora = DateTime.Now.ToString("HH:mm:ss");
                    HidUsuario.Value = UsuarioPagina.Id.ToString();
                    //lblHora.Text = System.DateTime.Today.ToLongDateString();
                    //lblNomUsuario.Text = ((Usuario)Session["usuario"]).Nombre;
                    try
                    {
                        if (Session["urlMenu"] != null)
                        {
                            String url = Session["urlMenu"].ToString();
                            string[] paramsURL = url.Split('=');

                            //foreach (var parameter in paramsURL)
                            //{
                            //    System.Console.WriteLine($"<{word}>");
                            //}
                            CargarConfigruacionHead(int.Parse(paramsURL[1].ToString()));

                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                var confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                if (confiPAgina.Rows.Count == 0)
                    return;

                var html = ConstruirHtmlCabecera(confiPAgina.Rows[0]);
                lblNombrePagina.Text = html; // Asegurarse que el control permita HTML (Label no auto-escapa).
            }
            catch (Exception)
            {
                // TODO: logging si procede
            }

        }

        private string ConstruirHtmlCabecera(DataRow row)
        {
            // PSEUDOCÓDIGO:
            // 1. Leer valores de columnas (nombre módulo, versión, URL completa).
            // 2. Construir breadcrumb usando urlCompleta:
            //    - Obtener parte de ruta (sin dominio).
            //    - Dividir por '/' ignorando vacíos.
            //    - Eliminar último segmento (página .aspx o módulo final).
            //    - Quitar extensión .aspx de cualquier segmento restante.
            //    - Unir con ' / '. Si queda vacío usar "/".
            // 3. Normalizar (quitar saltos de línea y espacios extremos).
            // 4. Formatear string final.
            // 5. Capturar excepciones y devolver string vacío ante error.
            try
            {
                string nombreModulo = Convert.ToString(row["fcDesModuloLargo"]) ?? string.Empty;
                string nombrePadre = Convert.ToString(row["fiDescPadre"]) ?? string.Empty;
                string urlCompleta = Convert.ToString(row["fcURL"]) ?? string.Empty;
                string version = Convert.ToString(row["fiVersion"]) ?? string.Empty;

                string IconoPadre= Convert.ToString(row["fiIconPadre"]) ?? string.Empty;
                string IconoModulo = Convert.ToString(row["fiUrlIco"]) ?? string.Empty;


       

                string Limpiar(string s) => (s ?? string.Empty).Replace("\r", " ").Replace("\n", " ").Trim();

                string moduloClean = Limpiar(nombreModulo);
                string versionClean = Limpiar(version);
                string IconoPadreClean = Limpiar(IconoPadre);
                string IconoModuloClean = Limpiar(IconoModulo);



                return $"{IconoPadreClean} {nombrePadre} | {IconoModuloClean} {moduloClean} | 🔢 Versión: {versionClean}";
            }
            catch
            {
                return string.Empty;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "window.parent.location.href='/login.aspx'; ", true);
            //Response.Redirect("login.aspx");

        }
    }
}