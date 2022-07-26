using System.Collections.Generic;
using Trivia.TDP.Conjuntos.Interfaz;

namespace Dominio
{
    public class ConjuntoPreguntas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; } = 20;
        public virtual Dificultad Dificultad { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual IList<Pregunta> Preguntas { get; set; }
        public void setPreguntas( IList<Pregunta> pPreguntas )
        {
            this.Preguntas = pPreguntas;
        }
    }
}