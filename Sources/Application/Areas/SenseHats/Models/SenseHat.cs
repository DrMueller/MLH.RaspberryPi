using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    public class SenseHat
    {
        public LedMatrix LedMatrix { get; }

        public SenseHat(LedMatrix ledMatrix)
        {
            Guard.ObjectNotNull(() => ledMatrix);
            LedMatrix = ledMatrix;
        }
    }
}