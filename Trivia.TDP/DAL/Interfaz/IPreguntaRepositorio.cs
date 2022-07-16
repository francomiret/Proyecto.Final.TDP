using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IPreguntaRepositorio : IRepositorio<Pregunta>
    {
        void AgregarPreguntas( IList<Pregunta> pPreguntas );
        IList<Pregunta> ObtenerPreguntasPorCriterio( int? categoriaId, int? dificultadId, int? conjunto );
        void EliminarPregunta( int preguntaId );
        void EliminarPreguntasDeConjunto( int? conjuntoId );
        int RespuestaCorrecta( int pPreguntaId );
    }
}
