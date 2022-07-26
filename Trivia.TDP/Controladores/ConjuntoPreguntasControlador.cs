using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System.Collections.Generic;
using Trivia.TDP.Conjuntos.Interfaz;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Controladores.OpentDB;

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
                        List<ConjuntoPreguntas> conuntoPreguntas = bUoW.ConjuntoPreguntasRepositorio.ObtenerConjuntos();
                        return conuntoPreguntas;
                    }
                    catch (DataNotFound)
                    {
                        throw new DataNotFound();
                    }
                }
            }
        }

        //TODO: A futuro este metodo obtiene el importador de un conjunto determinado.
        // Como actualmente solo soportamos OpenTDB devolvemos ese.
        public IimportadorData obtenerImportador()
        {
            return new ImportadorDataOpentDB();
        }

    }
}
