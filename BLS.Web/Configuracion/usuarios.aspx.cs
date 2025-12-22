using DevExpress.Web;
using BLS.Negocio.Operativa;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.Configuracion
{
    public partial class usuarios : PageBase
    {
        //DatosSAP_D losdatossap = new DatosSAP_D();
     
        #region variblesPrivadas

        #endregion

        #region propiedades
        public List<Usuario> ListaUsuarios
        {
            get
            {
                List<Usuario> dtUsuarios = new List<Usuario>();
                if (this.ViewState["dtUsuarios"] != null)
                {
                    dtUsuarios = (List<Usuario>)this.ViewState["dtUsuarios"];
                }

                return dtUsuarios;
            }
            set
            {
                this.ViewState["dtUsuarios"] = value;
            }

        }
        public Boolean MiUsuario
        {
            get
            {
                Boolean miusu = false;
                if (this.ViewState["MiUsuario"] != null)
                {
                    miusu = (Boolean)this.ViewState["MiUsuario"];
                }

                return miusu;
            }
            set
            {
                this.ViewState["MiUsuario"] = value;
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;

                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));

                CargarListaUsuarios();
            }
        }

        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                if (codPAgina == 16)
                {
                    MiUsuario = true;
                  
                }
                else
                {
                    MiUsuario = false;
                }

            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void CargarListaUsuarios()
        {
            try
            {
                if (MiUsuario)
                {
                    ListaUsuarios = datosUsuario.DameDatosUsuario(UsuarioPagina.Id);
                }
                else
                {
                    ListaUsuarios = datosUsuario.DameDatosUsuario(-1);
                }
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvUsuarios_DataBinding(object sender, EventArgs e)
        {
            try
            {
                gvUsuarios.DataSource = ListaUsuarios;
                if( MiUsuario)
                {
                    gvUsuarios.SettingsSearchPanel.Visible = false;
                }
               
            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvUsuarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                //Validar si existen cambios de lo contrario no es necesario actulizar nada
                Boolean existenCambios = false;

                foreach (DictionaryEntry item in e.OldValues)
                {
                    if (e.NewValues.Contains(item.Key))
                    {
                        if (!e.NewValues[item.Key].Equals(item.Value))
                        {
                            existenCambios = true;
                        }
                    }
                }

                if (existenCambios == false)
                {
                    gvUsuarios.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("No existen registros.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }



                var miUsuario = ListaUsuarios.Where(x => x.Id == int.Parse(e.Keys[0].ToString())).First();


                if (miUsuario != null)
                {

                    if (!MiUsuario)
                    {
                        //miUsuario.UserName = e.OldValues["UserName"].ToString();
                        miUsuario.Nombre = e.NewValues["Nombre"].ToString();
                        //miUsuario.FechaAlta = DateTime.Parse(e.NewValues["FechaAlta"].ToString());
                        miUsuario.Activo = Boolean.Parse(e.NewValues["Activo"].ToString());
                        miUsuario.Mail = e.NewValues["Mail"].ToString();
                        miUsuario.FechaBaja = DateTime.Parse(e.NewValues["FechaBaja"].ToString());
                        miUsuario.EsProyectista = Boolean.Parse(e.NewValues["EsProyectista"].ToString());
                        miUsuario.EsCreditos = Boolean.Parse(e.NewValues["EsCreditos"].ToString());

                        miUsuario.Avisoemail = Boolean.Parse(e.NewValues["Avisoemail"].ToString());
                        if (e.OldValues["Contraseña"].ToString() != e.NewValues["Contraseña"].ToString())
                        {
                            if (e.NewValues["Contraseña"].ToString().Length < 8 || e.NewValues["Contraseña"].ToString() == "12345678" || e.NewValues["Contraseña"].ToString() == "87654321")
                            {
                                cuInfoMsgbox1.mostrarMensaje(" la contraseña no cumple los niveles de seguridad. Introduzca una contraseña con al menos 8 carácteres", Controles.Usuario.InfoMsgBox.tipoMsg.error);


                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                miUsuario.Contraseña = e.NewValues["Contraseña"].ToString();

                            }
                        }

                        
                        datosUsuario.ActulizarDatosUsuario(miUsuario);
                    }
                    else
                    {
                        miUsuario.Nombre = e.NewValues["Nombre"].ToString();
                        miUsuario.Mail = e.NewValues["Mail"].ToString();
                       // miUsuario.Avisoemail = Boolean.Parse(e.NewValues["Avisoemail"].ToString());
                        if (e.OldValues["Contraseña"].ToString() != e.NewValues["Contraseña"].ToString())
                        {
                            if (e.NewValues["Contraseña"].ToString().Length < 8 || e.NewValues["Contraseña"].ToString() == "12345678" || e.NewValues["Contraseña"].ToString() == "87654321")
                            {
                                cuInfoMsgbox1.mostrarMensaje(" la contraseña no cumple los niveles de seguridad. Introduzca una contraseña con al menos 8 carácteres", Controles.Usuario.InfoMsgBox.tipoMsg.error);


                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                miUsuario.Contraseña = e.NewValues["Contraseña"].ToString();
                            }
                        }
                        datosUsuario.ActualizarPWD(miUsuario);

                    }

                }

                gvUsuarios.CancelEdit();
                e.Cancel = true;
                CargarListaUsuarios();


            }
            catch (Exception ex)
            {
                gvUsuarios.CancelEdit();
                e.Cancel = true;
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }
        protected void gvUsuarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
         
            
            try
            {


                Usuario nuevoUsuario = new Usuario()
                {
                    Id = 0,
                    UserName = e.NewValues["UserName"].ToString(),
                    Contraseña = e.NewValues["Contraseña"].ToString(),
                    Nombre = e.NewValues["Nombre"].ToString(),
                    FechaAlta = DateTime.Now,
                    Activo = Boolean.Parse(e.NewValues["Activo"].ToString()),
                    Mail = e.NewValues["Mail"].ToString(),
                    FechaBaja = DateTime.Parse(e.NewValues["FechaBaja"].ToString()),
                    EsProyectista = Boolean.Parse(e.NewValues["EsProyectista"].ToString()),
                    EsCreditos = Boolean.Parse(e.NewValues["EsCreditos"].ToString()),
                    Avisoemail = Boolean.Parse(e.NewValues["Avisoemail"].ToString()),
                    Creado = false
                };


                datosUsuario.AltaUsuario(nuevoUsuario);


                gvUsuarios.CancelEdit();
                e.Cancel = true;
                CargarListaUsuarios();

            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }


        protected void gvUsuarios_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                (gvUsuarios.Columns["Contraseña"] as GridViewDataColumn).EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.True;
                (gvUsuarios.Columns["UserName"] as GridViewDataColumn).EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.True;
                e.NewValues.Add("FechaAlta", DateTime.Now);
                e.NewValues.Add("FechaBaja", Constantes.FechaGlobal);
                e.NewValues.Add("UserName", "");
                e.NewValues.Add("Contraseña", "");
                e.NewValues.Add("Activo", true);
                e.NewValues.Add("Avisoemail", true);
            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvUsuarios_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            int clave = (int)e.KeyValue;
            if (MiUsuario)
            {
                if (e.Column.FieldName == "FechaBaja")
                {
                    ASPxTextBox  fechabaja= e.Editor as ASPxTextBox;
                    fechabaja.Enabled = false;
                }
            }
            

        }




        protected void gvUsuarios_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;
            if (MiUsuario)
            {
                gvUsuarios.Columns["FechaBaja"].Visible = false;
            }
        }

        protected void gvUsuarios_DataBound(object sender, EventArgs e)
        {
            if (MiUsuario)
            {
                
                gvUsuarios.Columns[5].Visible = false;
                gvUsuarios.Columns[6].Visible = false;
                gvUsuarios.Columns[8].Visible = false;
                gvUsuarios.Columns[9].Visible = false;
                gvUsuarios.Columns[10].Visible = false;
                //gvUsuarios.Columns[11].Visible = false;
                GridViewCommandColumn col = (GridViewCommandColumn)gvUsuarios.Columns[0];
                col.ShowNewButtonInHeader = false;
            }
        }

        protected void gvUsuarios_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (MiUsuario)
            {
                if (e.ButtonType== ColumnCommandButtonType.New)
                {
                    e.Visible = false;
                }
            }
            else
            {
                if (e.ButtonType == ColumnCommandButtonType.New)
                {
                    e.Visible = true;
                }
            }
        }

        protected void gvUsuarios_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.IsNewRow)
            {

                //Validar que el usuario a crear no exista la en la lista de usuarios

                var usuarioExistente = ListaUsuarios.Find(x => x.UserName == e.NewValues["UserName"].ToString().Trim());

                if (usuarioExistente != null)
                {

                    e.RowError += "El nombre de usuario: " + e.NewValues["UserName"].ToString() + " Ya existe utilice otro. \n ";
           
                }
                if (e.NewValues["Contraseña"].ToString().Length < 8 || e.NewValues["Contraseña"].ToString() == "12345678" || e.NewValues["Contraseña"].ToString() == "87654321")
                {
                    e.RowError += "La contraseña no cumple los niveles de seguridad. Introduzca una contraseña con al menos 8 carácteres. \n ";

                }


            }
        }
    }
}