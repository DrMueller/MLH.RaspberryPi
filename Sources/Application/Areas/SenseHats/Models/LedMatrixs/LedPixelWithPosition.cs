namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs
{
    public class LedPixelWithPosition
    {
        public int Column { get; }
        public LedPixel Pixel { get; }
        public int Row { get; }

        internal LedPixelWithPosition(int row, int column, LedPixel pixel)
        {
            Row = row;
            Column = column;
            Pixel = pixel;
        }
    }
}