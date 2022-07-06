using Dominio;
using System;
using System.Collections.Generic;
using System.Net;

namespace Trivia.TDP.Controladores.OpentDB
{
    class ImportadorDataOpentDB
    {
        private readonly CreadorURLOpentDB iUrlCreador;
        private readonly WebRequesterOpentDB iWebRequester;
        private readonly RespuestaParserOpentDB iParser;

        public  IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            if ((pConjunto == null) ||
                (pConjunto.Categoria == null) ||
                (pConjunto.Dificultad == null) ||
                String.IsNullOrEmpty(pConjunto.Nombre))
            {
                throw new ArgumentNullException();
            }

            if (pCantidad == 0)
            {
                return new List<Pregunta>();
            }
            var url = iUrlCreador.CrearUrl(pCantidad, pConjunto);
            var response = iWebRequester.PeticionAUrl(url);
            var responseParsed = iParser.ParseResponse(response, pConjunto);
            return responseParsed;
        }

        public List<Categoria> obtenerCategorias ()
        {
            var url = "https://opentdb.com/api_category.php";
            var response = iWebRequester.PeticionAUrl(url);
            List<Categoria> responseParsed = iParser.ParseResponseCategorias(response);
            return responseParsed;
        }

        public ImportadorDataOpentDB() 
        {
            this.iUrlCreador = new CreadorURLOpentDB();
            this.iWebRequester = new WebRequesterOpentDB();
            this.iParser = new RespuestaParserOpentDB();
        }
    }
}
