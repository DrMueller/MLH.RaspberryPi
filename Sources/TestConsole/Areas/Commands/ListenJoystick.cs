using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class ListenJoystick : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Listen for Joystick";
        public ConsoleKey Key => ConsoleKey.F2;

        public ListenJoystick(ISenseHatFactory senseHatFactory, IConsoleWriter consoleWriter)
        {
            _senseHatFactory = senseHatFactory;
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();

            senseHat.Joystick.Listen(ev =>
            {
                _consoleWriter.WriteLine("Joystick-Action: " + ev.Action, foregroundColor: ConsoleColor.Green);
                _consoleWriter.WriteLine("Joystick-Direction: " + ev.Direction, foregroundColor: ConsoleColor.Green);
            });

            return Task.CompletedTask;
        }
    }
}