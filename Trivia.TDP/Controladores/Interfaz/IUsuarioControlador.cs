using System.Collections.Generic;
using Dominio;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IUsuarioControlador
    {
        bool CrearUsuario( Usuario usuario );
        Usuario Autenticar( string legajo, string contrasena );
        Usuario ObtenerUsuarioAutenticado();
        void CerrarSesion();
        IList<Usuario> BuscarUsuario( Usuario usuario );
        void ActualizarUsuario( Usuario usuario );
        void EliminarUsuario( string legajo );
        string computeSHA256( string rawData );
    }
}
