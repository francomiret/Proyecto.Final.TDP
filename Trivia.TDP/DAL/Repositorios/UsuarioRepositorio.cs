using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalTDP.DAL.Repositorios
{

    class UsuarioRepositorio : EFRepositorio<Usuario, PruebaDBContext>, IUsuarioRepositorio
    {
        public UsuarioRepositorio( PruebaDBContext pContext ) : base(pContext)
        {

        }

        public Usuario buscarPorLegajo( string legajo )
        {
            return iDbContext.Usuarios.Where(u => u.Legajo == legajo && u.Activo == true).FirstOrDefault();
        }


        public IList<Usuario> buscar( Usuario usuario )
        {
            if (usuario.Nombre == "" && usuario.Apellido == "" && usuario.Legajo == "" && usuario.Activo == null)
            {
                return iDbContext.Usuarios.ToList();

            } else
            {
                return iDbContext.Usuarios.Where(u => (
                (usuario.Nombre != null && u.Nombre == usuario.Nombre) ||
                (usuario.Apellido != null && u.Apellido == usuario.Apellido) ||
                (usuario.Legajo != null && u.Legajo == usuario.Legajo) ||
                (u.Activo == usuario.Activo))
                ).ToList();
            }

        }

        public void actualizar( Usuario usuario )
        {
            Usuario user = iDbContext.Usuarios.Where(u => u.Legajo == usuario.Legajo).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            iDbContext.Entry(user).CurrentValues.SetValues(usuario);
        }

        public void eliminar( String legajo )
        {
            Usuario user = buscarPorLegajo(legajo);
            if (user == null)
            {
                return;
            }
            Usuario deletedUser = user;
            deletedUser.Activo = false;
            iDbContext.Entry(user).CurrentValues.SetValues(deletedUser);
        }
    }

}