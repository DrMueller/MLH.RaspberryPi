using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class ListenJoystick : IConsoleCommand
    {
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Listen for Joystick";
        public ConsoleKey Key => ConsoleKey.F2;

        public ListenJoystick(ISenseHatFactory senseHatFactory)
        {
            _senseHatFactory = senseHatFactory;
        }

        public Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();

            senseHat.Joystick.Listen(ev =>
            {
                Console.WriteLine(ev.Action);
                Console.WriteLine(ev.Direction);
            });

            return Task.CompletedTask;
        }
    }
}