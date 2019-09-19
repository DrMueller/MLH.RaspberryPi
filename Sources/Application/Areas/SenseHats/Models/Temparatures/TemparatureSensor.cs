using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Temparatures
{
    /// <summary>
    /// For some reason, this currently doesn't work, but just on the PI
    /// See also here: https://stackoverflow.com/questions/57980163/python-called-via-c-sharp-not-returning-value-when-in-infinite-loop
    /// </summary>
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
