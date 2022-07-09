using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class DificultadControlador : IDificultadControlador
    {
        public List<Dificultad> ObtenerDificultades()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    List<Dificultad> dificultades = bUoW.DificultadRepositorio.obtenerDificultades();
                    return dificultades;
                }
            }
        }
    }
}
