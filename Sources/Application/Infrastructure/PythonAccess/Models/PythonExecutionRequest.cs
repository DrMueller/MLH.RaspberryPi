namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    internal sealed class PythonExecutionRequest : PythonRequest
    {
        public PythonExecutionRequest(string filePath, string methodName, params PythonArgument[] arguments) : base(filePath, methodName, arguments)
        {
        }
    }
}