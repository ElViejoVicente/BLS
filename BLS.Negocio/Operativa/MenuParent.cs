using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
   public class MenuParent
    {
        public int IdParent { get; set; } = 0;
        public ItemMenu Itemparent { get; set; } = new ItemMenu();
        public List<MenuHijos> listMenus { get; set; } = new List<MenuHijos>();
        public Boolean Creado { get; set; } = false;
    }
}
