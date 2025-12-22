using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BLS.Web
{
    public class Global : HttpApplication
    {
      
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_End(object sender, EventArgs e)
        {
            //System.Web.Security.FormsAuthentication.SignOut();
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage("",false);
            //Server.Transfer("login.aspx");
            try
            {

                 //window.location.href='/login.aspx'; 
   
            }
            catch (Exception)
            {

                throw;
            }
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.  

        }
       
       
    }
}