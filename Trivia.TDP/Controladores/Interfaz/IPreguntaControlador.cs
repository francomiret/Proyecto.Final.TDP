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
        void agregarPreguntas(IList<Pregunta> pPreguntas);

        IList<Pregunta> obtenerPreguntasPorCriterio(int? categoria, int? dificultad, int? conjunto);

        void eliminarPregunta(int preguntaId);

        void EliminarPreguntasConjunto(int? pConjuntoId);
        IList<Pregunta> obtenerPreguntasPorCriterio(object categoriaId, object dificultadId, object id);
    }
}
