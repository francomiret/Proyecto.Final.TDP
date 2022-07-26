using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using System.Linq;
using Trivia.TDP.DAL.Interfaz;

namespace Trivia.TDP.DAL.Repositorios
{
    class CategoriaRepositorio : EFRepositorio<Categoria, PruebaDBContext>, ICategoriaRepositorio
    {
        public CategoriaRepositorio( PruebaDBContext pContext ) : base(pContext)
        {

        }

        public void AgregarCategorias( IList<Categoria> pCategorias )
        {
            var categorias = this.iDbContext.Categorias.Select(z => z.CategoriaId).ToList(); ;
            if (categorias != null)
            {
                for (var i = 0; i < pCategorias.Count; i++)
                {
                    iDbContext.Categorias.Add(pCategorias[i]);
                }
            }
        }

        public IList<Categoria> ObtenerCategorias()
        {
            IList<Categoria> categorias = iDbContext.Categorias.ToList();
            return categorias;
        }
    }
}
