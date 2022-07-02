using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
	public class Pregunta
	{
		[Key]
		public string PreguntaId { get; set; }

		private string descripcion { get; set; }

		public virtual Examen examen { get; set; }

		public virtual IList<Respuesta> listaRespuestas { get; set; }

        public ConjuntoPreguntas ConjuntoPreguntas { get; set; }

        public Pregunta(string pPregunta, ConjuntoPreguntas pConjunto)
        {
            PreguntaId = pPregunta;
            ConjuntoPreguntas = pConjunto;
        }

        public Pregunta() { }
	    }


}

