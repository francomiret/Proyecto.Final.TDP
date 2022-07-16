namespace Trivia.TDP.DTO
{
    class UsuarioDTO
    {
        public bool EsAdministrador;
        public int UsuarioId { get; set; }
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public bool? Activo { get; set; }
    }
}
