using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Dificultad
    {

        public Dificultad(int v1, string v, int v3)
        {
            this.DificultadId= v1;
            this.descripcion= v;
            this.peso= v3;
        }

        [Key]
        public int DificultadId { get; set; }
        public string descripcion { get; set; }
        public double peso { get; set; }
    }
}
