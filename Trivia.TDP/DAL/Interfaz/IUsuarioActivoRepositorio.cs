using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IUsuarioActivoRepositorio : IRepositorio<UsuarioActivo>
    {

        Usuario obtenerUsuario();
        void eliminar();
    }
}
