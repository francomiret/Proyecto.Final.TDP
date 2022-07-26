using Dominio;
using ProyectoFinalTDP.DAL;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Servicios.OpentDB;

namespace Trivia.TDP.DAL.Migrations
{
    internal sealed class Configuracion : DbMigrationsConfiguration<PruebaDBContext>
    {
        private ICategoriaControlador iCategoriaControlador;
        private ImportadorDataOpentDB estrategia = new ImportadorDataOpentDB();
        public Configuracion()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TP_Final.DAL.EntityFramework.TriviaDBContext";
            this.iCategoriaControlador = new CategoriaControlador();
        }

        protected override void Seed( PruebaDBContext pContext )
        {
            UsuariosSeeder.Seed(pContext);

            DificultadSeeder.Seed(pContext);

            IList<Categoria> categorias = estrategia.ObtenerCategorias();
            iCategoriaControlador.AgregarCategorias(categorias);

            base.Seed(pContext);
        }
    }
}
