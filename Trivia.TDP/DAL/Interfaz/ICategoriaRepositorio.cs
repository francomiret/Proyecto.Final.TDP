using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void agregarCategorias( IList<Categoria> pCategorias );

        IList<Categoria> obtenerCategorias();
    }
}
