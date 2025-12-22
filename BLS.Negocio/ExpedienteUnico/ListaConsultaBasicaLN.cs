using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ExpedienteUnico
{
    public class ListaConsultaBasicaLN
    {
        public string Nombres { get; set; } = "";
        public string ApellidoPaterno { get; set; } = "";
        public string ApellidoMaterno { get; set; } = "";
        public DateTime FechaNacimiento { get; set; } = Constantes.FechaGlobal;
        public string Sexo { get; set; } = "";
        public string TipoRegimen { get; set; } = "";
        public string Rfc { get; set; } = "";
        public string RazonSocial { get; set; } = "";
        public string NombreUsuarioConsulta { get; set; } = "";
    }
}
