using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class ConjuntoPreguntasControlador : IConjuntoPreguntasControlador
    {
        public void AgregarConjunto( ConjuntoPreguntas pConjunto )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.ConjuntoPreguntasRepositorio.AgregarConjunto(pConjunto);
                    bUoW.Complete();
                }
            }
        }

        public List<ConjuntoPreguntas> ObtenerConjuntos()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    try
                    {
                        List<ConjuntoPreguntas> conuntoPreguntas = bUoW.ConjuntoPreguntasRepositorio.obtenerConjuntos();
                        return conuntoPreguntas;
                    }
                    catch (DataNotFound e)
                    {
                        throw new DataNotFound();
                    }
                }
            }
        }

    }
}
