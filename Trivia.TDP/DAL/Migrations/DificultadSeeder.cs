﻿using Dominio;
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



            dificultades.Add(new Dificultad(1,"easy",1));
            dificultades.Add(new Dificultad(2, "medium", 2));
            dificultades.Add(new Dificultad(3, "hard", 3));


            foreach (Dificultad dificultad in dificultades)
            {
                if (pContext.Set<Dificultad>().Find(dificultad.DificultadId) == null)
                    pContext.Set<Dificultad>().Add(dificultad);
            }
        }
    }
}