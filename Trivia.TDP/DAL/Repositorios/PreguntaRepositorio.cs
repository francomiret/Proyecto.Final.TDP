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
                    var conjunto = this.iDbContext.ConjuntoPreguntas.First(c => c.Id == pregunta.ConjuntoPreguntas.Id);
                    if (conjunto != null)
                    {
                        pregunta.ConjuntoPreguntas = conjunto;
                    }
                    
                }
                catch (InvalidOperationException e)
                {

                }
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

        public IList<Pregunta> obtenerPreguntasPorCriterio(int? categoriaId, int? dificultadId, int? conjuntoId)
        {
            IList<Pregunta> preguntas = iDbContext.Preguntas.Include("ConjuntoPreguntas").Include("listaRespuestas")
            .Where(z =>
            ((categoriaId != null && z.ConjuntoPreguntas.Categoria.CategoriaId == categoriaId) ||
            (dificultadId != null && z.ConjuntoPreguntas.Dificultad.DificultadId == dificultadId)) ||
               z.ConjuntoPreguntas.Id == conjuntoId
            ).ToList();
            return preguntas;
        }

        public void eliminarPregunta(int preguntaId)
        {
            var pregunta = iDbContext.Preguntas.Include("listaRespuestas").SingleOrDefault(z => z.PreguntaId == preguntaId);
            if (pregunta != null)
            {
                IList<Respuesta> respuestas = iDbContext.Respuestas.Where(z => z.Pregunta.PreguntaId == preguntaId).ToList();
                if (respuestas != null)
                {
                    for (int i = 0; i < respuestas.Count; i++)
                    {
                        iDbContext.Respuestas.Remove(respuestas[i]);
                    }
                }
                iDbContext.Preguntas.Remove(pregunta);
            }
        }

        public void eliminarPreguntasDeConjunto(int? conjuntoId)
        {
            IList<Pregunta> preguntas = iDbContext.Preguntas.Where(z => z.ConjuntoPreguntas.Id == conjuntoId).ToList();

            if (preguntas != null)
            {
                foreach (var pregunta in preguntas)
                {
                    IList<Respuesta> respuestas = iDbContext.Respuestas.Where(z => z.Pregunta.PreguntaId == pregunta.PreguntaId).ToList();
                    if (respuestas != null)
                    {
                        for (int i = 0; i < respuestas.Count; i++)
                        {
                            iDbContext.Respuestas.Remove(respuestas[i]);
                        }
                    }
                    iDbContext.Preguntas.Remove(pregunta);
                }

            }
        }
    }
}
