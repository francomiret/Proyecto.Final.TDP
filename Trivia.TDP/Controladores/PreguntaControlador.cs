using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class PreguntaControlador : IPreguntaControlador
    {
        public void AgregarPreguntas( IList<Pregunta> pPreguntas )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.PreguntaRepositorio.agregarPreguntas(pPreguntas);
                    bUoW.Complete();
                }
            }
        }

        public IList<Pregunta> ObtenerPreguntasPorCriterio( int? categoria, int? dificultad, int? conjunto )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    try
                    {
                        IList<Pregunta> preguntas = bUoW.PreguntaRepositorio.obtenerPreguntasPorCriterio(categoria, dificultad, conjunto);
                        return preguntas;
                    }
                    catch (DataNotFound e)
                    {
                        throw new DataNotFound();
                    }
                }
            }
        }

        public void EliminarPregunta( int preguntaId )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    try
                    {
                        bUoW.PreguntaRepositorio.eliminarPregunta(preguntaId);
                        bUoW.Complete();
                    }
                    catch (DataNotFound e)
                    {
                        throw new DataNotFound();
                    }
                }
            }
        }

        public void EliminarPreguntasConjunto( int? pConjuntoId )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.PreguntaRepositorio.eliminarPreguntasDeConjunto(pConjuntoId);
                    bUoW.Complete();
                }
            }
        }


    }
}
