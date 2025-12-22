using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Cat_RolParticipantes
    {
        public int IdRol { get; set; } = 0;
        public int IdActo { get; set; }= 0;
        public string TextoFigura { get; set; } = "";
        public string TextoRol { get; set; } = "";
        public bool PreguntarSiEsAnafabeta { get; set; }= false;
        public string Descripcion { get; set; } = "";
        public bool Activo { get; set; } = false;
        public bool RequiereExUnico { get; set; } = false;
    }
}
