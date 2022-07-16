using Dominio;
using Nancy.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Trivia.TDP.Controladores.OpentDB
{
    public class ParserOpentDB
    {
        public IList<Pregunta> FormatearPreguntas( WebResponse webResponse, ConjuntoPreguntas pConjunto )
        {
            var preguntas = new List<Pregunta>();

            using (Stream responseStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                // Se iteran cada uno de los resultados.
                foreach (var bResponseItem in mResponseJSON.results)
                {
                    // De esta manera se accede a los componentes de cada item
                    string textoPregunta = HttpUtility.HtmlDecode(bResponseItem.question.ToString());
                    string nombreCategoria = bResponseItem.category.ToString();
                    string nombreDificultad = HttpUtility.HtmlDecode(bResponseItem.difficulty.ToString());
                    var respuestas = new List<Respuesta>();

                    if ((nombreCategoria != pConjunto.Categoria.Nombre) || (nombreDificultad != pConjunto.Dificultad.Descripcion))
                    {
                        throw new DataNotFound("Categoria o Dificultad no validos.");
                    }

                    //Obtiene el texto de la respuesta correcta
                    string textorespuestaCorrecta = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString());

                    //Obtiene el texto de las respuestas incorrectas
                    List<string> textoincorrectas = bResponseItem.incorrect_answers.ToObject<List<string>>();

                    //Crea la pregunta
                    Pregunta preg = new Pregunta()
                    {
                        ConjuntoPreguntas = pConjunto,
                        Descripcion = textoPregunta
                    };

                    //Crea la respuesta correcta
                    Respuesta respuestaCorrecta = new Respuesta()
                    {
                        Descripcion = textorespuestaCorrecta,
                        EsCorrecta = true
                    };

                    //Añade respuesta correcta a la lista
                    respuestas.Add(respuestaCorrecta);

                    //Por cada respuesta incorrecta, crea una respuesta y la añade a la lista
                    foreach (string tri in textoincorrectas)
                    {
                        Respuesta res = new Respuesta()
                        {
                            Descripcion = HttpUtility.HtmlDecode(tri),
                            EsCorrecta = false
                        };
                        respuestas.Add(res);
                    }

                    // Asocias las respuestas con la pregunta
                    preg.ListaRespuestas = respuestas;

                    //se agrega cada una de las preguntas a la lista
                    preguntas.Add(preg);
                }
            }
            return preguntas;
        }

        public List<Categoria> FormatearCategorias( WebResponse webResponse )
        {
            var categorias = new List<Categoria>();
            using (Stream responseStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                foreach (var bResponseItem in mResponseJSON.trivia_categories)
                {
                    int idCategoria = bResponseItem.id;
                    string nombreCategoria = bResponseItem.name.ToString();

                    //Crea la categoria
                    var categoria = new Categoria()
                    {
                        ProvidedId = idCategoria,
                        Nombre = nombreCategoria
                    };

                    categorias.Add(categoria);
                }
            }
            return categorias;
        }
    }
}
