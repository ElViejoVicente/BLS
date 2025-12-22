using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class BitacoraExpediente
    {
        public long IdRegistro { get; set; } = 0;
        public string UsuarioImplicado { get; set; } = string.Empty;
        public string IdExpediente { get; set; }= string.Empty;
        public string NombreCampo { get; set; } = string.Empty;
        public string ValorOriginal { get; set; }= string.Empty;
        public string ValorImputado { get; set; } = string.Empty;
        public string NombreModulo { get; set; } = String.Empty;
        public DateTime FechaImputacion { get; set; } = Constantes.FechaGlobal;
    }
}
