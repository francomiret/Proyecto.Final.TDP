using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUsuarioRepositorio: IRepositorio<Usuario>
    {
        Usuario buscarPorLegajo(string legajo);
        IList<Usuario> buscar(Usuario usuario);
        void actualizar(Usuario usuario);

        void eliminar(String legajo);
    }
}
