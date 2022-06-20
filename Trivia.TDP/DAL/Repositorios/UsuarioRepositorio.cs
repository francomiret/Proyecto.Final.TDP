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
            return iDbContext.Usuarios.Where(u => u.legajo == legajo).FirstOrDefault();
        }

        public Usuario buscarPorNombre(string nombre)
        {
            return iDbContext.Usuarios.Where(u => u.nombre == nombre).FirstOrDefault();
        }

        public Usuario buscarPorApellido(string apellido)
        {
            return iDbContext.Usuarios.Where(u => u.apellido == apellido).FirstOrDefault();
        }
    }

}