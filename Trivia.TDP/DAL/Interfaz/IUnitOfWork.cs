using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUnitOfWork : IDisposable
    {
        IUsuarioRepositorio UsuarioRepositorio { get; }

        IDificultadRepositorio DificultadRepositorio { get; }
        IConjuntoPreguntasRepositorio ConjuntoPreguntasRepositorio { get; }

        ICategoriaRepositorio CategoriaRepositorio { get; }

        IPreguntaRepositorio PreguntaRepositorio { get; }

        IExamenRepositorio ExamenRepositorio { get; }
        void Complete();

    }
}
