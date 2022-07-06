﻿using Dominio;
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
    class PreguntaControlador : IPreguntaControlador
    {
        public void agregarPreguntas(IList<Pregunta> pPreguntas)
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
    }
}
