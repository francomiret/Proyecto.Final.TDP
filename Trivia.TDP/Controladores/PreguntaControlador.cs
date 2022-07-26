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
                    bUoW.PreguntaRepositorio.AgregarPreguntas(pPreguntas);
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
                    IList<Pregunta> preguntas = bUoW.PreguntaRepositorio.ObtenerPreguntasPorCriterio(categoria, dificultad, conjunto);
                    return preguntas;
                }
            }
        }

        public void EliminarPregunta( int preguntaId )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.PreguntaRepositorio.EliminarPregunta(preguntaId);
                    bUoW.Complete();
                }
            }
        }

        public void EliminarPreguntasConjunto( int? pConjuntoId )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.PreguntaRepositorio.EliminarPreguntasDeConjunto(pConjuntoId);
                    bUoW.Complete();
                }
            }
        }


    }
}
