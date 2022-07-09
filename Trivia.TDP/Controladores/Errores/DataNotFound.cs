using System;
using System.Runtime.Serialization;

namespace Trivia.TDP.Controladores
{
    [Serializable]
    internal class DataNotFound : Exception
    {
        public DataNotFound()
        {
        }

        public DataNotFound( string message ) : base(message)
        {
        }

        public DataNotFound( string message, Exception innerException ) : base(message, innerException)
        {
        }

        protected DataNotFound( SerializationInfo info, StreamingContext context ) : base(info, context)
        {
        }
    }
}