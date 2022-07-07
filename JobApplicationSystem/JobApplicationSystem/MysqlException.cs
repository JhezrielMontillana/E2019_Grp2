using System;
using System.Runtime.Serialization;

namespace JobApplicationSystem
{
    [Serializable]
    internal class MysqlException : Exception
    {
        public MysqlException()
        {
        }

        public MysqlException(string message) : base(message)
        {
        }

        public MysqlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MysqlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int Number { get; internal set; }
    }
}