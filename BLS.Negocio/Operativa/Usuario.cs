using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLS.Negocio.Operativa
{
    [Serializable]
    public class Usuario
    {
        #region Propiedades
        public int Id { get;  set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string  Contraseña { get;  set; } =string.Empty ;
        public string Nombre { get;  set; } = string.Empty;
        public string NombrePerfil { get; set; } = string.Empty;
        public DateTime FechaAlta { get;  set; } = Constantes.FechaGlobal ;
        public Boolean Activo { get;  set; } = false;
        public string Mail { get;  set; } = string.Empty;
        public DateTime FechaBaja { get;  set; } = Constantes.FechaGlobal;
        public Boolean Avisoemail { get; set; } = false;
        public string AreaTrabajo { get; set; } = string.Empty;
        public Boolean EsProyectista { get; set; } = false;
        public Boolean EsCreditos { get; set; } = false;
        
        public int Perfil { get; set; } = 0;
        public Boolean Creado { get;  set; } = false;
      
        #endregion
    }
}
