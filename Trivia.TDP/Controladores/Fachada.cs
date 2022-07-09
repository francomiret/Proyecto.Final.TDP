using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Controladores.OpentDB;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Controladores
{
    class Fachada
    {
        private IImportadorDataOpentDB importador;

        private IUsuarioControlador iUsuarioControlador;

        private IDificultadControlador iDificultadControlador;

        private ICategoriaControlador iCategoriaControlador;

        private IConjuntoPreguntasControlador iConjuntoPreguntasControlador;

        private IPreguntaControlador iPreguntaControlador;

        public Fachada()
        {
            this.importador = new ImportadorDataOpentDB();
            this.iUsuarioControlador = new UsuarioControlador();
            this.iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            this.iDificultadControlador = new DificultadControlador();
            this.iCategoriaControlador = new CategoriaControlador();
            this.iPreguntaControlador = new PreguntaControlador();
        }

        internal UsuarioDTO ObtenerUsuarioAutenticado()
        {
            Usuario usuario = iUsuarioControlador.ObtenerUsuarioAutenticado();
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                UsuarioId = usuario.UsuarioId,
                active = usuario.active,
                apellido = usuario.apellido,
                contrasena = usuario.contrasena,
                legajo = usuario.legajo,
                nombre = usuario.nombre,
                esAdministrador = usuario.esAdministrador
            };

            return usuarioDTO;
        }

        internal bool CrearUsuario( UsuarioDTO pUsuarioDTO )
        {
            Usuario usuario = new Usuario()
            {
                UsuarioId = pUsuarioDTO.UsuarioId,
                active = pUsuarioDTO.active,
                apellido = pUsuarioDTO.apellido,
                contrasena = pUsuarioDTO.contrasena,
                legajo = pUsuarioDTO.legajo,
                nombre = pUsuarioDTO.nombre,
                esAdministrador = pUsuarioDTO.esAdministrador
            };

            return iUsuarioControlador.CrearUsuario(usuario);
        }

        internal void AgregarPreguntas( DificultadDTO pDificultadDTO, CategoriaDTO pCategoriaDTO, int pCant )
        {
            Categoria categoria = new Categoria()
            {
                CategoriaId = pCategoriaDTO.CategoriaId,
                nombre = pCategoriaDTO.nombre,
                providedId = pCategoriaDTO.providedId,
            };

            Dificultad dificultad = new Dificultad()
            {
                descripcion = pDificultadDTO.descripcion,
                DificultadId = pDificultadDTO.DificultadId,
                peso = pDificultadDTO.peso,
            };

            string nombreConjunto = categoria.nombre + " - " + dificultad.descripcion;
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas(nombreConjunto, dificultad, categoria);
            IList<Pregunta> preguntas = importador.ObtenerPreguntas(pCant, conjunto);
            conjunto.setPreguntas(preguntas);
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
        }

        internal void AgregarPreguntas( ConjuntoPreguntasDTO pConjuntoDTO )
        {
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas(pConjuntoDTO.Nombre, pConjuntoDTO.TiempoEsperadoRespuesta, pConjuntoDTO.Dificultad, pConjuntoDTO.Categoria);

            IList<Pregunta> preguntasActuales = iPreguntaControlador.ObtenerPreguntasPorCriterio(null, null, conjunto.Id);
            var cantPreg = preguntasActuales.Count;
            iPreguntaControlador.EliminarPreguntasConjunto(conjunto.Id);
            IList<Pregunta> preguntas = importador.ObtenerPreguntas(cantPreg, conjunto);
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
        }

        internal void CerrarSesion()
        {
            iUsuarioControlador.CerrarSesion();
        }

        internal UsuarioDTO Autenticar( string legajo, string contrasena )
        {
            Usuario usuario = iUsuarioControlador.Autenticar(legajo, contrasena);
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                UsuarioId = usuario.UsuarioId,
                active = usuario.active,
                apellido = usuario.apellido,
                contrasena = usuario.contrasena,
                legajo = usuario.legajo,
                nombre = usuario.nombre,
                esAdministrador = usuario.esAdministrador
            };

            return usuarioDTO;
        }

        public string ActivarUsuario( UsuarioDTO pUsuarioDTO )
        {
            if (pUsuarioDTO.active == false)
            {
                pUsuarioDTO.active = true;
                Usuario usuario = new Usuario()
                {
                    UsuarioId = pUsuarioDTO.UsuarioId,
                    active = pUsuarioDTO.active,
                    apellido = pUsuarioDTO.apellido,
                    contrasena = pUsuarioDTO.contrasena,
                    legajo = pUsuarioDTO.legajo,
                    nombre = pUsuarioDTO.nombre,
                    esAdministrador = pUsuarioDTO.esAdministrador
                };
                iUsuarioControlador.ActualizarUsuario(usuario);
                return "Usuario activado.";
            }
            else
            {
                return "El usuario ya existe en el sistema.";
            }
        }

        public string EliminarUsuario( DataGridViewRow pSelectedRow )
        {
            string cellValue = Convert.ToString(pSelectedRow.Cells["legajo"].Value);
            iUsuarioControlador.EliminarUsuario(cellValue);
            return "Usuario Eliminado";
        }

        public IList<UsuarioDTO> BuscarUsuarios( UsuarioDTO pUsuarioDTO )
        {
            Usuario usuario = new Usuario()
            {
                UsuarioId = pUsuarioDTO.UsuarioId,
                active = pUsuarioDTO.active,
                apellido = pUsuarioDTO.apellido,
                contrasena = pUsuarioDTO.contrasena,
                legajo = pUsuarioDTO.legajo,
                nombre = pUsuarioDTO.nombre,
                esAdministrador = pUsuarioDTO.esAdministrador

            };
            return (IList<UsuarioDTO>)iUsuarioControlador.BuscarUsuario(usuario);
        }

        public IList<DificultadDTO> ObtenerDificultades()
        {
            return (IList<DificultadDTO>)iDificultadControlador.ObtenerDificultades();
        }

        public IList<CategoriaDTO> ObtenerCategorias()
        {
            return (IList<CategoriaDTO>)iCategoriaControlador.ObtenerCategorias();
        }

        public IList<ConjuntoPreguntasDTO> ObtenerConjuntoPreguntas()
        {
            return (IList<ConjuntoPreguntasDTO>)iConjuntoPreguntasControlador.ObtenerConjuntos();
        }

        public IList<Pregunta> ObtenerPreguntasPorCriterio( int? pCategoriaId, int? pDificultadId, int? pConjuntoPreguntasId )
        {
            return iPreguntaControlador.ObtenerPreguntasPorCriterio(pCategoriaId, pDificultadId, pConjuntoPreguntasId);
        }

        internal void EliminarPregunta( string pPreguntaId )
        {
            iPreguntaControlador.EliminarPregunta(Int32.Parse(pPreguntaId));
        }
    }
}
