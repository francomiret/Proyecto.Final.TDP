using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;
using Trivia.TDP.DAL.Repositorios;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaDBContext pDbContext;
        private static volatile UnitOfWork cInstancia = null;
        private static readonly object cPadlock = new object();

        public UnitOfWork(PruebaDBContext pDbContex)
        {
            this.pDbContext = pDbContex;
            this.UsuarioRepositorio = new UsuarioRepositorio(pDbContext);
            this.ConjuntoPreguntasRepositorio = new ConjuntoPreguntasRepositorio(pDbContext);
            this.DificultadRepositorio = new DificultadRepositorio(pDbContext);
            this.CategoriaRepositorio = new CategoriaRepositorio(pDbContext);

        }


        public IUsuarioRepositorio UsuarioRepositorio { get; private set; }

        public IDificultadRepositorio DificultadRepositorio { get; private set; }
        public IConjuntoPreguntasRepositorio ConjuntoPreguntasRepositorio { get; private set; }

        public ICategoriaRepositorio CategoriaRepositorio { get; private set; }

        public void Complete()
        {
            this.pDbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.pDbContext.Dispose();
        }
    }
}
