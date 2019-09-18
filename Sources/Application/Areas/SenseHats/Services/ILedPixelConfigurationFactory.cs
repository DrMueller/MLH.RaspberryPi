using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services
{
    public interface ILedPixelConfigurationFactory
    {
        LedPixelConfiguration CreateEmpty();

        LedPixelConfiguration CreateForNumber(short number, RgbColor foreground, RgbColor background);
    }
}