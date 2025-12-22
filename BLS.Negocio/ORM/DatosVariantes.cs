using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class DatosVariantes
    {
        public int IdRegistro { get; set; } = 0;
        public int IdHojaDatos { get; set; }= 0;    
        public int IdActo { get; set; } = 0;
        public int IdVariante { get; set; } = 0;
        public string TextoActo { get; set; } = "";
        public string TextoVariante { get; set; } = "";
        public string NotasEspeciales { get; set; } = "";   
        public string Dispocisiones { get; set; } = "";
        public string NotasClausulasEspeciales { get; set; } = "";
        public string CoApActaNacNum { get; set; } = "";
        public DateTime CoApActaNacFecha { get; set; } = Constantes.FechaGlobal;
        public string OtrosNombres { get; set; } = "";
        public string NominacionPermisoSE { get; set; } = "";
        public string TipoSociedad { get; set; } = "";
        public string DatosFaltantes { get; set; } = "";    
    }
}
