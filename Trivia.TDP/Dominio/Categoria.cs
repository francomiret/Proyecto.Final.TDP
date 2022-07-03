using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {

        public Categoria(int v1, String v2)
        {
            this.CategoriaId = v1;
            this.nombre = v2;
        }

        [Key]
        public int CategoriaId { get; set; }
        public String nombre { get; set; }

    }
}
