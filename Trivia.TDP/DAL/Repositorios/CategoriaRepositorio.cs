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
                    var categoria = iDbContext.Categorias.Select(x => x.CategoriaId == pCategorias[i].CategoriaId);
                    if (categoria == null)
                        iDbContext.Categorias.Add(pCategorias[i]);
                }
                catch (InvalidOperationException e)
                {

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
