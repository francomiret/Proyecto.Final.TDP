using System;
using System.Runtime.Serialization;

namespace Trivia.TDP.Controladores
{
    [Serializable]
    internal class ErrorUsuarioNoAutenticado : Exception
    {
        public ErrorUsuarioNoAutenticado()
        {
        }

        public ErrorUsuarioNoAutenticado( string message ) : base(message)
        {
        }

        public ErrorUsuarioNoAutenticado( string message, Exception innerException ) : base(message, innerException)
        {
        }

        protected ErrorUsuarioNoAutenticado( SerializationInfo info, StreamingContext context ) : base(info, context)
        {
        }
    }
}