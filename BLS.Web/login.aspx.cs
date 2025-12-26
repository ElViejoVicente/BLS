using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BLS.Web
{
    public partial class Login : PageBase
    {
        private UsuariosEXT user = null;
        private List<Sociedad> ListaSociedades = null;
        private List<SociedadXUsuario> ListaSociedadesAutorizadas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["usuario"] = null;
                Session["listaSociedades"] = null;
                Session["sociedadesXusuario"] = null;
                if (!Page.IsPostBack)
                {
                    Response.Expires = 0;
                }
                txtUsername.Focus();

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        protected void BT_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    //ventana de error por que no estan los campos rellenado
                    cuInfoMsgbox1.mostrarMensaje("Todos los campos son requeridos", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    return;
                }

                user = datosUsuario.DameDatosUsuario(txtUsername.Text.Trim());
                if (user == null)
                {
                    //ventana de error por que no existe el usuario
                    cuInfoMsgbox1.mostrarMensaje("Usuario no existe, porfavor verifique.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                if (user.usActivo == false)
                {
                    //ventana de error por que el usuario esta dado de baja
                    cuInfoMsgbox1.mostrarMensaje("Usuario dado de baja.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    return;

                }


                if (PasswordHasher.VerifyPassword(txtPassword.Text.Trim(), user.usPWD))
                {

                    // despues de la validacion de contraseña consultamos las socieades permitidas para este usuario.
                    Session["usuario"] = user;
                      
                    Response.Redirect("index.aspx");


                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Usuario/Contraseña incorrectos.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    //ventana de error por usuario o cony¡traseña no validos
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void cuInfoMsgbox1_RespuestaClicked(object sender, EventArgs e)
        {
            string u = "";
        }

    }
}