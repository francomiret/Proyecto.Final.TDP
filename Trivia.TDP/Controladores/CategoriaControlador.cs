using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class CategoriaControlador : ICategoriaControlador
    {
        public void AgregarCategorias (IList<Categoria> pCategorias)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.CategoriaRepositorio.agregarCategorias(pCategorias);
                    bUoW.Complete();
                }
            }
        }

        public IList<Categoria> ObtenerCategorias()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    IList<Categoria>  categorias = bUoW.CategoriaRepositorio.obtenerCategorias();
                    return categorias;
                }
            }
        }
    }
}
