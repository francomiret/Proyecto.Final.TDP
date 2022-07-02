using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DTO
{
    class RespuestaDTO
    {
        public int RespuestaId { get; set; }

        public string descripcion { get; set; }

        public bool correcta { get; set; }
    }

}
