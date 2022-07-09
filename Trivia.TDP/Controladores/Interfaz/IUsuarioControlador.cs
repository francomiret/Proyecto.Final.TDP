using System;
using System.Collections.Generic;
using Dominio;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Controladores.Interfaz
{
    interface IUsuarioControlador
    {
        Boolean CrearUsuario( Usuario usuario );

        Usuario Autenticar( string legajo, string contrasena );

        Usuario ObtenerUsuarioAutenticado();

        void CerrarSesion();

        IList<Usuario> BuscarUsuario( Usuario usuario );

        void ActualizarUsuario( Usuario usuario );

        void EliminarUsuario( String legajo );
    }
}
