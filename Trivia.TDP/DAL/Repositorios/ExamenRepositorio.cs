using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using System.Linq;
using Trivia.TDP.DAL.Interfaz;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DAL.Repositorios
{
    class ExamenRepositorio : EFRepositorio<Examen, PruebaDBContext>, IExamenRepositorio
    {
        public ExamenRepositorio( PruebaDBContext pContext ) : base(pContext)
        {
        }

        public void AgregarExamen( Examen pExamen )
        {
            iDbContext.Examenes.Add(pExamen);
        }

        public Examen MejorExamen( Usuario pUsuario )
        {
            var examenes = iDbContext.Examenes?.Include("sesiones")?.Include("categoria")?.Include("dificultad")?.Include("usuario").ToList();
            if (examenes.Count != 0)
            {
                return examenes.OrderByDescending(p => p.Puntaje)?.First(e => e.Usuario.Legajo == pUsuario.Legajo);
            }
            else
            {
                return new Examen() { Sesiones = new List<SesionPregunta>() };
            }
        }

        public IList<Examen> Mejores10Examenes()
        {
            return iDbContext.Examenes?.Include("sesiones").Include("categoria").Include("dificultad").Include("usuario").OrderByDescending(p => p.Puntaje)?.Take(10).ToList();
        }
    }
}
