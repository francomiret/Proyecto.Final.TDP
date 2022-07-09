using System;
using System.Runtime.Serialization;

namespace Trivia.TDP.Controladores
{
    [Serializable]
    internal class ErrorContrasenaIncorrecta : Exception
    {
        public ErrorContrasenaIncorrecta()
        {
        }

        public ErrorContrasenaIncorrecta( string message ) : base(message)
        {
        }

        public ErrorContrasenaIncorrecta( string message, Exception innerException ) : base(message, innerException)
        {
        }

        protected ErrorContrasenaIncorrecta( SerializationInfo info, StreamingContext context ) : base(info, context)
        {
        }
    }
}