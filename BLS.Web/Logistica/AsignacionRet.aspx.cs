using GPB.Web.Controles.Servidor;
using GPB.Negocio.Operativa;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;

namespace GPB.Web
{
    public partial class AsignacionRet : PageBase
    {
        #region variblesPrivadas
        DatosRetornos_D elretorno = new DatosRetornos_D();
        DatosSAP_D losdatossap = new DatosSAP_D();
        Funcioneslog funcioneslog = new Funcioneslog();
        public DataTable DtAsignacion
        {
            get
            {
                DataTable dtasignacion = new DataTable();
                if (ViewState["DtAsignacion"] == null)
                {
                    DataColumn columnaId = new DataColumn("id", typeof(int));
                    DataColumn columnaNumEntrega = new DataColumn("numentrega", typeof(string));
                    DataColumn columnaIdAgencia = new DataColumn("idagencia", typeof(string));
                    DataColumn columnaNombreAgencia = new DataColumn("nombreagencia", typeof(string));
                    DataColumn columnaEmpresaGG = new DataColumn("empresaGG", typeof(string));
                    DataColumn columnaOrigen = new DataColumn("origen", typeof(string));
                    DataColumn columnaDestino = new DataColumn("destino", typeof(string));


                    //Cargamos las columnas
                    dtasignacion.Columns.Add(columnaId);
                    dtasignacion.Columns.Add(columnaNumEntrega);
                    dtasignacion.Columns.Add(columnaIdAgencia);
                    dtasignacion.Columns.Add(columnaNombreAgencia);
                    dtasignacion.Columns.Add(columnaOrigen);
                    dtasignacion.Columns.Add(columnaDestino);
                    dtasignacion.Columns.Add(columnaEmpresaGG);

                    ViewState.Add("DtAsignacion", dtasignacion);


                    return dtasignacion;
                }
                else
                {
                    return (DataTable)ViewState["DtAsignacion"];

                }
            }
            set
            {
                ViewState.Add("DtAsignacion", value);
            }

        }
        public DataTable DTAgencias
        {
            get
            {
                DataTable dtagencias = new DataTable();

                if (Session["DTAgencias"] != null)
                {

                    dtagencias = (DataTable)Session["DTAgencias"];
                }
                else
                {
                    string error = "";
                    dtagencias = losdatossap.dameagencias("", false, UsuarioPagina.CodProveedor.ToString(), ref error);
                    Session["DTAgencias"] = dtagencias;
                }
                return dtagencias;
            }
            set
            {
                Session["DTAgencias"] = value;
            }
        }
        public DataTable DTAgenciasTodos
        {
            get
            {
                DataTable dtagencias = new DataTable();

                if (Session["DTAgenciasTodos"] != null)
                {

                    dtagencias = (DataTable)Session["DTAgenciasTodos"];
                }
                else
                {
                    string error = "";
                    dtagencias = losdatossap.dameagencias("", true, UsuarioPagina.CodProveedor.ToString(), ref error);
                    Session["DTAgenciasTodos"] = dtagencias;
                }
                return dtagencias;

            }
            set
            {
                Session["DTAgenciasTodos"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {


            ComprobarEvento();
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));
                

                //gv_expediciones2.DataBind();
                // LB_AgenciasSeleccionadas.DataBind();
            }
        }
        private void ComprobarEvento()
        {

            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            //CuMensaje.OCultarMensaje();
            switch (nombreEvento)
            {

                //cuando hemos pulsado sobre el botón de estrella
                case ("Refrescaretornos"):
                    Comprobarbloqueo();
                    gv_retornos.DataBind();
                    Pup_AsignarAgencias.ShowOnPageLoad = false;
                    PUp_VerAgencias.ShowOnPageLoad = false;


                    break;


                default:

                    break;
            }


        }
        protected void Comprobarbloqueo()
        {
            if (Session["NumEntrega"] != null)
            {

                Retorno selectRet = elretorno.Damedatosretornopornum(Session["NumEntrega"].ToString());
                if (selectRet.MiNumAgencia == 0 && selectRet.MsMatricula == "")
                {
                    elretorno.bloqueaRetorno(Session["NumEntrega"].ToString() ,1);
                    
                }
                Session["NumEntrega"] = null;
            }
        }
        protected void CargarConfigruacionHead(int codPAgina)
        {
            try
            {
                DataTable confiPAgina = datosUsuario.DameConfiguracionPagina(codPAgina);
                if (confiPAgina.Rows.Count > 0)
                {
                    imagenLogo.ImageUrl = confiPAgina.Rows[0]["fiUrlIcoLarge"].ToString();
                    lblNombrePagina.Text = confiPAgina.Rows[0]["fcDesModuloLargo"].ToString();
                    lblVersion.Text = confiPAgina.Rows[0]["fiVersion"].ToString();
                }
            }
            catch (Exception ex)
            {

                // cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }

        protected void gv_retornos_DataBinding(object sender, EventArgs e)
        {
            gv_retornos.DataSource = losdatossap.dameentregas("");
        }

        protected void btnVerAgencias_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;

            Negocio.Logistica.RetornoPte fila = (Negocio.Logistica.RetornoPte)gv_retornos.GetRow(currentIndex);

            // DataRow dt = container.Grid.GetDataRow(currentIndex);

            HidIdretorno.Value = fila.NumEntrega.ToString();
            HidEmpresa.Value = fila.Sociedad.ToString();
            PUp_VerAgencias.ShowOnPageLoad = true;
        }

        protected void btnAsignarAgencia_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;
            Negocio.Logistica.RetornoPte fila = (Negocio.Logistica.RetornoPte)gv_retornos.GetRow(currentIndex);
            // DataRow dt = container.Grid.GetDataRow(currentIndex);



            HidIdretorno.Value = fila.NumEntrega.ToString();
            HidEmpresa.Value = fila.Sociedad.ToString();
            Retorno selectRet = elretorno.Damedatosretornopornum(fila.NumEntrega.ToString());

            if (selectRet.MiEstado < 2)
            {

                elretorno.bloqueaRetorno(numentrega: selectRet.MsNumEntrega,
                    estadoBloqueo:2);
                string url = "..\\Logistica\\AsignacionMatRet.aspx?initCod=14&idRet=" + selectRet.MsNumEntrega;
                Session["NumEntrega"] = selectRet.MsNumEntrega;
                Session["Empresa"] = fila.Sociedad.ToString();
                Pup_AsignarAgencias.ContentUrl = url;
                Pup_AsignarAgencias.ShowOnPageLoad = true;
            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("El retorno ya fue solicitada por otra agencia, selecciona otra.", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                gv_retornos.DataBind();

            }
        }

        protected void CB_Filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_Agencias.DataBind();
        }

        protected void LB_Agencias_DataBinding(object sender, EventArgs e)
        {
            string error = "";
            DataTable dtfiltrado = new DataTable();
            try
            {
                //LB_Agencias.DataSource = losdatossap.dameagencias("",false, UsuarioPagina.CodProveedor.ToString(), ref error);

                if (CB_Filtros.Text != "Todas")
                {
                    dtfiltrado = DTAgencias.Select("Grupo ='" + CB_Filtros.SelectedItem.Value.ToString() + "'").CopyToDataTable(); ;
                    LB_Agencias.DataSource = dtfiltrado;
                }
                else
                {
                    DataTable dtagenciassinrepe = DTAgencias.DefaultView.ToTable(true, "CodProveedor", "Nombreproveedor");
                    LB_Agencias.DataSource = dtagenciassinrepe;
                }
                //LB_Agencias.DataSource = DTAgencias;
                LB_Agencias.TextField = "Nombreproveedor";
                LB_Agencias.ValueField = "CodProveedor";
            }
            catch (Exception ex)
            {
                cuInfoMsgbox1.mostrarMensaje("Error consultando Agencias" + error, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
        }

        protected void BT_Asignar_Click(object sender, EventArgs e)
        {
            int index;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            //  DataRow datosexpe;
            int Idexpedicion;
            if (gv_retornos.Selection.Count > 0)
            {
                DtAsignacion.Clear();
                //LB_AgenciasSeleccionadas.SelectAll();
                List<Object> valoreKeySeleccionados = gv_retornos.GetSelectedFieldValues("NumEntrega");
                foreach (int numeentrega in valoreKeySeleccionados)
                {
                    index = gv_retornos.FindVisibleIndexByKeyValue(numeentrega);
                    //DataRow datosexpe = gv_expedicion.GetDataRow(index);
                    Negocio.Logistica.RetornoPte fila = (Negocio.Logistica.RetornoPte)gv_retornos.GetRow(index);

                    //lafuncionesgoogle.CodificacionGeografica2();
                   
                    if (fila.NumEntrega != "")
                    {

                        foreach (ListEditItem agenciaselec in LB_Agencias.SelectedItems)
                        {
                            insertafilatabla(fila.NumEntrega, agenciaselec.Value.ToString(), agenciaselec.Text,fila.Poblacion, fila.Destino, fila.Sociedad);
                        }
                    }
                    else
                    {
                        cuInfoMsgbox1.mostrarMensaje("No se ha podido guardar el retorno", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }

                }

            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("Debe seleccionar alguna expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
            GV_Asignacion.DataBind();
        }
        private int insertafilatabla(string numentrega, string numagencia, string nombreagencia, string origen, string destino,  string empresa)
        {
            DataRow nuevafila = DtAsignacion.NewRow();
            int idasignacion = 0;
            int res = 0;
            try
            {
                idasignacion = (this.DtAsignacion.Rows.Count + 1) * 10;
                int maxpos = Convert.ToInt32(DtAsignacion.AsEnumerable().Max(row => row["id"]));
                idasignacion = maxpos + 10;
                nuevafila["id"] = idasignacion;
                nuevafila["numentrega"] = numentrega;
                nuevafila["idagencia"] = numagencia;
                nuevafila["nombreagencia"] = nombreagencia;
             
                nuevafila["origen"] = origen;
                nuevafila["destino"] = destino;
                nuevafila["empresaGG"] = empresa;


                DtAsignacion.Rows.Add(nuevafila);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }

        }

        protected void Gv_AgenciasAsignadas_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void Gv_AgenciasAsignadas_DataBinding(object sender, EventArgs e)
        {
            if (HidIdretorno.Value != "")
            {
                Gv_AgenciasAsignadas.DataSource = elretorno.dameagenciaretorno(HidIdretorno.Value.ToString());

            }
        }

        protected void GV_Asignacion_DataBinding(object sender, EventArgs e)
        {
            GV_Asignacion.DataSource = this.DtAsignacion;
            GV_Asignacion.KeyFieldName = "id";
        }

        protected void GV_Asignacion_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            int index;
            DataRow datosexpe;
            int Idexpedicion;
            string latitud = "", longitud = "", dirgeo = "";
            string latorigen = "", longorigen = "", dirorigen = "";
            decimal coorlatitud = 0, coorlongitud = 0;
            decimal coorlatorigen = 0, coorlongorigen = 0;
            if (gv_retornos.Selection.Count > 0)
            {

                List<Object> valoreKeySeleccionados = gv_retornos.GetSelectedFieldValues("NumExpedicion");
                foreach (string numexpe in valoreKeySeleccionados)
                {

                    index = gv_retornos.FindVisibleIndexByKeyValue(numexpe);
                    datosexpe = gv_retornos.GetDataRow(index);

                   

                        insertafilatabla( datosexpe["NumEntrega"].ToString(), datosexpe["NumAgencia"].ToString(), datosexpe["NombreAgencia"].ToString(), datosexpe["origen"].ToString(), datosexpe["destino"].ToString(), datosexpe["empresa"].ToString());

                    

                }

            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("Debe seleccionar alguna expedición", Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }
            GV_Asignacion.DataBind();
        }

        protected void BT_Quitartodo_Click(object sender, EventArgs e)
        {
            elretorno.QuitaAsignacionRet(0, HidIdretorno.Value.ToString(), HidEmpresa.Value.ToString());
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void btn_quitaragencia_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer row2 = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            GridViewDataItemTemplateContainer container = ((ASPxButton)sender).NamingContainer as GridViewDataItemTemplateContainer;
            int currentIndex = container.VisibleIndex;

            DataRow fila = (DataRow)Gv_AgenciasAsignadas.GetDataRow(currentIndex);
            elretorno.QuitaAsignacionRet(Convert.ToInt32(fila["IdAgencia"]), HidIdretorno.Value.ToString(), HidEmpresa.Value.ToString());
            Gv_AgenciasAsignadas.DataBind();
        }

        protected void btnGuaqrdar_Click(object sender, EventArgs e)
        {
            int idagenciaant = 0;
            int idagenciaact = 0;
            foreach (DataRow fila in DtAsignacion.Rows)
            {
                if (Convert.ToInt32(fila["idagencia"]) == 115043)
                {
                    int i = 0;
                }
                int res = elretorno.GuardaAsignacion(fila["idagencia"].ToString(),fila["numentrega"].ToString(), fila["nombreagencia"].ToString());


                //  enviaemailasig(Convert.ToInt32(fila["idagencia"]));
            }
            DataTable dtagenciasasig = DtAsignacion.DefaultView.ToTable(true, "idagencia");
            foreach (DataRow fila in dtagenciasasig.Rows)
            {
                enviaemailasigret(Convert.ToInt32(fila["idagencia"]));
            }
            DataTable dtexpasig = DtAsignacion.DefaultView.ToTable(true,  "numentrega", "empresaGG");
            foreach (DataRow fila in dtexpasig.Rows)
            {
                elretorno.guardalog(fila["numentrega"].ToString(), fila["empresaGG"].ToString(), "", "0", "Asignación agencias retorno", UsuarioPagina.UserName);
            
            }
            DtAsignacion.Clear();
            GV_Asignacion.DataBind();
            gv_retornos.Selection.UnselectAll();
            LB_Agencias.UnselectAll();
            cuInfoMsgbox1.mostrarMensaje("Asignaciones Guardadas", Controles.Usuario.InfoMsgBox.tipoMsg.info);
        }
        protected void enviaemailasigret(int idagencia)
        {
            string email = "";
            DataTable listaemail = new DataTable();
            DatosUsuario losdatousu = new DatosUsuario();
            listaemail = losdatousu.dameemailagencias(idagencia, true);
            foreach (DataRow fila in listaemail.Rows)
            {
                if (email == "")
                {
                    email = fila["usmail"].ToString();
                }
                else
                {
                    email = email + "," + fila["usmail"].ToString();
                }
            }
            if (email != "")
            {
                Negocio.Operativa.Emails.envioemailAsginaciónRet(email);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gv_retornos.DataBind();
        }
    }
}