using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class RecibosDePago
    {
        public int IdRegistro { get; set; }
        public string NumRecibo { get; set; }
        public int IdHojaDatos { get; set; }
        public decimal CantidadTotal { get; set; }
        public decimal CantidadAbonada { get; set; }
        public string Concepto { get; set; }
        public string UsuarioRecibe { get; set; }
        public string NotaComentario { get; set; }
    }
}
