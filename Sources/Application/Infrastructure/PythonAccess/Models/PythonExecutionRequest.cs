using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    internal class PythonExecutionRequest
    {
        public PythonArgument[] Arguments { get; }
        public string FilePath { get; }
        public string MethodName { get; }

        public PythonExecutionRequest(string filePath, string methodName, params PythonArgument[] arguments)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            Guard.StringNotNullOrEmpty(() => methodName);

            FilePath = filePath;
            MethodName = methodName;
            Arguments = arguments;
        }
    }
}