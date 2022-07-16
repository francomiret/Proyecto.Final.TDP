using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.DAL.Interfaz;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DAL.Repositorios
{
    class UsuarioActivoRepositorio : EFRepositorio<UsuarioActivo, PruebaDBContext>, IUsuarioActivoRepositorio
    {
        public UsuarioActivoRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }

        public Usuario ObtenerUsuario()
        {
            UsuarioActivo user = iDbContext.UsuariosActivos.First();
            Usuario usuario = null;
            if (user != null)
            {
                usuario = iDbContext.Usuarios.First(z => z.UsuarioId == user.UsuarioId);
            }
            return usuario;
        }

        public void Eliminar()
        {
            iDbContext.UsuariosActivos.RemoveRange(iDbContext.UsuariosActivos);
        }


    }
}
