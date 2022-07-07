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
                try
                {
                    var dificultad = this.iDbContext.Dificultades.First(c => c.DificultadId == pregunta.ConjuntoPreguntas.Dificultad.DificultadId);
                    pregunta.ConjuntoPreguntas.Dificultad = dificultad;
                }
                catch (InvalidOperationException e)
                {

                }
                try
                {
                    var categoria = this.iDbContext.Categorias.First(c => c.CategoriaId == pregunta.ConjuntoPreguntas.Categoria.CategoriaId);
                    pregunta.ConjuntoPreguntas.Categoria = categoria;
                }
                catch (InvalidOperationException e)
                {

                }
                iDbContext.Preguntas.Add(pregunta);
            } 
        }

        public IList<Pregunta> obtenerPreguntas()
        {
            var preguntas = iDbContext.Preguntas.ToList();
            return preguntas;
        }
    }
}
