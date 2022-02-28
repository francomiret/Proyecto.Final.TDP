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

        

        private UnitOfWork()
        {

            this.pDbContext = new PruebaDBContext();
            this.UsuarioRepositorio = new UsuarioRepositorio(pDbContext);
       
        }

        public IUsuarioRepositorio UsuarioRepositorio { get; private set; }

        public static UnitOfWork Instancia
        {
            get
            {
                if (cInstancia == null)
                {
                    lock (cPadlock)
                    {
                        if (cInstancia == null)
                        {
                            cInstancia = new UnitOfWork();
                        }
                    }
                }
                return cInstancia;
            }
        }

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
