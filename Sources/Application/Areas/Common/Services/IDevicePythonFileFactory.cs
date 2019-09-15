using System;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.Services
{
    internal interface IDevicePythonFileFactory
    {
        string CreateScriptFile(Type deviceType);
    }
}