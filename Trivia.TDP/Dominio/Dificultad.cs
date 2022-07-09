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
        public int DificultadId { get; set; }
        public string descripcion { get; set; }
        public double peso { get; set; }
    }
}
