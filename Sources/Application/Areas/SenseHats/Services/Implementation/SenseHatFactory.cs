using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Implementation;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services.Implementation
{
    internal class SenseHatFactory : ISenseHatFactory
    {
        public SenseHatFactory(IPythonExecutor pythonExecutor)
        {
            _pythonExecutor = pythonExecutor;
        }

        public SenseHat Create(string basePath)
        {
            var locator = new PythonFileLocator(basePath);
            var led = new LedMatrix(_pythonExecutor, locator);
            var senseHat = new SenseHat(led);

            return senseHat;
        }

        private readonly IPythonExecutor _pythonExecutor;
    }
}