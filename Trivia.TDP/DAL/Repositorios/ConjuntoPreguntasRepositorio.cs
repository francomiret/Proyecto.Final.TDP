﻿using Dominio;
using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    class ConjuntoPreguntasRepositorio : EFRepositorio<ConjuntoPreguntas, PruebaDBContext>, IConjuntoPreguntasRepositorio
    {
        public ConjuntoPreguntasRepositorio(PruebaDBContext pContext) : base(pContext)
        {

        }

        public void AgregarConjunto(ConjuntoPreguntas pConjunto)
        {
            try
            {
                var dificultad = this.iDbContext.Dificultades.First(c => c.DificultadId == pConjunto.Dificultad.DificultadId);
                pConjunto.Dificultad = dificultad;
            }
            catch (InvalidOperationException e)
            {

            }
            try
            {
                var categoria = this.iDbContext.Categorias.First(c => c.CategoriaId == pConjunto.Categoria.CategoriaId);
                pConjunto.Categoria = categoria;
            }
            catch (InvalidOperationException e)
            {

            }
            iDbContext.ConjuntoPreguntas.Add(pConjunto);

        }

        public List<ConjuntoPreguntas> obtenerConjuntos()
        {
            var conjuntos = iDbContext.ConjuntoPreguntas.ToList();
            return conjuntos;
        }
    }
}
