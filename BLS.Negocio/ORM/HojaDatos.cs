using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class HojaDatos
    {
        public int IdHojaDatos { get; set; } = 0;
        public string numExpediente { get; set; } = "";
        public string NombreAsesor { get; set; } = "";
        public DateTime FechaIngreso { get; set; } = Constantes.FechaGlobal;
        public DateTime FechaCompleto { get; set; } =Constantes.FechaGlobal;
        public long IdUsuarioResponsable { get; set; } = 0;
        public int IdEquipoResponsable { get; set; } = 0;
        public string NumbreUsuarioTramita { get; set; } = "";
        public string NumTelCelular1 { get; set; } = "";
        public string NumTelCelular2 { get; set; } = "";
        public string CorreoElectronico { get; set; } = "";
    }
}
