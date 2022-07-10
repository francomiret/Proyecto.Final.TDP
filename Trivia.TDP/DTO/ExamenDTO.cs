using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DTO
{
    public class ExamenDTO
    {
		public int Examenid { get; set; }

		public DateTime FechaInicio { get; set; }

		public double TiempoUsado { get; set; }

		public double puntaje { get; set; }

		public int CantidadPreguntas { get; set; }
		public double tiempoDeResolucion { get; set; }

		public double factorTiempo { get; set; }

		public int cantRespCorrectas { get; set; }

		public virtual Usuario usuario { get; set; }

		public virtual Dificultad dificultad { get; set; }

		public virtual Categoria categoria { get; set; }

		public virtual IList<SesionPreguntaDTO> sesiones { get; set; }
	}
}
