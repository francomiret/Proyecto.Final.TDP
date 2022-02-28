using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Administrador.Dominio
{
	public class Pregunta
	{
		[Key]
		public int PreguntaId { get; set; }

		private string descripcion { get; set; }

		public virtual Examen examen { get; set; }

		public virtual IList<Respuesta> listaRespuestas { get; set; }

	}

}

