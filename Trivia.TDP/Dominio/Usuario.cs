using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
	public class Usuario
	{
		[Key]
		public int UsuarioId { get; set; }

		public String legajo { get; set; }

		public String nombre { get; set; }

		public String apellido { get; set; }

		public String contrasena { get; set; }

		public Boolean esAdministrador { get; set; }

		public Boolean active { get; set; }

		public virtual IList<Examen> listaExamenes { get; set; }
       
    }

}

