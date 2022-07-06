﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class ConjuntoPreguntas
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual IEnumerable<Pregunta> Preguntas { get; set; }
        public ConjuntoPreguntas(string pNombre, float pTiempoEsperadoRespuesta, Dificultad pDificultad, Categoria pCategoria)
        {
            this.Nombre = pNombre;
            this.Dificultad = pDificultad;
            this.Categoria = pCategoria;
            this.TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }

        public ConjuntoPreguntas(string pNombre, Dificultad pDificultad, Categoria pCategoria)
        {
            this.Nombre = pNombre;
            this.Dificultad = pDificultad;
            this.Categoria = pCategoria;
            this.TiempoEsperadoRespuesta = 20;
        }

        public void setPreguntas(IEnumerable<Pregunta> pPreguntas)
        {
            this.Preguntas = pPreguntas;
        }
    }
}