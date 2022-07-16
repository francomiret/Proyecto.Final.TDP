using Dominio;
using System;
using System.Collections.Generic;
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
		public double TiempoDeResolucion { get; set; }
		public double FactorTiempo { get; set; }
		public virtual Usuario Usuario { get; set; }
		public virtual Dificultad Dificultad { get; set; }
		public virtual Categoria Categoria { get; set; }
		public virtual IList<SesionPreguntaDTO> Sesiones { get; set; }
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
			this.Categoria = examen.Categoria;
			this.Usuario = examen.Usuario;
			this.CantidadPreguntas = examen.CantidadPreguntas;
			this.Dificultad = examen.Dificultad;
			this.TiempoUsado = examen.TiempoUsado;
			this.TiempoDeResolucion = examen.TiempoDeResolucion;
			this.Puntaje = examen.Puntaje;
			this.Sesiones = ExamenDTO.SesionPreguntaDTO(examen.Sesiones);
		}
		public ExamenDTO ()
        {

        }
	}
}
