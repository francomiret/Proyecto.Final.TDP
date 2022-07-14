using Dominio;
using System.Collections.Generic;

namespace Trivia.TDP.DAL.Interfaz
{
    interface IDificultadRepositorio
    {
        List<Dificultad> obtenerDificultades();
    }
}
