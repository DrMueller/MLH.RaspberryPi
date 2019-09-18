using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class WritePixels : IConsoleCommand
    {
        private readonly ILedPixelConfigurationFactory _ledPixelConfigFactory;
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Write Pixels";
        public ConsoleKey Key => ConsoleKey.F4;

        public WritePixels(
            ISenseHatFactory senseHatFactory,
            ILedPixelConfigurationFactory ledPixelConfigFactory)
        {
            _senseHatFactory = senseHatFactory;
            _ledPixelConfigFactory = ledPixelConfigFactory;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var rndColor = RgbColor.CreateRandom();

            var config = _ledPixelConfigFactory.CreateEmpty();
            config.ForPosition(1, 1).SetColor(rndColor);
            config.ForPosition(1, 8).SetColor(rndColor);
            config.ForPosition(8, 1).SetColor(rndColor);
            config.ForPosition(8, 8).SetColor(rndColor);

            await senseHat.LedMatrix.ShowPixels(config);
        }
    }
}