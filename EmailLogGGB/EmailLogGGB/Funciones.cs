using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Data;

using System.Data.SqlClient;


namespace EmailLogGGB
{
    public class expedicion
    {
        public string numexpedicion;
        public string matricula;
        public string fechamatricula;
        public string fechaestcarga;
        public string destino;
        public string centrocarga;
        public string poblacioncarga;


    }
    public  class Funciones
    {
        public static string envioemail(DataRow expedicion,string emailp ,string pais,string nombresociedad)
        {

            string asunto;
            string cuerpo;
            string mensajer = "1";
            switch (pais)
            {
                case "ES":
                    cuerpo = cuerpomensaje(expedicion,nombresociedad);
                    asunto = "Expedicion retrasada";
                    break;
                case "IT":
                    cuerpo = cuerpomensaje(expedicion, nombresociedad);
                    asunto = "Expedicion retrasada/ Order delayed";
                    break;
                default:
                    cuerpo = cuerpomensaje(expedicion, nombresociedad);
                    asunto = "Order delayed";
                    break;
            }
            
            mensajer = enviarmail(emailp, asunto, cuerpo);

            if (mensajer == "0")
            {
                return "0";
            }
            else { return mensajer; }
        }
        public static string envioemailagrupado(expedicion[] lisexpedicion, string emailp, string pais, string nombresociedad)
        {

            string asunto;
            string cuerpo;
            string mensajer = "1";
            switch (pais)
            {
                case "ES":
                    cuerpo = cuerpomensajeagrupado(lisexpedicion, nombresociedad);
                    asunto = "Expedicion retrasada";
                    break;
                case "IT":
                    cuerpo = cuerpomensajeagrupado(lisexpedicion, nombresociedad);
                    asunto = "Expedicion retrasada/ Order delayed";
                    break;
                default:
                    cuerpo = cuerpomensajeagrupado(lisexpedicion, nombresociedad);
                    asunto = "Order delayed";
                    break;
            }

            mensajer = enviarmail(emailp, asunto, cuerpo);

            if (mensajer == "0")
            {
                return "0";
            }
            else { return mensajer; }
        }
        public static string cuerpomensaje(DataRow listaexpedicion,string nombresociedad)
        {
            string mensaje = "";
            string jerarquiacompleta = "";
            string nombrepais;
            string mensajep = "";


            mensaje = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" +
                      @"<html xmlns=""http://www.w3.org/1999/xhtml"">" +
                      "<head>" +
                      "<title></title>" +
                      @"<style type=""text/css"">" +
                      "p.MsoNormal()" +
                      "{margin-top:0cm;" +
                      "margin-right:0cm;" +
                      "margin-bottom:8.0pt;" +
                      "margin-left:0cm;" +
                      "line-height:107%;" +
                      "font-size:11.0pt;" +
                      @"font-family:""Calibri"",sans-serif;" +
                      "}" +
                      "p()" +
                      "{margin-right:0cm;" +
                      "margin-left:0cm;" +
                      "font-size:12.0pt;" +
                      @"font-family:""Times New Roman"",serif;" +
                      "}" +
                      "</style>" +
                      "</head>" +
                      "<body>" +
                      @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif"">Estimados Sres. " +
                        "<o:p></o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Le comunicamos que la siguiente expedición  </o:p></span></p>";
            //foreach (expedicion laexpe in listaexpedicion)
            //        {
                       
                            mensajep = mensajep + @"<p class=""MsoNormal"">" +
                              @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Expedición: " + listaexpedicion["Expedicion"].ToString()  + " ,con matricula: "+listaexpedicion["trans_mat"].ToString()+" y fecha salida prevista: " + listaexpedicion["exped_fecestirecogida"].ToString() + " desde el centro logistico: " + nombresociedad + ": " + listaexpedicion["Centro_Carga"].ToString() + " " + listaexpedicion["pob_carga"].ToString() + "</o:p></span></p>";
                       
                    //}
            mensaje = mensaje + mensajep;
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
             @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>No se ha cargado en la fecha prevista, concurriendo en un retraso. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Le regamos informe urgentemente sobre el estado de esta expedicion, y por favor, tenga en cuenta que las fechas de carga deben ser respetadas. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Por favor, póngase en contacto con su persona de contacto lo antes posible y confirmenos la información </o:p></span></p>";
            
            return mensaje;
        }
        public static string cuerpomensajeagrupado(expedicion[] listaexpedicion, string nombresociedad)
        {
            string mensaje = "";
            string jerarquiacompleta = "";
            string nombrepais;
            string mensajep = "";


            mensaje = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" +
                      @"<html xmlns=""http://www.w3.org/1999/xhtml"">" +
                      "<head>" +
                      "<title></title>" +
                      @"<style type=""text/css"">" +
                      "p.MsoNormal()" +
                      "{margin-top:0cm;" +
                      "margin-right:0cm;" +
                      "margin-bottom:8.0pt;" +
                      "margin-left:0cm;" +
                      "line-height:107%;" +
                      "font-size:11.0pt;" +
                      @"font-family:""Calibri"",sans-serif;" +
                      "}" +
                      "p()" +
                      "{margin-right:0cm;" +
                      "margin-left:0cm;" +
                      "font-size:12.0pt;" +
                      @"font-family:""Times New Roman"",serif;" +
                      "}" +
                      "</style>" +
                      "</head>" +
                      "<body>" +
                      @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif"">Estimados Sres. " +
                        "<o:p></o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Le comunicamos que las siguientes expediciones:  </o:p></span></p>";
            foreach (expedicion fila in listaexpedicion)
            {

                mensajep = mensajep + @"<p class=""MsoNormal"">" +
                  @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Expedición: " + fila.numexpedicion.ToString() + " , con matricula: " + fila.matricula + " y fecha salida prevista: " + fila.fechaestcarga + " desde el centro logistico: " + nombresociedad + ": " + fila.centrocarga + " " + fila.poblacioncarga + "</o:p></span></p>";

            }
            mensaje = mensaje + mensajep;
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
             @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>No se ha cargado en la fecha prevista, concurriendo en un retraso. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Le regamos informe urgentemente sobre el estado de esta expedicion, y por favor, tenga en cuenta que las fechas de carga deben ser respetadas. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Por favor, póngase en contacto con su persona de contacto lo antes posible y confirmenos la información </o:p></span></p>";

            return mensaje;
        }
        public static string cuerpomensajeespingles(expedicion[] listaexpedicion)
        {
            string mensaje = "";
            string jerarquiacompleta = "";
            string nombrepais;
            string mensajep = "";


            mensaje = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" +
                      @"<html xmlns=""http://www.w3.org/1999/xhtml"">" +
                      "<head>" +
                      "<title></title>" +
                      @"<style type=""text/css"">" +
                      "p.MsoNormal()" +
                      "{margin-top:0cm;" +
                      "margin-right:0cm;" +
                      "margin-bottom:8.0pt;" +
                      "margin-left:0cm;" +
                      "line-height:107%;" +
                      "font-size:11.0pt;" +
                      @"font-family:""Calibri"",sans-serif;" +
                      "}" +
                      "p()" +
                      "{margin-right:0cm;" +
                      "margin-left:0cm;" +
                      "font-size:12.0pt;" +
                      @"font-family:""Times New Roman"",serif;" +
                      "}" +
                      "</style>" +
                      "</head>" +
                      "<body>" +
                      @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif"">Estimados Sres. " +
                        "<o:p></o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Los pedidos con número:  </o:p></span></p>";
            foreach (expedicion laexpe in listaexpedicion)
            {

                mensajep = mensajep + @"<p class=""MsoNormal"">" +
                          @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Expedición:" + laexpe.numexpedicion + " Fecha estimada carga:" + laexpe.fechaestcarga + " Destino:" + laexpe.destino + " Centro carga:" + laexpe.centrocarga + "</o:p></span></p>";

            }
            mensaje = mensaje + mensajep;
            mensajep = "";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
             @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>realizado a su empresa presenta un retraso de tres días respecto a la fecha de entrega acordada. Requerimos que informen </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>urgentemente de la situacion de este pedido. Tenga en cuenta que las fechas de entrega deben cumplirse con puntualidad. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Nuestro sistema informático registra todos los retrasos en el servicio y esos datos serán evaluados y tenido en cuenta de cara a su valoración como proveedor </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p> de Cristian Lay.</o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Por favor, contacte con su tramitador tan pronto como sea posible y cumplimente la información en el portal de aprovisionamiento.</o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>http://cpp.cristianlay.com/ </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Quedamos a la espera de su respuesta </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Cordiales saludos </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                  @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>The orders number:  </ o:p ></ span ></ p > ";
            foreach (expedicion laexpe in listaexpedicion)
            {

                mensajep = mensajep + @"<p class=""MsoNormal"">" +
                          @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Expedición:" + laexpe.numexpedicion + " Fecha estimada carga:" + laexpe.fechaestcarga + " Destino:" + laexpe.destino + " Centro carga:" + laexpe.centrocarga + "</o:p></span></p>";

            }
            mensaje = mensaje + mensajep;
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
             @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>made to your company has a delay of three days according to the delivery date agreed. We request you to inform urgently </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>about the production status of this order. Please note that delivery dates should be followed on time.  </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Our computer system records all delays in deliveries and these data will be evaluated & used in order to assess your company as Cristian Lay´s supplier. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Please, contact with your contact person as soon as possible and confirm us the information in the purchase order management system.</o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>http://cpp.cristianlay.com/ </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>We are looking forward hearing from you about this matter. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Kind regards, </o:p></span></p>";
            return mensaje;
            return mensaje;
        }
     
        public static string cuerpomensajeingles(expedicion[] listaexpedicion)
        {
            string mensaje = "";
            string jerarquiacompleta = "";
            string nombrepais;
            string mensajep = "";


            mensaje = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" +
                      @"<html xmlns=""http://www.w3.org/1999/xhtml"">" +
                      "<head>" +
                      "<title></title>" +
                      @"<style type=""text/css"">" +
                      "p.MsoNormal()" +
                      "{margin-top:0cm;" +
                      "margin-right:0cm;" +
                      "margin-bottom:8.0pt;" +
                      "margin-left:0cm;" +
                      "line-height:107%;" +
                      "font-size:11.0pt;" +
                      @"font-family:""Calibri"",sans-serif;" +
                      "}" +
                      "p()" +
                      "{margin-right:0cm;" +
                      "margin-left:0cm;" +
                      "font-size:12.0pt;" +
                      @"font-family:""Times New Roman"",serif;" +
                      "}" +
                      "</style>" +
                      "</head>" +
                      "<body>" +
                      @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif"">Dear Sirs, " +
                        "<o:p></o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                   @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>The orders number:  </ o:p ></ span ></ p > ";
            foreach (expedicion laexpe in listaexpedicion)
            {

                mensajep = mensajep + @"<p class=""MsoNormal"">" +
                          @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Expedición:" + laexpe.numexpedicion + " Fecha estimada carga:" + laexpe.fechaestcarga + " Destino:" + laexpe.destino + " Centro carga:" + laexpe.centrocarga + "</o:p></span></p>";

            }
            mensaje = mensaje + mensajep;
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
             @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>made to your company has a delay of three days according to the delivery date agreed. We request you to inform urgently </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>about the production status of this order. Please note that delivery dates should be followed on time.  </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Our computer system records all delays in deliveries and these data will be evaluated & used in order to assess your company as Cristian Lay´s supplier. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Please, contact with your contact person as soon as possible and confirm us the information in the purchase order management system.</o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>http://cpp.cristianlay.com/ </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>We are looking forward hearing from you about this matter. </o:p></span></p>";
            mensaje = mensaje + @"<p class=""MsoNormal"">" +
                 @"<span style=""font-family:&quot;Century Gothic&quot;,sans-serif""><o:p>Kind regards, </o:p></span></p>";
            return mensaje;
        }
       

        public static string enviarmail(string destinatario, string asunto, string cuerpomensaje)
        {
            string respuesta = "0";
            //   DataTable drficheros;
            int i = 0;
            string[] destinatarios;
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials("orders@clgrupoindustrial.com", "PedidosCL1234");


                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;

                // service.AutodiscoverUrl("orders@clgrupoindustrial.com");
                service.Url = new Uri("https://outlook.office365.com/ews/exchange.asmx");

                EmailMessage email = new EmailMessage(service);

                destinatarios = destinatario.Split(',');
                foreach (string d in destinatarios)
                {
                    EmailAddress dir = new EmailAddress();
                    dir.Address = d.Trim();
                    email.ToRecipients.Add(dir);
                }

                /*  EmailAddress dir2 = new EmailAddress();
                      dir2.Address = "orders@clgrupoindustrial.com";
                      email.ToRecipients.Add(dir2);
                 EmailAddress dir3 = new EmailAddress();
                      dir3.Address = "vmunoz@cristianlay.com";
                      email.ToRecipients.Add(dir3);*/

                email.Subject = asunto;

                email.Body = new MessageBody(BodyType.HTML, cuerpomensaje);


              


                //email.Send();
                email.SendAndSaveCopy();

                respuesta = "0";
                return respuesta;
            }
            catch (Exception ex)
            {
                //   escribeenfichero("Error envio email" + DateTime.Now + ".");
                respuesta = ex.Message;
                return respuesta;
            }
        }
       
       

    }
}
