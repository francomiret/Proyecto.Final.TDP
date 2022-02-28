using Administrador.Dominio;
using ProyectoFinalTDP.Administrador.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.Administrador.DAL.Repositorios
{

    class UsuarioRepositorio : EFRepositorio<Usuario, PruebaDBContext>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }
    }

}