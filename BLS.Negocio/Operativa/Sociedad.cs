using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    [Serializable]
   public class Sociedad
    {
        #region Propiedades
        public int IdCodigo { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string codSociedad { get; set; } = string.Empty;
        public int SociedadSAP { get; set; } = 0;
        public int DiasLaborales { get; set; } = 0;
        public Boolean Creado { get; set; } = false;
        public Boolean chk { get; set; } = false;
        public Boolean porDefecto { get; set; } = false;
        #endregion
    }
}
