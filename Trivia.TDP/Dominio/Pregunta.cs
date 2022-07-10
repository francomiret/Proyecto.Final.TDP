using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
	public class Pregunta
	{

		public int PreguntaId { get; set; }

		public string descripcion { get; set; }

		public virtual IList<Respuesta> listaRespuestas { get; set; }

        public virtual ConjuntoPreguntas ConjuntoPreguntas { get; set; }

        public Pregunta(string pDescripcion, ConjuntoPreguntas pConjunto)
        {
            descripcion = pDescripcion;
            ConjuntoPreguntas = pConjunto;
        }

        public Pregunta() { }
	    }



}

