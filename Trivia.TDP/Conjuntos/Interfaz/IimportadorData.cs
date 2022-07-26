using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.Conjuntos.Interfaz
{
    public interface IimportadorData
    {
        List<Categoria> ObtenerCategorias();

        IList<Pregunta> ObtenerPreguntas(int pCantidad, ConjuntoPreguntas pConjunto);
    }
}
