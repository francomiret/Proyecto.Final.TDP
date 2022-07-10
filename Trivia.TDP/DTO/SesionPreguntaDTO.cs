using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DTO
{
    public class SesionPreguntaDTO
    {
        public int Id { get; set; }
        public virtual int PreguntaID { get; set; }
        public virtual int? RespuestaSeleccionadaId { get; set; }
    }
}
