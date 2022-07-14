using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IPreguntaRepositorio : IRepositorio<Pregunta>
    {
        void agregarPreguntas( IList<Pregunta> pPreguntas );

        IList<Pregunta> obtenerPreguntasPorCriterio( int? categoriaId, int? dificultadId, int? conjunto );

        void eliminarPregunta( int preguntaId );

        void eliminarPreguntasDeConjunto( int? conjuntoId );

        int respuestaCorrecta( int pPreguntaId );
    }
}
