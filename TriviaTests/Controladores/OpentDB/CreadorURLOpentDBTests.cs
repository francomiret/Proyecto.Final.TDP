using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trivia.TDP.Servicios.OpentDB.Tests
{
    [TestClass()]
    public class CreadorURLOpentDBTests
    {
        CreadorURLOpentDB creador = new CreadorURLOpentDB();

        [TestMethod()]
        public void ConstruirUrlTest()
        {
            // Arrange.
            string esperado = "https://opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple";

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
            string resultado = creador.ConstruirUrl(10, conjunto);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }
    }
}