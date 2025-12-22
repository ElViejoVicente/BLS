using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class Perfil
    {
        #region Propiedades
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public Boolean Activo { get; set; } = false;
        public Boolean Creado { get; set; } = false;
        public Boolean chk { get; set; } = false;
        #endregion
    }
}
