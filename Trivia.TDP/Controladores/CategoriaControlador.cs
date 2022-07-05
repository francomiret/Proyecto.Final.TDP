using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class CategoriaControlador : ICategoriaControlador
    {
        public void agregarCategorias (IList<Categoria> pCategorias)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {

                    bUoW.CategoriaRepositorio.agregarCategorias(pCategorias);;
                    bUoW.Complete();
                }
            }
        }

        public IList<Categoria> obtenerCategorias()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {

                    IList<Categoria>  categorias = bUoW.CategoriaRepositorio.obtenerCategorias();
                    bUoW.Complete();
                    return categorias;
                }
            }
        }
    }
}
