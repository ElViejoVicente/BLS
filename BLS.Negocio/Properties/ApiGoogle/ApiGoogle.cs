using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Runtime;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;



namespace BLS.Negocio.ApiGoogle
{
    public class ApiGoogle
    {
        string sRegionRes = "es";
        Boolean bSensor = false;
        string sIdiomaRes = "es";
        int iTimeOut = 3000;
        private string Pcopyright;
        private ArrayList PdistanciaTotal = new ArrayList();
        private ArrayList PduracionTotal = new ArrayList();
        private string PidRuta;
        private ArrayList PordenHitos = new ArrayList();
        private ArrayList Ppolilineas = new ArrayList();
        private ArrayList PtiempoTotal = new ArrayList();
        public string Copyright {
            get  {
                return this.Pcopyright;}
        }
        public ArrayList DistanciaTotal {
            get
            {
                return this.PdistanciaTotal;
            }
        }
    
        public ArrayList DuracionTotal {
            get {
                return this.PduracionTotal;
                }
        
        }
        public string IDruta {
            get {
                return this.PidRuta;
                }
        
        }
    
        public ArrayList OrdenHitos {
            get {
                return this.PordenHitos;
                }
        
        }

        public ArrayList Polilineas {
            get {
                return this.Ppolilineas;
                }
        
        }


        public ArrayList TiempoTotal {
            get
            {
                return this.PtiempoTotal;
            }
        
        }
    
             public enum TipoTransporte : int
        {

            
            Andando = 1,

            
            Bicicleta = 2,

            
            Coche = 0,

            
        }
        public enum RestriccionesVias : int
        {
            Sin_Autovias_Autopistas = 2,
            Sin_Peajes = 1,
            Sin_restricciones = 0,
        }

        public void CambioPais(int iCodPais)
        {
            switch(iCodPais)
            {
                case 9:
                    this.sRegionRes = "pr";
                    this.sIdiomaRes = "es";
                    break;
                case 39:
                    this.sRegionRes = "it";
                    this.sIdiomaRes = "it";
                    break;
                case 51:
                    this.sRegionRes = "pt";
                    this.sIdiomaRes = "pt";
                    break;
                case 52:
                    this.sRegionRes = "mx";
                    this.sIdiomaRes = "es";
                    break;
                case 56:
                    this.sRegionRes = "cl";
                    this.sIdiomaRes = "es";
                    break;
                case 57:
                    this.sRegionRes = "co";
                    this.sIdiomaRes = "es";
                    break;
                default:
                    this.sRegionRes = "es";
                    this.sIdiomaRes = "es";
                    break;
            }

        }
        public void CambiaPais(string Pais)
        {
            switch (Pais)
            {
                case "PUERTO RICO":
                    this.sRegionRes = "pr";
                    this.sIdiomaRes = "es";
                    break;
                case "ITALIA":
                    this.sRegionRes = "it";
                    this.sIdiomaRes = "it";
                    break;
                case "PORTUGAL":
                    this.sRegionRes = "pt";
                    this.sIdiomaRes = "pt";
                    break;
                case "MEXICO":
                    this.sRegionRes = "mx";
                    this.sIdiomaRes = "es";
                    break;
                case "CHILE":
                    this.sRegionRes = "cl";
                    this.sIdiomaRes = "es";
                    break;
                case "COLOMBIA":
                    this.sRegionRes = "co";
                    this.sIdiomaRes = "es";
                    break;
                default:
                    this.sRegionRes = "es";
                    this.sIdiomaRes = "es";
                    break;
            }

        }
        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Bounds
        {
            public Location northeast { get; set; }
            public Location southwest { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Bounds viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public bool partial_match { get; set; }
            public List<string> types { get; set; }
        }

        public class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
        public class Geocoded
        {
           public string geocoder_status { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }

        }
        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }
        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }
        public class Polyline
        {
            public string points { get; set; }
        }
        public class Step
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public Location end_location { get; set; }
            public string html_instructions { get; set; }
            public Polyline polyline { get; set; }
            public Location start_location { get; set; }
            public string travel_mode { get; set; }
        }
        public class Legs
        {
            public Distance distance { get; set; }

            public Duration duration { get; set; }
            public string end_address { get; set; }
            public Location end_location { get; set; }
            public string start_address { get; set; }
            public Location start_location { get; set; }
            public List<Step> steps { get; set; }
            public List<string> traffic_speed_entry { get; set; }
            public List<string> via_waypoint { get; set; }
            

        }
        public class Routes
        {
          
            public Bounds bounds { get; set; }
            public string copyrights { get; set; }
            public List<Legs>  legs { get; set; }
            public Polyline overview_polyline { get; set; }
            public string  summary { get; set; }
            public List<string> warnings { get; set; }
            public List<string> waypoint_order { get; set; }

        }
        public class Ruta
        {
            public List<Geocoded> geocoded_waypoints { get; set; }
            public List<Routes> routes { get; set; }
            public string status { get; set; }
        }
        private WebClient wsProxy = new WebClient();
        public ApiGoogle()
        {
         
        }
        public RootObject CodificacionGeografica2(string Direccion)
        {
            string sDireccionValida;
            RootObject dir = new RootObject();
            try
            {
                wsProxy.Encoding = System.Text.Encoding.UTF8;
                sDireccionValida = Direccion;
                sDireccionValida = coviertecadenabuena(sDireccionValida);
                string url = "https://maps.google.com/maps/api/geocode/json?address=" + sDireccionValida + "  &region = " + sRegionRes + " &language=" + sIdiomaRes + "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg";
                var resultadoRes = wsProxy.DownloadString(url);
                //   var result = new System.Net.WebClient().DownloadString(resultadoRes);
                var root = JsonConvert.DeserializeObject<RootObject>(resultadoRes);


                return root;
            }
            catch(Exception ex)
            {
                return dir;
            }
            
        }
        public RootObject CodificacionGeograficaInversa2(string latitud, string longitud)
        {
            wsProxy.Encoding = System.Text.Encoding.UTF8;
            //string[] url = new string[] { "https://maps.googleapis.com/maps/api/geocode/xml?latlng=", Conversions.ToString(latitud), ",", Conversions.ToString(longitud), "&region=", sRegionRes, "&sensor=", bSensor.ToString().ToLower(), "&language=", sIdiomaRes, "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg&v=3.21" };
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + Conversions.ToString(latitud) + "," + Conversions.ToString(longitud) + "&region=" + sRegionRes + "&sensor=" + bSensor.ToString().ToLower() + "&language=" + sIdiomaRes + "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg";
            var resultadoRes = wsProxy.DownloadString((new Uri(url)));
            //   var result = new System.Net.WebClient().DownloadString(resultadoRes);
            var root = JsonConvert.DeserializeObject<RootObject>(resultadoRes);


            return root;

        }
        public Ruta CalcularRuta2 (string DireccionOrigen, string DireccionDestino, TipoTransporte tipoTransport = 0, RestriccionesVias RestriccionesCarretera = 0, ArrayList Hitos = null, Boolean optimizar = false)
        {
            wsProxy.Encoding = System.Text.Encoding.UTF8;
            string str3;
            this.PordenHitos.Clear();
            this.PtiempoTotal.Clear();
            this.PdistanciaTotal.Clear();
            this.PduracionTotal.Clear();
            this.Ppolilineas.Clear();
            this.Pcopyright = "Copyright";
            this.PidRuta = "ID de la ruta";
            string str6 = Conversions.ToString(Convert.ToInt32(tipoTransport));
            switch (tipoTransport)
            {
                case TipoTransporte.Coche:
                    str6 = "&mode=driving";
                    break;
                case TipoTransporte.Andando:
                    str6 = "&mode=walking";
                    break;
                case TipoTransporte.Bicicleta:
                    str6 = "&mode=bicycling";
                    break;


            }
            string str2 = DireccionOrigen;
            string str = DireccionDestino;

            DireccionOrigen = coviertecadenabuena(DireccionOrigen);
            DireccionOrigen = ("&origin=" + DireccionOrigen);

            DireccionDestino = coviertecadenabuena(DireccionDestino);
            DireccionDestino = ("&destination=" + DireccionDestino);
            string left = "&waypoints=";
            if (optimizar)
            {
                left = "&waypoints=optimize:true|";
            }
            if (Hitos is null)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = Hitos.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Object right = RuntimeHelpers.GetObjectValue(enumerator.Current).ToString().Replace(" ", "+");
                        left = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(left, right), "|"));
                    }
                }
                catch (Exception ex)
                {

                }
            }
            left = "";
            str3 = "";
            switch (RestriccionesCarretera)
            {
                case RestriccionesVias.Sin_restricciones:
                    str3 = "";
                    break;
                case RestriccionesVias.Sin_Peajes:
                    str3 = "&avoid=tolls";
                    break;
                case RestriccionesVias.Sin_Autovias_Autopistas:
                    str3 = "&avoid=highways";
                    break;
            }
            wsProxy.Encoding = System.Text.Encoding.UTF8;
            string url = "https://maps.googleapis.com/maps/api/directions/json?"+ DireccionOrigen+ DireccionDestino+ left+ str6+ str3+ "&region="+ sRegionRes+ "&sensor="+ bSensor.ToString().ToLower()+ "&language="+ sIdiomaRes+ "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg";
            var resultadoRes = wsProxy.DownloadString((new Uri(url)));
            
            var root = JsonConvert.DeserializeObject<Ruta>(resultadoRes);
            return root;
        }
        public ArrayList CodificacionGeografia(string Direccion)
        {
            string sDireccionValida;
            ArrayList list2=new ArrayList();
            string estatus = "";

            sDireccionValida = Direccion;
            sDireccionValida = coviertecadenabuena(sDireccionValida);
            string[] url = new string[] { "https://maps.googleapis.com/maps/api/geocode/xml?new_forward_geocoder=true&address=", sDireccionValida, "&region=", sRegionRes, "&sensor=", bSensor.ToString().ToLower(), "&language=", sIdiomaRes, "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg&v=3.21" };
            string requestUriString = String.Concat(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = iTimeOut;
            try
            {
                IEnumerator  enumerator;
                Stream responseStream = request.GetResponse().GetResponseStream();
                XPathDocument document= new XPathDocument(responseStream);

                XPathNavigator instance;
                instance= document.CreateNavigator();
                string xpath  = "GeocodeResponse/status";
                string str4 = "GeocodeResponse/result/geometry/location/lat";
                string str5 = "GeocodeResponse/result/geometry/location/lng";
                string str3 = "GeocodeResponse/result/formatted_address";
                ArrayList[] list3 = new ArrayList[2];
                list3[0].Add(str4);
                list3[1].Add(str5);
                list3[2].Add(str3);
                XPathNodeIterator iterator = instance.Select(xpath);
                do
                {
                    estatus = iterator.Current.Value;
                    break;
                 } while (iterator.MoveNext());
                enumerator = list3.GetEnumerator();
                try
                {
                  
                    while (enumerator.MoveNext())
                    {
                        object objectvalue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                        object[] arguments = (object[]) RuntimeHelpers.GetObjectValue(objectvalue);
                        Boolean[] copyBack = new Boolean[0];
                        copyBack[0] = true;

                        if (copyBack[0])
                        {
                            objectvalue= RuntimeHelpers.GetObjectValue(arguments[0]);
                        }
                        iterator = (XPathNodeIterator)NewLateBinding.LateGet(instance, null, "Select", arguments, null, null, copyBack);
                        while (iterator.MoveNext())
                        {
                            list2.Add(iterator.Current.Value);
                        }

                    }

                }

                catch(Exception ex)
                {
                    if (enumerator is IDisposable)
                        {
                      
                      }
                
                }
                
                responseStream.Close();
                return list2;

            }
            catch(Exception ex)
            {
                ProjectData.SetProjectError(ex);
                estatus = "LOST";
                ProjectData.ClearProjectError();
                return list2;
            }

            

        }
        public string[] CalcularRuta(string DireccionOrigen,string DireccionDestino , TipoTransporte tipoTransport = 0, RestriccionesVias RestriccionesCarretera  = 0, ArrayList   Hitos  = null ,Boolean optimizar = false)

        {
            string str3;
            this.PordenHitos.Clear();
            this.PtiempoTotal.Clear();
            this.PdistanciaTotal.Clear();
            this.PduracionTotal.Clear();
            this.Ppolilineas.Clear();
            this.Pcopyright = "Copyright";
            this.PidRuta = "ID de la ruta";
            string str6  = Conversions.ToString(Convert.ToInt32(tipoTransport));
            switch (tipoTransport)
            {
               case TipoTransporte.Coche:
                                    str6 = "&mode=driving";
                                    break;
                case TipoTransporte.Andando:
                    str6 = "&mode=walking";
                    break;
                case TipoTransporte.Bicicleta:
                    str6 = "&mode=bicycling";
                    break;


             }
            string str2 = DireccionOrigen;
            string str = DireccionDestino;

            DireccionOrigen = coviertecadenabuena(DireccionOrigen);
            DireccionOrigen = ("&origin=" + DireccionOrigen);

            DireccionDestino = coviertecadenabuena(DireccionDestino);
            DireccionDestino = ("&destination=" + DireccionDestino);
            string left = "&waypoints=";
            if (optimizar)
            {
                left = "&waypoints=optimize:true|";
            }
            if (Hitos is null)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = Hitos.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Object right = RuntimeHelpers.GetObjectValue(enumerator.Current).ToString().Replace(" ", "+");
                        left = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(left, right), "|"));
                    }
                }
                catch (Exception ex)
                {

                }
            }
            left = "";
            str3 = "";
                switch(RestriccionesCarretera)
                {
                    case RestriccionesVias.Sin_restricciones:
                        str3 = "";
                        break;
                    case RestriccionesVias.Sin_Peajes:
                        str3 = "&avoid=tolls";
                        break;
                    case RestriccionesVias.Sin_Autovias_Autopistas:
                        str3 = "&avoid=highways";
                        break;
                }
                string[] url = new string[] { "https://maps.googleapis.com/maps/api/directions/xml?", DireccionOrigen, DireccionDestino, left, str6, str3, "&region=", sRegionRes, "&sensor=", bSensor.ToString().ToLower(), "&language=", sIdiomaRes, "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg&v=3.21" };
                string requestUriString = String.Concat(url);
                string estatus = "";
                ArrayList list= new ArrayList();
                string[] strArray2 = new string[0];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
                request.Timeout = iTimeOut;
                try
                {
                    IEnumerator enumerator2;
                    Stream responseStream = request.GetResponse().GetResponseStream();
                    XPathDocument document = new XPathDocument(responseStream);
                    XPathNavigator instance;
                    instance = document.CreateNavigator();
                    string xpath = "DirectionsResponse/status";
                    string str13 = "DirectionsResponse/route/leg/step/start_location/lat";
                    string str14 = "DirectionsResponse/route/leg/step/start_location/lng";
                    string str19 = "DirectionsResponse/route/leg/step/duration/text";
                    string str9 = "DirectionsResponse/route/leg/step/distance/text";
                    string str12 = "DirectionsResponse/route/leg/step/html_instructions";
                    string str17 = "DirectionsResponse/route/summary";
                    string str8  = "DirectionsResponse/route/copyrights";
                    string str15 = "DirectionsResponse/route/waypoint_index";
                    string str11 = "DirectionsResponse/route/leg/duration/value";
                    string str10 = "DirectionsResponse/route/leg/distance/value";
                    string str20 = "DirectionsResponse/route/leg/step/duration/value";
                    string str16  = "DirectionsResponse/route/leg/step/polyline/points";
                    XPathNodeIterator iterator = instance.Select(xpath);
                    while (iterator.MoveNext())
                    {
                        estatus = iterator.Current.Value;
                        break;
                    }
                    iterator = instance.Select(str8);
                    while (iterator.MoveNext())
                    {
                        this.Pcopyright = iterator.Current.Value;
                    }
                    iterator = instance.Select(str15);
                    while (iterator.MoveNext())
                    {
                        this.PordenHitos.Add(iterator.Current.Value);
                    }
                    iterator = instance.Select(str17);
                    while (iterator.MoveNext())
                    {
                        this.PidRuta = iterator.Current.Value;
                    }
                    iterator = instance.Select(str11);
                    while (iterator.MoveNext())
                    {
                        this.PduracionTotal.Add(iterator.Current.Value);
                    }
                    iterator = instance.Select(str10);
                    while (iterator.MoveNext())
                    {
                        this.PdistanciaTotal.Add(iterator.Current.Value);
                    }
                    iterator = instance.Select(str20);
                    while (iterator.MoveNext())
                    {
                        this.PtiempoTotal.Add(iterator.Current.Value);
                    }
                    iterator = instance.Select(str16);
                    while (iterator.MoveNext())
                    {
                        this.Ppolilineas.Add(iterator.Current.Value);
                     }
                    string[] cadenas = new String[] { str13, str14, str19, str9, str12 };
                    ArrayList list2 = new ArrayList();
                    list2.AddRange(cadenas);
                    try
                    {
                        enumerator2 = list2.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            Object objectValue = RuntimeHelpers.GetObjectValue(enumerator2.Current);
                            Object[] arguments = new Object[] { RuntimeHelpers.GetObjectValue(objectValue) };
                            Boolean[] copyBack = new Boolean[] { true};
                            if (copyBack[0])
                                {
                                objectValue = RuntimeHelpers.GetObjectValue(arguments[0]);
                               }
                            iterator = (XPathNodeIterator)NewLateBinding.LateGet(instance, null, "Select", arguments, null, null, copyBack);
                            while (iterator.MoveNext())
                            {
                                list.Add(iterator.Current.Value);
                             }
                        }
                
                    }
                    catch(Exception ex)
                    {

                    }
                    
                    
                    strArray2 = new String[] { };
                    int num2 = Convert.ToInt32(Math.Round(Convert.ToDouble((Convert.ToDouble(list.Count) / 5))));
                    int index = 0;
                    int num4 = num2 - 1;
                    int i = 0;
                    while (i <= num4)
                    {
                        strArray2[index] = Conversions.ToString(list[i]);
                        strArray2[(index + 1)] = Conversions.ToString(list[(i + num2)]);
                        strArray2[(index + 2)] = Conversions.ToString(list[((i + num2) + num2)]);
                        strArray2[(index + 3)] = Conversions.ToString(list[(((i + num2) + num2) + num2)]);
                        strArray2[(index + 4)] = Conversions.ToString(list[((((i + num2) + num2) + num2) + num2)]);
                        index = (index + 5);
                        i += 1;
                   }

                    responseStream.Close();
                        return strArray2;
                }
                catch(Exception ex)
                {
                    estatus = "LOST";
                    ProjectData.ClearProjectError();
                    return strArray2;
                }


           

        }
        public ArrayList CodificacionGeograficaInversa(string latitud,string longitud)
        {
            string[] url = new string[]{ "https://maps.googleapis.com/maps/api/geocode/xml?latlng=", Conversions.ToString(latitud), ",", Conversions.ToString(longitud), "&region=", sRegionRes, "&sensor=", bSensor.ToString().ToLower(), "&language=", sIdiomaRes, "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg&v=3.21" };
            string requestUriString = String.Concat(url);
            ArrayList list2 = new ArrayList();
            string estatus = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = iTimeOut;

            try
            {
                Stream responseStream = request.GetResponse().GetResponseStream();
                XPathNavigator navigator = new XPathDocument(responseStream).CreateNavigator();
                string xpath = "GeocodeResponse/status";
                string str3 = "GeocodeResponse/result/formatted_address";
                XPathNodeIterator iterator = navigator.Select(xpath);
                while (iterator.MoveNext())
                {
                    estatus = iterator.Current.Value;
                }
                iterator = navigator.Select(str3);
                while (iterator.MoveNext())
                {
                    list2.Add(iterator.Current.Value);
                }
                if (list2.Count == 0)
                {
                    list2.Add("Sin datos");
                    }
                responseStream.Close();

            }
            catch(Exception ex)
            {
                estatus = "LOST";
                ProjectData.ClearProjectError();
            }
            return list2;
        }   
        public string CodigoPostal(string localizacion)
        {
            string[] url = new string[] { "https://maps.googleapis.com/maps/api/geocode/xml?address=", localizacion, "&region=", sRegionRes, "&sensor=", bSensor.ToString().ToLower(), "&language=", sIdiomaRes, "&key=AIzaSyA-5Jr0R2FqRkOnFyCnVZjvVp-FuqL54cg&v=3.21" };
            string requestUriString  = String.Concat(url);
            ArrayList list=new ArrayList();
            string estatus = "";
            string str2 = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = iTimeOut;
            try
            {
                Stream responseStream = request.GetResponse().GetResponseStream();
                XPathNavigator navigator = new XPathDocument(responseStream).CreateNavigator();
                string xpath = "/GeocodeResponse/result/address_component";
                string str6 = "GeocodeResponse/status";
                XPathNodeIterator iterator = navigator.Select(str6);
                while (iterator.MoveNext())
                {
                    estatus = iterator.Current.Value;
                }
                iterator = navigator.Select(xpath);
                while (iterator.MoveNext())
                {
                    if (iterator.Current.Value.Contains("postal_code"))
                    {
                        str2 = iterator.Current.Value.Substring(0, 5);
                        break;
                    }
                    
                }
                if (str2 == "")
                {
                    str2 = "No hay resultados, sea más específico.";
                }

                responseStream.Close();
            }
            catch (Exception ex)
            {
                estatus = "LOST";
                ProjectData.ClearProjectError();
             }

            return str2;
        }

        private string coviertecadenabuena(string cadena)
        {
            string respuesta;
            respuesta = cadena;
            respuesta = respuesta.Replace("%", "%25");
            respuesta = respuesta.Replace("!", "%21");
            respuesta = respuesta.Replace("*", "%2A");
            respuesta = respuesta.Replace("(", "%28");
            respuesta = respuesta.Replace(")", "%29");
            respuesta = respuesta.Replace(";", "%3B");
            respuesta = respuesta.Replace(":", "%3A");
            respuesta = respuesta.Replace("@", "%40");
            respuesta = respuesta.Replace("&", "%26");
            respuesta = respuesta.Replace("=", "%3D");
            respuesta = respuesta.Replace("+", "%2B");
            respuesta = respuesta.Replace("$", "%24");
            respuesta = respuesta.Replace(",", "%2C");
            respuesta = respuesta.Replace("/", "%2F");
            respuesta = respuesta.Replace("?", "%3F");
            respuesta = respuesta.Replace("#", "%23");
            respuesta = respuesta.Replace("[", "%5B");
            respuesta = respuesta.Replace("]", "%5D");
            respuesta = respuesta.Replace(" ", "+");
            return respuesta;
        }
    }
  
}
