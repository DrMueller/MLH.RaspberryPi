using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services
{
    internal interface IPythonExecutor
    {
        Task<PythonExecutionResult> ExecuteAsnc(PythonExecutionRequest request);
    }
}