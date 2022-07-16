using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.DTO
{
    public class PreguntaDTO
    {
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
        public virtual IList<Respuesta> ListaRespuestas { get; set; }
        public virtual ConjuntoPreguntas ConjuntoPreguntas { get; set; }
    }
}
