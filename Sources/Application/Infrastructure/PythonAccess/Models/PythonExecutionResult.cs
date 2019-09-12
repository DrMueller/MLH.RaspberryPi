using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    public class PythonExecutionResult
    {
        public Maybe<string> ErrorMessage { get; }
        public Maybe<string> Result { get; }

        public PythonExecutionResult(Maybe<string> result, Maybe<string> errorMessage)
        {
            Guard.ObjectNotNull(() => result);
            Guard.ObjectNotNull(() => errorMessage);

            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}