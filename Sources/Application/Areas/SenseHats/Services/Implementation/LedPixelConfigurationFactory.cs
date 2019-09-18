using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services.Implementation
{
    internal class LedPixelConfigurationFactory : ILedPixelConfigurationFactory
    {
        public LedPixelConfiguration CreateEmpty()
        {
            return new LedPixelConfiguration();
        }

        public LedPixelConfiguration CreateForNumber(short number, RgbColor foreground, RgbColor background)
        {
            Guard.That(() => number >= 0 && number <= 9, "Number must be between 0 and 9.");
            var config = CreateEmpty();
            config.SetAllColors(background);

            switch (number)
            {
                case 1:
                    {
                        config.ForPosition(2, 4).SetColor(foreground);
                        config.ForPosition(3, 4).SetColor(foreground);
                        config.ForPosition(3, 3).SetColor(foreground);
                        config.ForPosition(4, 4).SetColor(foreground);
                        config.ForPosition(5, 4).SetColor(foreground);
                        config.ForPosition(6, 4).SetColor(foreground);
                        config.ForPosition(7, 4).SetColor(foreground);
                        config.ForPosition(8, 3).SetColor(foreground);
                        config.ForPosition(8, 4).SetColor(foreground);
                        config.ForPosition(8, 5).SetColor(foreground);
                        break;
                    }
            }

            return config;
        }
    }
}