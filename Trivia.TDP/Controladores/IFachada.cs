using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Controladores
{
    interface IFachada
    {
        string ActivarUsuario( UsuarioDTO pUsuarioDTO );
        IList<PreguntaDTO> AgregarPreguntas( ConjuntoPreguntasDTO pConjuntoDTO );
        IList<PreguntaDTO> AgregarPreguntas( DificultadDTO pDificultadDTO, CategoriaDTO pCategoriaDTO, int pCant );
        UsuarioDTO Autenticar( string legajo, string contrasena );
        IList<UsuarioDTO> BuscarUsuarios( UsuarioDTO pUsuarioDTO );
        void CerrarSesion();
        bool CrearUsuario( UsuarioDTO pUsuarioDTO );
        void EliminarPregunta( string pPreguntaId );
        string EliminarUsuario( DataGridViewRow pSelectedRow );
        ExamenDTO IniciarExamen( ConjuntoPreguntasDTO pConjunto, IList<PreguntaDTO> preguntas );
        IList<ExamenDTO> Mejores10Examenes();
        ExamenDTO MejorExamenUsuario();
        IList<CategoriaDTO> ObtenerCategorias();
        IList<ConjuntoPreguntasDTO> ObtenerConjuntoPreguntas();
        IList<DificultadDTO> ObtenerDificultades();
        IList<PreguntaDTO> ObtenerPreguntasPorCriterio( int? pCategoriaId, int? pDificultadId, int? pConjuntoPreguntasId );
        UsuarioDTO ObtenerUsuarioAutenticado();
        ExamenDTO FinalizarExamen( ExamenDTO examen );
    }
}