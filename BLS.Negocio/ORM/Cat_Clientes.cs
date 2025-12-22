using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Cat_Clientes
    {
        public int idCliente { get; set; }
        public string Gestor { get; set; }
        public string NumTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
        public string Observaciones { get; set; }
    }
}
