using Dominio;
using System.Collections.Generic;
using System.Linq;
using Trivia.TDP.DAL.Interfaz;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class DificultadRepositorio : EFRepositorio<Dificultad, PruebaDBContext>, IDificultadRepositorio
    {
        public DificultadRepositorio( PruebaDBContext pContext ) : base(pContext)
        {

        }

        public List<Dificultad> ObtenerDificultades()
        {
            return iDbContext.Dificultades.ToList();
        }
    }
}
