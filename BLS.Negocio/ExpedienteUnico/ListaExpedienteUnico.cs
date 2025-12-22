using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLS.Negocio.ExpedienteUnico
{
    public  class ListaExpedienteUnico
    {
        public string ImageEstado { get; set; } = "";
        public string IdExpediente { get; set; } = "";
        public string IdEstatus { get; set; } = "";
        public string TextoEstatus { get; set; } = "";
        public string TextoActo { get; set; } = "";
        public DateTime FechaIngreso { get; set; } = Constantes.FechaGlobal;
        public string TextoVariante { get; set; } = "";
        public bool RequiereExUnico { get; set; } = false;
        public int IdRegistro { get; set; } = 0;
        public int IdHojaDatos { get; set; } = 0;
        public string FiguraOperacion { get; set; } = "";
        public string RolOperacion { get; set; } = "";

        public string Nombres { get; set; } = "";
        public string ApellidoPaterno { get; set; } = "";
        public string ApellidoMaterno { get; set; } = "";
        public DateTime FechaNacimiento { get; set; } = Constantes.FechaGlobal;
        public string Sexo { get; set; } = "";
        public string Ocupacion { get; set; } = "";
        public string EstadoCivil { get; set; } = "";
        public string RegimenConyugal { get; set; } = "";
        public string SabeLeerEscribir { get; set; } = "";
        public string Notas { get; set; } = "";

        public string TipoRegimen { get; set; } = "";
        public string PaisNacimiento { get; set; } = "";
        public string PaisNacionalidad { get; set; } = "";
        public string Domicilio { get; set; } = "";
        public string NumeroExterior { get; set; } = "";
        public string NumeroInterior { get; set; } = "";
        public string Colonia { get; set; } = "";
        public string Municipio { get; set; } = "";
        public string Ciudad { get; set; } = "";
        public string Estado { get; set; } = "";
        public string PaisDomicilio { get; set; } = "";
        public string CP { get; set; } = "";
        public string NumeroTefonico { get; set; } = "";
        public string CorreoElectronico { get; set; } = "";
        public string Curp { get; set; } = "";
        public string Rfc { get; set; } = "";
        public string NombreIdentificacionID { get; set; } = "";
        public string AutoridadEmiteID { get; set; } = "";
        public string NumeroSerieID { get; set; } = "";
        public string RazonSocial { get; set; } = "";
        public DateTime FechaConstitucion { get; set; } = Constantes.FechaGlobal;
        public string PaisRazonSocial { get; set; } = "";
        public string ActividadRazonSocial { get; set; } = "";
        public bool SeValidoEnListaNegra { get; set; } = false;
        public DateTime FechaPrimeraValidacion { get; set; } = Constantes.FechaGlobal;
        public string ObsePrimeraValidacion { get; set; } = "";
        public DateTime FechaSegundaValicacion { get; set; } = Constantes.FechaGlobal;
        public string ObseSegundaValidacion { get; set; } = "";

        public string IdFideicomiso { get; set; } = "";

        public string Resumen
        {
            get 
            {
                return IdExpediente.Trim() + " - " + TextoActo.Trim() + " - " + TextoVariante.Trim() + " - " + FechaIngreso.ToString() + " - " + TextoEstatus; 
            }
            
        }


    }
}
