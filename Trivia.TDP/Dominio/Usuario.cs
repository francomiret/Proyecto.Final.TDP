using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public bool EsAdministrador { get; set; }
        public bool? Activo { get; set; }
        public virtual IList<Examen> ListaExamenes { get; set; }
    }
}

