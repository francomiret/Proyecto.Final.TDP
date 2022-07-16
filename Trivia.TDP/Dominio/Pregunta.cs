using System.Collections.Generic;

namespace Dominio
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
        public virtual IList<Respuesta> ListaRespuestas { get; set; }
        public virtual ConjuntoPreguntas ConjuntoPreguntas { get; set; }
    }
}

