using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;

namespace Trivia.TDP.DAL.Repositorios
{
    class ExamenRepositorio : EFRepositorio<Examen, PruebaDBContext>, IExamenRepositorio
    {
        public ExamenRepositorio(PruebaDBContext pContext) : base(pContext)
        {
            
        }

        public void AgregarExamen(Examen pExamen)
        {
            iDbContext.Examenes.Add(pExamen);
        }

        public Examen MejorExamen(Usuario pUsuario)
        {
            return iDbContext.Examenes.Include("sesiones").Include("categoria").Include("dificultad").Include("usuario").OrderByDescending(p => p.Puntaje).First(e => e.usuario.legajo == pUsuario.legajo);
        }

        public IList<Examen> Mejores10Examenes()
        {
            return iDbContext.Examenes.Include("sesiones").Include("categoria").Include("dificultad").Include("usuario").OrderByDescending(p => p.Puntaje).Take(10).ToList();
        }

    }
}
