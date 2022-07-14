using Dominio;
using System.Collections.Generic;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IConjuntoPreguntasRepositorio : IRepositorio<ConjuntoPreguntas>
    {
        void AgregarConjunto( ConjuntoPreguntas pConjunto );

        List<ConjuntoPreguntas> obtenerConjuntos();

    }
}
