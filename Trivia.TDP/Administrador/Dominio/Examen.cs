using Administrador.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Administrador.Dominio
{
	public class Examen
	{
		[Key]
		public int Examenid { get; set; }

		private TimeSpan fechaInicio { get; set; }

		private TimeSpan fechaFin { get; set; }

		private double puntaje { get; set; }

		private double tiempoDeResolucion { get; set; }

		private int cantPreguntas { get; set; }

		private double factorTiempo { get; set; }

		private int cantRespCorrectas { get; set; }

		public virtual Usuario usuario { get; set; }
		 
		public virtual Dificultad dificultad { get; set; }

		public virtual Categoria categoria { get; set; }

		public virtual IList<Pregunta> listaPreguntas { get; set; }

		public double getPuntaje(double tfactorTiempo, int cantPreguntas, int cantRespCorrectas, Dificultad dificultad)
		{
			return 0;
		}

		public double setFactorTiempo(System.DateTime tiempoDeResolucion, int cantPreguntas)
		{
			return 0;
		}

		public void GetPreguntas(string categoria, string dificultad, string tipo)
		{

		}

		public void setTiempoDeResolucion(System.DateTime fechaInicio, System.DateTime fechaFin)
		{

		}

		public void SetCantRespCorrectas()
		{

		}

	}

}

