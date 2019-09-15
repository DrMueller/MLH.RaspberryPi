using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.Services.Implementation
{
    internal class DevicePythonFileFactory : IDevicePythonFileFactory
    {
        private static readonly Assembly _thisAssembly = typeof(DevicePythonFileFactory).Assembly;
        private readonly IFileSystem _fileSystem;
        private readonly List<string> _resources;

        public DevicePythonFileFactory(IFileSystem fileSystem)
        {
            _resources = _thisAssembly
                .GetManifestResourceNames()
                .Where(f => f.ToUpperInvariant()
                .EndsWith(".py", StringComparison.OrdinalIgnoreCase)).ToList();

            _fileSystem = fileSystem;
        }

        public string CreateScriptFile(Type deviceType)
        {
            var tempPath = _fileSystem.Path.GetTempPath();
            var pythonFileName = $"{deviceType.FullName}.py";
            var filePath = _fileSystem.Path.Combine(tempPath, pythonFileName);

            var script = ReadPythonResourceScript(pythonFileName);
            _fileSystem.File.WriteAllText(filePath, script);

            return filePath;
        }

        private string ReadPythonResourceScript(string pythonFileName)
        {
            var foundPythonResources = _resources.Where(res => res == pythonFileName).ToList();
            Guard.That(() => foundPythonResources.Count == 1, $"Didn't find exactly one python resource for {pythonFileName}.");

            using (var stream = _thisAssembly.GetManifestResourceStream(foundPythonResources.Single()))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}