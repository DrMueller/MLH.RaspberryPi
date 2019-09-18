using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    internal sealed class PythonListeningRequest : PythonRequest
    {
        public Action<string> DataReceived { get; }
        public Action<string> ErrorReceived { get; }

        public PythonListeningRequest(
            string filePath,
            string methodName,
            Action<string> dataReceived,
            Action<string> errorReceived,
            params PythonArgument[] arguments)
            : base(filePath, methodName, arguments)
        {
            Guard.ObjectNotNull(() => dataReceived);
            Guard.ObjectNotNull(() => errorReceived);

            DataReceived = dataReceived;
            ErrorReceived = errorReceived;
        }
    }
}