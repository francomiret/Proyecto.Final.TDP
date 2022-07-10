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
    class ExamenControlador : IExamenControlador
    {
        public static int CantidadRespuestasCorrectas(Examen examen)
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

        public static double GetFactorDificultad(Examen examen)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.PreguntaRepositorio.Get(examen.sesiones.First().PreguntaId).ConjuntoPreguntas.Dificultad.peso;
                }
            }
        }

        public static void GuardarExamen(Examen examen)
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
    }
}
