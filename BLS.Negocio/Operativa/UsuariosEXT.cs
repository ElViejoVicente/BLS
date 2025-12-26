using BLS.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.Operativa
{
    public class UsuariosEXT:Usuarios
    {
        public string NombrePerfil { get; set; }
        public int Perfil { get; set; }

        
    }
}
