using System;

namespace Trivia.TDP.DTO
{
    class UsuarioDTO
    {
        public bool esAdministrador;

        public int UsuarioId { get; set; }

        public String legajo { get; set; }

        public String nombre { get; set; }

        public String apellido { get; set; }

        public String contrasena { get; set; }

        public Boolean active { get; set; }
    }
}
