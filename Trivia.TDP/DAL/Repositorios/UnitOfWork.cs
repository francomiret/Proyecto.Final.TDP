using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }


        public IUsuarioRepositorio UsuarioRepositorio { get; private set; }


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
