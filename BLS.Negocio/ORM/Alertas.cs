using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class Alertas
    {
        public int IdAlerta { get; set; } = 0;
        public string NumExpediente { get; set; } = "";
        public DateTime FechaAlta { get; set; } = Constantes.FechaGlobal;
        public string NomUsuarioInformante { get; set; } = "";
        public string MensajeAlerta { get; set; } = "";
        public string Prioridad { get; set; } = "";
        public bool AlertaActiva { get; set; }=false;
        public string NomUsuarioCierra { get; set; } = "";
        public DateTime FechaCierre { get; set; }= Constantes.FechaGlobal;
    }
}
