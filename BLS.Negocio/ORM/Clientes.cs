using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Clientes
    {
        public int idCliente { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string PrimerNombre { get; set; }
        public string SegunoNombre { get; set; }
        public string AppPaterno { get; set; }
        public string AppMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreNegocio { get; set; }
        public string RFC { get; set; }
        public string DomCalle { get; set; }
        public string DomNumeroInt { get; set; }
        public string DomNumeroExt { get; set; }
        public string DomCiudad { get; set; }
        public string DomEstado { get; set; }
        public int DomCP { get; set; }
        public string DomTelefono { get; set; }
    }
}
