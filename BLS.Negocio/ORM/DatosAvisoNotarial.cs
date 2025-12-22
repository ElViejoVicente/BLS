using BLS.Negocio.Operativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS.Negocio.ORM
{
    public class DatosAvisoNotarial
    {
        public string IdExpediente { get; set; } = "";
        public string ClaveCatastral { get; set; } = "";
        public string InstitucionPracticoAvaluo { get; set; } = "";
        public string NaturalezaActoConceptoAdquisicion { get; set; } = "";
        public decimal DatCatastroSuperficie { get; set; } = 0;
        public decimal DatCatastroVendida { get; set; } = 0;
        public decimal DatCatastroRestante { get; set; } = 0;
        public decimal DatCatastroConstruida { get; set; } = 0;
        public decimal DatCatastroPlantas { get; set; } = 0;
        public string DatDiNoRePuPartida { get; set; } = "";
        public string DatDiNoRePuFojas { get; set; } = "";
        public string DatDiNoRePuSeccion { get; set; } = "";
        public string DatDiNoRePuVolumen { get; set; } = "";
        public string DatDiNoRePuDistrito { get; set; } = "";
        public string DatDiNoRePuFolioRealElectronico { get; set; } = "";
        public string DatDiNoRePuSelloRegistral { get; set; } = "";
        public string UbicacionDescripcionDeLosBienes { get; set; } = "";
        public string MedidasColindancias { get; set; } = "";
        public string ObservacionesAclaraciones { get; set; } = "";
        public string ReciboPagoImpuestoPredial { get; set; } = "";
        public DateTime FechaUltimoPago { get; set; } = Constantes.FechaGlobal;
        public string UbiPredioCalle { get; set; } = "";
        public string UbiPredioNumero { get; set; } = "";
        public string UbiPredioColonia { get; set; } = "";
        public string UbiPredioEstado { get; set; } = "";
        public string UbiPredioMunicipio { get; set; } = "";
        public string UbiPredioLocalidad { get; set; } = "";
        public string ObservacionesSolicitudPropiedad { get; set; } ="";
    }
}
