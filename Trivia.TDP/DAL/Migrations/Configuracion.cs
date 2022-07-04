using ProyectoFinalTDP.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DAL.Migrations
{
    internal sealed class Configuracion : DbMigrationsConfiguration<PruebaDBContext>
    {
        public Configuracion()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TP_Final.DAL.EntityFramework.TriviaDBContext";
        }

        protected override void Seed(PruebaDBContext pContext)
        {
            UsuariosSeeder.Seed(pContext);

            DificultadSeeder.Seed(pContext);

            base.Seed(pContext);
        }
    }
}
