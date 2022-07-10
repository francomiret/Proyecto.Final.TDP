using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Dominio
{
    public class SesionPregunta
    {
        public int Id { get; set; }
        public virtual int PreguntaId { get; set; }
        public virtual int? RespuestaSeleccionadaId { get; set; }

        public SesionPregunta(SesionPreguntaDTO pSesionPreguntaDTO)
        {
            this.Id = pSesionPreguntaDTO.Id;
            this.PreguntaId = pSesionPreguntaDTO.PreguntaID;
            this.RespuestaSeleccionadaId = pSesionPreguntaDTO.RespuestaSeleccionadaId;
        }

        public SesionPregunta()
        {

        }
    }
}
