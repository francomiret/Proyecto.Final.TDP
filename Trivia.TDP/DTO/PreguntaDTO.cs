using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.DTO
{
    public class PreguntaDTO
    {
        public int PreguntaId { get; set; }

        public string descripcion { get; set; }

        public virtual Examen examen { get; set; }

        public virtual IList<Respuesta> listaRespuestas { get; set; }

        public virtual ConjuntoPreguntas ConjuntoPreguntas { get; set; }
    }
}
