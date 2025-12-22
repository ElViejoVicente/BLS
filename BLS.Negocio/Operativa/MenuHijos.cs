using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    public class MenuHijos
    {
        public int IdParent { get; set; } = 0;
        public ItemMenu Itemparent { get; set; } = new ItemMenu();
        public List<ItemMenu> listSubMenus { get; set; } = new List<ItemMenu>();

        public Boolean Creado { get; set; } = false;
    }
}
