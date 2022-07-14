using Dominio;
using System;
using System.Collections.Generic;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario buscarPorLegajo( string legajo );
        IList<Usuario> buscar( Usuario usuario );
        void actualizar( Usuario usuario );

        void eliminar( String legajo );
    }
}
