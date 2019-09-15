using Mmu.Mlh.RaspberryPi.Areas.Common.Services;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services.Implementation
{
    internal class SenseHatFactory : ISenseHatFactory
    {
        private readonly IDevicePythonFileFactory _devicePythonFileFactory;
        private readonly IPythonExecutor _pythonExecutor;

        public SenseHatFactory(IPythonExecutor pythonExecutor, IDevicePythonFileFactory devicePythonFileFactory)
        {
            _pythonExecutor = pythonExecutor;
            _devicePythonFileFactory = devicePythonFileFactory;
        }

        public SenseHat Create(string basePath)
        {
            var ledMatrixScriptPath = _devicePythonFileFactory.CreateScriptFile(typeof(LedMatrix));
            var led = new LedMatrix(_pythonExecutor, ledMatrixScriptPath);

            var joystickScriptPath = _devicePythonFileFactory.CreateScriptFile(typeof(Joystick));
            var joystick = new Joystick(_pythonExecutor, joystickScriptPath);

            var senseHat = new SenseHat(led, joystick);
            return senseHat;
        }
    }
}