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
        /// <summary>
        /// Calcula la cantidad de respuestas correctas
        /// </summary>
        /// <param name="examen">Examen</param>
        /// <returns>Cantidad de respuestas correctas</returns>
        public static int CantidadRespuestasCorrectas( Examen examen )
        {
            int cantidadRespuestasCorrectas = 0;
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {

                    foreach (var sesion in examen.Sesiones)
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

        /// <summary>
        /// Calcular el factor dificultad del examen
        /// </summary>
        /// <param name="examen">Examen</param>
        /// <returns>Factor dificultad</returns>
        public static double GetFactorDificultad( Examen examen )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.PreguntaRepositorio.Get(examen.Sesiones.First().PreguntaId).ConjuntoPreguntas.Dificultad.Peso;
                }
            }
        }

        /// <summary>
        /// Guarda una examen
        /// </summary>
        /// <param name="examen">Examen a guardar</param>
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

        /// <summary>
        /// Busca el examen con mayor puntaje de un usuario.
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Mejor examen</returns>
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

        /// <summary>
        /// Busca los 10 examenes con mayor puntaje.
        /// </summary>
        /// <returns>Lista de examenes</returns>
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
