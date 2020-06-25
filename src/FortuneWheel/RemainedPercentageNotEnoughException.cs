using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneWheel
{

    [Serializable]
    public class RemainedPercentageNotEnoughException : Exception
    {
        public RemainedPercentageNotEnoughException() { }
        public RemainedPercentageNotEnoughException(string message) : base(message) { }
        public RemainedPercentageNotEnoughException(string message, Exception inner) : base(message, inner) { }
        protected RemainedPercentageNotEnoughException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
