using Dominio;
using System.Data.Entity;
using Trivia.TDP.DAL.Migrations;

namespace ProyectoFinalTDP.DAL
{

    public class PruebaDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<ConjuntoPreguntas> ConjuntoPreguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }

        public PruebaDBContext() : base("Trivia")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PruebaDBContext, Configuracion>());
        }
    }
}
