using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IConjuntoPreguntasControlador
    {
        void AgregarConjunto( ConjuntoPreguntas pConjunto );
        List<ConjuntoPreguntas> ObtenerConjuntos();
    }
}
