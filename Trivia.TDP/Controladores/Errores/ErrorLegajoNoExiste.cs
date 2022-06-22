using System;
using System.Runtime.Serialization;

namespace Trivia.TDP.Controladores
{
    [Serializable]
    internal class ErrorUsuarioNoExiste : Exception
    {
        public ErrorUsuarioNoExiste()
        {
        }

        public ErrorUsuarioNoExiste(string message) : base(message)
        {
        }

        public ErrorUsuarioNoExiste(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorUsuarioNoExiste(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}