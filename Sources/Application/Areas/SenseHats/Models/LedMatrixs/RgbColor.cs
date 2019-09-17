using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs
{
    public class RgbColor
    {
        private readonly short _blue;
        private readonly short _green;
        private readonly short _red;

        public RgbColor(short red, short green, short blue)
        {
            Guard.That(() => red >= 0 && red <= 255, "Red has to be between 0 and 255.");
            Guard.That(() => green >= 0 && green <= 255, "Green has to be between 0 and 255.");
            Guard.That(() => blue >= 0 && blue <= 255, "Blue has to be between 0 and 255.");

            _red = red;
            _green = green;
            _blue = blue;
        }

        public static RgbColor CreateBlack()
        {
            return new RgbColor(0, 0, 0);
        }

        public static RgbColor CreateRandom()
        {
            var rnd = new Random();
            return new RgbColor(
                (short)rnd.Next(0, 255),
                (short)rnd.Next(0, 255),
                (short)rnd.Next(0, 255));
        }

        public static RgbColor CreateWhite()
        {
            return new RgbColor(255, 255, 255);
        }

        internal string AsString()
        {
            var result = $"[{_red},{_green},{_blue}]";
            return result;
        }
    }
}