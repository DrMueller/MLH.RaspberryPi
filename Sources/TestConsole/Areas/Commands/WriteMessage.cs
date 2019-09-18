using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class WriteMessage : IConsoleCommand
    {
        private readonly ISenseHatFactory _senseHatFactory;

        public string Description => "Write message to LED";
        public ConsoleKey Key => ConsoleKey.F1;

        public WriteMessage(ISenseHatFactory senseHatFactory)
        {
            _senseHatFactory = senseHatFactory;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var foregroundPink = new RgbColor(255, 0, 255);
            var backgroundDarkGreen = new RgbColor(0, 128, 64);

            await senseHat.LedMatrix.ShowMessage("Hello World", 2f, foregroundPink, backgroundDarkGreen);
        }
    }
}