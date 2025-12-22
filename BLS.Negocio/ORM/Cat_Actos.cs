using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
	public class Cat_Actos
	{
		public int IdActo { get; set; } = 0;
		public string TextoActo { get; set; } = "";
		public string Descripcion { get; set; } = "";
		public bool Activo { get; set; } = false;
        public bool AvisoAcVulnerable { get; set; } = false;
		public decimal UmbralAcVulnerable { get; set; } = 0;
        public bool ReqTraslado { get; set; } = false;
        public bool TapAP { get; set; } = false;
        public bool TapProyecto { get; set; } = false;
        public bool TapFirmas { get; set; } = false;
        public bool TapAD { get; set; } = false;
        public bool TapEscritura { get; set; } = false;
        public bool TapEntrega { get; set; } = false;
        public bool TapContabilidad { get; set; } = false;
        public bool TapPLD { get; set; } = false;
    }
}
