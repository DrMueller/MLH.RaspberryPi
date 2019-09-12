using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Implementation
{
    internal class PythonExecutor : IPythonExecutor
    {
        public async Task<PythonExecutionResult> ExecuteAsnc(PythonExecutionRequest request)
        {
            var pythonFilePath = FindPythonExeFilePath();

            var start = new ProcessStartInfo
            {
                FileName = pythonFilePath,
                Arguments = CreateArgumentsString(request),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (var process = Process.Start(start))
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

        private static string CreateArgumentsString(PythonExecutionRequest request)
        {
            var sb = new StringBuilder();
            sb.Append(request.FilePath);
            sb.Append(" ");

            sb.Append(request.MethodName);
            sb.Append(" ");

            foreach (var arg in request.Arguments)
            {
                var val = arg.Value;
                if (arg.Escape)
                {
                    val = string.Format("\"{0}\"", val);
                }

                sb.Append(val);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        private string FindPythonExeFilePath()
        {
            return @"C:\Users\mlm\AppData\Local\Programs\Python\Python37-32\python.exe";
        }
    }
}