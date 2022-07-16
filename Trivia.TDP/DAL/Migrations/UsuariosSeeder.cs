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
                Nombre = "Felipe",
                Apellido = "Cestau",
                Legajo = "123",
                Contrasena = usuarioControlador.computeSHA256("123"),
                EsAdministrador = true,
                Activo = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 2,
                Nombre = "Franco",
                Apellido = "Miret",
                Legajo = "34",
                Contrasena = usuarioControlador.computeSHA256("34"),
                EsAdministrador = true,
                Activo = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 3,
                Nombre = "Rodrigo",
                Apellido = "Mignola",
                Legajo = "66",
                Contrasena = usuarioControlador.computeSHA256("66"),
                EsAdministrador = true,
                Activo = true
            });

            foreach (Usuario bUser in bDefaultUsers)
            {
                if (pContext.Set<Usuario>().Find(bUser.UsuarioId) == null)
                    pContext.Set<Usuario>().Add(bUser);
            }
        }
    }
}
