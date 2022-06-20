using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Controladores.Errores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class UsuarioControlador : IUsuarioControlador
    {
        private static Usuario usuarioAutenticado;
        public Usuario autenticar(string legajo, string contrasena)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario usuario = bUoW.UsuarioRepositorio.buscarPorLegajo(legajo);
                    if (usuario == null)
                        throw new ErrorUsuarioNoExiste();
                    if (usuario.contrasena != contrasena)
                        throw new ErrorContrasenaIncorrecta();

                    bUoW.Complete();
                    usuarioAutenticado = usuario;
                    return usuarioAutenticado;
                }
            }
        }

        public Boolean crearUsuario(Usuario usuario)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    if (bUoW.UsuarioRepositorio.buscarPorLegajo(usuario.legajo) != null)
                        throw new ErrorUsuarioYaExiste();

                    bUoW.UsuarioRepositorio.Add(usuario);

                    bUoW.Complete();
                    return true;
                }
            }
        }

        public Usuario ObtenerUsuarioAutenticado()
        {
            if (usuarioAutenticado == null)
                throw new ErrorUsuarioNoAutenticado();

            return usuarioAutenticado;
        }

        public void CerrarSesion()
        {
            usuarioAutenticado = null;
        }

        public IList<Usuario> buscarUsuario(String legajo, String nombre)
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    IList<Usuario> usuarios = new List<Usuario>();
                    if (legajo != null)
                    {
                        Usuario usuario = bUoW.UsuarioRepositorio.buscarPorLegajo(legajo);
                        if (usuario == null)
                            throw new ErrorUsuarioNoExiste();
                        usuarios.Add(usuario);
                        return usuarios;

                    } else
                    {
                        if (nombre != null)
                        {
                            Usuario usuario = bUoW.UsuarioRepositorio.buscarPorNombre(nombre);
                            if (usuario == null)
                                throw new ErrorUsuarioNoExiste();
                            usuarios.Add(usuario);
                            return usuarios;
                        }                                             
                    }
                    bUoW.Complete();
                    return null;
                }
            }
        }
    }

}
