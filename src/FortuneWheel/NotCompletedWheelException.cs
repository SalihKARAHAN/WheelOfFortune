using System;
using System.Runtime.Serialization;

namespace FortuneWheel
{
    [Serializable]
    internal class NotCompletedWheelException : Exception
    {
        public NotCompletedWheelException()
        {
        }

        public NotCompletedWheelException(string message) : base(message)
        {
        }

        public NotCompletedWheelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCompletedWheelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}