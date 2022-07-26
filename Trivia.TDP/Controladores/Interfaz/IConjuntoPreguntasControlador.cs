using Dominio;
using System.Collections.Generic;
using Trivia.TDP.Conjuntos.Interfaz;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IConjuntoPreguntasControlador
    {
        void AgregarConjunto( ConjuntoPreguntas pConjunto );
        List<ConjuntoPreguntas> ObtenerConjuntos();

        IimportadorData obtenerImportador();
    }
}
