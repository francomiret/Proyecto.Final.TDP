﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Conjuntos.Interfaz;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.DTO;
using Trivia.TDP.Servicios.OpentDB;

namespace Trivia.TDP.Controladores
{
    class Fachada : IFachada
    {
        private IUsuarioControlador iUsuarioControlador;

        private IDificultadControlador iDificultadControlador;

        private ICategoriaControlador iCategoriaControlador;

        private IConjuntoPreguntasControlador iConjuntoPreguntasControlador;

        private IPreguntaControlador iPreguntaControlador;

        private IExamenControlador iExamenControlador;

        /// <summary>
        /// Obtiene el usuario autenticado
        /// </summary>
        /// <returns>El usuario autenticado</returns>
        public UsuarioDTO ObtenerUsuarioAutenticado()
        {
            iUsuarioControlador = new UsuarioControlador();

            Usuario usuario = iUsuarioControlador.ObtenerUsuarioAutenticado();
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                UsuarioId = usuario.UsuarioId,
                Activo = usuario.Activo,
                Apellido = usuario.Apellido,
                Contrasena = usuario.Contrasena,
                Legajo = usuario.Legajo,
                Nombre = usuario.Nombre,
                EsAdministrador = usuario.EsAdministrador
            };

            return usuarioDTO;
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="pUsuarioDTO">Usuario a agregar</param>
        /// <returns>Devuelve true si pudo crear el usuario, falso sino</returns>
        public bool CrearUsuario( UsuarioDTO pUsuarioDTO )
        {
            iUsuarioControlador = new UsuarioControlador();

            Usuario usuario = new Usuario()
            {
                UsuarioId = pUsuarioDTO.UsuarioId,
                Activo = pUsuarioDTO.Activo,
                Apellido = pUsuarioDTO.Apellido,
                Contrasena = pUsuarioDTO.Contrasena,
                Legajo = pUsuarioDTO.Legajo,
                Nombre = pUsuarioDTO.Nombre,
                EsAdministrador = pUsuarioDTO.EsAdministrador
            };

            return iUsuarioControlador.CrearUsuario(usuario);
        }

        /// <summary>
        /// Agregar una lista de preguntas
        /// </summary>
        /// <param name="pDificultadDTO">difucultad de las preguntas</param>
        /// <param name="pCategoriaDTO">categoria de las preguntas</param>
        /// <param name="pCant">cantidad de preguntas</param>
        /// <returns>Lista de preguntas agregada</returns>
        public IList<PreguntaDTO> AgregarPreguntas( DificultadDTO pDificultadDTO, CategoriaDTO pCategoriaDTO, int pCant )
        {
            iPreguntaControlador = new PreguntaControlador();
            iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            IimportadorData importador = new ImportadorDataOpentDB();

            Categoria categoria = new Categoria()
            {
                CategoriaId = pCategoriaDTO.CategoriaId,
                Nombre = pCategoriaDTO.Nombre,
                ProvidedId = pCategoriaDTO.ProvidedId,
            };

            Dificultad dificultad = new Dificultad()
            {
                Descripcion = pDificultadDTO.Descripcion,
                DificultadId = pDificultadDTO.DificultadId,
                Peso = pDificultadDTO.Peso,
            };

            string nombreConjunto = categoria.Nombre + " - " + dificultad.Descripcion;

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
                    Descripcion = pregunta.Descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    ListaRespuestas = pregunta.ListaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
            return preguntasParsed;
        }

        /// <summary>
        /// Agrega una lista de pregunas
        /// </summary>
        /// <param name="pConjuntoDTO">Conjunto de preguntas</param>
        /// <returns>Lista de preguntas agregada</returns>
        public IList<PreguntaDTO> AgregarPreguntas( ConjuntoPreguntasDTO pConjuntoDTO )
        {
            iPreguntaControlador = new PreguntaControlador();
            iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            IimportadorData importador = iConjuntoPreguntasControlador.obtenerImportador();

            ConjuntoPreguntas conjunto = new ConjuntoPreguntas()
            {
                Id = pConjuntoDTO.Id,
                Nombre = pConjuntoDTO.Nombre,
                TiempoEsperadoRespuesta = pConjuntoDTO.TiempoEsperadoRespuesta,
                Dificultad = pConjuntoDTO.Dificultad,
                Categoria = pConjuntoDTO.Categoria,
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
                    Descripcion = pregunta.Descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    ListaRespuestas = pregunta.ListaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            this.iPreguntaControlador.AgregarPreguntas(preguntas);
            return preguntasParsed;
        }

        /// <summary>
        /// Cierra la sesion actual
        /// </summary>
        public void CerrarSesion()
        {
            iUsuarioControlador = new UsuarioControlador();
            iUsuarioControlador.CerrarSesion();
        }

        /// <summary>
        /// Autentica a un usuario
        /// </summary>
        /// <param name="legajo">legajo del usuario</param>
        /// <param name="contrasena">contraseña del usuario</param>
        /// <returns>usuario autenticado</returns>
        public UsuarioDTO Autenticar( string legajo, string contrasena )
        {
            iUsuarioControlador = new UsuarioControlador();
            Usuario usuario = iUsuarioControlador.Autenticar(legajo, contrasena);
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                UsuarioId = usuario.UsuarioId,
                Activo = usuario.Activo,
                Apellido = usuario.Apellido,
                Contrasena = usuario.Contrasena,
                Legajo = usuario.Legajo,
                Nombre = usuario.Nombre,
                EsAdministrador = usuario.EsAdministrador
            };

            return usuarioDTO;
        }

        /// <summary>
        /// Activa un usuario que estaba inactivo
        /// </summary>
        /// <param name="pUsuarioDTO">usuario a activar</param>
        /// <returns>Mensaje de usuario activado</returns>
        public string ActivarUsuario( UsuarioDTO pUsuarioDTO )
        {
            iUsuarioControlador = new UsuarioControlador();
            if (pUsuarioDTO.Activo == false)
            {
                pUsuarioDTO.Activo = true;
                Usuario usuario = new Usuario()
                {
                    UsuarioId = pUsuarioDTO.UsuarioId,
                    Activo = pUsuarioDTO.Activo,
                    Apellido = pUsuarioDTO.Apellido,
                    Contrasena = pUsuarioDTO.Contrasena,
                    Legajo = pUsuarioDTO.Legajo,
                    Nombre = pUsuarioDTO.Nombre,
                    EsAdministrador = pUsuarioDTO.EsAdministrador
                };
                iUsuarioControlador.ActualizarUsuario(usuario);
                return "Usuario activado.";
            }
            else
            {
                return "El usuario ya existe en el sistema.";
            }
        }

        /// <summary>
        /// Inactiva un usuario del sistema
        /// </summary>
        /// <param name="pSelectedRow">usuario seleccionado</param>
        /// <returns>Menasje de usuario eliminado</returns>
        public string EliminarUsuario( DataGridViewRow pSelectedRow )
        {
            iUsuarioControlador = new UsuarioControlador();
            string cellValue = Convert.ToString(pSelectedRow.Cells["legajo"].Value);
            iUsuarioControlador.EliminarUsuario(cellValue);
            return "Usuario Eliminado";
        }

        /// <summary>
        /// Busca usuarios que mas coinciden
        /// </summary>
        /// <param name="pUsuarioDTO">Usuario a buscar</param>
        /// <returns>Lista de usuarios coincidentes</returns>
        public IList<UsuarioDTO> BuscarUsuarios( UsuarioDTO pUsuarioDTO )
        {
            iUsuarioControlador = new UsuarioControlador();
            Usuario usuario = new Usuario()
            {
                UsuarioId = pUsuarioDTO.UsuarioId,
                Activo = pUsuarioDTO.Activo,
                Apellido = pUsuarioDTO.Apellido,
                Contrasena = pUsuarioDTO.Contrasena,
                Legajo = pUsuarioDTO.Legajo,
                Nombre = pUsuarioDTO.Nombre,
                EsAdministrador = pUsuarioDTO.EsAdministrador

            };
            IList<Usuario> usuarios = iUsuarioControlador.BuscarUsuario(usuario);
            IList<UsuarioDTO> usuariosDto = new List<UsuarioDTO>();
            foreach (var user in usuarios)
            {
                UsuarioDTO usuarioDto = new UsuarioDTO()
                {
                    UsuarioId = user.UsuarioId,
                    Activo = user.Activo,
                    Apellido = user.Apellido,
                    Legajo = user.Legajo,
                    Nombre = user.Nombre,
                    EsAdministrador = user.EsAdministrador

                };
                usuariosDto.Add(usuarioDto);
            }
            return usuariosDto;
        }

        /// <summary>
        /// Obtiene todas las dificutlades
        /// </summary>
        /// <returns>Lista de dificultades</returns>
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
                    Descripcion = dificultad.Descripcion,
                    Peso = dificultad.Peso
                };
                difcultadesParsed.Add(dificultadParsedDTO);
            }
            return difcultadesParsed;
        }

        /// <summary>
        /// Obtiene todas las categorias.
        /// </summary>
        /// <returns>Listra de categorias</returns>
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
                    Nombre = categoria.Nombre,
                    ProvidedId = categoria.ProvidedId
                };
                categoriasParsed.Add(categoriaParsedDTO);
            }
            return categoriasParsed;
        }

        /// <summary>
        /// Obtiene todos los conjunto de preguntas
        /// </summary>
        /// <returns>Lista de conjunto de preguntas</returns>
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

        /// <summary>
        /// Descarga la lista de preguntas segun los parametros.
        /// Si se pasa el Conjunto de preguntas actualiza las preguntas de dicho conjunto.
        /// </summary>
        /// <param name="pCategoriaId">Categoria</param>
        /// <param name="pDificultadId">Dificultad</param>
        /// <param name="pConjuntoPreguntasId">Conkunto de preguntas</param>
        /// <returns>Lista de preguntas</returns>
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
                    Descripcion = pregunta.Descripcion,
                    ConjuntoPreguntas = pregunta.ConjuntoPreguntas,
                    ListaRespuestas = pregunta.ListaRespuestas
                };
                preguntasParsed.Add(preguntaParsed);
            }
            return preguntasParsed;
        }

        /// <summary>
        /// Elimina una pregunta especifica.
        /// </summary>
        /// <param name="pPreguntaId">Id de la pregunta a eliminar</param>
        public void EliminarPregunta( string pPreguntaId )
        {
            iPreguntaControlador = new PreguntaControlador();
            iPreguntaControlador.EliminarPregunta(Int32.Parse(pPreguntaId));
        }


        /// <summary>
        /// Inicia el examen
        /// </summary>
        /// <param name="pConjunto">Conjunto de preguntas seleccionado</param>
        /// <param name="preguntas">Lista de preguntas</param>
        /// <returns>Examen creado</returns>
        public ExamenDTO IniciarExamen( ConjuntoPreguntasDTO pConjunto, IList<PreguntaDTO> preguntas )
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
                Categoria = pConjunto.Categoria,
                Dificultad = pConjunto.Dificultad,
                Usuario = usuario,
                FechaInicio = DateTime.Now,
                TiempoDeResolucion = tiempoResolucion,
                Sesiones = sesiones,
                CantidadPreguntas = preguntas.Count
            };

            return examen;
        }

        /// <summary>
        /// Finaliza el examen
        /// </summary>
        /// <param name="pExamen">Examen a finalizar</param>
        /// <returns>Examen finalizado</returns>
        public ExamenDTO FinalizarExamen( ExamenDTO pExamen )
        {
            Examen examen = new Examen(pExamen);
            int respsCorrectas = ExamenControlador.CantidadRespuestasCorrectas(examen);
            double factorDificultad = ExamenControlador.GetFactorDificultad(examen);
            examen.Finalizar(respsCorrectas, factorDificultad);
            ExamenControlador.GuardarExamen(examen);


            return new ExamenDTO(examen);
        }

        /// <summary>
        /// Busca el examen que mayor puntaje tiene para el usuario autenticado.
        /// </summary>
        /// <returns>Examen con mayor puntaje</returns>
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

        /// <summary>
        /// Obtiene los 10 examenes con mayor puntaje.
        /// </summary>
        /// <returns>Lista con 10 examenes</returns>
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
