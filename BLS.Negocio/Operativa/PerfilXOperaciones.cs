using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class PerfilXOperaciones
    {
        #region Propiedades
        public int IdOperacion { get; set; } = 0;
        public int IdModulo { get; set; } = 0;
        public string OperacionDesc { get; set; } = string.Empty;
        public string OperacionNombre { get; set; } = string.Empty;
        public Boolean OperacionActiva { get; set; } = false;
        public string OperacionTrans { get; set; } = string.Empty;
        public Boolean Creado { get; set; } = false;
        #endregion
    }
}
