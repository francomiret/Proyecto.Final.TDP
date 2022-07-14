using Dominio;
using ProyectoFinalTDP.DAL;
using System.Collections.Generic;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.DAL.Migrations
{
    class UsuariosSeeder
    {

        public static void Seed( PruebaDBContext pContext )
        {
            IList<Usuario> bDefaultUsers = new List<Usuario>();

            IUsuarioControlador usuarioControlador = new UsuarioControlador();

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 1,
                nombre = "Felipe",
                apellido = "Cestau",
                legajo = "123",
                contrasena = usuarioControlador.computeSHA256("123"),
                esAdministrador = true,
                active = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 2,
                nombre = "Franco",
                apellido = "Miret",
                legajo = "34",
                contrasena = usuarioControlador.computeSHA256("34"),
                esAdministrador = true,
                active = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 3,
                nombre = "Rodrigo",
                apellido = "Mignola",
                legajo = "66",
                contrasena = usuarioControlador.computeSHA256("66"),
                esAdministrador = true,
                active = true
            });

            foreach (Usuario bUser in bDefaultUsers)
            {
                if (pContext.Set<Usuario>().Find(bUser.UsuarioId) == null)
                    pContext.Set<Usuario>().Add(bUser);
            }
        }
    }
}
