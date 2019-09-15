using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Joysticks;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Temparatures;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    public class SenseHat
    {
        public Joystick Joystick { get; }
        public LedMatrix LedMatrix { get; }
        public TemparatureSensor TemparatureSensor { get; }

        public SenseHat(
            LedMatrix ledMatrix,
            Joystick joystick,
            TemparatureSensor temparatureSensor)
        {
            Guard.ObjectNotNull(() => ledMatrix);
            Guard.ObjectNotNull(() => joystick);
            Guard.ObjectNotNull(() => temparatureSensor);

            LedMatrix = ledMatrix;
            Joystick = joystick;
            TemparatureSensor = temparatureSensor;
        }
    }
}