using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.APP
{
    public class ListaConsultaFolio
    {
        public string IdExpediente { get; set; } = "";
        public DateTime FechaUltimoTratamiento { get; set; } = Constantes.FechaGlobal;

        public string IdEstatus { get; set; } = "";
        public string Descripcion { get; set; } = "";

        public string AvisoAlCliente { get; set; } = "";

    }
}
