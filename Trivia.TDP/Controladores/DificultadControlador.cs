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
    class DificultadControlador : IDificultadControlador
    {
        public List<Dificultad> ObtenerDificultades()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    List<Dificultad>  dificultades = bUoW.DificultadRepositorio.obtenerDificultades();
                    bUoW.Complete();
                    return dificultades;
                }
            }
        }
    }
}
