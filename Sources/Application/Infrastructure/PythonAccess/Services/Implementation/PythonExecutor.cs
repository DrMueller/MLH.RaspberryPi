using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Implementation
{
    internal class PythonExecutor : IPythonExecutor
    {
        private readonly IFileSystem _fileSystem;

        public PythonExecutor(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<PythonExecutionResult> ExecuteAsnc(PythonExecutionRequest request)
        {
            var pythonFilePath = FindPythonExeFilePath();
            var args = CreateArgumentsString(request);

            var start = new ProcessStartInfo
            {
                FileName = pythonFilePath,
                Arguments = args,
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
                sb.Append(arg.AsString());
                sb.Append(" ");
            }

            var result = sb.ToString();
            return result;
        }

        private string FindPythonExeFilePath()
        {
            var possibleFilePaths = new string[]
            {
                @"C:\Users\mlm\AppData\Local\Programs\Python\Python37-32\python.exe",
                @"C:\WINDOWS\py.exe",
                "/usr/bin/python"
            };

            var existingPythonPath = possibleFilePaths.FirstOrDefault(fp => _fileSystem.File.Exists(fp));
            Guard.That(() => existingPythonPath != null, "No python path found.");

            return existingPythonPath;
        }
    }
}