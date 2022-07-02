using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DTO
{
    class UsuarioDTO
    {
		public int UsuarioId { get; set; }

		public String legajo { get; set; }

		public String nombre { get; set; }

		public String apellido { get; set; }

		public String contrasena { get; set; }

	}
}
