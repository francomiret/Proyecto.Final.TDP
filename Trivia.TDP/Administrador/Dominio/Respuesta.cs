using System.ComponentModel.DataAnnotations;

namespace Administrador.Dominio
{
	public class Respuesta
	{
		[Key]
		public int RespuestaId { get; set; }

		private string descripcion { get; set; }

		private bool correcta { get; set; }

		public virtual Pregunta Pregunta { get; set; }
	}

}

