using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Servants.Implementation
{
    internal class ProcessStartInfoFactory : IProcessStartInfoFactory
    {
        private readonly IFileSystem _fileSystem;

        public ProcessStartInfoFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public ProcessStartInfo CreateForExecution(PythonRequest request)
        {
            return new ProcessStartInfo
            {
                FileName = FindPythonExeFilePath(),
                Arguments = CreateArgumentsString(request),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
        }

        public ProcessStartInfo CreateForListening(PythonRequest request)
        {
            return new ProcessStartInfo
            {
                FileName = FindPythonExeFilePath(),
                Arguments = CreateArgumentsString(request),
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
        }

        private static string CreateArgumentsString(PythonRequest request)
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