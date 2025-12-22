using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class SociedadXUsuario
    {
        #region Propiedades
        public int suUsuario { get; set; } = 0;
        public int suSociedad { get; set; } = 0;
        public Boolean suPorDefecto { get; set; } = false;
        public Boolean Creado { get; set; } = false;
        #endregion
    }
}
