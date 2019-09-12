using System;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.Services
{
    internal interface IDevicePythonFileLocator
    {
        string LocatePythonFilePath(Type deviceType);
    }
}