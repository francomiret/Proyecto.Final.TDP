using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IPreguntaControlador
    {
        void AgregarPreguntas( IList<Pregunta> pPreguntas );
        IList<Pregunta> ObtenerPreguntasPorCriterio( int? categoria, int? dificultad, int? conjunto );
        void EliminarPregunta( int preguntaId );
        void EliminarPreguntasConjunto( int? pConjuntoId );
    }
}
