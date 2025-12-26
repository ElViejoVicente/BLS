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
using BLS.Negocio.ORM;
using BLS.Negocio.CRUD;

namespace BLS.Web.Configuracion
{
    public partial class Sociedades : PageBase
    {
        public List<Sociedad> ListaSociedades
        {
            get
            {
                List<Sociedad> dtSociedad = new List<Sociedad>();
                if (this.ViewState["dtSociedad"] != null)
                {
                    dtSociedad = (List<Sociedad>)this.ViewState["dtSociedad"];
                }

                return dtSociedad;
            }
            set
            {
                this.ViewState["dtSociedad"] = value;
            }
        }

        public List<Usuarios> ListaUsuarios
        {
            get
            {
                List<Usuarios> dtUsuarios = new List<Usuarios>();
                if (this.ViewState["dtUsuarios"] != null)
                {
                    dtUsuarios = (List<Usuarios>)this.ViewState["dtUsuarios"];
                }

                return dtUsuarios;
            }
            set
            {
                this.ViewState["dtUsuarios"] = value;
            }

        }

        DatosCrud datosCrud = new DatosCrud();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GV_Sociedad.Enabled = false;
                Response.Expires = 0;

               // CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                CargarListaSociedades();
                CargarListaUsuarios();
            }
            //ComprobarEvento();
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


        //private void ComprobarEvento()
        //{
        //    string nombreEvento = this.Request.Form["__EVENTTARGET"];
        //    switch (nombreEvento)
        //    {
        //        case ("seleccionar"):
        //            seleccionarDafult();
        //            break;
        //        case ("asignacionPerfil"):
        //            break;
        //    }
        //}


        private void seleccionarDafult(int idCodigo)
        {
            try
            {
                //List<object> ids = GV_Sociedad.GetSelectedFieldValues("IdCodigo");

                //int idSociedad = Int32.Parse(ids[0].ToString());

                foreach (var sociedad in ListaSociedades)
                {
                    if(sociedad.IdCodigo== idCodigo)
                    sociedad.porDefecto= true;
                    else
                    sociedad.porDefecto = false;
                }

                //GV_Sociedad.DataBind();
                }

            catch (Exception e)
            {

                throw e;
            }
        }


        protected void CargarListaSociedades()
        {
            try
            {
                ListaSociedades = datosUsuario.DameDatosSociedades();
                GV_Sociedad.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void GV_Sociedad_DataBinding(object sender, EventArgs e)
        {
            try
            {
                GV_Sociedad.DataSource = ListaSociedades;
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void GV_Sociedad_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                    GV_Sociedad.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("No existen registros.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                //seleccionarDafult();

                var idUsuario = Cb_Usuarios.SelectedItem.Value.ToString();
                if (idUsuario != null)
                {
                    List<Sociedad> asignacionSociedad = new List<Sociedad>();
                    Sociedad per = new Sociedad();
                    foreach (DictionaryEntry item in e.NewValues)
                    {


                        if (item.Key.ToString() == "chk")
                        {
                            per.chk = Boolean.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "IdCodigo")
                        {
                            per.IdCodigo = Int32.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "Nombre")
                        {
                            per.Nombre = item.Value.ToString();
                        }
                        else if (item.Key.ToString() == "codSociedad")
                        {
                            per.codSociedad = item.Value.ToString();
                        }
                        else if (item.Key.ToString() == "SociedadSAP")
                        {
                            per.SociedadSAP = Int32.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "DiasLaborales")
                        {
                            per.DiasLaborales = Int32.Parse(item.Value.ToString());
                        }
                        else if (item.Key.ToString() == "porDefecto")
                        {
                            per.porDefecto = Boolean.Parse(item.Value.ToString());
                        }

                    }
                    if(per.porDefecto == true)
                        seleccionarDafult(per.IdCodigo);

                    asignacionSociedad.Add(per);

                    foreach (Sociedad item in asignacionSociedad)
                    {
                        int operacion = 0;
                        int porDEfecto = 0;
                        if (item.chk == true)
                        {
                            operacion = 1;
                        }
                        else
                            operacion = 2;


                        if (item.porDefecto == true)
                        {
                            porDEfecto = 1;
                        }
                        else
                            porDEfecto = 0;


                        datosUsuario.ActualizaSociedadesUsuario(idUsuario: Int32.Parse(idUsuario),
                                                             idSociedad: item.IdCodigo,
                                                             porDefecto: porDEfecto,
                                                             operacion: operacion);

                    }


                    GV_Sociedad.CancelEdit();
                    e.Cancel = true;
                    consultaSociedadesxUsuario(Int32.Parse(idUsuario));
                    GV_Sociedad.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void GV_Sociedad_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            try
            {
                string Nombre = e.NewValues["Nombre"].ToString();
                string CodSociedad = e.NewValues["codSociedad"].ToString();
                int SociedadSAP = Int32.Parse(e.NewValues["SociedadSAP"].ToString());
                int diasLaborales = Int32.Parse(e.NewValues["DiasLaborales"].ToString());
               

                if (Nombre == null || Nombre == "")
                {
                    GV_Sociedad.CancelEdit();
                    e.Cancel = true;

                    cuInfoMsgbox1.mostrarMensaje("Debe capturar los datos requeridos.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    return;
                }

                datosUsuario.NuevaSociedad(Nombre: Nombre,CodSociedad: CodSociedad,SociedadSAP: SociedadSAP, DiasLaborales: diasLaborales);

                GV_Sociedad.CancelEdit();
                e.Cancel = true;

                int idUsuario = Int32.Parse(Cb_Usuarios.SelectedItem.Value.ToString());
                consultaSociedadesxUsuario(idUsuario);

                cuInfoMsgbox1.mostrarMensaje("Perfil creado correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.success);


            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }






        }

        protected void GV_Sociedad_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                //e.NewValues.Add("Nombre", "");
                //e.NewValues.Add("codSociedad","");
                //e.NewValues.Add("SociedadSAP", 0);
                //e.NewValues.Add("DiasLaborales", 0);
                e.NewValues.Add("porDefecto", false);
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

        protected void Cb_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GV_Sociedad.Enabled = true;
                int idUsuario = Int32.Parse(Cb_Usuarios.SelectedItem.Value.ToString());
                consultaSociedadesxUsuario(idUsuario);

                // cuInfoMsgbox1.mostrarMensaje("Perfil creado correctamente.", Controles.Usuario.InfoMsgBox.tipoMsg.success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void consultaSociedadesxUsuario(int idUsuario)
        {
            try
            {
                foreach (var sociedad in ListaSociedades)
                {
                    sociedad.chk = false;
                }

                List<SociedadXUsuario> miListaSociedadUsuario = new List<SociedadXUsuario>();
                miListaSociedadUsuario = datosUsuario.DameSociedadesUsuario(idUsuario);

                foreach (SociedadXUsuario perfilUsu in miListaSociedadUsuario)
                {

                    var miSociedad = ListaSociedades.Where(x => x.IdCodigo == perfilUsu.suSociedad).FirstOrDefault();
                    if (miSociedad != null)
                    {
                        miSociedad.chk = true;
                        if (perfilUsu.suPorDefecto == true)
                        {
                            miSociedad.porDefecto = true;
                        }
                    }

                }
                GV_Sociedad.DataBind();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void CargarListaUsuarios()
        {
            try
            {
                ListaUsuarios = datosCrud.ConsultaUsuario();
                Cb_Usuarios.DataBind();
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

    }
}