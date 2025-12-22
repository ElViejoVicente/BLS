using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Controles.Usuario
{
    public partial class InfoMsgBox : System.Web.UI.UserControl
    {

        public enum tipoMsg
        {
            info = 1,
            success = 2,
            warning = 3,
            error = 4,
            preguntar = 5

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Boolean mostrarMensaje(string mensaje, tipoMsg tipoMenssaje)
        {
            try
            {
                if (mensaje.Trim() == "" && tipoMenssaje == 0)
                {
                    return false;
                }

                if (tipoMenssaje == tipoMsg.info)
                {
                    //ejemplo de mensaje
                    //cuSweetMsgbox1.mostrarMensaje("Seleccione un filtro de busqueda antes de consultar.", Controles.Usuario.SweetMsgBox.tipoMsg.info);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "msgInfo(\"" + mensaje + "\")", true);
                }
                else if (tipoMenssaje == tipoMsg.success)
                {
                    //ejemplo de mensaje
                    //cuInfoMsgbox1.mostrarMensaje("Usuario dado de alta con éxito.", Controles.Usuario.InfoMsgBox.tipoMsg.success);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "msgSuccess(\"" + mensaje + "\")", true);
                }
                else if (tipoMenssaje == tipoMsg.warning)
                {
                    //ejemplo de mensaje
                    //cuInfoMsgbox1.mostrarMensaje("No todas las familias cuentan con una  planificación.", Controles.Usuario.InfoMsgBox.tipoMsg.warning);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "msgWarning(\"" + mensaje + "\")", true);
                }
                else if (tipoMenssaje == tipoMsg.error)
                {
                    //ejemplo de mensaje
                    //cuInfoMsgbox1.mostrarMensaje("ha fallado el procedimiento almacenado storeProcedurotest en la base de datos.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "msgError(\"" + mensaje + "\")", true);
                }
                else if (tipoMenssaje == tipoMsg.preguntar)
                {
                    //ejemplo de mensaje
                    //cuInfoMsgbox1.mostrarMensaje("¿Esta seguro de eliminar toda la base de datos y todo el GPB?", Controles.Usuario.InfoMsgBox.tipoMsg.preguntar);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "msgQuestion(\"" + mensaje + "\")", true);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}