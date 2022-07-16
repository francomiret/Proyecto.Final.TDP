using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.DTO
{
    public class ConjuntoPreguntasDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual IList<Pregunta> Preguntas { get; set; }
        public void SetPreguntas(IList<Pregunta> pPreguntas)
        {
            this.Preguntas = pPreguntas;
        }
    }
}