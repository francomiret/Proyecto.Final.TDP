using Dominio;
using System;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.OpentDB
{
    public class ImportadorDataOpentDB : IImportadorDataOpentDB
    {
        private CreadorURLOpentDB iUrlCreador;
        private WebRequesterOpentDB iWebRequester;
        private ParserOpentDB iParser;

        public IList<Pregunta> ObtenerPreguntas( int pCantidad, ConjuntoPreguntas pConjunto )
        {
            iUrlCreador = new CreadorURLOpentDB();
            iWebRequester = new WebRequesterOpentDB();
            iParser = new ParserOpentDB();

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
            var url = iUrlCreador.ConstruirUrl(pCantidad, pConjunto);
            var response = iWebRequester.CrearConsulta(url);
            var responseParsed = iParser.FormatearPreguntas(response, pConjunto);
            return responseParsed;
        }

        public List<Categoria> ObtenerCategorias()
        {
            iWebRequester = new WebRequesterOpentDB();
            iParser = new ParserOpentDB();

            var url = "https://opentdb.com/api_category.php";
            var response = iWebRequester.CrearConsulta(url);
            List<Categoria> responseParsed = iParser.FormatearCategorias(response);
            return responseParsed;
        }
    }
}
