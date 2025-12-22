using Microsoft.Exchange.WebServices.Data;
using BLS.Negocio.Operativa;
using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Expediente
{
    public class ListaHojaDatos
    {

        public string IdEstatus { get; set; } = "";
        public string TextoEstatus { get; set; } = "";
        public int IdHojaDatos { get; set; } = 0;
        public string numExpediente { get; set; } = "";
        public string NombreAsesor { get; set; } = "";
        public DateTime FechaIngreso { get; set; } = Constantes.FechaGlobal;
        public DateTime FechaCompleto { get; set; } = Constantes.FechaGlobal;
        public int IdUsuarioResponsable { get; set; } = 0;
        public int IdEquipoResponsable { get; set; } = 0;
        public string NumbreUsuarioTramita { get; set; } = "";
        public string NumTelCelular1 { get; set; } = "";
        public string NumTelCelular2 { get; set; } = "";
        public string CorreoElectronico { get; set; } = "";
        public string TextoActo { get; set; } = "";
        public string TextoVariante { get; set; } = "";
        public string Otorga { get; set; } = "";
        public string AfavorDe { get; set; } = "";
        public Boolean ReqTraslado { get; set; } = false;


        public HojaDatos DetalleHojaDatos { get; set; } = null;
        public DatosVariantes DetalleVariante { get; set; }=null;
        public Expedientes DetalleExpediente { get; set; } = null;
        public List<DatosParticipantes> DetalleParticipantes { get;set; }=null;
        public List<DatosDocumentos> DetalleDocumentos { get; set; } = null;
        public List<RecibosDePago> DetalleRecibosPago { get; set; } = null;



        // estos son solo para uso en los reportes
        public List<DatosDocumentos> DetalleDocumentosOtorgSolicita { get; set;} =null;
        public List<DatosDocumentos> DetalleDocumentosAfavorDe { get; set; } = null;




    }
}
