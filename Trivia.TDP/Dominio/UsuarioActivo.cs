using System.ComponentModel.DataAnnotations;

namespace Trivia.TDP.Dominio
{
    public class UsuarioActivo
    {
        /// <summary>
        /// Id de la fila
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id del usuario autenticado
        /// </summary>
        public int UsuarioId { get; set; }
    }
}
