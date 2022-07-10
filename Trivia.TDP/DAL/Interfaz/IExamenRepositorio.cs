using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IExamenRepositorio : IRepositorio<Examen>
    {
        void AgregarExamen(Examen pExamen);
    }
}
