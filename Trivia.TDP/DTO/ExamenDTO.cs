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

		public double Puntaje { get; set; }

		public double CantidadPreguntas { get; set; }
		public double tiempoDeResolucion { get; set; }

		public double factorTiempo { get; set; }

		public virtual Usuario usuario { get; set; }

		public virtual Dificultad dificultad { get; set; }

		public virtual Categoria categoria { get; set; }

		public virtual IList<SesionPreguntaDTO> sesiones { get; set; }

		private static IList<SesionPreguntaDTO> SesionPreguntaDTO(IList<SesionPregunta> pSesionesPregunta)
		{
			var sesionesPreguntaDTO = new List<SesionPreguntaDTO>();

			foreach (var sesionPregunta in pSesionesPregunta)
			{
				sesionesPreguntaDTO.Add(new SesionPreguntaDTO(sesionPregunta));
			}
			return sesionesPreguntaDTO;
		}

		public ExamenDTO(Examen examen)
		{
			this.FechaInicio = examen.FechaInicio;
			this.Examenid = examen.Examenid;
			this.categoria = examen.categoria;
			this.usuario = examen.usuario;
			this.CantidadPreguntas = examen.CantidadPreguntas;
			this.dificultad = examen.dificultad;
			this.TiempoUsado = examen.TiempoUsado;
			this.tiempoDeResolucion = examen.tiempoDeResolucion;
			this.Puntaje = examen.Puntaje;
			this.sesiones = ExamenDTO.SesionPreguntaDTO(examen.sesiones);
		}
		public ExamenDTO ()
        {

        }
	}
}
