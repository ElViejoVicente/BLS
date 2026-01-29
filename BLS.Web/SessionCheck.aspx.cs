using System;

namespace BLS.Web
{
    public partial class SessionCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            var alive = (Session["usuario"] != null); // esta es tu sesión real
            Response.Write(alive ? "{\"alive\":true}" : "{\"alive\":false}");
            Response.End();
        }
    }
}
