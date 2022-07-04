using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class DificultadRepositorio : EFRepositorio<Dificultad, PruebaDBContext>, IDificultadRepositorio
    {
        public DificultadRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }
            
        public List<Dificultad> obtenerDificultades()
        {
            return iDbContext.Dificultades.Select(u => u).ToList();
        }
    }
}
