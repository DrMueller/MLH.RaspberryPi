using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Areas.Commands
{
    public class WriteNumber : IConsoleCommand
    {
        private readonly ILedPixelConfigurationFactory _ledPixelConfigFactory;
        private readonly ISenseHatFactory _senseHatFactory;
        public string Description => "Write number";
        public ConsoleKey Key => ConsoleKey.F5;

        public WriteNumber(
            ISenseHatFactory senseHatFactory,
            ILedPixelConfigurationFactory ledPixelConfigFactory)
        {
            _senseHatFactory = senseHatFactory;
            _ledPixelConfigFactory = ledPixelConfigFactory;
        }

        public async Task ExecuteAsync()
        {
            var senseHat = _senseHatFactory.Create();
            var foregroundPink = new RgbColor(255, 0, 255);
            var config = _ledPixelConfigFactory.CreateForNumber(
                1,
                foregroundPink,
                RgbColor.CreateBlack());

            await senseHat.LedMatrix.ShowPixels(config);
        }
    }
}