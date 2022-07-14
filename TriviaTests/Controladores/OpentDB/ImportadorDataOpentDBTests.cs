using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia.TDP.Controladores.OpentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Trivia.TDP.Controladores.OpentDB.Tests
{
    [TestClass()]
    public class ImportadorDataOpentDBTests
    {
        [TestMethod()]
        public void ObtenerPreguntasTest_10Preguntas()
        {
            var dificultad = new Dificultad()
            {
                DificultadId = 1,
                descripcion = "easy",
                peso = 1
            };
            var categoria = new Categoria() { CategoriaId = 18, nombre = "Science: Computers" };
            var conjunto = new ConjuntoPreguntas() { Categoria = categoria, Dificultad = dificultad, Nombre = "OpentDb" };

            var importador = new ImportadorDataOpentDB();
            var res = importador.ObtenerPreguntas(10, conjunto);

            Assert.IsTrue(res.Any());
        }

        [TestMethod()]
        public void ObtenerPreguntasTest_NingunaPregunta()
        {
            var dificultad = new Dificultad()
            {
                DificultadId = 1,
                descripcion = "easy",
                peso = 1
            };
            var categoria = new Categoria() { CategoriaId = 18, nombre = "Science: Computers" };
            var conjunto = new ConjuntoPreguntas() { Categoria = categoria, Dificultad = dificultad, Nombre = "OpentDb" };

            var importador = new ImportadorDataOpentDB();
            var res = importador.ObtenerPreguntas(0, conjunto);

            Assert.IsFalse(res.Any());
        }

        [TestMethod()]
        public void ObtenerCategoriasTest()
        {
            throw new NotImplementedException();
        }
    }
}