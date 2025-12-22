using GPB.Web.Controles.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPB.Negocio.Operativa;
using GPB.Negocio.Logistica;
using GPB.Negocio.Servicio_SAP;
using System.Data;
using System.Text.RegularExpressions;


namespace GPB.Web
{
    public partial class AsignacionMatRet : PageBase
    {
        #region variablesprivadas

        //DatosRetornos_D elretorno = new DatosRetornos_D();
        DatosRetornos elretorno = new DatosRetornos();
        //DatosSAP_D losdatossap = new DatosSAP_D();
        DatosSAP losdatossap = new DatosSAP();
        // DatosTransportistas_D lostransportistas = new DatosTransportistas_D();
        DatosTransportistas lostransportistas = new DatosTransportistas();
        #endregion

        #region propiedades
        public int IDRetornoseleccionado
        {
            get
            {

                if (Session["IDRetornoseleccionado"] != null)
                {
                    return (int)Session["IDRetornoseleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["IDRetornoseleccionado"] = value;
            }
        }
        public GPB.Negocio.Logistica.Retorno RetornoSeleccionado
        {
            get
            {
                GPB.Negocio.Logistica.Retorno retornoseleccionado = new Retorno();
                if (this.ViewState["RetornoSeleccionado"] != null)
                {
                    retornoseleccionado = (GPB.Negocio.Logistica.Retorno)this.ViewState["RetornoSeleccionado"];
                }


                return retornoseleccionado;

            }
            set
            {
                this.ViewState["RetornoSeleccionado"] = value;
            }
        }

        #endregion  
        protected void Page_Load(object sender, EventArgs e)
        {

            ComprobarEvento(sender, e);

            if (!Page.IsPostBack)
            {
                Response.Expires = 0;

                //  CargarConfigruacionHead(int.Parse(Request.QueryString["initCod"].ToString()));

                if (Request.QueryString["idRet"] != null)
                {
                    IDRetornoseleccionado = Convert.ToInt32(Request.QueryString["idRet"].ToString());
                    RetornoSeleccionado = elretorno.Damedatosretornopornum(IDRetornoseleccionado.ToString());
                }
                rellenadatos();
                CB_Agencia.DataBind();
            }
        }
        private void ComprobarEvento(object sender, EventArgs e)
        {
            string nombreEvento = this.Request.Form["__EVENTTARGET"];
            //CuMensaje.OCultarMensaje();
            switch (nombreEvento)
            {
                case ("seleccionar"):
                    seleccionaragencia(sender, e);
                    break;
                case ("Refrescatransportistas"):
                    CB_Transportistas.DataBind();
                    Pup_AddTransportista.ShowOnPageLoad = false;
                    PUp_VerAgencias.ShowOnPageLoad = false;
                    break;
            }

        }
        private void seleccionaragencia(object sender, EventArgs e)
        {
            List<object> Agencias = Gv_AgenciasAsignadas.GetSelectedFieldValues("AgenciaId");
            if (Agencias[0].ToString() != "No_SAP")
            {
                CB_Agencia.Value = Agencias[0].ToString().PadLeft(10, '0');
            }
            List<object> Matremolque = Gv_AgenciasAsignadas.GetSelectedFieldValues("MatRemolque");
            txt_matricularemolque.Text = Matremolque[0].ToString();
            List<object> transportista = Gv_AgenciasAsignadas.GetSelectedFieldValues("TransportistaNom");
            //Txt_transportista.Text = transportista[0].ToString();
            CB_Transportistas.Text = transportista[0].ToString();
            PUp_VerAgencias.ShowOnPageLoad = false;

        }
        private void rellenadatos()
        {

        }

        protected void txt_matricula_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        protected void cuInfoMsgbox1_RespuestaClick()
        {

        }

        protected void txt_matricula_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void Txt_Fechaprevcarga_CalendarDayCellPrepared(object sender, DevExpress.Web.CalendarDayCellPreparedEventArgs e)
        {

        }

        protected void CB_Agencia_DataBinding(object sender, EventArgs e)
        {

        }

        protected void CB_Transportistas_DataBinding(object sender, EventArgs e)
        {

        }

        protected void BT_AñadirTrans_Click(object sender, EventArgs e)
        {

        }

        protected void Gv_AgenciasAsignadas_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void Gv_AgenciasAsignadas_DataBinding(object sender, EventArgs e)
        {

        }
    }
}