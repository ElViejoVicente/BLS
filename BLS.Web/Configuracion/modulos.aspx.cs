
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
    public partial class Modulos : PageBase
    {

        #region propiedades
        public List<Modulo> ListaModulos
        {
            get
            {
                List<Modulo> dtModulos = new List<Modulo>();
                if (this.ViewState["dtModulos"] != null)
                {
                    dtModulos = (List<Modulo>)this.ViewState["dtModulos"];
                }

                return dtModulos;
            }
            set
            {
                this.ViewState["dtModulos"] = value;
            }

        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;

                //CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                CargarListaModulos();
            }
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

        protected void CargarListaModulos()
        {
            try
            {
                ListaModulos = datosUsuario.DameDatosModulos();
                gvModulos.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }



        protected void gvModulos_DataBinding(object sender, EventArgs e)
        {
            try
            {
                gvModulos.DataSource = ListaModulos;
            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvModulos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                //Validar si existen cambios de lo contrario no es necesario actulizar nada
                Boolean existenCambios = false;

                foreach (DictionaryEntry item in e.OldValues)
                {
                    if (e.NewValues.Contains(item.Key))
                    {
                        if (!e.NewValues[item.Key].Equals(item.Value== null? "": item.Value))
                        {
                            existenCambios = true;
                        }
                    }
                }

                if (existenCambios == false)
                {
                    gvModulos.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("No existen registros.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }



                var miModulo = ListaModulos.Where(x => x.IdModulo == int.Parse(e.Keys[0].ToString())).First();


                if (miModulo != null)
                {
                    miModulo.Descripcion = e.NewValues["Descripcion"].ToString();
                    miModulo.DescripcioLarga = e.NewValues["DescripcioLarga"].ToString();
                    miModulo.URL = e.NewValues["URL"].ToString();
                    miModulo.ParentID = Convert.ToInt32(e.NewValues["ParentID"].ToString());
                    miModulo.UrlICon = e.NewValues["UrlICon"].ToString();
                    miModulo.UrlIConLarge = e.NewValues["UrlIConLarge"].ToString();
                    miModulo.Orden = Convert.ToInt32(e.NewValues["Orden"].ToString());
                    miModulo.Version = e.NewValues["Version"].ToString();
                    miModulo.Comentarios = e.NewValues["Comentarios"].ToString();

                    datosUsuario.ActualizarDatosModulo(miModulo);
                }

                gvModulos.CancelEdit();
                e.Cancel = true;
                CargarListaModulos();

            }
            catch (Exception ex)
            {
                gvModulos.CancelEdit();
                e.Cancel = true;
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvModulos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {

                //Validar que el usuario a crear no exista la en la lista de usuarios

                var moduloExistente = ListaModulos.Find(x => x.Descripcion == e.NewValues["Descripcion"].ToString().Trim());

                if (moduloExistente != null)
                {

                    cuInfoMsgbox1.mostrarMensaje("El nombre del modulo: " + e.NewValues["Descripcion"].ToString() + " Ya existe utilice otro.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

               Modulo nuevoModulo = new Modulo()
                {
                    IdModulo = 0,
                    Descripcion = e.NewValues["Descripcion"].ToString(),
                    DescripcioLarga = e.NewValues["DescripcioLarga"].ToString(),
                    URL = e.NewValues["URL"].ToString(),
                    ParentID = Convert.ToInt32(e.NewValues["ParentID"].ToString()),
                    UrlICon = e.NewValues["UrlICon"].ToString(),
                    UrlIConLarge = e.NewValues["UrlIConLarge"].ToString(),
                    Orden = Convert.ToInt32(e.NewValues["Orden"].ToString()),
                    Version = e.NewValues["Version"].ToString(),
                    Comentarios = e.NewValues["Comentarios"].ToString(),
                    Creado = false
                };

                datosUsuario.AltaModulo(nuevoModulo);

                gvModulos.CancelEdit();
                e.Cancel = true;
                CargarListaModulos();

            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void gvModulos_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {

            try
            {
                e.NewValues.Add("Descripcion", "");
                e.NewValues.Add("DescripcioLarga", "");
                e.NewValues.Add("URL", "");
                e.NewValues.Add("ParentID", 0);
                e.NewValues.Add("UrlICon", "");
                e.NewValues.Add("UrlIConLarge", "");
                e.NewValues.Add("Orden", 1);
                e.NewValues.Add("Version", "");
                e.NewValues.Add("Comentarios", "");
            }
            catch (Exception ex)
            {

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }
    }
}