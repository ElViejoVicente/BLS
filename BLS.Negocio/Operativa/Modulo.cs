using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class Modulo
    {
        #region Propiedades
        public int IdModulo { get; set; } = 0;
        public string Descripcion { get; set; } = string.Empty;
        public string DescripcioLarga { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public int ParentID { get; set; } = 0;
        public string UrlICon { get; set; } = string.Empty;
        public string UrlIConLarge { get; set; } = string.Empty;
        public int Orden { get; set; } = 0;
        public string Version { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
        //public Boolean Activo { get; set; } = false;
        public Boolean Creado { get; set; } = false;
        #endregion
    }
}
