using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Trivia.TDP.Controladores.Errores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Controladores
{
    class UsuarioControlador : IUsuarioControlador
    {
        private static Usuario usuarioAutenticado;

        public Usuario Autenticar( string legajo, string contrasena )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    // hasheo de contraseña.
                    var hash = new Rfc2898DeriveBytes(contrasena, 20);

                    Usuario usuario = bUoW.UsuarioRepositorio.buscarPorLegajo(legajo);
                    if (usuario == null)
                        throw new ErrorUsuarioNoExiste();
                    if (usuario.contrasena != hash.ToString())
                        throw new ErrorContrasenaIncorrecta();

                    bUoW.Complete();
                    usuarioAutenticado = usuario;
                    return usuarioAutenticado;
                }
            }
        }

        public bool CrearUsuario( Usuario usuario )
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

        public IList<Usuario> BuscarUsuario( Usuario usuario )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    IList<Usuario> usuarios = new List<Usuario>();
                    usuarios = bUoW.UsuarioRepositorio.buscar(usuario);
                    if (usuario == null)
                        throw new ErrorUsuarioNoExiste();
                    usuarios.Add(usuario);
                    bUoW.Complete();
                    return usuarios;
                }
            }
        }

        public void ActualizarUsuario( Usuario usuario )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.UsuarioRepositorio.actualizar(usuario);
                    bUoW.Complete();
                }
            }
        }

        public void EliminarUsuario( String legajo )
        {
            using (var bDbContext = new PruebaDBContext())
            {
                using (IUnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.UsuarioRepositorio.eliminar(legajo);
                    bUoW.Complete();
                }
            }
        }
    }

}
