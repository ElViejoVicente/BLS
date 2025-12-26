using BLS.Web.Controles.Servidor;
using DevExpress.Web;
using DevExpress.Web.Internal.XmlProcessor;
using DevExpress.XtraEditors.Filtering.Templates;
using BLS.Negocio.CRUD;
using BLS.Negocio.Expediente;
using BLS.Negocio.ExpedienteUnico;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using BLS.Web.Catalogos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLS.Web.ExpedienteUnico
{
    public partial class PanelExpedienteUnico : PageBase
    {
        #region Propiedades
        DatosCrud datosCrud = new DatosCrud();
        DatosExpedienteUnico datosExpUnico = new DatosExpedienteUnico();

        public List<ListaExpedienteUnico> lsExpedienteUnico
        {
            get

            {
                List<ListaExpedienteUnico> sseListaExpediente = new List<ListaExpedienteUnico>();
                if (this.Session["sseListaExpedienteUnico"] != null)
                {
                    sseListaExpediente = (List<ListaExpedienteUnico>)this.Session["sseListaExpedienteUnico"];
                }

                return sseListaExpediente;
            }
            set
            {
                this.Session["sseListaExpedienteUnico"] = value;
            }

        }

        public List<Cat_Paises> catPaises
        {
            get

            {
                List<Cat_Paises> sseCatPaises = new List<Cat_Paises>();
                if (this.Session["sseCatPaises"] != null)
                {
                    sseCatPaises = (List<Cat_Paises>)this.Session["sseCatPaises"];
                }

                return sseCatPaises;
            }
            set
            {
                this.Session["sseCatPaises"] = value;
            }

        }


        #endregion

        #region Funciones
        private void DameCatalogos()

        {
            try
            {

                catPaises = datosCrud.ConsultaCatPaises();

                //  cbPaisNacimiento.



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        private void CargarDatos()
        {
          

                lsExpedienteUnico = datosExpUnico.DameListaExpedienteUnico(fechaInicial: dtFechaInicio.Date, fechaFinal: dtFechaFin.Date,
                    todasLasFechas: chkBusquedaCompleta.Checked).OrderByDescending(x => x.FechaIngreso).ToList();// cargamos todos los registros


                gvExpedienteUnico.DataBind();
                return;
            
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UsuarioConsultaLN"] = UsuarioPagina.usNombre;
                dtFechaInicio.Date = DateTime.Now.Date.AddDays(-15);
                dtFechaFin.Date = DateTime.Now.Date;
                DameCatalogos();
            }
        }

        protected void gvExpedienteUnico_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView control = (ASPxGridView)sender;
            control.DataSource = lsExpedienteUnico;

        }

        protected void gvExpedienteUnico_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {

            if (e.Parameters == "CargarRegistros")
            {

                CargarDatos();
            }

        }

        protected void gvExpedienteUnico_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {

        }

        protected void gvExpedienteUnico_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {

        }




        #endregion

        protected void cbSexoOtorgaSolicita_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbPaisNacimiento_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;

        }

        protected void cbPaisNacimiento_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            //cb.DataSource = catPaises;
            cb.TextField = "TextoPais";
            cb.ValueField = "TextoPais";
            cb.ValueType = typeof(string);

            cb.DataSource = catPaises;
        }

        protected void cbPaisNacionalidad_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;
        }

        protected void cbPaisNacionalidad_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            //cb.DataSource = catPaises;
            cb.TextField = "TextoPais";
            cb.ValueField = "TextoPais";
            cb.ValueType = typeof(string);

            cb.DataSource = catPaises;
        }

        protected void cbPaisDomicilio_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;

        }

        protected void cbPaisDomicilio_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            //cb.DataSource = catPaises;
            cb.TextField = "TextoPais";
            cb.ValueField = "TextoPais";
            cb.ValueType = typeof(string);

            cb.DataSource = catPaises;
        }

        protected void cbPaisRazonSocial_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.DataSource = catPaises;
        }

        protected void cbPaisRazonSocial_DataBinding(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;

            //cb.DataSource = catPaises;
            cb.TextField = "TextoPais";
            cb.ValueField = "TextoPais";
            cb.ValueType = typeof(string);

            cb.DataSource = catPaises;
        }

        protected void cbTipoRegimen_Init(object sender, EventArgs e)
        {
            ASPxComboBox cb = (ASPxComboBox)sender;
            cb.SelectedIndex = -1;

        }

        protected void gvExpedienteUnico_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Boolean existenCambios = false;


            foreach (DictionaryEntry item in e.OldValues)
            {
                if (e.NewValues.Contains(item.Key))
                {
                    if (e.NewValues[item.Key] != null && !e.NewValues[item.Key].Equals(item.Value))
                    {
                        existenCambios = true;
                        break;
                    }
                }
            }

            if (existenCambios == false)
            {
                gvExpedienteUnico.CancelEdit();
                e.Cancel = true;
                return;
            }



            var miRegistro = datosCrud.ConsultaDatosParticipantes(Convert.ToInt32(e.Keys[0]));
            var miRegistroOld = datosCrud.ConsultaDatosParticipantes(Convert.ToInt32(e.Keys[0]));

            if (miRegistro != null)
            {


                miRegistro.Sexo = e.NewValues["Sexo"].ToString();
                miRegistro.Ocupacion = e.NewValues["Ocupacion"] == null ? "-" : e.NewValues["Ocupacion"].ToString();
                miRegistro.FechaNacimiento = Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString());
                miRegistro.TipoRegimen = e.NewValues["TipoRegimen"].ToString();
                miRegistro.PaisNacimiento = e.NewValues["PaisNacimiento"].ToString();
                miRegistro.PaisNacionalidad = e.NewValues["PaisNacionalidad"].ToString();
                miRegistro.Domicilio = e.NewValues["Domicilio"].ToString();
                miRegistro.NumeroExterior = e.NewValues["NumeroExterior"] == null ? "-" : e.NewValues["NumeroExterior"].ToString();
                miRegistro.NumeroInterior = e.NewValues["NumeroInterior"] == null ? "-" : e.NewValues["NumeroInterior"].ToString();
                miRegistro.Colonia = e.NewValues["Colonia"] == null ? "-" : e.NewValues["Colonia"].ToString();
                miRegistro.Municipio = e.NewValues["Municipio"] == null ? "-" : e.NewValues["Municipio"].ToString();
                miRegistro.Ciudad = e.NewValues["Municipio"] == null ? "-" : e.NewValues["Municipio"].ToString();
                miRegistro.Estado = e.NewValues["Estado"] == null ? "-" : e.NewValues["Estado"].ToString();
                miRegistro.PaisDomicilio = e.NewValues["PaisDomicilio"].ToString();
                miRegistro.CP = e.NewValues["CP"] == null ? "-" : e.NewValues["CP"].ToString();
                miRegistro.NumeroTefonico = e.NewValues["NumeroTefonico"].ToString();
                miRegistro.CorreoElectronico = e.NewValues["CorreoElectronico"].ToString();
                miRegistro.Curp = e.NewValues["Curp"] == null ? "-" : e.NewValues["Curp"].ToString();
                miRegistro.Rfc = e.NewValues["Rfc"] == null ? "-" : e.NewValues["Rfc"].ToString();
                miRegistro.NombreIdentificacionID = e.NewValues["NombreIdentificacionID"] == null ? "-" : e.NewValues["NombreIdentificacionID"].ToString();
                miRegistro.AutoridadEmiteID = e.NewValues["AutoridadEmiteID"] == null ? "-" : e.NewValues["AutoridadEmiteID"].ToString();
                miRegistro.NumeroSerieID = e.NewValues["NumeroSerieID"] == null ? "-" : e.NewValues["NumeroSerieID"].ToString();

                miRegistro.RazonSocial = e.NewValues["RazonSocial"] == null ? "-" : e.NewValues["RazonSocial"].ToString();

                miRegistro.FechaConstitucion = e.NewValues["FechaConstitucion"]==null? Constantes.FechaGlobal : Convert.ToDateTime(e.NewValues["FechaConstitucion"].ToString());

                miRegistro.PaisRazonSocial = e.NewValues["PaisRazonSocial"] ==null ?"-" : e.NewValues["PaisRazonSocial"].ToString();

                miRegistro.ActividadRazonSocial = e.NewValues["ActividadRazonSocial"]==null? "-": e.NewValues["ActividadRazonSocial"].ToString();

                miRegistro.IdFideicomiso = e.NewValues["IdFideicomiso"] == null ? "-" : e.NewValues["IdFideicomiso"].ToString();



                datosCrud.ActualizaDatosParticipantes(miRegistro);



                #region Validacion de Cambios LOG


                HojaDatos hojaDatos = datosCrud.ConsultaHojaDatos(miRegistro.IdHojaDatos);

                BitacoraExpediente logCambios = new BitacoraExpediente();
                logCambios.UsuarioImplicado = UsuarioPagina.usNombre;
                logCambios.IdExpediente = hojaDatos.numExpediente;
                logCambios.NombreModulo = "Expediente Unico";

                if (miRegistro.Sexo != miRegistroOld.Sexo)
                {
                    logCambios.NombreCampo = "Eu-Sexo";
                    logCambios.ValorOriginal = miRegistroOld.Sexo;
                    logCambios.ValorImputado = miRegistro.Sexo;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Ocupacion != miRegistroOld.Ocupacion)
                {
                    logCambios.NombreCampo = "Eu-Actividad/Ocupacion";
                    logCambios.ValorOriginal = miRegistroOld.Ocupacion;
                    logCambios.ValorImputado = miRegistro.Ocupacion;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.FechaNacimiento != miRegistroOld.FechaNacimiento)
                {
                    logCambios.NombreCampo = "Eu-F.Nacimiento";
                    logCambios.ValorOriginal = miRegistroOld.FechaNacimiento.ToString();
                    logCambios.ValorImputado = miRegistro.FechaNacimiento.ToString();
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.TipoRegimen != miRegistroOld.TipoRegimen)
                {
                    logCambios.NombreCampo = "Eu-T.Persona";
                    logCambios.ValorOriginal = miRegistroOld.TipoRegimen;
                    logCambios.ValorImputado = miRegistro.TipoRegimen;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.PaisNacimiento != miRegistroOld.PaisNacimiento)
                {
                    logCambios.NombreCampo = "Eu-P.Nacimiento";
                    logCambios.ValorOriginal = miRegistroOld.PaisNacimiento;
                    logCambios.ValorImputado = miRegistro.PaisNacimiento;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.PaisNacionalidad != miRegistroOld.PaisNacionalidad)
                {
                    logCambios.NombreCampo = "Eu-P.Nacionalidad";
                    logCambios.ValorOriginal = miRegistroOld.PaisNacionalidad;
                    logCambios.ValorImputado = miRegistro.PaisNacionalidad;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Domicilio != miRegistroOld.Domicilio)
                {
                    logCambios.NombreCampo = "Eu-Domicilio (Calle)";
                    logCambios.ValorOriginal = miRegistroOld.Domicilio;
                    logCambios.ValorImputado = miRegistro.Domicilio;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.NumeroExterior != miRegistroOld.NumeroExterior)
                {
                    logCambios.NombreCampo = "Eu-Num.Exterior";
                    logCambios.ValorOriginal = miRegistroOld.NumeroExterior;
                    logCambios.ValorImputado = miRegistro.NumeroExterior;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.NumeroInterior != miRegistroOld.NumeroInterior)
                {
                    logCambios.NombreCampo = "Eu-Num.Interior";
                    logCambios.ValorOriginal = miRegistroOld.NumeroInterior;
                    logCambios.ValorImputado = miRegistro.NumeroInterior;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Colonia != miRegistroOld.Colonia)
                {
                    logCambios.NombreCampo = "Eu-Colonia";
                    logCambios.ValorOriginal = miRegistroOld.Colonia;
                    logCambios.ValorImputado = miRegistro.Colonia;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Municipio != miRegistroOld.Municipio)
                {
                    logCambios.NombreCampo = "Eu-Municipio";
                    logCambios.ValorOriginal = miRegistroOld.Municipio;
                    logCambios.ValorImputado = miRegistro.Municipio;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Ciudad != miRegistroOld.Ciudad)
                {
                    logCambios.NombreCampo = "Eu-Ciudad";
                    logCambios.ValorOriginal = miRegistroOld.Ciudad;
                    logCambios.ValorImputado = miRegistro.Ciudad;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Estado != miRegistroOld.Estado)
                {
                    logCambios.NombreCampo = "Eu-Estado";
                    logCambios.ValorOriginal = miRegistroOld.Estado;
                    logCambios.ValorImputado = miRegistro.Estado;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.PaisDomicilio != miRegistroOld.PaisDomicilio)
                {
                    logCambios.NombreCampo = "Eu-P.Domicilio";
                    logCambios.ValorOriginal = miRegistroOld.PaisDomicilio;
                    logCambios.ValorImputado = miRegistro.PaisDomicilio;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.CP != miRegistroOld.CP)
                {
                    logCambios.NombreCampo = "Eu-CP";
                    logCambios.ValorOriginal = miRegistroOld.CP;
                    logCambios.ValorImputado = miRegistro.CP;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.NumeroTefonico != miRegistroOld.NumeroTefonico)
                {
                    logCambios.NombreCampo = "Eu-Num.Tefonico";
                    logCambios.ValorOriginal = miRegistroOld.NumeroTefonico;
                    logCambios.ValorImputado = miRegistro.NumeroTefonico;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.CorreoElectronico != miRegistroOld.CorreoElectronico)
                {
                    logCambios.NombreCampo = "Eu-Correo E.";
                    logCambios.ValorOriginal = miRegistroOld.CorreoElectronico;
                    logCambios.ValorImputado = miRegistro.CorreoElectronico;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Curp != miRegistroOld.Curp)
                {
                    logCambios.NombreCampo = "Eu-Curp";
                    logCambios.ValorOriginal = miRegistroOld.Curp;
                    logCambios.ValorImputado = miRegistro.Curp;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.Rfc != miRegistroOld.Rfc)
                {
                    logCambios.NombreCampo = "Eu-Rfc";
                    logCambios.ValorOriginal = miRegistroOld.Rfc;
                    logCambios.ValorImputado = miRegistro.Rfc;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.NombreIdentificacionID != miRegistroOld.NombreIdentificacionID)
                {
                    logCambios.NombreCampo = "Eu-Identificacion";
                    logCambios.ValorOriginal = miRegistroOld.NombreIdentificacionID;
                    logCambios.ValorImputado = miRegistro.NombreIdentificacionID;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.AutoridadEmiteID != miRegistroOld.AutoridadEmiteID)
                {
                    logCambios.NombreCampo = "Eu-Autoridad Emite";
                    logCambios.ValorOriginal = miRegistroOld.AutoridadEmiteID;
                    logCambios.ValorImputado = miRegistro.AutoridadEmiteID;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.NumeroSerieID != miRegistroOld.NumeroSerieID)
                {
                    logCambios.NombreCampo = "Eu-Numero ID";
                    logCambios.ValorOriginal = miRegistroOld.NumeroSerieID;
                    logCambios.ValorImputado = miRegistro.NumeroSerieID;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.RazonSocial != miRegistroOld.RazonSocial)
                {
                    logCambios.NombreCampo = "Eu-Razon Social";
                    logCambios.ValorOriginal = miRegistroOld.RazonSocial;
                    logCambios.ValorImputado = miRegistro.RazonSocial;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.FechaConstitucion != miRegistroOld.FechaConstitucion)
                {
                    logCambios.NombreCampo = "Eu-F.Constitucion";
                    logCambios.ValorOriginal = miRegistroOld.FechaConstitucion.ToString();
                    logCambios.ValorImputado = miRegistro.FechaConstitucion.ToString();
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.PaisRazonSocial != miRegistroOld.PaisRazonSocial)
                {
                    logCambios.NombreCampo = "Eu-P.RazonSocial";
                    logCambios.ValorOriginal = miRegistroOld.PaisRazonSocial;
                    logCambios.ValorImputado = miRegistro.PaisRazonSocial;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.ActividadRazonSocial != miRegistroOld.ActividadRazonSocial)
                {
                    logCambios.NombreCampo = "Eu-Actividad Razon Social";
                    logCambios.ValorOriginal = miRegistroOld.ActividadRazonSocial;
                    logCambios.ValorImputado = miRegistro.ActividadRazonSocial;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }
                if (miRegistro.IdFideicomiso != miRegistroOld.IdFideicomiso)
                {
                    logCambios.NombreCampo = "Eu-Num.Fideicomiso";
                    logCambios.ValorOriginal = miRegistroOld.IdFideicomiso;
                    logCambios.ValorImputado = miRegistro.IdFideicomiso;
                    datosCrud.AltaBitacoraExpediente(logCambios);
                }



                #endregion  



            }


            CargarDatos();
            gvExpedienteUnico.CancelEdit();
            e.Cancel = true;
            gvExpedienteUnico.DataBind();



        }

        protected void gvExpedienteUnico_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            object sexo = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["Sexo"] as GridViewDataComboBoxColumn, "cbSexoOtorgaSolicita")).Value;

            object tipoRegimen = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["TipoRegimen"] as GridViewDataComboBoxColumn, "cbTipoRegimen")).Value;

            object PaisNacimiento = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["PaisNacimiento"] as GridViewDataComboBoxColumn, "cbPaisNacimiento")).Value;

            object PaisNacionalidad = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["PaisNacionalidad"] as GridViewDataComboBoxColumn, "cbPaisNacionalidad")).Value;

            object PaisDomicilio = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["PaisDomicilio"] as GridViewDataComboBoxColumn, "cbPaisDomicilio")).Value;

            object PaisRazonSocial = ((ASPxComboBox)gvExpedienteUnico.FindEditRowCellTemplateControl(gvExpedienteUnico.Columns["PaisRazonSocial"] as GridViewDataComboBoxColumn, "cbPaisRazonSocial")).Value;

            if ( Convert.ToDateTime(e.NewValues["FechaNacimiento"].ToString()).ToString("yyyy-MM-dd") =="1900-01-01")           
            {
                e.RowError += "El campo Fecha de nacimiento es obligatorio.\n ";
            }

            if (sexo==null)
            {
                e.RowError += "El campo Sexo es obligatorio.\n ";
                return;
                
            }


            if (tipoRegimen == null)
            {
                e.RowError += "El campo Tipo regimen es obligatorio.\n ";
                return;
            }

            if (PaisNacimiento== null)
            {
                e.RowError += "El campo Pais de nacimiento es obligatorio.\n ";
                return;
            }


            if (PaisNacionalidad == null)
            {
                e.RowError += "El campo Pais de nacionalidad es obligatorio.\n ";
                return;
            }


            if (e.NewValues["Domicilio"] == null)
            {
                e.RowError += "El campo domicilio es obligatorio.\n ";
            }

            if (e.NewValues["NumeroExterior"] == null)
            {
                e.RowError += "El campo numero exterior es obligatorio.\n ";
            }

            //if (e.NewValues["NumeroInterior"] == null)
            //{
            //    e.RowError += "El campo numero interior es obligatorio.\n ";
            //}

            if (e.NewValues["Colonia"] == null)
            {
                e.RowError += "El campo colonia es obligatorio.\n ";
            }

            if (e.NewValues["Colonia"] == null)
            {
                e.RowError += "El campo colonia es obligatorio.\n ";
            }

            if (e.NewValues["Municipio"] == null)
            {
                e.RowError += "El campo Municipio es obligatorio.\n ";
            }

            if (e.NewValues["Ciudad"] == null)
            {
                e.RowError += "El campo Ciudad es obligatorio.\n ";
            }

            if (e.NewValues["Estado"] == null)
            {
                e.RowError += "El campo Estado es obligatorio.\n ";
            }

            if (PaisDomicilio==null)
            {
                e.RowError += "El campo Pais del domicilio es obligatorio.\n ";
                return;
            }

            if (e.NewValues["CP"] == null) 
            {
                e.RowError += "El campo CP es obligatorio.\n ";
            }

            if (e.NewValues["NumeroTefonico"] == null)
            {
                e.RowError += "El campo Numero Tefonico es obligatorio.\n ";
            }

            if (e.NewValues["CorreoElectronico"] == null)
            {
                e.RowError += "El campo Correo Electronico  es obligatorio.\n ";
            }

            if (e.NewValues["Curp"] == null)
            {
                e.RowError += "El campo Curp es obligatorio.\n ";
            }

            if (e.NewValues["Rfc"] == null)
            {
                e.RowError += "El campo Rfc es obligatorio.\n ";
            }

            if (e.NewValues["NombreIdentificacionID"] == null)
            {
                e.RowError += "El campo Identificacion es obligatorio.\n ";
            }

            if (e.NewValues["AutoridadEmiteID"] == null)
            {
                e.RowError += "El campo Autoridad Emite es obligatorio.\n ";
            }

            if (e.NewValues["NumeroSerieID"] == null)
            {
                e.RowError += "El campo Numero ID es obligatorio.\n ";
            }



            //if (tipoRegimen.ToString()== "Apoderado")
            //{

            //    if (e.NewValues["Apoderado"] == null)
            //    {
            //        e.RowError += "El campo Apoderado es obligatorio.\n ";
            //    }
            //}


            if (tipoRegimen.ToString() == "Moral")
            {

                if (e.NewValues["RazonSocial"] == null)
                {
                    e.RowError += "El campo Razon Social es obligatorio.\n ";
                }

                if (Convert.ToDateTime(e.NewValues["FechaConstitucion"].ToString()).ToString("yyyy-MM-dd") == "1900-01-01")
                {
                    e.RowError += "El campo Fecha Constitucion es obligatorio.\n ";
                }

                if (e.NewValues["RazonSocial"] == null)
                {
                    e.RowError += "El campo Razon Social es obligatorio.\n ";
                }

                if (PaisRazonSocial==null)
                {
                    e.RowError += "El campo Pais Razon Social es obligatorio.\n ";
                }

                if (e.NewValues["ActividadRazonSocial"] == null)
                {
                    e.RowError += "El campo Actividad Razon Social es obligatorio.\n ";
                }
            }



        }
    }
}