using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs
{
    public class LedPixelConfiguration
    {
        private readonly List<LedPixelWithPosition> _pixelsWithPositions;

        internal LedPixelConfiguration()
        {
            _pixelsWithPositions = new List<LedPixelWithPosition>();

            for (var row = 1; row <= 8; row++)
            {
                for (var column = 1; column <= 8; column++)
                {
                    _pixelsWithPositions.Add(new LedPixelWithPosition(row, column, new LedPixel()));
                }
            }
        }

        public LedPixel ForPosition(int row, int column)
        {
            Guard.That(() => row >= 1 && row <= 8, "Row must between 1 and 8.");
            Guard.That(() => column >= 1 && column <= 8, "Column must between 1 and 8.");

            return _pixelsWithPositions.Single(f => f.Row == row && f.Column == column).Pixel;
        }

        public void SetAllColors(RgbColor color)
        {
            _pixelsWithPositions.ForEach(pix => pix.Pixel.SetColor(color));
        }

        internal string AsString()
        {
            var sb = new StringBuilder();
            _pixelsWithPositions
                .OrderBy(pix => pix.Row)
                .ThenBy(pix => pix.Column)
                .ForEach(pix =>
                {
                    sb.Append(pix.Pixel.AsString());
                    sb.Append(",");
                });

            var str = sb.ToString();
            str = str.Substring(0, str.Length - 1);
            var result = $"[{str}]";
            return result;
        }
    }
}