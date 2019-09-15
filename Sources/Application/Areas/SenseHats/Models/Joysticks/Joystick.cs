using System;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Joysticks
{
    public class Joystick : Device
    {
        private readonly IPythonExecutor _executor;
        private readonly string _scriptFilePath;

        internal Joystick(IPythonExecutor executor, string scriptFilePath) : base(executor, scriptFilePath)
        {
            _executor = executor;
            _scriptFilePath = scriptFilePath;
        }

        public void Listen(Action<JoystickEvent> eventReceived)
        {
            var req = new PythonListeningRequest(_scriptFilePath, "getEvents", InputReceived, Maybe.CreateNone<Action<string>>());
            _executor.Listen(req);
        }

        public async Task SayHello()
        {
            var execResult = await ExecuteAsync("sayHello");
            execResult.Result.Evaluate(res => Console.WriteLine(res));
        }

        private void InputReceived(string str)
        {
            Console.WriteLine(str);
            //var splitted = str.Split(':');
            //var act = splitted[0];
            //var dir = splitted[1];
        }
    }
}