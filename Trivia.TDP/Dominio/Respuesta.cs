using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
	public class Respuesta
	{
		[Key]
		public int RespuestaId { get; set; }

		private string descripcion { get; set; }

		private bool correcta { get; set; }

		public virtual Pregunta Pregunta { get; set; }

		public Respuesta(string pTexto, bool pCorrecta)
		{
			descripcion = pTexto;
			correcta = pCorrecta;
		}

		public Respuesta() { }
	}

}

