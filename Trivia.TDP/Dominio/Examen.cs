using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

		public int CantidadPreguntas { get; set; }
		public int cantRespCorrectas { get; set; }

		public virtual Usuario usuario { get; set; }
		 
		public virtual Dificultad dificultad { get; set; }

		public virtual Categoria categoria { get; set; }

		public virtual IList<Pregunta> listaPreguntas { get; set; }

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
			this.Puntaje = pCantRespCorrectas / this.CantidadPreguntas * pFactorDificultad * this.FactorTiempo;
		}

		public void Finalizar(int pCantidadRespuestasCorrectas, double pFactorDificultad)
		{
			this.TiempoUsado = (DateTime.Now - this.FechaInicio).TotalSeconds;
			this.CalcularPuntaje(pCantidadRespuestasCorrectas, pFactorDificultad);
		}

	}

}

