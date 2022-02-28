using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUnitOfWork : IDisposable
    {
        IUsuarioRepositorio UsuarioRepositorio { get; }
        void Complete();
    }
}
