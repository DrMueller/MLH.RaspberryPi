using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class WritePixels : IConsoleCommand
    {
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Write Pixels";
        public ConsoleKey Key => ConsoleKey.F4;

        public WritePixels(ISenseHatFactory senseHatFactory)
        {
            _senseHatFactory = senseHatFactory;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var rndColor = RgbColor.CreateRandom();

            var cnfconfig = new LedPixelConfiguration();
            cnfconfig.ForPosition(1, 1).SetColor(rndColor);
            cnfconfig.ForPosition(1, 8).SetColor(rndColor);
            cnfconfig.ForPosition(8, 1).SetColor(rndColor);
            cnfconfig.ForPosition(8, 8).SetColor(rndColor);

            await senseHat.LedMatrix.ShowPixels(cnfconfig);
        }
    }
}