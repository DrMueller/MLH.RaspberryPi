using Mmu.Mlh.RaspberryPi.Areas.Common.Services.Implementation;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services.Implementation
{
    internal class SenseHatFactory : ISenseHatFactory
    {
        private readonly IPythonExecutor _pythonExecutor;

        public SenseHatFactory(IPythonExecutor pythonExecutor)
        {
            _pythonExecutor = pythonExecutor;
        }

        public SenseHat Create(string basePath)
        {
            var locator = new DevicePythonFileLocator(basePath);
            var led = new LedMatrix(_pythonExecutor, locator);
            var senseHat = new SenseHat(led);

            return senseHat;
        }
    }
}