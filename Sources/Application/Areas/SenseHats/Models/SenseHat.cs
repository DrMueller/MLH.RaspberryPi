using System.Device.Gpio;
using System.Device.I2c;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models
{
    internal class SenseHat
    {
        private const int DeviceAddress = 0x46;

        public SenseHat()
        {
            var controller = new GpioController(PinNumberingScheme.Board);

            var tra = new I2cConnectionSettings(2, DeviceAddress);
            var con = I2cDevice.Create(tra);
        }
    }
}