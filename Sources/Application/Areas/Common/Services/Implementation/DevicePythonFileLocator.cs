using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.Services.Implementation
{
    internal class DevicePythonFileLocator : IDevicePythonFileLocator
    {
        private readonly string _basePath;

        internal DevicePythonFileLocator(string basePath)
        {
            _basePath = basePath;
        }

        public string LocatePythonFilePath(Type deviceType)
        {
            var pythonFileName = $"{deviceType.Name}.py";
            var splittedName = deviceType.Namespace.Split('.').ToList();
            var assemblyName = deviceType.Assembly.GetName().Name.Split('.');

            splittedName.RemoveRange(0, assemblyName.Count());

            var allparts = new List<string>
            {
                _basePath
            };

            splittedName.ForEach(f => allparts.Add(f));
            allparts.Add(pythonFileName);

            var path = Path.Combine(allparts.ToArray());
            return path;
        }
    }
}