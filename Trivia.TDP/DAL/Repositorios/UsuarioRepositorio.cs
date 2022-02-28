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
    }

}