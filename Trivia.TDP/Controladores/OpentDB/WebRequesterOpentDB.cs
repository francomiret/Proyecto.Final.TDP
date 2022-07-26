using System.Net;

namespace Trivia.TDP.Controladores.OpentDB
{
    public class WebRequesterOpentDB
    {
        public WebResponse CrearConsulta( string pUrl )
        {
            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //CultureInfo provider = new CultureInfo("en-us");

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(pUrl);
            WebResponse mResponse = mRequest.GetResponse();
            return mResponse;
        }
    }
}
