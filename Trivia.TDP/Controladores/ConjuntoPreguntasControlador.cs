using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Controladores.Errores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class ConjuntoPreguntasControlador : IConjuntoPreguntasControlador
    {
        public void agregarConjunto(ConjuntoPreguntas pConjunto)
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

        public List<ConjuntoPreguntas> obtenerConjuntos()
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    try
                    {
                        List<ConjuntoPreguntas> conuntoPreguntas = bUoW.ConjuntoPreguntasRepositorio.obtenerConjuntos();
                        bUoW.Complete();
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
