using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.Dominio
{
    public class SesionPregunta
    {
        public int Id { get; set; }
        public virtual Pregunta Pregunta { get; set; }
        public virtual Respuesta RespuestaSeleccionada { get; set; }
    }
}
