using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class ReadTemparature : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Read Temparature";
        public ConsoleKey Key => ConsoleKey.F3;

        public ReadTemparature(ISenseHatFactory senseHatFactory, IConsoleWriter consoleWriter)
        {
            _senseHatFactory = senseHatFactory;
            _consoleWriter = consoleWriter;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var temparature = await senseHat.TemparatureSensor.ReadTemparature();
            _consoleWriter.WriteLine(temparature.AsDescription(), foregroundColor: ConsoleColor.Green);
        }
    }
}