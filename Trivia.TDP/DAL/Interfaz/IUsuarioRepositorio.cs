using Dominio;
using System;
using System.Collections.Generic;

namespace ProyectoFinalTDP.DAL.Interfaz
{
    interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLegajo( string legajo );
        IList<Usuario> Buscar( Usuario usuario );
        void Actualizar( Usuario usuario );
        void Eliminar( String legajo );
    }
}
