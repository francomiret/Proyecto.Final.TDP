﻿using Dominio;

namespace Trivia.TDP.Servicios.OpentDB
{
    public class CreadorURLOpentDB
    {
        public string ConstruirUrl( int pCantidad, ConjuntoPreguntas pConjunto )
        {
            var url = string.Format("https://opentdb.com/api.php?amount={0}&category={1}&difficulty={2}&type=multiple",
                                pCantidad,
                                pConjunto.Categoria.ProvidedId,
                                pConjunto.Dificultad.Descripcion);
            return url;
        }

    }
}
