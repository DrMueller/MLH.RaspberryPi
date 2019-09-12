using System;
using System.Runtime.Serialization;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.Exceptions
{
    [Serializable]
    public class PythonException : Exception
    {
        public PythonException()
        { }

        public PythonException(string message)
            : base(message)
        { }

        public PythonException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected PythonException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}