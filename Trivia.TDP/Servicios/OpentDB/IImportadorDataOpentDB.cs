using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Servicios.OpentDB
{
    interface IImportadorDataOpentDB
    {
        List<Categoria> ObtenerCategorias();

        IList<Pregunta> ObtenerPreguntas( int pCantidad, ConjuntoPreguntas pConjunto );
    }
}