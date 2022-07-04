using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IConjuntoPreguntasRepositorio: IRepositorio<ConjuntoPreguntas>
    {
        void AgregarConjunto(ConjuntoPreguntas pConjunto);

        List<ConjuntoPreguntas> obtenerConjuntos();
    }
}
