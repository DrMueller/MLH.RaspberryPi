using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services
{
    public interface ISenseHatFactory
    {
        SenseHat Create(string basePath);
    }
}