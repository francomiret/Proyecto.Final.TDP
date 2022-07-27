using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Servicios.OpentDB.Tests
{
    [TestClass()]
    public class ImportadorDataOpentDBTests
    {
        ImportadorDataOpentDB importador = new ImportadorDataOpentDB();

        [TestMethod()]
        public void ObtenerPreguntasTest_10Preguntas()
        {
            // Arrange.
            Dificultad dificultad = new Dificultad()
            {
                DificultadId = 1,
                Descripcion = "easy",
            };
            Categoria categoria = new Categoria()
            {
                CategoriaId = 1,
                Nombre = "General Knowledge",
                ProvidedId = 9
            };
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas()
            {
                Categoria = categoria,
                Dificultad = dificultad,
                Nombre = "easy General Knowledge"
            };

            // Act.
            IList<Pregunta> resultado = importador.ObtenerPreguntas(10, conjunto);


            // Assert
            Assert.IsTrue(resultado.Any());
            Assert.IsTrue(resultado.Count == 10);
        }

        [TestMethod()]
        public void ObtenerPreguntasTest_NingunaPregunta()
        {
            // Arrange.
            Dificultad dificultad = new Dificultad()
            {
                DificultadId = 1,
                Descripcion = "easy",
                Peso = 1
            };
            Categoria categoria = new Categoria()
            {
                CategoriaId = 1,
                Nombre = "General Knowledge",
                ProvidedId = 9
            };
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas()
            {
                Categoria = categoria,
                Dificultad = dificultad,
                Nombre = "OpentDb"
            };

            // Act.
            IList<Pregunta> resultado = importador.ObtenerPreguntas(0, conjunto);

            // Assertk
            Assert.IsFalse(resultado.Any());
            Assert.IsTrue(resultado.Count == 0);
        }

        [TestMethod()]
        public void ObtenerCategoriasTest()
        {
            // Act.
            IList<Categoria> resultado = importador.ObtenerCategorias();

            // Assert.
            Assert.IsTrue(resultado.Any());
            Assert.IsTrue(resultado.Count == 24);
        }
    }
}