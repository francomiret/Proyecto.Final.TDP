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
            IList<Categoria> expected = new List<Categoria>() {
                new Categoria()
                {
                    CategoriaId = 0,
                    Nombre = "General Knowledge",
                    ProvidedId = 9
                },
                new Categoria()
                {
                    CategoriaId = 1,
                    Nombre = "Entertainment: Books",
                    ProvidedId = 10
                },
                new Categoria()
                {
                    CategoriaId = 2,
                    Nombre = "Entertainment: Film",
                    ProvidedId = 11
                },
                new Categoria()
                {
                    CategoriaId = 3,
                    Nombre = "Entertainment: Music",
                    ProvidedId = 12
                },
                new Categoria()
                {
                    CategoriaId = 4,
                    Nombre = "Entertainment: Musicals & Theatres",
                    ProvidedId = 13
                },
                new Categoria()
                {
                    CategoriaId = 5,
                    Nombre = "Entertainment: Television",
                    ProvidedId = 14
                },
                new Categoria()
                {
                    CategoriaId = 6,
                    Nombre = "Entertainment: Video Games",
                    ProvidedId = 15
                },
                new Categoria()
                {
                    CategoriaId = 7,
                    Nombre = "Entertainment: Board Games",
                    ProvidedId = 16
                },
                new Categoria()
                {
                    CategoriaId = 8,
                    Nombre = "Science & Nature",
                    ProvidedId = 17
                },
                new Categoria()
                {
                    CategoriaId = 9,
                    Nombre = "Science: Computers",
                    ProvidedId = 18
                },
                new Categoria()
                {
                    CategoriaId = 10,
                    Nombre = "Science: Mathematics",
                    ProvidedId = 19
                },
                new Categoria(){
                    CategoriaId = 11,
                    Nombre = "Mythology",
                    ProvidedId = 20
                },
                new Categoria()
                {
                    CategoriaId = 12,
                    Nombre = "Sports",
                    ProvidedId = 21
                },
                new Categoria()
                {
                    CategoriaId = 13,
                    Nombre = "Geography",
                    ProvidedId = 22
                },
                new Categoria()
                {
                    CategoriaId = 14,
                    Nombre = "History",
                    ProvidedId = 23
                },
                new Categoria()
                {
                    CategoriaId = 15,
                    Nombre = "Politics",
                    ProvidedId = 24
                },
                new Categoria()
                {
                    CategoriaId = 16,
                    Nombre = "Art",
                    ProvidedId = 25
                },
                new Categoria()
                {
                    CategoriaId = 17,
                    Nombre = "Celebrities",
                    ProvidedId = 26
                },
                new Categoria()
                {
                    CategoriaId = 18,
                    Nombre = "Animals",
                    ProvidedId = 27
                },
                new Categoria()
                {
                    CategoriaId = 19,
                    Nombre = "Vehicles",
                    ProvidedId = 28
                },
                new Categoria()
                {
                    CategoriaId = 20,
                    Nombre = "Entertainment: Comics",
                    ProvidedId = 29
                },
                new Categoria()
                {
                    CategoriaId = 21,
                    Nombre = "Science: Gadgets",
                    ProvidedId = 30
                },
                new Categoria()
                {
                    CategoriaId = 22,
                    Nombre = "Entertainment: Japanese Anime & Manga",
                    ProvidedId = 31
                },
                new Categoria()
                {
                    CategoriaId = 23,
                    Nombre = "Entertainment: Cartoon & Animations",
                    ProvidedId = 32
                },
            };
            
            // Act.
            IList<Categoria> res = parser.FormatearCategorias(response);

            // Assert.
            Assert.IsTrue(res.Any());
            Assert.AreEqual(expected.Count, res.Count);
        }
    }
}