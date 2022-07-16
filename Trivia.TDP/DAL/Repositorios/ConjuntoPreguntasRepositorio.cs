using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
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
            try
            {
                var dificultad = this.iDbContext.Dificultades.First(c => c.DificultadId == pConjunto.Dificultad.DificultadId);
                pConjunto.Dificultad = dificultad;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            try
            {
                var categoria = this.iDbContext.Categorias.First(c => c.CategoriaId == pConjunto.Categoria.CategoriaId);
                pConjunto.Categoria = categoria;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            iDbContext.ConjuntoPreguntas.Add(pConjunto);

        }

        public List<ConjuntoPreguntas> ObtenerConjuntos()
        {
            var conjuntos = iDbContext.ConjuntoPreguntas.Include("Dificultad").Include("Categoria").ToList();
            return conjuntos;
        }

    }
}
