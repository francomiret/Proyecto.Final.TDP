using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Respuesta
    {
        [Key]
        public int RespuestaId { get; set; }
        public string Descripcion { get; set; }
        public bool EsCorrecta { get; set; }
        public virtual Pregunta Pregunta { get; set; }
    }
}

