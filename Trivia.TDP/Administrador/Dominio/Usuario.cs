using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Administrador.Dominio
{
	public class Usuario
	{
		[Key]
		public int UsuarioId { get; set; }

		private string dni { get; set; }

		private string nombre { get; set; }

		private string apellido { get; set; }

		private TimeSpan fechaNacimiento { get; set; }

		public virtual IList<Examen> listaExamenes { get; set; }

}

}

