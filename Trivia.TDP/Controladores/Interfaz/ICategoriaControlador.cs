using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface ICategoriaControlador
    {
        void AgregarCategorias( IList<Categoria> pCategorias );
        IList<Categoria> ObtenerCategorias();
    }
}
