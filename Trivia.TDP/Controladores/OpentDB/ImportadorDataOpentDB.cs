using Dominio;
using System;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.OpentDB
{
    class ImportadorDataOpentDB : IImportadorDataOpentDB
    {
        private readonly CreadorURLOpentDB iUrlCreador;
        private readonly WebRequesterOpentDB iWebRequester;
        private readonly RespuestaParserOpentDB iParser;

        public ImportadorDataOpentDB()
        {
            this.iUrlCreador = new CreadorURLOpentDB();
            this.iWebRequester = new WebRequesterOpentDB();
            this.iParser = new RespuestaParserOpentDB();
        }

        public IList<Pregunta> ObtenerPreguntas( int pCantidad, ConjuntoPreguntas pConjunto )
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
            var url = iUrlCreador.ConstruirUrl(pCantidad, pConjunto);
            var response = iWebRequester.CrearConsulta(url);
            var responseParsed = iParser.FormatearRespuesta(response, pConjunto);
            return responseParsed;
        }

        public List<Categoria> ObtenerCategorias()
        {
            var url = "https://opentdb.com/api_category.php";
            var response = iWebRequester.CrearConsulta(url);
            List<Categoria> responseParsed = iParser.ParseResponseCategorias(response);
            return responseParsed;
        }
    }
}
