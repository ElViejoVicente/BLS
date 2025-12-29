using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.RegistroClientes
{
    public partial class ResumenCreditos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool esNuevoCliente = true;

            if (esNuevoCliente)
            {
                pnlClienteNuevo.ClientVisible= true;
            }
            else
            {
                pnlResumenCliente.ClientVisible = true;
            }


        }
    }
}