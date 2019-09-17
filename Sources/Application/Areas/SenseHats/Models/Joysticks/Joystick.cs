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
            var req = new PythonListeningRequest(
                _scriptFilePath,
                "listen",
                str => InputReceived(str, eventReceived),
                Maybe.CreateNone<Action<string>>());

            _executor.Listen(req);
        }

        public async Task SayHello()
        {
            var execResult = await ExecuteAsync("sayHello");
            execResult.Result.Evaluate(res => Console.WriteLine(res));
        }

        private static void InputReceived(string str, Action<JoystickEvent> callback)
        {
            Console.WriteLine(str);
            var splitted = str.Split(':');
            var act = splitted[0];
            var dir = splitted[1];

            var action = ParseAction(act);
            var direction = ParseDirection(dir);

            var joystickEvent = new JoystickEvent(action, direction);
            callback(joystickEvent);
        }

        private static JoystickAction ParseAction(string str)
        {
            switch (str.ToUpperInvariant())
            {
                case "PRESSED":
                    return JoystickAction.Pressed;

                case "RELEASED":
                    return JoystickAction.Released;

                case "HELD":
                    return JoystickAction.Held;

                default:
                    throw new ArgumentException($"Joystick Action {str} not found.");
            }
        }

        private static JoystickDirection ParseDirection(string str)
        {
            switch (str.ToUpperInvariant())
            {
                case "UP":
                    return JoystickDirection.Up;

                case "DOWN":
                    return JoystickDirection.Down;

                case "LEFT":
                    return JoystickDirection.Left;

                case "RIGHT":
                    return JoystickDirection.Right;

                case "MIDDLE":
                    return JoystickDirection.Middle;

                default:
                    throw new ArgumentException($"Joystick Direction {str} not found.");
            }
        }
    }
}