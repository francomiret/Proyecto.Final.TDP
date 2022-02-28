using Administrador.Dominio;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.Administrador.DAL
{

    public class PruebaDBContext : DbContext
    {
       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }

        public PruebaDBContext() : base("Trivia")
        {
       
        }
    }
}
