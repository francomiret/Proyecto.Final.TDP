using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
	public class Respuesta
	{
		[Key]
		public int RespuestaId { get; set; }

		public string descripcion { get; set; }

		public bool correcta { get; set; }

		public virtual Pregunta Pregunta { get; set; }
	}

}

