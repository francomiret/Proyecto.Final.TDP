using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
