using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Cat_TipoInventario
    {
        public int idTipoInventario { get; set; }
        public string TextoInventario { get; set; }
        public bool Activo { get; set; }
    }
}
