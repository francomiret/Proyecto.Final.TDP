using ProyectoFinalTDP.DAL.Interfaz;
using Trivia.TDP.DAL.Interfaz;
using Trivia.TDP.DAL.Repositorios;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaDBContext pDbContext;
        private static volatile UnitOfWork cInstancia = null;
        private static readonly object cPadlock = new object();

        public UnitOfWork( PruebaDBContext pDbContex )
        {
            pDbContext = pDbContex;
            UsuarioRepositorio = new UsuarioRepositorio(pDbContext);
            UsuarioActivoRepositorio = new UsuarioActivoRepositorio(pDbContext);
            ConjuntoPreguntasRepositorio = new ConjuntoPreguntasRepositorio(pDbContext);
            DificultadRepositorio = new DificultadRepositorio(pDbContext);
            CategoriaRepositorio = new CategoriaRepositorio(pDbContext);
            PreguntaRepositorio = new PreguntaRepositorio(pDbContext);
            ExamenRepositorio = new ExamenRepositorio(pDbContext);

        }


        public IUsuarioRepositorio UsuarioRepositorio { get; private set; }

        public IUsuarioActivoRepositorio UsuarioActivoRepositorio { get; private set; }

        public IDificultadRepositorio DificultadRepositorio { get; private set; }
        public IConjuntoPreguntasRepositorio ConjuntoPreguntasRepositorio { get; private set; }

        public ICategoriaRepositorio CategoriaRepositorio { get; private set; }

        public IPreguntaRepositorio PreguntaRepositorio { get; private set; }

        public IExamenRepositorio ExamenRepositorio { get; private set; }
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
