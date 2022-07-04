using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IConjuntoPreguntasControlador
    {
        void agregarConjunto(ConjuntoPreguntas pConjunto);
        List<ConjuntoPreguntas> obtenerConjuntos();
    }
}
