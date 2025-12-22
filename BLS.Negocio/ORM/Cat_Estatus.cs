using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Cat_Estatus
    {
        public string IdEstatus { get; set; }
        public string Modulo { get; set; }
        public string IdEstadoPadre { get; set; }
        public int Orden { get; set; }
        public string PerfilesAutorizados { get; set; }
        public string TextoEstatus { get; set; }
        public string Descripcion { get; set; }
    }
}
