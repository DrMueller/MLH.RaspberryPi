using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.Common.Exceptions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions
{
    // https://github.com/astro-pi/python-sense-hat/tree/master/sense_hat
    public abstract class Device
    {
        internal Device(
            IPythonExecutor executor,
            IPythonFileLocator locator)
        {
            _executor = executor;
            _filePath = locator.Locate(GetType());
        }

        protected async Task ExecuteAsync(string methodName, params PythonArgument[] arguments)
        {
            var req = new PythonExecutionRequest(_filePath, methodName, arguments);
            var res = await _executor.ExecuteAsnc(req);

            res.ErrorMessage.Evaluate(
                whenSome: str =>
                {
                    throw new PythonException(str);
                });
        }

        private readonly IPythonExecutor _executor;
        private readonly string _filePath;
        private readonly IPythonFileLocator _locator;
    }
}