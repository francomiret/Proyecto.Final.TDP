using System;
using Trivia.TDP.DAL.Interfaz;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUnitOfWork : IDisposable
    {
        IUsuarioRepositorio UsuarioRepositorio { get; }

        IUsuarioActivoRepositorio UsuarioActivoRepositorio { get; }
        IDificultadRepositorio DificultadRepositorio { get; }
        IConjuntoPreguntasRepositorio ConjuntoPreguntasRepositorio { get; }

        ICategoriaRepositorio CategoriaRepositorio { get; }

        IPreguntaRepositorio PreguntaRepositorio { get; }

        IExamenRepositorio ExamenRepositorio { get; }
        void Complete();

    }
}
