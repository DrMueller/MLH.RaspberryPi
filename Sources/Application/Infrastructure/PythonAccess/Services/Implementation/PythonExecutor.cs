using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Servants;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Implementation
{
    internal class PythonExecutor : IPythonExecutor
    {
        private readonly IProcessStartInfoFactory _startInfoFactory;

        public PythonExecutor(IProcessStartInfoFactory startInfoFactory)
        {
            _startInfoFactory = startInfoFactory;
        }

        public async Task<PythonExecutionResult> ExecuteAsnc(PythonExecutionRequest request)
        {
            var startInfo = _startInfoFactory.CreateForExecution(request);

            using (var process = Process.Start(startInfo))
            {
                var errorString = await process.StandardError.ReadToEndAsync();
                string resultString = null;

                using (var reader = process.StandardOutput)
                {
                    resultString = await reader.ReadToEndAsync();
                    process.WaitForExit();
                }

                var err = string.IsNullOrEmpty(errorString) ? Maybe.CreateNone<string>() : Maybe.CreateSome(errorString);
                var res = string.IsNullOrEmpty(resultString) ? Maybe.CreateNone<string>() : Maybe.CreateSome(resultString);
                return new PythonExecutionResult(res, err);
            }
        }

        public void Listen(PythonListeningRequest request)
        {
            var startInfo = _startInfoFactory.CreateForListening(request);

            var process = Process.Start(startInfo);
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    request.DataReceived(e.Data);
                }
            };

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    request.ErrorReceived(e.Data);
                }
            };
        }
    }
}