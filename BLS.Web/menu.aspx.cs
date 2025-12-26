using DevExpress.Web;
using BLS.Negocio.Operativa;
using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLS.Negocio.ORM;

namespace BLS.Web
{
    public partial class menu : PageBase
    {
        DatosUsuario datosUsuario = new DatosUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                if (Session["usuario"] != null)
                {
                    //Response.Redirect("login.aspx");
                    CargarConfiguracionUser();
                }
                GeneraArbol();
                CargarOperacionXPerfil();
            }
        }
        //2021-05-25 lo operaciones por perfil se utilizan para limitar en un modulo aspx las acciones por ejemplo que un perfil puedo ver o no un boton o ejecutar un accione
        protected void CargarOperacionXPerfil()
        {
            try
            {
                // datosUsuario = new DatosUsuario();

                var AccionesPermitidad = datosUsuario.DameAccionesPermitidas(Idusuario: ((Usuarios)Session["usuario"]).usCodigo);
                if (AccionesPermitidad.Count > 0)
                {
                    Session["AccionesControXPerfil"] = AccionesPermitidad;
                }
                else
                {
                    Session["AccionesControXPerfil"] = null;
                }
            }
            catch (Exception)
            {
                // throw;
            }
        }
        protected void GeneraArbol()
        {
            DataSet ds = new DataSet();
            if (Session["usuario"] != null)
            {
                DataTable nodos = datosUsuario.ObtenNodosMenu(parent: 0, codUsuario: ((Usuarios)Session["usuario"]).usCodigo, vertodo: false).Copy();
                ds.Tables.Add(nodos);
                ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["fiIdModulo"], ds.Tables[0].Columns["fiParentId"]);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row.IsNull("fiParentId"))
                    {
                        TreeViewNode node = new TreeViewNode(text: row["fcDescModulo"].ToString(),
                                                            name: row["fiIdModulo"].ToString(),
                                                            imageUrl: "",
                                                            navigateUrl: "");
                        node.Target = row["fcURL"].ToString();

                        rtvMenu.Nodes.Add(node);
                        AgregaHijos(row, node);
                        rtvMenu.ExpandToNode(node);
                        rtvMenu.CollapseAll();
                    }
                }
                rtvMenu.Nodes[0].Expanded = true;
            }
        }
        private void AgregaHijos(DataRow dbRow, TreeViewNode node)
        {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                TreeViewNode childNode = new TreeViewNode(text: childRow["fiUrlIco"].ToString() + childRow["fcDescModulo"].ToString(),
                                                        name: childRow["fiIdModulo"].ToString(),
                                                        imageUrl: "",
                                                        navigateUrl: "");
                childNode.Target = childRow["fcURL"].ToString();

                node.Nodes.Add(childNode);
                AgregaHijos(childRow, childNode);
                rtvMenu.ExpandToNode(childNode);
            }
        }

        protected void rtvMenu_NodeClick(object source, DevExpress.Web.TreeViewNodeEventArgs e)
        {
           
            string usuario = String.Empty;
            try
            {
                if (!string.IsNullOrEmpty(e.Node.Target.Trim()))
                {
                    var ruta = e.Node.Target;
                    var id = e.Node.Name;

                    Session["urlMenu"]= ruta;

                    Session["idUltimaPagina"] = id;
                    //EjecutarJavaScript("vernodo(" + ruta + ");");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "vernodo("+ ruta + ")", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "parent.headerGPB.location ='" + "header.aspx" + "'; ", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "parent.basefrm.location ='" + ruta + "'; ", true);
                }
                else
                {
                    var ruta = "paginaConstruccion.aspx";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "parent.basefrm.location ='" + ruta + "'", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "", true);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void CargarConfiguracionUser()
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuariosEXT user = (UsuariosEXT)Session["usuario"];
                    lblPerfil.Text = user.NombrePerfil.Trim();
                    lblNomUsuario.Text = user.usNombre.Trim();
                    lblMail.Text = user.usMail;
                   // imagenUser.ImageUrl = "imagenes/menu/avatar-face-head.png";
                }

                //DataTable confiPagina = datosUsuario.DameConfiguracionPagina(codPAgina);
                //if (confiPagina.Rows.Count > 0)
                //{
                //    imagenLogo.ImageUrl = confiPagina.Rows[0]["fiUrlIcoLarge"].ToString();

                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void rtvMenu_ExpandedChanging(object source, TreeViewNodeCancelEventArgs e)
        {
            string Nombre = e.Node.Name;

            if (e.Node.Parent.Name != "")
            {
                e.Node.Expanded = true;
            }
            else
            {
                rtvMenu.CollapseAll();
                e.Node.Expanded = true;
            }
        }
    }
}