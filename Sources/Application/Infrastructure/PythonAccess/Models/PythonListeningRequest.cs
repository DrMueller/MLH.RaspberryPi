using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    internal sealed class PythonListeningRequest : PythonRequest
    {
        public PythonListeningRequest(
            string filePath,
            string methodName,
            Action<string> dataReceived,
            Maybe<Action<string>> errorReceivedMaybe,
            params PythonArgument[] arguments)
            : base(filePath, methodName, arguments)
        {
            Guard.ObjectNotNull(() => dataReceived);
            Guard.ObjectNotNull(() => errorReceivedMaybe);

            DataReceived = dataReceived;
            ErrorReceivedMaybe = errorReceivedMaybe;
        }

        public Action<string> DataReceived { get; }
        public Maybe<Action<string>> ErrorReceivedMaybe { get; }
    }
}
