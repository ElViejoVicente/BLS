using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class AVDetectadas
    {
        public long IdAV { get; set; } = 0;
        public string TipoAVDetectada { get; set; } = string.Empty;
        public string IdExpediente { get; set; }= string.Empty;
        public DateTime FechaIngreso { get; set; } =  Constantes.FechaGlobal;
        public string IdEstatus { get; set; } = string.Empty;
        public string TextoEstatus { get; set; } = string.Empty;
        public string TextoActo { get; set; } = string.Empty;
        public string TextoVariante { get; set; } = string.Empty;
        public int Escritura { get; set; } = 0; 
        public int Volumen { get; set; } = 0;
        public decimal ValorOperacion { get; set; } = 0;
        public decimal UmbralAcVulnerable { get; set; } = 0;
        public string UsuarioGestionaAviso { get; set; } = string.Empty;
        public bool AvActiva { get; set; }=false;
        public string FolioDeAviso { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
    }
}
