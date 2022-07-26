using System.Net;

namespace Trivia.TDP.Servicios.OpentDB
{
    public class WebRequesterOpentDB
    {
        public WebResponse CrearConsulta( string pUrl )
        {
            // Establecimiento del protocolo ssl de transporte
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //CultureInfo provider = new CultureInfo("en-us");

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(pUrl);
            WebResponse mResponse = mRequest.GetResponse();
            return mResponse;
        }
    }
}
