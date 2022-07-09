using Dominio;
using ProyectoFinalTDP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.TDP.DAL.Migrations
{
    class DificultadSeeder
    {
        public static void Seed(PruebaDBContext pContext)
        {

            List<Dificultad> dificultades = new List<Dificultad>();



            dificultades.Add(new Dificultad() { 
              DificultadId = 1,
              descripcion = "easy",
              peso = 1
            });
            dificultades.Add(new Dificultad()
            {
                DificultadId = 2,
                descripcion = "medium",
                peso = 2
            });
            dificultades.Add(new Dificultad()
            {
                DificultadId = 3,
                descripcion = "hard",
                peso = 3
            });


            foreach (Dificultad dificultad in dificultades)
            {
                if (pContext.Set<Dificultad>().Find(dificultad.DificultadId) == null)
                    pContext.Set<Dificultad>().Add(dificultad);
            }
        }
    }
}
