using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IExamenControlador
    {
        Examen MejorExamen(Usuario usuario);

        IList<Examen> Mejores10Examenes();
    }
}
