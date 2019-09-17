using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class WriteAllPixels : IConsoleCommand
    {
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Write all Pixels";
        public ConsoleKey Key => ConsoleKey.F5;

        public WriteAllPixels(ISenseHatFactory senseHatFactory)
        {
            _senseHatFactory = senseHatFactory;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var rndColor = RgbColor.CreateRandom();

            var config = new LedPixelConfiguration();
            config.SetAllColors(rndColor);

            await senseHat.LedMatrix.ShowPixels(config);
        }
    }
}