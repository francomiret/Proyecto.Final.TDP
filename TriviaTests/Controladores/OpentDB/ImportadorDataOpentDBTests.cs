using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.Controladores.OpentDB.Tests
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
                descripcion = "easy",
            };
            Categoria categoria = new Categoria() { CategoriaId = 1, nombre = "General Knowledge", providedId = 9 };
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas() { Categoria = categoria, Dificultad = dificultad, Nombre = "easy General Knowledge" };

            // Act.
            IList<Pregunta> res = importador.ObtenerPreguntas(10, conjunto);


            // Assert
            Assert.IsTrue(res.Any());
            Assert.IsTrue(res.Count == 10);
        }

        [TestMethod()]
        public void ObtenerPreguntasTest_NingunaPregunta()
        {
            // Arrange.
            Dificultad dificultad = new Dificultad()
            {
                DificultadId = 1,
                descripcion = "easy",
                peso = 1
            };
            Categoria categoria = new Categoria() { CategoriaId = 1, nombre = "General Knowledge", providedId = 9 };
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas() { Categoria = categoria, Dificultad = dificultad, Nombre = "OpentDb" };

            // Act.
            IList<Pregunta> res = importador.ObtenerPreguntas(0, conjunto);

            // Assertk
            Assert.IsFalse(res.Any());
            Assert.IsTrue(res.Count == 0);
        }

        [TestMethod()]
        public void ObtenerCategoriasTest()
        {            
            // Act.
            IList<Categoria> res = importador.ObtenerCategorias();

            // Assert.
            Assert.IsTrue(res.Any());
        }
    }
}