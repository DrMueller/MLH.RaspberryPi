using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Temparatures
{
    public class TemparatureSensor : Device
    {
        internal TemparatureSensor(IPythonExecutor executor, string scriptFilePath) : base(executor, scriptFilePath)
        {
        }

        public async Task<Temparature> ReadTemparature()
        {
            var execResult = await ExecuteAsync("readTemparature");
            var temparatureString = execResult.Result.Reduce(string.Empty);

            return Temparature.Parse(temparatureString);
        }
    }
}
