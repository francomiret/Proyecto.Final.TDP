using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using System.Linq;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class ExamenControlador : IExamenControlador
    {
        public static int CantidadRespuestasCorrectas( Examen examen )
        {
            int cantidadRespuestasCorrectas = 0;
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (var sesion in examen.sesiones)
                    {
                        if (sesion.RespuestaSeleccionadaId != null)
                        {
                            int respuestaCorrectaId = bUoW.PreguntaRepositorio.respuestaCorrecta(sesion.PreguntaId);
                            if (respuestaCorrectaId == sesion.RespuestaSeleccionadaId)
                            {
                                cantidadRespuestasCorrectas += 1;
                            }

                        }

                    }
                }
            }
            return cantidadRespuestasCorrectas;
        }

        public static double GetFactorDificultad( Examen examen )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.PreguntaRepositorio.Get(examen.sesiones.First().PreguntaId).ConjuntoPreguntas.Dificultad.peso;
                }
            }
        }

        public static void GuardarExamen( Examen examen )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.ExamenRepositorio.AgregarExamen(examen);
                    bUoW.Complete();
                }
            }
        }

        public Examen MejorExamen( Usuario usuario )
        {
            Examen examen;
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    examen = bUoW.ExamenRepositorio.MejorExamen(usuario);
                }
            }
            return examen;
        }

        public IList<Examen> Mejores10Examenes()
        {
            IList<Examen> examenes;
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    examenes = bUoW.ExamenRepositorio.Mejores10Examenes();
                }
            }
            return examenes;
        }
    }
}
