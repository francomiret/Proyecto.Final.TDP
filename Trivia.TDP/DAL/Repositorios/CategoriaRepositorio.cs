using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;

namespace Trivia.TDP.DAL.Repositorios
{
    class CategoriaRepositorio: EFRepositorio<Categoria, PruebaDBContext>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }

        public void agregarCategorias(IList<Categoria> pCategorias)
        {

            for (var i = 0; i < pCategorias.Count; i++)
            {
                try
                {
                    iDbContext.Categorias.Add(pCategorias[i]);
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
                
                
            }

        }

        public IList<Categoria> obtenerCategorias()
        {
            var categorias = iDbContext.Categorias.Select(u => u).ToList();
            return categorias;
        }
    }
}
