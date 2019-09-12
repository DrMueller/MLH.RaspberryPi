using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    public class LedMatrix : Device
    {
        public async Task ShowMessage(string message)
        {
            await ExecuteAsync(
                "showMessage",
                new PythonArgument(message, false));
        }

        internal LedMatrix(IPythonExecutor executor, IPythonFileLocator locator) : base(executor, locator)
        {
        }
    }
}