using Dominio;
using ProyectoFinalTDP.DAL;
using ProyectoFinalTDP.DAL.Interfaz;
using ProyectoFinalTDP.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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

                    Usuario usuario = bUoW.UsuarioRepositorio.buscarPorLegajo(legajo);

                    if (usuario == null)
                        throw new ErrorUsuarioNoExiste();
                    if (usuario.contrasena != computeSHA256(contrasena))
                        throw new ErrorContrasenaIncorrecta();

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

                    usuario.contrasena = computeSHA256(usuario.contrasena);
                    bUoW.UsuarioRepositorio.Add(usuario);

                    bUoW.Complete();
                    return true;
                }
            }
        }

        public string computeSHA256( string rawData )
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
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
