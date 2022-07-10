using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DTO
{
    public class SesionPreguntaDTO
    {
        public int Id { get; set; }
        public virtual int PreguntaID { get; set; }
        public virtual int? RespuestaSeleccionadaId { get; set; }

        public SesionPreguntaDTO(SesionPregunta pSesionPregunta)
        {
            this.Id = pSesionPregunta.Id;
            this.PreguntaID = pSesionPregunta.PreguntaId;
            this.RespuestaSeleccionadaId = pSesionPregunta.RespuestaSeleccionadaId;
        }
        public SesionPreguntaDTO()
        {

        }
    }
}
