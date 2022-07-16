using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IExamenRepositorio : IRepositorio<Examen>
    {
        void AgregarExamen( Examen pExamen );
        Examen MejorExamen( Usuario pUsuario );
        IList<Examen> Mejores10Examenes();
    }
}
