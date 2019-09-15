using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    public class Joystick : Device
    {
        internal Joystick(IPythonExecutor executor, string scriptFilePath) : base(executor, scriptFilePath)
        {
        }

        public async Task SayHello()
        {
            await ExecuteAsync("sayHello");
        }
    }
}