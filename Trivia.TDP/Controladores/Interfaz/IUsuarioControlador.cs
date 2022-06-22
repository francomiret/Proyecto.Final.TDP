using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Trivia.TDP.Controladores.Interfaz
{
    interface IUsuarioControlador
    {
        Boolean crearUsuario(Usuario usuario);
        Usuario autenticar(string legajo, string contrasena);
        Usuario ObtenerUsuarioAutenticado();
        void CerrarSesion();
        IList<Usuario> buscarUsuario(Usuario usuario);

        void actualizarUsuario(Usuario usuario);

        void eliminarUsuario(String legajo);
    }
}
