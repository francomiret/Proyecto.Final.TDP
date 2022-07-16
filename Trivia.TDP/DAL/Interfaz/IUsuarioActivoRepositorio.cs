using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using Trivia.TDP.Dominio;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IUsuarioActivoRepositorio : IRepositorio<UsuarioActivo>
    {
        Usuario ObtenerUsuario();
        void Eliminar();
    }
}
