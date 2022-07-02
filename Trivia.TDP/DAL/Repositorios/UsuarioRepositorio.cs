using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.DAL.Repositorios
{

    class UsuarioRepositorio : EFRepositorio<Usuario, PruebaDBContext>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }

        public Usuario buscarPorLegajo (string legajo)
        {
            return iDbContext.Usuarios.Where(u => u.legajo == legajo && u.active == true).FirstOrDefault();
        }


        public IList<Usuario> buscar(Usuario usuario)
        {
            return iDbContext.Usuarios.Where(u => (
            (usuario.nombre != null && u.nombre == usuario.nombre) ||
            (usuario.apellido != null && u.apellido == usuario.apellido) ||
            (usuario.legajo != null && u.legajo == usuario.legajo) ||
            (u.active == usuario.active))
            ).ToList();
        }

        public void actualizar(Usuario usuario)
        {
            Usuario user = iDbContext.Usuarios.Where(u => u.legajo == usuario.legajo).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            iDbContext.Entry(user).CurrentValues.SetValues(usuario);
        }

        public void eliminar(String legajo)
        {
            Usuario user = buscarPorLegajo(legajo);
            if (user == null)
            {
                return;
            }
            Usuario deletedUser = user;
            deletedUser.active = false;
            iDbContext.Entry(user).CurrentValues.SetValues(deletedUser);
        }
    }

}