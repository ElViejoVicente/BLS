using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace BLS.Negocio.Operativa
{
    public class Constantes
    {
        public static DateTime FechaGlobal = DateTime.Parse("1900-01-01");

        
        public struct Usuario
        {
            public const string Centro_SAP = "01";
            public const string CodigoSociedadSAP = "";
        }

        public struct Cliente
        {
            public const string ClienteSAP = "";
            public const string CodigoSociedadSAP = "";
        }

        public enum FormatoFecha : int
        {
            Fecha_yyyyMMdd = 0,
            Fecha_ddMMyyyy_Barra = 1,
            Fecha_ddMMyyyy_Guion = 2
        }

       
        //public static string ClienteSAP
        //{
        //    get;
        //    set;
        //}

        public enum tipoOrdenFamilia
        {
            visualizacion=1,
            Fabricacion =2
        }

        public enum EstatusFabricacion
        {
            Pendiente=0,
            EnMarcha=1,
            Finalizado=2

        }


        public struct TipoMaterial
        {
            // Public Const NINGUNO As String = ""
            // Public Const ProdTerminado As String = "1206"
            // Public Const MatPrima As String = "1201"
            // Public Const Packaging As String = "1202"
            // Public Const Semielaborado As String = "1215"
            // Public Const Fabricaciones As String = "1205"
            // Public Const MatCliente As String = "1203"
            // Public Const Repuestos As String = "1209"
            public const string NINGUNO = "";
            public const string MatPrimaCL = "0";
            public const string SemielaboradoCL = "1";
            public const string ProductoTerminadoFabricacion = "2";
            public const string SuministrosCL = "3";
            public const string PackagingCL = "5";
            public const string MatPrimaPE = "6";
            public const string SemielaboradoPE = "7";
            public const string ProductoTerminadoPE = "8";
            public const string MatGenPTFabricacion = "9";
            public const string ProductoTerminadoCompra = "21";
            public const string ProductoTerminadoModula = "22";
            public const string MatGenPTCompra = "91";
            public const string MatGenSECompra = "92";
        }

      


    }
    public  class GGBSociedad
    {
        public static string AG_SIDERURGICA_BALBOA_SA = "FI11";
        public static string AG_FERRO_MALLAS_SA = "FI14";
        public static string CORRUGADOS_GETAFE_SL = "FI22";
        public static string CORRUGADOS_LASAO_SLU = "FI23";
        public static string MARCELIANO_MARTIN = "FI31";
        public static string ALFONSO_GALLARDO_SA = "FI41";
        public static string TODAS = "Todas";

    }

    public class Sistema
    {
        private string sServidorSAP;
        private string sUsuarioSAP;
        private string sClaveSAP;
        private string sSistemaSAP;
        private string sClienteSAP;
        private string sInstanciaSAP;

        static Sistema  sSis;

        public Sistema(string ServidorSAP, string InstanciaSAP, string SistemaSAP, string UsuarioSAP, string ClaveSAP, string ClienteSAP)
        {
            sServidorSAP = ServidorSAP;
            sUsuarioSAP = UsuarioSAP;
            sClaveSAP = ClaveSAP;
            sSistemaSAP = SistemaSAP;
            sClienteSAP = ClienteSAP;
            sInstanciaSAP = InstanciaSAP;
        }
        
        
        public static Sistema Sis
        {
            get
            {
                return sSis;
            }
            set
            {
                sSis = value;
            }
        }

        public  string ServidorSAP
        {
            get
            {
                return sServidorSAP;
            }
            set
            {
                sServidorSAP = value;
            }
        }

        public string ClaveSAP
        {
            get { return sClaveSAP; }
            set { sClaveSAP = value; }
        }

        public string UsuarioSAP
        {
            get { return sUsuarioSAP; }
            set { sUsuarioSAP = value; }
        }

        public string SistemaSAP
        {
            get { return sSistemaSAP; }
            set { sSistemaSAP = value; }
        }

        public string ClienteSAP
        {
            get { return sClienteSAP; }
            set { sClienteSAP = value; }
        }

        public string InstanciaSAP
        {
            get { return sInstanciaSAP; }
            set { sInstanciaSAP = value; }
        }
    }
    

}
