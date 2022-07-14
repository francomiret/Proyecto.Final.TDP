using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IExamenControlador
    {
        Examen MejorExamen( Usuario usuario );
        IList<Examen> Mejores10Examenes();
    }
}
