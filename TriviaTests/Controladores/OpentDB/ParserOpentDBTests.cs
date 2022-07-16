using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Trivia.TDP.Controladores.OpentDB.Tests
{
    [TestClass()]
    public class ParserOpentDBTests
    {
        ParserOpentDB parser = new ParserOpentDB();
        WebRequesterOpentDB requester = new WebRequesterOpentDB();

        [TestMethod()]
        public void FormatearPreguntasTest()
        {
            // Arrange.
            Dificultad dificultad = new Dificultad()
            {
                DificultadId = 1,
                Descripcion = "easy",
            };
            Categoria categoria = new Categoria() { CategoriaId = 1, Nombre = "General Knowledge", ProvidedId = 9 };
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas() { Categoria = categoria, Dificultad = dificultad, Nombre = "easy General Knowledge" };
            string mockURL = "https://opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple";
            var response = requester.CrearConsulta(mockURL);


            // Act.
            IList<Pregunta> res = parser.FormatearPreguntas(response, conjunto);

            // Assert
            Assert.IsTrue(res.Any());
            Assert.IsTrue(res.Count == 10);
        }

        [TestMethod()]
        public void FormatearCategoriasTest()
        {
            // Arrange.
            var url = "https://opentdb.com/api_category.php";
            var response = requester.CrearConsulta(url);

            // Act.
            IList<Categoria> res = parser.FormatearCategorias(response);

            // Assert.
            Assert.IsTrue(res.Any());
        }
    }
}