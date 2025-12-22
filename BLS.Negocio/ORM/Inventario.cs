using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Inventario
    {
        public int IdInventario { get; set; } = 0;
        public string TipoInventario { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Marca { get; set; } = "";
        public DateTime FechaAlta { get; set; }= Constantes.FechaGlobal;
        public DateTime FechaBaja { get; set; }=Constantes.FechaGlobal;
        public decimal ValorCompra { get; set; } = 0;
        public string AreaOficina { get; set; } = "";
        public string Responsable { get; set; } = "";
        public DateTime FechaAsignacion { get; set; } = Constantes.FechaGlobal;
        public bool Activo { get; set; }=false;
        public string Observaciones { get; set; } = "";
        public string NumeroSerie { get; set; } = "";
    }
}
