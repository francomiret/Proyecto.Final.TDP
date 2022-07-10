using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trivia.TDP.Dominio;
using Trivia.TDP.DTO;

namespace Dominio
{
	public class Examen
	{
		[Key]
		public int Examenid { get; set; }

		public DateTime FechaInicio { get; set; }

		public double TiempoUsado { get; set; }

		public double Puntaje { get; set; }

		public double tiempoDeResolucion { get; set; }

		public double CantidadPreguntas { get { return this.sesiones.Count; } }

		public virtual Usuario usuario { get; set; }
		 
		public virtual Dificultad dificultad { get; set; }

		public virtual Categoria categoria { get; set; }

		public virtual IList<SesionPregunta> sesiones { get; set; }


		public double getPuntaje(double tfactorTiempo, int cantPreguntas, int cantRespCorrectas, Dificultad dificultad)
		{
			return 0;
		}

		public double FactorTiempo
		{
			get
			{
				double factor = TiempoUsado / CantidadPreguntas;

				if (factor < 5)
				{
					return 5;
				}
				else if (factor < 20)
				{
					return 3;
				}
				else return 1;
			}
		}

		private void CalcularPuntaje(int pCantRespCorrectas, double pFactorDificultad)
		{
			Puntaje = pCantRespCorrectas / this.CantidadPreguntas * pFactorDificultad * this.FactorTiempo;
		}

		public void Finalizar(int pCantidadRespuestasCorrectas, double pFactorDificultad)
		{
			this.TiempoUsado = (DateTime.Now - this.FechaInicio).TotalSeconds;
			this.CalcularPuntaje(pCantidadRespuestasCorrectas, pFactorDificultad);
		}

		private static IList<SesionPregunta> DTOaSesionPregunta(IList<SesionPreguntaDTO> pSesionPreguntas)
		{
			var dtos = new List<SesionPregunta>();
			foreach (var sesionPreg in pSesionPreguntas)
			{
				dtos.Add(new SesionPregunta(sesionPreg));
			}
			return dtos;
		}

		public Examen(ExamenDTO examenDTO)
        {
			this.FechaInicio = examenDTO.FechaInicio;
			this.Examenid = examenDTO.Examenid;
			this.categoria = examenDTO.categoria;
			this.usuario = examenDTO.usuario;
			this.dificultad = examenDTO.dificultad;
			this.TiempoUsado = examenDTO.TiempoUsado;
			this.tiempoDeResolucion = examenDTO.tiempoDeResolucion;
			this.Puntaje = examenDTO.Puntaje;
			this.sesiones = Examen.DTOaSesionPregunta(examenDTO.sesiones);
		}


	}

}

