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
    }
}
