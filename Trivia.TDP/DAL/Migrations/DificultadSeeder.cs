using Dominio;
using ProyectoFinalTDP.DAL;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Migrations
{
    class DificultadSeeder
    {
        public static void Seed( PruebaDBContext pContext )
        {
            List<Dificultad> dificultades = new List<Dificultad>();

            dificultades.Add(new Dificultad()
            {
                DificultadId = 1,
                Descripcion = "easy",
                Peso = 1
            });
            dificultades.Add(new Dificultad()
            {
                DificultadId = 2,
                Descripcion = "medium",
                Peso = 2
            });
            dificultades.Add(new Dificultad()
            {
                DificultadId = 3,
                Descripcion = "hard",
                Peso = 3
            });


            foreach (Dificultad dificultad in dificultades)
            {
                if (pContext.Set<Dificultad>().Find(dificultad.DificultadId) == null)
                    pContext.Set<Dificultad>().Add(dificultad);
            }
        }
    }
}
