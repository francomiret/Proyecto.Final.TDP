using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class ConjuntoPreguntasRepositorio : EFRepositorio<ConjuntoPreguntas, PruebaDBContext>, IConjuntoPreguntasRepositorio
    {
        public ConjuntoPreguntasRepositorio( PruebaDBContext pContext ) : base(pContext)
        {

        }

        public void AgregarConjunto( ConjuntoPreguntas pConjunto )
        {
            var dificultad = this.iDbContext.Dificultades.First(c => c.DificultadId == pConjunto.Dificultad.DificultadId);
            pConjunto.Dificultad = dificultad;

            var categoria = this.iDbContext.Categorias.First(c => c.CategoriaId == pConjunto.Categoria.CategoriaId);
            pConjunto.Categoria = categoria;

            iDbContext.ConjuntoPreguntas.Add(pConjunto);

        }

        public List<ConjuntoPreguntas> ObtenerConjuntos()
        {
            var conjuntos = iDbContext.ConjuntoPreguntas.Include("Dificultad").Include("Categoria").ToList();
            return conjuntos;
        }

    }
}
