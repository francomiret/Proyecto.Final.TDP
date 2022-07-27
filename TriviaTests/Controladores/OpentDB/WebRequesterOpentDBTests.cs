using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Trivia.TDP.Servicios.OpentDB.Tests
{
    [TestClass()]
    public class WebRequesterOpentDBTests
    {
        WebRequesterOpentDB requester = new WebRequesterOpentDB();

        [TestMethod()]
        public void CrearConsultaTest()
        {
            // Arrange.
            string url = "https://opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple";

            // Act.
            WebResponse resultado = requester.CrearConsulta(url);

            // Assert
            Assert.AreEqual(resultado.ResponseUri, url);
        }
    }
}