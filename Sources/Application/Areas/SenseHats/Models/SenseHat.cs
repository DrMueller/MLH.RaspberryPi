using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    public class SenseHat
    {
        public Joystick Joystick { get; }
        public LedMatrix LedMatrix { get; }

        public SenseHat(LedMatrix ledMatrix, Joystick joystick)
        {
            Guard.ObjectNotNull(() => ledMatrix);
            Guard.ObjectNotNull(() => joystick);

            LedMatrix = ledMatrix;
            Joystick = joystick;
        }
    }
}