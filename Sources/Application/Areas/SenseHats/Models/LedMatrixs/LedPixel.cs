namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs
{
    public class LedPixel
    {
        private RgbColor _color;

        public LedPixel()
        {
            _color = RgbColor.CreateWhite();
        }

        public void SetColor(RgbColor color)
        {
            _color = color;
        }

        internal string AsString()
        {
            return _color.AsString();
        }
    }
}