using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class PerfilesXUsuario
    {
        #region Propiedades
        public int IdUsuario { get; set; } = 0;
        public int IdPerfil { get; set; } = 0;
        
        public Boolean Creado { get; set; } = false;
        #endregion

    }
}
