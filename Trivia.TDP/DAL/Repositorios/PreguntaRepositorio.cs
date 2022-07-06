using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;

namespace Trivia.TDP.DAL.Repositorios
{
    class PreguntaRepositorio : EFRepositorio<Pregunta, PruebaDBContext>, IPreguntaRepositorio
    {
        public PreguntaRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }

        public void agregarPreguntas(IList<Pregunta> pPreguntas)
        {
            foreach (var pregunta in pPreguntas)
            {
                var conjunto = iDbContext.ConjuntoPreguntas.First(z => z.Id == pregunta.ConjuntoPreguntas.Id);
                pregunta.ConjuntoPreguntas = conjunto;
                iDbContext.Preguntas.Add(pregunta);
            } 
        }
    }
}
