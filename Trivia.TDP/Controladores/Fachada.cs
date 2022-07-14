using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Controladores.OpentDB;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Controladores
{
    class Fachada : IFachada
    {
        private IImportadorDataOpentDB importador;

        private IUsuarioControlador iUsuarioControlador;

        private IDificultadControlador iDificultadControlador;

        private ICategoriaControlador iCategoriaControlador;

        private IConjuntoPreguntasControlador iConjuntoPreguntasControlador;

        private IPreguntaControlador iPreguntaControlador;

        private IExamenControlador iExamenControlador;

        public UsuarioDTO ObtenerUsuarioAutenticado()
        {
            iUsuarioControlador = new UsuarioControlador();

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

        public bool CrearUsuario( UsuarioDTO pUsuarioDTO )
        {
            iUsuarioControlador = new UsuarioControlador();

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

        public IList<PreguntaDTO> AgregarPreguntas( DificultadDTO pDificultadDTO, CategoriaDTO pCategoriaDTO, int pCant )
        {
            iPreguntaControlador = new PreguntaControlador();
            importador = new ImportadorDataOpentDB();
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

            ConjuntoPreguntas conjunto = new ConjuntoPreguntas()
            {
                Nombre = nombreConjunto,
                Dificultad = dificultad,
                Categoria = categoria
            };
            IList<Pregunta> preguntas = importador.ObtenerPreguntas(pCant, conjunto);
            conjunto.setPreguntas(preguntas);
            IList<PreguntaDTO> preguntasParsed = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in preguntas)
            {
                PreguntaDTO preguntaParsed = new PreguntaDTO()
                {
                    PreguntaId = pregunta.PreguntaId,
                    descripcion = pregunta.descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    listaRespuestas = pregunta.listaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
            return preguntasParsed;
        }

        public IList<PreguntaDTO> AgregarPreguntas( ConjuntoPreguntasDTO pConjuntoDTO )
        {
            iPreguntaControlador = new PreguntaControlador();
            importador = new ImportadorDataOpentDB();

            ConjuntoPreguntas conjunto = new ConjuntoPreguntas()
            {
                Id = pConjuntoDTO.Id,
                Nombre = pConjuntoDTO.Nombre,
                TiempoEsperadoRespuesta = pConjuntoDTO.TiempoEsperadoRespuesta,
                Dificultad = pConjuntoDTO.Dificultad,
                Categoria = pConjuntoDTO.Categoria
            };

            IList<Pregunta> preguntasActuales = iPreguntaControlador.ObtenerPreguntasPorCriterio(null, null, conjunto.Id);
            var cantPreg = preguntasActuales.Count;
            iPreguntaControlador.EliminarPreguntasConjunto(conjunto.Id);
            IList<Pregunta> preguntas = importador.ObtenerPreguntas(cantPreg, conjunto);
            IList<PreguntaDTO> preguntasParsed = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in preguntas)
            {
                PreguntaDTO preguntaParsed = new PreguntaDTO()
                {
                    PreguntaId = pregunta.PreguntaId,
                    descripcion = pregunta.descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    listaRespuestas = pregunta.listaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
            return preguntasParsed;
        }

        public void CerrarSesion()
        {
            iUsuarioControlador = new UsuarioControlador();
            iUsuarioControlador.CerrarSesion();
        }

        public UsuarioDTO Autenticar( string legajo, string contrasena )
        {
            iUsuarioControlador = new UsuarioControlador();
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
            iUsuarioControlador = new UsuarioControlador();
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
            iUsuarioControlador = new UsuarioControlador();
            string cellValue = Convert.ToString(pSelectedRow.Cells["legajo"].Value);
            iUsuarioControlador.EliminarUsuario(cellValue);
            return "Usuario Eliminado";
        }

        public IList<UsuarioDTO> BuscarUsuarios( UsuarioDTO pUsuarioDTO )
        {
            iUsuarioControlador = new UsuarioControlador();
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
            iDificultadControlador = new DificultadControlador();
            IList<DificultadDTO> difcultadesParsed = new List<DificultadDTO>();
            IList<Dificultad> dificultades = iDificultadControlador.ObtenerDificultades();

            foreach (var dificultad in dificultades)
            {
                DificultadDTO dificultadParsedDTO = new DificultadDTO()
                {
                    DificultadId = dificultad.DificultadId,
                    descripcion = dificultad.descripcion,
                    peso = dificultad.peso
                };
                difcultadesParsed.Add(dificultadParsedDTO);
            }
            return difcultadesParsed;
        }

        public IList<CategoriaDTO> ObtenerCategorias()
        {
            iCategoriaControlador = new CategoriaControlador();
            IList<CategoriaDTO> categoriasParsed = new List<CategoriaDTO>();
            IList<Categoria> categorias = iCategoriaControlador.ObtenerCategorias();

            foreach (var categoria in categorias)
            {
                CategoriaDTO categoriaParsedDTO = new CategoriaDTO()
                {
                    CategoriaId = categoria.CategoriaId,
                    nombre = categoria.nombre,
                    providedId = categoria.providedId
                };
                categoriasParsed.Add(categoriaParsedDTO);
            }
            return categoriasParsed;
        }

        public IList<ConjuntoPreguntasDTO> ObtenerConjuntoPreguntas()
        {
            iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            IList<ConjuntoPreguntasDTO> conjuntoPreguntasParsed = new List<ConjuntoPreguntasDTO>();
            IList<ConjuntoPreguntas> conjuntos = iConjuntoPreguntasControlador.ObtenerConjuntos();
            foreach (var conjunto in conjuntos)
            {
                ConjuntoPreguntasDTO conjuntoPreguntasParsedDTO = new ConjuntoPreguntasDTO()
                {
                    Id = conjunto.Id,
                    Categoria = conjunto.Categoria,
                    Dificultad = conjunto.Dificultad,
                    Nombre = conjunto.Nombre,
                    TiempoEsperadoRespuesta = conjunto.TiempoEsperadoRespuesta
                };
                conjuntoPreguntasParsed.Add(conjuntoPreguntasParsedDTO);
            }
            return conjuntoPreguntasParsed;
        }

        public IList<PreguntaDTO> ObtenerPreguntasPorCriterio( int? pCategoriaId, int? pDificultadId, int? pConjuntoPreguntasId )
        {
            iPreguntaControlador = new PreguntaControlador();
            IList<Pregunta> preguntas = iPreguntaControlador.ObtenerPreguntasPorCriterio(pCategoriaId, pDificultadId, pConjuntoPreguntasId);
            IList<PreguntaDTO> preguntasParsed = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in preguntas)
            {
                PreguntaDTO preguntaParsed = new PreguntaDTO()
                {
                    PreguntaId = pregunta.PreguntaId,
                    descripcion = pregunta.descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    listaRespuestas = pregunta.listaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            return preguntasParsed;
        }

        public void EliminarPregunta( string pPreguntaId )
        {
            iPreguntaControlador = new PreguntaControlador();
            iPreguntaControlador.EliminarPregunta(Int32.Parse(pPreguntaId));
        }



        public ExamenDTO iniciarExamen( ConjuntoPreguntasDTO pConjunto, IList<PreguntaDTO> preguntas )
        {
            iUsuarioControlador = new UsuarioControlador();
            var usuario = iUsuarioControlador.ObtenerUsuarioAutenticado();
            var tiempoResolucion = preguntas.Count * pConjunto.TiempoEsperadoRespuesta;
            List<SesionPreguntaDTO> sesiones = new List<SesionPreguntaDTO>();
            foreach (var pregunta in preguntas)
            {
                var sesion = new SesionPreguntaDTO()
                {
                    PreguntaID = pregunta.PreguntaId
                };
                sesiones.Add(sesion);
            }
            ExamenDTO examen = new ExamenDTO()
            {
                categoria = pConjunto.Categoria,
                dificultad = pConjunto.Dificultad,
                usuario = usuario,
                FechaInicio = DateTime.Now,
                tiempoDeResolucion = tiempoResolucion,
                sesiones = sesiones,
                CantidadPreguntas = preguntas.Count
            };

            return examen;
        }

        public ExamenDTO FinalizarExamen( ExamenDTO pExamen )
        {
            Examen examen = new Examen(pExamen);
            int respsCorrectas = ExamenControlador.CantidadRespuestasCorrectas(examen);
            double factorDificultad = ExamenControlador.GetFactorDificultad(examen);
            examen.Finalizar(respsCorrectas, factorDificultad);
            ExamenControlador.GuardarExamen(examen);


            return new ExamenDTO(examen);
        }

        public ExamenDTO MejorExamenUsuario()
        {
            iExamenControlador = new ExamenControlador();
            iUsuarioControlador = new UsuarioControlador();
            var usuario = iUsuarioControlador.ObtenerUsuarioAutenticado();
            Examen examen = iExamenControlador.MejorExamen(usuario);
            if (examen != null)
            {
                return new ExamenDTO(examen);
            }
            else
            {
                return null;
            }

        }

        public IList<ExamenDTO> Mejores10Examenes()
        {
            iExamenControlador = new ExamenControlador();
            IList<Examen> examenes = iExamenControlador.Mejores10Examenes();
            IList<ExamenDTO> examenesDto = new List<ExamenDTO>();
            foreach (var examen in examenes)
            {
                examenesDto.Add(new ExamenDTO(examen));
            }
            return examenesDto;
        }
    }
}
