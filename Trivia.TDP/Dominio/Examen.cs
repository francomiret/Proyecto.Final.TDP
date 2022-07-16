using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trivia.TDP.Dominio;
using Trivia.TDP.DTO;

namespace Dominio
{
    public class Examen
    {
        [Key]
        public int Examenid { get; set; }
        public DateTime FechaInicio { get; set; }
        public double TiempoUsado { get; set; }
        public double Puntaje { get; set; }
        public double TiempoDeResolucion { get; set; }
        public double CantidadPreguntas { get { return this.Sesiones.Count; } }
        public virtual Usuario Usuario { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual IList<SesionPregunta> Sesiones { get; set; }

        public double GetPuntaje( double tfactorTiempo, int cantPreguntas, int cantRespCorrectas, Dificultad dificultad )
        {
            return 0;
        }

        public double FactorTiempo
        {
            get
            {
                double factor = TiempoUsado / CantidadPreguntas;

                if (factor < 5)
                {
                    return 5;
                }
                else if (factor < 20)
                {
                    return 3;
                }
                else return 1;
            }
        }

        private void CalcularPuntaje( int pCantRespCorrectas, double pFactorDificultad )
        {
            Puntaje = pCantRespCorrectas / this.CantidadPreguntas * pFactorDificultad * this.FactorTiempo;
        }

        public void Finalizar( int pCantidadRespuestasCorrectas, double pFactorDificultad )
        {
            this.TiempoUsado = (DateTime.Now - this.FechaInicio).TotalSeconds;
            this.CalcularPuntaje(pCantidadRespuestasCorrectas, pFactorDificultad);
        }

        private static IList<SesionPregunta> DTOaSesionPregunta( IList<SesionPreguntaDTO> pSesionPreguntas )
        {
            var dtos = new List<SesionPregunta>();
            foreach (var sesionPreg in pSesionPreguntas)
            {
                dtos.Add(new SesionPregunta(sesionPreg));
            }
            return dtos;
        }

        public Examen( ExamenDTO examenDTO )
        {
            this.FechaInicio = examenDTO.FechaInicio;
            this.Examenid = examenDTO.Examenid;
            this.Categoria = examenDTO.Categoria;
            this.Usuario = examenDTO.Usuario;
            this.Dificultad = examenDTO.Dificultad;
            this.TiempoUsado = examenDTO.TiempoUsado;
            this.TiempoDeResolucion = examenDTO.TiempoDeResolucion;
            this.Puntaje = examenDTO.Puntaje;
            this.Sesiones = Examen.DTOaSesionPregunta(examenDTO.Sesiones);
        }
        public Examen()
        {
        }
    }
}

