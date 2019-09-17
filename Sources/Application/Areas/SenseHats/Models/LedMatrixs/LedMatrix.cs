using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.LedMatrixs
{
    public class LedMatrix : Device
    {
        internal LedMatrix(IPythonExecutor executor, string scriptFilePath)
            : base(executor, scriptFilePath)
        {
        }

        public async Task ShowMessage(
            string message,
            float scrollSpeed = 0.1f,
            RgbColor textColor = null,
            RgbColor backgroundColor = null)
        {
            textColor = textColor ?? RgbColor.CreateWhite();
            backgroundColor = backgroundColor ?? RgbColor.CreateBlack();

            await ExecuteAsync(
                "showMessage",
                new PythonArgument(message, true),
                new PythonArgument(scrollSpeed),
                new PythonArgument(textColor.AsString()),
                new PythonArgument(backgroundColor.AsString()));
        }

        public async Task ShowPixels(LedPixelConfiguration pixelConfig)
        {
            var pixelStr = pixelConfig.AsString();
            await ExecuteAsync(
                "showPixels",
                new PythonArgument(pixelStr, true));
        }
    }
}