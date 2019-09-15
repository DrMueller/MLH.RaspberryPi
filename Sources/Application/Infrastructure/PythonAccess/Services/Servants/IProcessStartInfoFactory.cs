using System.Diagnostics;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Servants
{
    internal interface IProcessStartInfoFactory
    {
        ProcessStartInfo CreateForExecution(PythonRequest request);

        ProcessStartInfo CreateForListening(PythonRequest request);
    }
}