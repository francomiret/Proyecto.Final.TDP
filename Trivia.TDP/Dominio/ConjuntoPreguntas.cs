using System;

namespace Dominio
{
    public class ConjuntoPreguntas
    {
        private char v1;
        private int v2;

        public String Id { get; set; }
        public String Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; }
        public Dificultad Dificultad { get; set; }
        public Categoria Categoria { get; set; }
        public string V { get; }

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
    }
}