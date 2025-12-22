using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GPB.Negocio.Servicio_SAP;
using GPB.Negocio.Logistica;
using GPB.Negocio.ApiGoogle;
namespace GPB.Web
{
    public partial class AltaRetornos : PageBase
    {
        #region variablesprivadas
        DatosSAP_D losdatossap = new DatosSAP_D();
        DatosRetornos_D elretorno = new DatosRetornos_D();
        ApiGoogle lafuncionesgoogle = new ApiGoogle();
        public DataTable DTPaises
        {
            get
            {
                DataTable dtpaises = new DataTable();

                if (Session["DTPaises"] != null)
                {

                    dtpaises = (DataTable)Session["DTPaises"];
                }
                else
                {
                    string error = "";
                    dtpaises = losdatossap.damepaises();
                    Session["DTPaises"] = dtpaises;
                }
                return dtpaises;

            }
            set
            {
                Session["DTPaises"] = value;
            }
        }
        public DataTable DTRegiones
        {
            get
            {
                DataTable dtregiones = new DataTable();

                if (Session["DTRegiones"] != null)
                {

                    dtregiones = (DataTable)Session["DTRegiones"];
                }
                else
                {
                    string error = "";
                    if (CB_Pais.SelectedIndex != -1)
                    {
                        dtregiones = losdatossap.dameregiones(CB_Pais.SelectedItem.Value.ToString());
                    }
                    Session["DTRegiones"] = dtregiones;
                }
                return dtregiones;

            }
            set
            {
                Session["DTRegiones"] = value;
            }
        }
        public DataTable DTProveedoresMM
        {
            get
            {
                DataTable dtregiones = new DataTable();

                if (Session["DTProveedoresMM"] != null)
                {

                    dtregiones = (DataTable)Session["DTProveedoresMM"];
                }
                else
                {
                    string error = "";

                    dtregiones = losdatossap.dameproveedoresMM();
                    Session["DTProveedoresMM"] = dtregiones;
                }
                return dtregiones;

            }
            set
            {
                Session["DTProveedoresMM"] = value;
            }
        }
        public DataTable DTPoblaciones
        {
            get
            {
                DataTable dtregiones = new DataTable();

                if (Session["DTPoblaciones"] != null)
                {

                    dtregiones = (DataTable)Session["DTPoblaciones"];
                }
                else
                {
                    string error = "";
                    if (Cb_ProveedoresMM.SelectedIndex != -1)
                    {
                        dtregiones = losdatossap.damePoblacionesProveedorMM(Cb_ProveedoresMM.SelectedItem.Value.ToString());
                        Session["DTPoblaciones"] = dtregiones;
                    }
                }
                return dtregiones;

            }
            set
            {
                Session["DTProveedoresMM"] = value;
            }
        }
        public DataTable DtDetalleCamion
        {
            get
            {
                DataTable dtdetallecamion = new DataTable();
                if (ViewState["DtDetalleCamion"] == null)
                {
                    DataColumn columnaId = new DataColumn("id", typeof(int));
                    DataColumn columnaCantidad = new DataColumn("Cantidad", typeof(Decimal));
                    DataColumn columnaMaterial = new DataColumn("Material", typeof(string));
                    DataColumn columnaDesMaterial = new DataColumn("DesMaterial", typeof(string));
                    


                    //Cargamos las columnas
                    dtdetallecamion.Columns.Add(columnaId);
                    dtdetallecamion.Columns.Add(columnaCantidad);
                    dtdetallecamion.Columns.Add(columnaMaterial);
                    dtdetallecamion.Columns.Add(columnaDesMaterial);

                    ViewState.Add("DtDetalleCamion", dtdetallecamion);


                    return dtdetallecamion;
                }
                else
                {
                    return (DataTable)ViewState["DtDetalleCamion"];

                }
            }
            set
            {
                ViewState.Add("DtDetalleCamion", value);
            }

        }
        #endregion
        protected override PageStatePersister PageStatePersister
        {
            get
            {
                // Unlike as exemplified in the MSDN docs, we cannot simply return a new PageStatePersister
                // every call to this property, as it causes problems
                return new SessionPageStatePersister(this);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Expires = 0;
                CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));

                Cb_ProveedoresMM.DataBind();
                CB_Pais.DataBind();
               // CB_Region.DataBind();
                
                CB_Material.DataBind();
                if (UsuarioPagina.CodProveedor != 0 && UsuarioPagina.Perfil == 9)
                {
                    rellenadatosproveedor();
                 }
                // LB_AgenciasSeleccionadas.DataBind();
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

                cuInfoMsgbox1.mostrarMensaje(ex.Message, Controles.Usuario.InfoMsgBox.tipoMsg.error);
            }

        }
        protected void rellenadatosproveedor()
        {
            DataTable dtdatoproveedor = new DataTable();

            Cb_ProveedoresMM.Value = UsuarioPagina.CodProveedor;
            Cb_ProveedoresMM.Enabled = false;
            dtdatoproveedor = losdatossap.damedatosproveedoresMM(UsuarioPagina.CodProveedor.ToString());
            if (dtdatoproveedor.Rows.Count > 0)
            {
                Txt_Calle.Text = dtdatoproveedor.Rows[0]["Calle"].ToString();
                Txt_Codpostal.Text= dtdatoproveedor.Rows[0]["CodPostal"].ToString();
                CB_Poblaciones.Text= dtdatoproveedor.Rows[0]["Poblacion"].ToString();
                CB_Pais.Value= dtdatoproveedor.Rows[0]["Pais"].ToString();
                //CB_Region.DataBind();
                //CB_Region.Value= dtdatoproveedor.Rows[0]["Region"].ToString();
            }


        }
        protected void btnGuaqrdar_Click(object sender, EventArgs e)
        {
            string numentrega;
            string portes = "";
            string errordev = "";
            string direccion;
            string region = "", pais = "ES";
            string poblacion = "BADAJOZ";
            decimal coorlatitud = 0, coorlongitud = 0;
            string dirgeo;
            int numcamiones = 1;
            string empresaentrega = "";
            ApiGoogle.RootObject resultado;
            if ( CB_Poblaciones.SelectedIndex!=-1  && DtDetalleCamion.Rows.Count>0 && Txt_numcamiones.Text!="0" && CB_Pais.SelectedIndex!=-1)
            {
                numcamiones = Convert.ToInt32(Txt_numcamiones.Text);

                for (int i = 0; i < numcamiones; i++)
                {
                    if (Chb_Portespagados.Checked)
                    {
                        portes = "X";
                    }
                    //numentrega=losdatossap.crearentregaretorno(UsuarioPagina.CodProveedor.ToString(), CB_Material.SelectedItem.Value.ToString(), Convert.ToDecimal(Txt_Cantidad.Text),portes,Txt_Observaciones.Text, Txt_Poblacion.Text, ref errordev);
                    numentrega = losdatossap.crearentregaretorno(Cb_ProveedoresMM.SelectedItem.Value.ToString(), portes, Txt_Observaciones.Text, CB_Poblaciones.SelectedItem.Value.ToString(), DtDetalleCamion, ref errordev, ref empresaentrega);

                    if (numentrega != "")
                    {
                        insertaentregatabla(numentrega);
                        //if (CB_Region.SelectedIndex != -1)
                        //{
                        //    region = CB_Region.SelectedItem.Value.ToString();
                        //}
                        if (CB_Pais.SelectedIndex != -1)
                        {
                            pais = CB_Pais.SelectedItem.Value.ToString();
                        }
                        if (CB_Poblaciones.SelectedIndex != -1)
                        {
                            poblacion = CB_Poblaciones.SelectedItem.Value.ToString();
                        }
                        direccion = Txt_Calle.Text + ", " + poblacion + ", " + Txt_Codpostal.Text + ", " + pais;
                        resultado = lafuncionesgoogle.CodificacionGeografica2(direccion);
                        Txt_Latitud.Text = resultado.results[0].geometry.location.lat.ToString();
                        Txt_Longitud.Text = resultado.results[0].geometry.location.lng.ToString();
                        Txt_dirlatlon.Text = resultado.results[0].formatted_address;
                        coorlatitud = Convert.ToDecimal(resultado.results[0].geometry.location.lat.ToString());
                        coorlongitud = Convert.ToDecimal(resultado.results[0].geometry.location.lng.ToString());
                        dirgeo = resultado.results[0].formatted_address;
                        int elidretorno = elretorno.guardaretorno(0, "", Cb_ProveedoresMM.SelectedItem.Value.ToString(), Txt_Calle.Text,
                            CB_Poblaciones.SelectedItem.Value.ToString(), Txt_Codpostal.Text, "", CB_Pais.Text, coorlatitud, coorlongitud,
                            dirgeo, numentrega, empresaentrega, Convert.ToInt32(Txt_numcamiones.Text));
                        //     guardadistanciasap(numentrega,dirgeo);
                        if (elidretorno > 0)
                        {
                            foreach (DataRow fila in DtDetalleCamion.Rows)
                            {
                                elretorno.guardadetalleretorno(elidretorno, Convert.ToDecimal(fila["Cantidad"]), fila["Material"].ToString(), fila["DesMaterial"].ToString());
                            }
                            
                        }
                        else
                        {
                     
                            cuInfoMsgbox1.mostrarMensaje("Error dando de alta la recogida ", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                            break;

                        }
                    }
                    else
                    {

                        cuInfoMsgbox1.mostrarMensaje("Error dando de alta la recogida " + errordev, Controles.Usuario.InfoMsgBox.tipoMsg.error);
                        break;
                    }
                }
                limpiardatos();
                cuInfoMsgbox1.mostrarMensaje("Se ha dado alta la recogida.", Controles.Usuario.InfoMsgBox.tipoMsg.success);
            }
            else
            {
                cuInfoMsgbox1.mostrarMensaje("Rellene todos los campos obligatorios", Controles.Usuario.InfoMsgBox.tipoMsg.error);

            }
        }

        private void insertaentregatabla(string numentrega)
        {
            DataTable Dtdistancias = new DataTable();
            Dtdistancias.Reset();
            Dtdistancias.Columns.Add("Distancia");
            Dtdistancias.Columns.Add("Numentrega");
            Dtdistancias.Columns.Add("Numexpedicion");
            Dtdistancias.Columns.Add("Fecha");
            Dtdistancias.Columns.Add("Codproveedor");
            Dtdistancias.Columns.Add("Sociedad");
            try
            {
                
                        DataRow filadist = Dtdistancias.NewRow();
                      
                        filadist["Distancia"] = 0;
                        filadist["Numentrega"] = numentrega;
                        filadist["Numexpedicion"] = "";
                        filadist["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd");
                        filadist["Sociedad"] = "";
                        Dtdistancias.Rows.Add(filadist);
                        losdatossap.insertadistentregas(Dtdistancias);
            }
            catch (Exception ex)
            {

            }
        }
        protected Decimal Damesumacamion()
        {
            if (DtDetalleCamion.Rows.Count > 0)
            {
                decimal sum = Convert.ToInt32(DtDetalleCamion.Compute("SUM(Cantidad)", string.Empty));
                return sum;
            }
            else
            {
                return 0;
            }
        }
        protected void limpiardatos()
        {
            DtDetalleCamion.Clear();
            Txt_Calle.Text = "";
            Txt_Cantidad.Text = "";
            Txt_Codpostal.Text = "";
            Txt_dirlatlon.Text = "";
            Txt_Latitud.Text = "";
            Txt_Longitud.Text = "";
            Txt_numcamiones.Text = "";
            Txt_Observaciones.Text = "";
            CB_Material.SelectedIndex = -1;
            CB_Pais.SelectedIndex = -1;
            CB_Poblaciones.SelectedIndex = -1;
            //CB_Region.SelectedIndex = -1;
            GV_Detallecamion.DataBind();
        }

        protected void guardadistanciasap(string numentrega,string dirgeoentrega)
        {
            DataTable dtDistancias = new DataTable();
            dtDistancias = rellenatabladistancias(numentrega, dirgeoentrega);
            losdatossap.insertadistentregas(dtDistancias);
        }
        protected DataTable rellenatabladistancias(string numentrega,string dirgeoentrega)
        {
            DataTable dtdistancias = new DataTable();
            decimal distancia = 0;
            DatosExpedicion laexpedicion = new DatosExpedicion();
            dtdistancias.Reset();
            dtdistancias.Columns.Add("Distancia");
            dtdistancias.Columns.Add("Numentrega");
            dtdistancias.Columns.Add("Numexpedicion");
            dtdistancias.Columns.Add("Fecha");
            dtdistancias.Columns.Add("Codproveedor");
            dtdistancias.Columns.Add("Sociedad");
            try
            {
                DataTable dtexpedicionpendiente = laexpedicion.dameexpedicionesPendientes();
                foreach(DataRow fila in dtexpedicionpendiente.Rows)
                {
                    DataRow filadist = dtdistancias.NewRow();
                    distancia = elretorno.damedistancia(fila["Exdirgeolocalizada"].ToString(), dirgeoentrega);
                    filadist["Distancia"] = distancia;
                    filadist["Numentrega"] = numentrega;
                    filadist["Numexpedicion"] = fila["ExNumexpedicion"].ToString();
                    filadist["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd");
                    filadist["Sociedad"] = fila["ExEmpresa"].ToString();
                    dtdistancias.Rows.Add(filadist);
                }
                return dtdistancias;
            }
            catch(Exception ex)
            {
                return dtdistancias;
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiardatos();
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void Cb_ProveedoresMM_DataBinding(object sender, EventArgs e)
        {
            Cb_ProveedoresMM.DataSource = this.DTProveedoresMM;
            Cb_ProveedoresMM.ValueField = "CodProveedor";
            Cb_ProveedoresMM.TextField = "NombreProveedor";
            if (UsuarioPagina.CodProveedor!=0)
            {
                Cb_ProveedoresMM.Value = UsuarioPagina.CodProveedor.ToString();
                Cb_ProveedoresMM.Visible = false;
                Frm_Retornos.FindItemOrGroupByName("Proveedor").Visible = false;
            }
            else
            {
                Cb_ProveedoresMM.Visible = true;
                Frm_Retornos.FindItemOrGroupByName("Proveedor").Visible = true;
            }
        }

        protected void CB_Pais_DataBinding(object sender, EventArgs e)
        {
            CB_Pais.DataSource = this.DTPaises;
            CB_Pais.TextField = "Nombrepais";
            CB_Pais.ValueField = "CodPais";
            CB_Pais.Value = "ES";
        }

        protected void CB_Region_DataBinding(object sender, EventArgs e)
        {
            //CB_Region.DataSource = this.DTRegiones;
            //CB_Region.TextField = "Nombreregion";
            //CB_Region.ValueField = "Codregion";
            
        }

        protected void CB_Material_DataBinding(object sender, EventArgs e)
        {
            string portes="";
            if (CB_Poblaciones.SelectedIndex != -1)
            {
                if (Chb_Portespagados.Checked)
                {
                    portes = "X";
                }
                CB_Material.DataSource = losdatossap.damematerialesretornoxproveedor(CB_Poblaciones.SelectedItem.Text, Cb_ProveedoresMM.SelectedItem.Value.ToString(), portes);
                CB_Material.TextField = "Descripcion";
                CB_Material.ValueField = "Material";
            }
        }

        protected void BT_vergeolocalizacion_Click(object sender, EventArgs e)
        {
            string direccion;
            string region="", pais="ES",poblacion="BADAJOZ";
            ApiGoogle.RootObject resultado;
            //if (CB_Region.SelectedIndex!=-1)
            //{
            //    region = CB_Region.SelectedItem.Value.ToString();
            //}
            if (CB_Pais.SelectedIndex != -1)
            {
                pais = CB_Pais.SelectedItem.Value.ToString();
            }
            if (CB_Poblaciones.SelectedIndex != -1)
            {
                poblacion = CB_Pais.SelectedItem.Value.ToString();
            }
            direccion = Txt_Calle.Text + ", " + poblacion + ", " + Txt_Codpostal.Text + ", " + pais;
            resultado=lafuncionesgoogle.CodificacionGeografica2(direccion);
            Txt_Latitud.Text = resultado.results[0].geometry.location.lat.ToString();
            Txt_Longitud.Text= resultado.results[0].geometry.location.lng.ToString();
            Txt_dirlatlon.Text = resultado.results[0].formatted_address;
        }

        protected void BT_Verdireccion_Click(object sender, EventArgs e)
        {
            if (Txt_Longitud.Text != "" && Txt_Latitud.Text != "")
            {
                lafuncionesgoogle.CodificacionGeograficaInversa2(Txt_Latitud.Text.Replace(",","."), Txt_Longitud.Text.Replace(",", "."));
            }

        }

        protected void CB_Poblaciones_DataBinding(object sender, EventArgs e)
        {
            CB_Poblaciones.DataSource = this.DTPoblaciones;
            CB_Poblaciones.ValueField = "CodPoblacion";
            CB_Poblaciones.TextField = "Nombrepoblacion";
        }

        protected void BT_Anadirdetalle_Click(object sender, EventArgs e)
        {
            decimal cantidadtotal = 0;
            try
            {
                if (Txt_Cantidad.Text != "0,0" && CB_Material.SelectedIndex != -1)
                {
                    cantidadtotal = Damesumacamion() + Convert.ToDecimal(Txt_Cantidad.Text);
                    if (cantidadtotal <= 23)
                    {
                            insertafilatabla(Convert.ToDecimal(Txt_Cantidad.Text), CB_Material.SelectedItem.Value.ToString(), CB_Material.SelectedItem.Text);
                            Txt_Cantidad.Text = "";
                            CB_Material.SelectedIndex = -1;
                            GV_Detallecamion.DataBind();
                     
                    }
                    else
                    {
                        Txt_Cantidad.Focus();
                        cuInfoMsgbox1.mostrarMensaje("La suma total es mayor de 23 TM de un camión. Cambie la cantidad para que no supere 23 TM", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                    }
                }
                else
                {
                    cuInfoMsgbox1.mostrarMensaje("Rellene campo cantidad y seleccione material ", Controles.Usuario.InfoMsgBox.tipoMsg.error);
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void GV_Detallecamion_DataBinding(object sender, EventArgs e)
        {
            GV_Detallecamion.DataSource = DtDetalleCamion;
            GV_Detallecamion.KeyFieldName = "id";
        }
        private int insertafilatabla(decimal cantidad, string material,string descripcionmat)
        {
            DataRow nuevafila = DtDetalleCamion.NewRow();
            int idasignacion = 0;
            int res = 0;
            try
            {
                idasignacion = (this.DtDetalleCamion.Rows.Count + 1) * 10;
                int maxpos = Convert.ToInt32(DtDetalleCamion.AsEnumerable().Max(row => row["id"]));
                idasignacion = maxpos + 10;
                nuevafila["id"] = idasignacion;
                nuevafila["Cantidad"] = cantidad;
                nuevafila["Material"] = material;
                nuevafila["DesMaterial"] = descripcionmat;


                DtDetalleCamion.Rows.Add(nuevafila);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }

        }

        protected void CB_Poblaciones_ValueChanged(object sender, EventArgs e)
        {
            CB_Material.DataBind();
        }

        protected void Cb_ProveedoresMM_ValueChanged(object sender, EventArgs e)
        {
            CB_Poblaciones.DataBind();

        }
    }
}