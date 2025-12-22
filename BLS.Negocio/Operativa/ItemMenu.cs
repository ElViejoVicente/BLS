using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    public class ItemMenu
    {
        public int IdModulo { get; set; } = 0;
        public string descModulo { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public int parentID { get; set; } = 0;
        public string Icon { get; set; } = string.Empty;
        public Boolean Creado { get; set; } = false;
    }
}
