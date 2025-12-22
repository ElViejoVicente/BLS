using DevExpress.Web;
using BLS.Negocio.Operativa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.CodeParser;
using BLS.Web.Controles.Servidor;

namespace BLS.Web.Configuracion
{
    public partial class Perfiles : PageBase
    {
        #region propiedades
        public List<Perfil> ListaPerfiles
        {
            get

            {
                List<Perfil> dtPerfiles = new List<Perfil>();
                if (this.ViewState["dtPerfiles"] != null)
                {
                    dtPerfiles = (List<Perfil>)this.ViewState["dtPerfiles"];
                }

                return dtPerfiles;
            }
            set
            {
                this.ViewState["dtPerfiles"] = value;
            }

        }

        public List<Perfil> ListaPerfilesModulos
        {
            get

            {
                List<Perfil> dtPerfiles = new List<Perfil>();
                if (this.ViewState["dtPerfiles"] != null)
                {
                    dtPerfiles = (List<Perfil>)this.ViewState["dtPerfiles"];
                }

                return dtPerfiles;
            }
            set
            {
                this.ViewState["dtPerfiles"] = value;
            }

        }

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

 
 

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GV_Perfil.Enabled = false;
                rtvModulos.Enabled = false;
                //CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                //tab1
                consultaPerfilesUsuario();
                CargarListaUsuarios();

                //tab2
                rtvModulos.Nodes.Clear();
                consultaPerfiles();
                GeneraArbol();
            }
            ComprobarEvento();
        }



        //protected void CargarConfigruacionHead(int codPAgina)
        //{
        //    try
        //    {
        //        DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
        //        if (confiPAgina.Rows.Count > 0)
        //        {
        //            imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
        //            lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
        //            lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
        //    }

        //}



        private void ComprobarEvento()
        {
            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            switch (nombreEvento)
            {
                case ("seleccionar"):
                    seleccionarPerfil();
                    break;
                case ("asignacionPerfil"):
                    break;
            }
        }

        private void cambioEstatus()
        {

        }

        private void seleccionarPerfil()
        {
            try
            {
                rtvModulos.Enabled = true;
                IEnumerable items = rtvModulos.Nodes.GetVisibleItems();

                foreach (TreeViewNode item in items)
                {
                    item.Checked = false;
                    IEnumerable itemsChild = item.Nodes.GetVisibleItems();
                    foreach (TreeViewNode child in itemsChild)
                    {
                        child.Checked = false;
                        IEnumerable ChildNodes = child.Nodes.GetVisibleItems();
                        foreach (TreeViewNode node in ChildNodes)
                        {
                            node.Checked = false;
                        }

                    }
                }


                List<object> ids = GV_modulo_perfil.GetSelectedFieldValues("Id");
                int idPerfil = Int32.Parse(ids[0].ToString());

                List<PerfilXModulo> dtPerfilesModulos = new List<PerfilXModulo>();
                dtPerfilesModulos = datosUsuario.DameModulosPerfil(idPerfil: idPerfil);

                foreach (PerfilXModulo item in dtPerfilesModulos)
                {
                    try
                    {
                        rtvModulos.Nodes.FindByName(item.IdModulo.ToString()).Checked = true;
                    }
                    catch (Exception)
                    { }
                    
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        protected void GeneraArbol()
        {
            DataSet ds = new DataSet();
            DataTable nodos = datosUsuario.ObtenNodosMenu(parent: 0, codUsuario: ((Usuario)Session["usuario"]).Id, vertodo:true ).Copy();
            ds.Tables.Add(nodos);
            ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["fiIdModulo"], ds.Tables[0].Columns["fiParentId"]);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("fiParentId"))
                {
                    TreeViewNode node = new TreeViewNode(text: row["fcDescModulo"].ToString(),
                                                        name: row["fiIdModulo"].ToString(),
                                                        imageUrl: row["fiUrlIco"].ToString(),
                                                        navigateUrl: "");
                    node.Target = row["fcURL"].ToString();

                    rtvModulos.Nodes.Add(node);
                    AgregaHijos(row, node);

                    rtvModulos.ExpandToNode(node);
                }
            }
        }


        private void AgregaHijos(DataRow dbRow, TreeViewNode node)
        {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                int fidModulo = Int32.Parse(childRow["fiIdModulo"].ToString());
                TreeViewNode childNode = new TreeViewNode(text: childRow["fcDescModulo"].ToString(),
                                                        name: childRow["fiIdModulo"].ToString(),
                                                        imageUrl: childRow["fiUrlIco"].ToString(),
                                                        navigateUrl: "");

                node.Nodes.Add(childNode);
                AgregaHijos(childRow, childNode);
                rtvModulos.AllowCheckNodes = true;
                rtvModulos.ExpandToNode(childNode);
            }
        }


        private void consultaPerfiles()
        {
            try
            {
                ListaPerfilesModulos = datosUsuario.DamePerfiles();
                GV_modulo_perfil.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }


        private void consultaPerfilesUsuario()
        {
            try
            {
                ListaPerfiles = datosUsuario.DamePerfiles();
                GV_Perfil.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }


        protected void GV_modulo_perfil_DataBinding(object sender, EventArgs e)
        {
            try
            {
                GV_modulo_perfil.DataSource = ListaPerfilesModulos;
            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }


        protected void GV_modulo_perfil_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
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
                    GV_modulo_perfil.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("No existen registros.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }


                var miPerfil = ListaPerfilesModulos.Where(x => x.Id == int.Parse(e.Keys[0].ToString())).First();


                if (miPerfil != null)
                {

                    miPerfil.Id = Int32.Parse(e.NewValues["Id"].ToString());
                    miPerfil.Nombre= e.NewValues["Nombre"].ToString();
                    miPerfil.Desc = e.NewValues["Desc"].ToString();
                    miPerfil.Activo = Boolean.Parse(e.NewValues["Activo"].ToString());

                    datosUsuario.ActualizaPerfil(miPerfil);
                }

                GV_modulo_perfil.CancelEdit();
                e.Cancel = true;
                consultaPerfiles();


            }
            catch (Exception ex)
            {
                GV_modulo_perfil.CancelEdit();
                e.Cancel = true;
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }




        }


        protected void GV_modulo_perfil_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {

                string Nombre = e.NewValues["Nombre"].ToString();
                string Descripcion = e.NewValues["Desc"].ToString();
                Boolean Activo = Boolean.Parse(e.NewValues["Activo"].ToString());

                if (Nombre == null || Nombre == "")
                {
                    GV_modulo_perfil.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("Debe capturar los datos requeridos.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                datosUsuario.NuevoPerfil(Nombre, Descripcion, Activo);

                GV_modulo_perfil.CancelEdit();
                e.Cancel = true;
                consultaPerfiles();

                cuInfoMsgbox1.mostrarMensaje("Perfil creado correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.success);
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }


        protected void GV_modulo_perfil_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                (GV_modulo_perfil.Columns["Id"] as GridViewDataColumn).EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.False;
                (GV_modulo_perfil.Columns["Id"] as GridViewDataColumn).Visible = false;
                e.NewValues.Add("Desc", "");
                e.NewValues.Add("Nombre", "");
                e.NewValues.Add("Activo", true);
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }


        protected void GV_Perfil_DataBinding(object sender, EventArgs e)
        {
            try
            {
                GV_Perfil.DataSource = ListaPerfiles;
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }


        protected void GV_Perfil_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
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
                    GV_Perfil.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("No existen registros.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                var idUsuario = Cb_Usuarios.SelectedItem.Value.ToString();      
                if (idUsuario != null)
                {
                    List<Perfil> asignacionPerfiles = new List<Perfil>();
                    Perfil per = new Perfil();
                    foreach (DictionaryEntry item in e.NewValues)
                    {
                        

                        if (item.Key.ToString() == "chk")
                        {
                            per.chk = Boolean.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "Id")
                        {
                            per.Id = Int32.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "Desc")
                        {
                            per.Desc = item.Value.ToString();
                        }
                        else if (item.Key.ToString() == "Activo")
                        {
                            per.Activo = Boolean.Parse(item.Value.ToString());
                        }
                        
                    }
                    asignacionPerfiles.Add(per);

                    foreach (Perfil item in asignacionPerfiles)
                    {
                        int operacion = 0;
                        if (item.chk == true)
                        {
                            operacion = 1;
                        }
                        else
                            operacion = 2;

                        datosUsuario.ActualizaPerfilesUsuario(idUsuario: Int32.Parse(idUsuario),
                                                             idPerfil: item.Id,
                                                             operacion: operacion);

                    }


                    GV_Perfil.CancelEdit();
                    e.Cancel = true;
                    consultaPerfilesxUsuario(Int32.Parse(idUsuario));
                    GV_Perfil.DataBind();
                    }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected void GV_Perfil_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                string Nombre = e.NewValues["Nombre"].ToString();
                string Descripcion = e.NewValues["Desc"].ToString();
                Boolean Activo = Boolean.Parse(e.NewValues["Activo"].ToString());

                if (Nombre == null || Nombre == "")
                {
                    GV_Perfil.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("Debe capturar los datos requeridos.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                datosUsuario.NuevoPerfil(Nombre, Descripcion, Activo);

                GV_Perfil.CancelEdit();
                e.Cancel = true;
                consultaPerfilesUsuario();

                cuInfoMsgbox1.mostrarMensaje("Perfil creado correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.success);


            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }


        protected void GV_Perfil_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                (GV_Perfil.Columns["Id"] as GridViewDataColumn).EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.True;
                e.NewValues.Add("desc", "");
                e.NewValues.Add("Activo", true);
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
                ListaUsuarios = datosUsuario.DameDatosUsuario(-1);
                Cb_Usuarios.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void Cb_Usuarios_DataBinding(object sender, EventArgs e)
        {
            Cb_Usuarios.DataSource = ListaUsuarios;
            Cb_Usuarios.TextField = "UserName";
            Cb_Usuarios.ValueField = "Id";

        }



        protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
        {
            try
            {
                string algo = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rtvModulos_CheckedChanged(object source, TreeViewNodeEventArgs e)
        {
            try
            {
                int idModulo = Int32.Parse(e.Node.Name.ToString());
                List<object> ids = GV_modulo_perfil.GetSelectedFieldValues("Id");
                int idPerfil = Int32.Parse(ids[0].ToString());
                PerfilXModulo modulo = new PerfilXModulo();
                modulo.IdModulo = idModulo;
                modulo.IdPerfil = idPerfil;

                int operacion = 0;
                if (e.Node.Checked)
                {
                    operacion = 1;
                }
                else
                {
                    operacion = 2;
                }


                datosUsuario.ActualizaModulo(perfilModulo: modulo, operacion: operacion);

                seleccionarPerfil();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Cb_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GV_Perfil.Enabled = true;
                int idUsuario = Int32.Parse(Cb_Usuarios.SelectedItem.Value.ToString());
                consultaPerfilesxUsuario(idUsuario);

               // cuInfoMsgbox1.mostrarMensaje("Perfil creado correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void consultaPerfilesxUsuario(int idUsuario)
        {
            try
            {
                foreach (var perfil in ListaPerfiles)
                {
                    perfil.chk = false;
                }

                List<PerfilesXUsuario> miListaPerfilesUsuario = new List<PerfilesXUsuario>();
                miListaPerfilesUsuario = datosUsuario.DamePerfilesUsuario(idUsuario);

                foreach (PerfilesXUsuario perfilUsu in miListaPerfilesUsuario)
                {

                    var miPerfil = ListaPerfiles.Where(x => x.Id == perfilUsu.IdPerfil).FirstOrDefault();
                    if (miPerfil != null)
                    {
                        miPerfil.chk = true;
                    }

                }
                GV_Perfil.DataBind();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected void carTabPage_TabClick(object source, TabControlCancelEventArgs e)
        {
            try
            {
                if (e.Tab.Name == "TpModulos")
                {
                    GV_modulo_perfil.DataBind();
                }
                else
                {
                    GV_Perfil.DataBind();
                }
            }
            catch (Exception ex)
            {



                throw;
            }
        }

        //protected void GV_Perfil_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        //{
        //    //if (e.Column.FieldName == "chk")
        //    //{
                
        //    //    e.Editor.ClientEnabled = false;
        //    //}
        //    GV_Perfil.Enabled = false;
        //}
    }


}