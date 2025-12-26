using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Usuarios
    {
        public Int64 usCodigo { get; set; }
        public string usMail { get; set; }
        public string usPWD { get; set; }
        public string usNombre { get; set; }
        public DateTime usFecAlta { get; set; }
        public bool usActivo { get; set; }
        public DateTime usFecBaja { get; set; }
    }
}
