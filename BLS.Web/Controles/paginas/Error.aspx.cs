using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Controles.paginas
{

        public partial class Error : System.Web.UI.Page
        {
            #region variblesPrivadas
            DatosUsuario datosUsuario = new DatosUsuario();
            #endregion
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack == false)
                {
                    Response.Expires = 0;


                    string mensaje = this.Request.QueryString["mensaje"];
                    if (mensaje != null)
                    {
                        this.LblMensaje.Text = mensaje;
                        this.PanelMensaje.Visible = true;
                    }
                    else
                    {
                        Exception error = Server.GetLastError();
                        if (error != null)
                        {
                            this.LblMensajeError.Text = error.Message;
                            this.LblMensajeErrorDetallado.Text = error.ToString();

                            string mensajeEmailError = "Error Ocurrido:" + " " + this.Request.Url.ToString() + @": " + error.ToString().Replace('"', '\'');
                        }
                        this.PanelError.Visible = true;
                    }
                }



            }
            protected void CargarConfigruacionHead(int codPAgina)
            {
                try
                {
                    DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                    if (confiPAgina.Rows.Count > 0)
                    {
                        //imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                        //lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                        //lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
                }

            }
            protected void LnkMostrarDetallesError_Click(object sender, EventArgs e)
            {
                this.LblMensajeErrorDetallado.Visible = !this.LblMensajeErrorDetallado.Visible;
                if (this.LblMensajeErrorDetallado.Visible == true)
                {
                    this.LnkMostrarDetallesError.Text = "Ocultar detalles del error";
                }
                else
                {
                    this.LnkMostrarDetallesError.Text = "Mostrar detalles del error";
                }
            }
        }
}