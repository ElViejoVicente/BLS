using BLS.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using BLS.Negocio.Operativa;
using System.Data;
using ItemMenu = BLS.Negocio.Operativa.ItemMenu;

namespace BLS.Web
{
    public partial class menuMovil : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                //if (Session["usuario"] == null)
                //{
                //    Response.Redirect("login.aspx");
                //}
                GenerarMenu();
            }
            ComprobarEvento();
        }


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


        protected void seleccionarPerfil()
        {


        }


        protected void GenerarMenu()
        {
            try
            {
                DataSet ds = new DataSet();
                if (Session["usuario"] != null)
                {
                    DataTable nodos = datosUsuario.ObtenNodosMenu(0, ((Usuario)Session["usuario"]).Id,false).Copy();
                    ds.Tables.Add(nodos);
                    ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["fiIdModulo"], ds.Tables[0].Columns["fiParentId"]);
                   

                    List<MenuParent> listaPadres = new List<MenuParent>();
                    List<int> listIdsHijos = new List<int>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        MenuParent item = new MenuParent();
                        if (row.IsNull("fiParentId"))
                        {
                            ItemMenu elemento = new ItemMenu();
                            elemento.IdModulo = Int32.Parse(row["fiIdModulo"].ToString());
                            elemento.descModulo = row["fcDescModulo"].ToString();
                            elemento.URL = row["fcURL"].ToString();
                            elemento.Icon = row["fiUrlIco"].ToString();
                            item.IdParent= Int32.Parse(row["fiIdModulo"].ToString());
                            item.Itemparent = elemento;
                            listaPadres.Add(item);
                        }
                        else
                        {
                            listIdsHijos.Add(Int32.Parse(row["fiParentId"].ToString()));
                        }
                    }


                   
                    foreach (MenuParent item in listaPadres)
                    {
                        List<MenuHijos> listaHijos = new List<MenuHijos>();
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            if (!row.IsNull("fiParentId"))
                            {
                                MenuHijos menuHijo = new MenuHijos();
                                int idrow = Int32.Parse(row["fiParentId"].ToString());
                                if (idrow == item.IdParent)
                                {
                                    ItemMenu elemento = new ItemMenu();
                                    elemento.IdModulo = Int32.Parse(row["fiIdModulo"].ToString());
                                    elemento.descModulo = row["fcDescModulo"].ToString();
                                    elemento.URL = row["fcURL"].ToString();
                                    elemento.Icon = row["fiUrlIco"].ToString();

                                    menuHijo.IdParent= Int32.Parse(row["fiIdModulo"].ToString());
                                    menuHijo.Itemparent = elemento;

                                    listIdsHijos.Remove(item.IdParent);

                                     menuHijo.listSubMenus = NodosHijos(ds, menuHijo.IdParent, listIdsHijos);

                                    listaHijos.Add(menuHijo);
                                }
                            }
                        }
                        item.listMenus = listaHijos;
                    }



                    string armadoMenu = "";

                    foreach (MenuParent item in listaPadres)
                    {
                        armadoMenu += "<div class=\"card\">" +
                                                      "<div class=\"card-header\" id=\"heading" + item.IdParent + "\">" +
                                                         "<h2 class=\"mb-5\">" +
                                                             "<a data-toggle=\"collapse\" data-target=\"#collapse" + item.IdParent + "\" aria-expanded=\"false\" aria-controls=\"collapse" + item.IdParent + "\">" +
                                                                 "<span><img class=\"card-img\" src=\""+item.Itemparent.Icon+"\" alt=\"Card image\">" + item.Itemparent.descModulo + "</span>" +
                                                                 "<i class=\"fa fa-chevron-down toggle\"></i>" +
                                                             "</a>" +
                                                         "</h2>" +
                                                     "</div>" +
                                                     "<div id = \"collapse" + item.IdParent + "\" class=\"collapse\" aria-labelledby=\"heading" + item.IdParent + "\" data-parent=\"#accordionMenu\">" +
                                                             AgregaNodosHijos(item) +
                                                     "</div>" +
                                                 "</div>";

                    }
                   

                   accordionMenu.InnerHtml = armadoMenu;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private string AgregaNodosHijos(MenuParent itemParent)
        {
            string menus = "";
            try
            {
                string nodosHijos = "";
                string nodosSubHijos = "";
                List <MenuHijos> listMenu = itemParent.listMenus;

                foreach (MenuHijos itemMenu in listMenu)
                {
                   
                    if (itemMenu.listSubMenus.Count() != 0)
                    {

                        string subHijos = "";
                        List<ItemMenu> listSubMenu = itemMenu.listSubMenus;

                        foreach (ItemMenu itemSub in listSubMenu)
                        {
                            subHijos += "<li id=\"" + itemSub.IdModulo + "\" class=\"list-group-item\"><a href = \"#\" " +
                                            " onClick=\"colapsarmenu(\'" + itemSub.URL + "\')\" ><img class=\"card-img ml-5\" src=\"" + itemSub.Icon + "\" alt=\"Card image\">" + itemSub.descModulo + "</a></li>";
                        }

                        nodosSubHijos += "<div class=\"card-header\" id=\"heading" + itemMenu.IdParent + "\">" +
                                 "<h2 class=\"ml-4 mb-4\">" +
                                    "<a data-toggle=\"collapse\" data-target=\"#collapse" + itemMenu.IdParent + "\" aria-expanded=\"true\" aria-controls=\"collapse" + itemMenu.IdParent + "\">" +
                                         "<span><img class=\"card-img\" src=\"" + itemMenu.Itemparent.Icon + "\" alt=\"Card image\">" + itemMenu.Itemparent.descModulo + "</span>" +
                                         "<i class=\"fa fa-chevron-down toggle\"></i>" +
                                     "</a>" +
                                 "</h2>" +
                             "</div>" +
                             "<div id = \"collapse" + itemMenu.IdParent + "\" class=\"collapse\" aria-labelledby=\"heading" + itemMenu.IdParent + "\" data-parent=\"#collapse" + itemMenu.IdParent + "\">" +
                                 "<div class=\"card-body\">" +
                                     "<ul class=\"list-group\">" +
                                        subHijos +
                                     "</ul>" +
                                 "</div>" +
                             "</div>";
                    }
                    else
                    {
                        nodosHijos += "<li id=\"" + itemMenu.IdParent + "\" class=\"list-group-item\"><a href = \"#\" " +
                       " onClick=\"colapsarmenu(\'"+ itemMenu.Itemparent.URL + "\')\"><img class=\"card-img\" src=\"" + itemMenu.Itemparent.Icon + "\" alt=\"Card image\">" + itemMenu.Itemparent.descModulo + "</a></li>";

                       
                    }

                }

                if (nodosSubHijos != "")
                {
                    menus = "<div class=\"card-body\">" +
                                "<ul class=\"list-group\">" +
                                    nodosHijos +
                                "</ul>" +
                                    nodosSubHijos +
                                "</div>";
                }
                else { 
                 menus = "<div class=\"card-body\">" +
                                "<ul class=\"list-group\">" +
                               nodosHijos +
                                "</ul>" +
                                "</div>";
                }
  
            }
            catch (Exception)
            {

                throw;
            }
            return menus;

        }


        private string NodosSubHijos2(DataRow childRow, string idParent)
        {
            string listaNodosHijos = "";
            foreach (DataRow child in childRow.GetChildRows("NodeRelation"))
            {
                listaNodosHijos += "<li id=\"" + child["fiIdModulo"].ToString() + "\" class=\"list-group-item\"><a href = \"" + child["fcURL"].ToString() +
                                               "\" ><img class=\"card-img\" src=\"" + child["fiUrlIco"].ToString() + "\" alt=\"Card image\">" + child["fcDescModulo"].ToString() + "</a></li>";
            }


            String nodosHijos = "<div class=\"card-header\" id=\"heading" + idParent + "\">" +
                                    "<h2 class=\"ml-5\">" +
                                       "<a data-toggle=\"collapse\" data-target=\"#collapse" + idParent + "\" aria-expanded=\"false\" aria-controls=\"collapse" + idParent + "\">" +
                                            "<span><img class=\"card-img\" src=\"" + childRow["fiUrlIco"].ToString() + "\" alt=\"Card image\">" + childRow["fcDescModulo"].ToString() + "</span>" +
                                            "<i class=\"fa fa-chevron-down toggle\"></i>" +
                                        "</a>" +
                                    "</h2>" +
                                "</div>" +
                                "<div id = \"collapse" + idParent + "\" class=\"collapse\" aria-labelledby=\"heading" + idParent + "\" data-parent=\"#collapse" + idParent + "\">" +
                                    "<div class=\"card-body\">" +
                                        "<ul class=\"list-group\">" +
                                           listaNodosHijos +
                                        "</ul>" +
                                    "</div>" +
                                "</div>";
            return nodosHijos;
        }


        private List<ItemMenu> NodosHijos(DataSet ds, int idParent, List<int> listIdsHijos)
        {
            List<ItemMenu> listaHijos = new List<ItemMenu>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (!row.IsNull("fiParentId"))
                {
                    MenuHijos menuHijo = new MenuHijos();
                    int idrow = Int32.Parse(row["fiParentId"].ToString());
                    if (idrow == idParent)
                    {
                        ItemMenu elemento = new ItemMenu();
                        elemento.IdModulo = Int32.Parse(row["fiIdModulo"].ToString());
                        elemento.descModulo = row["fcDescModulo"].ToString();
                        elemento.URL = row["fcURL"].ToString();
                        elemento.Icon = row["fiUrlIco"].ToString();

                        listaHijos.Add(elemento);
                        listIdsHijos.Remove(idParent);
                    }
                }
            }



            return listaHijos;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "window.parent.location.href='/login.aspx'; ", true);
            //Response.Redirect("login.aspx");

        }

    }
}