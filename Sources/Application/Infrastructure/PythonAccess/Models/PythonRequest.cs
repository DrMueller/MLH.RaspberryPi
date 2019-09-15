using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    internal abstract class PythonRequest
    {
        public PythonArgument[] Arguments { get; }
        public string FilePath { get; }
        public string MethodName { get; }

        public PythonRequest(string filePath, string methodName, params PythonArgument[] arguments)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            Guard.StringNotNullOrEmpty(() => methodName);

            FilePath = filePath;
            MethodName = methodName;
            Arguments = arguments;
        }
    }
}