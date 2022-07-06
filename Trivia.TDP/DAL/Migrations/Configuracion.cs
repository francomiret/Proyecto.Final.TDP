using Dominio;
using ProyectoFinalTDP.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Controladores.OpentDB;

namespace Trivia.TDP.DAL.Migrations
{
    internal sealed class Configuracion : DbMigrationsConfiguration<PruebaDBContext>
    {
        private ICategoriaControlador iCategoriaControlador;
        private Estrategia estrategia = new Estrategia();
        public Configuracion()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TP_Final.DAL.EntityFramework.TriviaDBContext";
            this.iCategoriaControlador = new CategoriaControlador();
        }

        protected override void Seed(PruebaDBContext pContext)
        {
            UsuariosSeeder.Seed(pContext);

            DificultadSeeder.Seed(pContext);

            IList<Categoria> categorias = estrategia.obtenerCategorias();
            iCategoriaControlador.agregarCategorias(categorias);

            base.Seed(pContext);
        }
    }
}
