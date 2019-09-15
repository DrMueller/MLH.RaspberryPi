using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
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
            RedGreenBlue textColor = null,
            RedGreenBlue backgroundColor = null)
        {
            textColor = textColor ?? RedGreenBlue.CreateWhite();
            backgroundColor = backgroundColor ?? RedGreenBlue.CreateBlack();

            await ExecuteAsync(
                "showMessage",
                new PythonArgument(message, true),
                new PythonArgument(scrollSpeed),
                new PythonArgument(textColor.AsString()),
                new PythonArgument(backgroundColor.AsString()));
        }
    }
}