using System;
using System.Runtime.Serialization;

namespace Trivia.TDP.Vistas
{
    [Serializable]
    internal class ErrorLegajoNoExiste : Exception
    {
        public ErrorLegajoNoExiste()
        {
        }

        public ErrorLegajoNoExiste(string message) : base(message)
        {
        }

        public ErrorLegajoNoExiste(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorLegajoNoExiste(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}