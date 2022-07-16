using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void AgregarCategorias( IList<Categoria> pCategorias );
        IList<Categoria> ObtenerCategorias();
    }
}
