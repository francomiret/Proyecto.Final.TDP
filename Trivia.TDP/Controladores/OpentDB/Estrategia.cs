using Dominio;
using System;
using System.Collections.Generic;
using System.Net;

namespace Trivia.TDP.Controladores.OpentDB
{
    class Estrategia
    {
        ///Clase compuesta por 

        private readonly CreadorURLOpentDB iUrlCreador;
        private readonly OpentDBWebRequester iWebRequester;
        private readonly ResponseParser iParser;


        /// <summary>
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <returns></returns>
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

        public Estrategia() 
        {
            this.iUrlCreador = new CreadorURLOpentDB();
            this.iWebRequester = new OpentDBWebRequester();
            this.iParser = new ResponseParser();
        }
    }
}
