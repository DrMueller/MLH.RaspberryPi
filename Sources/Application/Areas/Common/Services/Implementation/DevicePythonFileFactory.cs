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
        private readonly object _lock = new object();
        private List<IFileInfo> _files = new List<IFileInfo>();
        private bool _initialized = false;
        private List<string> _resources;

        public DevicePythonFileFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void AssureInitialized()
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (!_initialized)
                    {
                        InitializeResources();
                        RecreateScriptFiles();
                        _initialized = true;
                    }
                }
            }
        }

        public string CreateScriptFile(Type deviceType)
        {
            var pythonFileName = $"{deviceType.FullName}.py";
            return _files.Single(f => f.Name == pythonFileName).FullName;
        }

        private void InitializeResources()
        {
            _resources = _thisAssembly
                            .GetManifestResourceNames()
                            .Where(f => f.ToUpperInvariant()
                            .EndsWith(".py", StringComparison.OrdinalIgnoreCase)).ToList();
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

        private void RecreateScriptFiles()
        {
            _files = _resources.Select(resource =>
            {
                var tempPath = _fileSystem.Path.GetTempPath();
                var filePath = _fileSystem.Path.Combine(tempPath, resource);

                if (_fileSystem.File.Exists(filePath))
                {
                    _fileSystem.File.Delete(filePath);
                }

                var script = ReadPythonResourceScript(resource);
                _fileSystem.File.WriteAllText(filePath, script);

                return _fileSystem.FileInfo.FromFileName(filePath);
            }).ToList();
        }
    }
}