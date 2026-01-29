using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BLS.Web.Controles.Servidor;
using BLS.Negocio.Operativa;
using System.Data;
using System.Web.UI;
using BLS.Negocio.ORM;


namespace BLS.Web.Controles.Servidor
{
    public class PageBase : System.Web.UI.Page
    {
        #region Variables privadas
        public DatosUsuario datosUsuario = new DatosUsuario();
        protected virtual bool RequiereSesion => true;

        public UsuariosEXT UsuarioPagina
        {
            get
            {
                UsuariosEXT user = null;
                if (Session["usuario"] != null)
                {
                    return (UsuariosEXT)Session["usuario"];
                }
                else
                {
                    return user;
                }
            }
            set
            {
                Session["usuario"] = value;
            }
        }
        public List<PerfilXOperaciones> AccionesPermitidasUsuario
        {
            get
            {
                if (Session["AccionesControXPerfil"] != null)
                {
                    return (List<PerfilXOperaciones>)Session["AccionesControXPerfil"];
                }
                else
                {
                    return new List<PerfilXOperaciones>();
                }
            }
        }
        public List<Sociedad> SociedadesPermitidas
        {
            get
            {
                List<Sociedad> resultado = new List<Sociedad>();

                if (Session["listaSociedades"] != null && Session["sociedadesXusuario"] != null)
                {
                   var ListaSociedades =(List<Sociedad>) Session["listaSociedades"];
                   var ListaSociedadesAutorizadas = (List<SociedadXUsuario>)Session["sociedadesXusuario"];

                    if (ListaSociedadesAutorizadas.Count>0)
                    {

                        foreach (var item in ListaSociedades)
                        {
                            if (ListaSociedadesAutorizadas.FirstOrDefault(x => x.suPorDefecto == true) != null)
                            {
                                if (item.IdCodigo == ListaSociedadesAutorizadas.FirstOrDefault(x => x.suPorDefecto == true).suSociedad)
                                {
                                    item.porDefecto = true;
                                }
                            }

                        }

                        resultado = (from dato in ListaSociedades
                                     where ListaSociedadesAutorizadas.Exists(x => x.suSociedad == dato.IdCodigo)
                                     select dato).ToList();

                        resultado = resultado.OrderByDescending(x => x.porDefecto).ToList();
                    }

                }

                return resultado;
            }
        }
      

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
             InitializeComponent();

            // ✅ Si la página no requiere sesión, NO validamos
            if (!RequiereSesion) return;

            // Aquí tu validación real
            if (UsuarioPagina == null) // o tu Session["usuario"] == null
            {
                // ✅ Evita llenar historial y rompe frames
                var js = "window.top.location.replace('/login.aspx');";

                // Si es callback/async postback usa JS
                bool isAsync = this.IsCallback || (System.Web.UI.ScriptManager.GetCurrent(this)?.IsInAsyncPostBack ?? false);
                if (isAsync)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(
                        this, this.GetType(), Guid.NewGuid().ToString(), js, true);
                }
                else
                {
                    // request normal: redirect servidor (más estable)
                    Response.Redirect("~/login.aspx", true);
                }
            }
        }
        private void Pagina_Error(object sender, EventArgs e)
        {

            Server.Transfer("/Controles/paginas/Error.aspx", true);


        }
        private void InitializeComponent()
        {
            this.Error += new EventHandler(Pagina_Error);
        }
        #endregion
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //AutoRedirect();
        }
        public void AutoRedirect()
        {
            int int_MilliSecondsTimeOut = (this.Session.Timeout * 60000);
            string str_Script = @"
               <script type='text/javascript'> 
                   intervalset = window.setInterval('Redirect()'," +
                       int_MilliSecondsTimeOut.ToString() + @");
                   function Redirect()
                   {
                       window.parent.location.href='/login.aspx'; 
                   }
               </script>";
          
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", str_Script);
        }
        public void InsertarScript(string id, string script)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("$(document).ready(function(){ ");
            sbScript.Append(script);
            sbScript.Append(" });");
            this.ClientScript.RegisterStartupScript(this.GetType(), id, sbScript.ToString(), true);
        }
        public void WindowOpen(string url)
        {
            string script = "window.open('" + url + "', '_blank');";
            this.InsertarScript("open", script);
        }

        #region EjecutarJavaScript

        /// <summary>
        /// Ejecuta el código javascript especificado
        /// </summary>
        /// <param name="codigoJavaScript">código javascript que se ejecuta</param>
        public void EjecutarJavaScript(string codigoJavaScript)
        {
            this.EjecutarJavaScript(codigoJavaScript, "EjecutarJavaScript", true);
        }

        /// <summary>
        /// Ejecuta el código javascript especificado
        /// </summary>
        /// <param name="codigoJavaScript">código javascript que se ejecuta</param>
        /// <param name="nombre">nombre asociado al código javascript</param>
        public void EjecutarJavaScript(string codigoJavaScript, string nombre)
        {
            this.EjecutarJavaScript(codigoJavaScript, nombre, true);
        }

        /// <summary>
        /// Ejecuta el código javascript especificado
        /// </summary>
        /// <param name="codigoJavaScript">código javascript que se ejecuta</param>
        /// <param name="nombre">nombre asociado al código javascript</param>
        /// <param name="cargarPagina">
        /// True si se ejecuta el script al terminar de cargar la página, 
        /// False si no se hace esa comprobación
        /// </param>
        public void EjecutarJavaScript(string codigoJavaScript, string nombre, bool cargarPagina)
        {
            System.Text.StringBuilder js = new System.Text.StringBuilder();
            js.Append("<script language=\"javascript\">");
            js.Append(codigoJavaScript);
            js.Append("</script>");

            if (cargarPagina == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), nombre, js.ToString());
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), nombre, js.ToString());
            }
        }

        #endregion
        public static string AnadirParametro(string url, string parametro, string valor)
        {
            string urlFinal;

            int posicionParametro = url.IndexOf("?" + parametro + "=");
            if (posicionParametro < 0)
            {
                posicionParametro = url.IndexOf("&" + parametro + "=");
            }

            if (posicionParametro > -1)
            {
                //Ya existe el parámetro, hay que modificar su valor
                //Se salta el separador anterior
                posicionParametro = posicionParametro + 1;
                urlFinal = url.Substring(0, posicionParametro) + parametro + "=" + valor;
                //busca el siguiente separador
                int posicionSeparador = url.IndexOf("&", posicionParametro);
                if (posicionSeparador > -1)
                {
                    urlFinal = urlFinal + url.Substring(posicionSeparador);
                }
            }
            else
            {
                //No existe el parámetro, lo añade
                string separador = "?";

                if (url.IndexOf(separador) > -1)
                {
                    separador = "&";
                }

                urlFinal = url + separador + parametro + "=" + valor;
            }

            return urlFinal;
        }

    }
}