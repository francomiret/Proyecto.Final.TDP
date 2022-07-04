using Dominio;
using ProyectoFinalTDP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DAL.Migrations
{
    class UsuariosSeeder
    {
        public static void Seed(PruebaDBContext pContext)
        {
            IList<Usuario> bDefaultUsers = new List<Usuario>();

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 1,
                nombre = "Felipe",
                apellido = "Cestau",
                legajo = "123",
                contrasena = "123",
                esAdministrador = true,
                active = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 2,
                nombre = "Franco",
                apellido = "Miret",
                legajo = "34",
                contrasena = "34",
                esAdministrador = true,
                active = true
            });

            bDefaultUsers.Add(new Usuario()
            {
                UsuarioId = 3,
                nombre = "Rodrigo",
                apellido = "Mignola",
                legajo = "66",
                contrasena = "66",
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
