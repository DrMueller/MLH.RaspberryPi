using System;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services
{
    internal interface IPythonFileLocator
    {
        string Locate(Type deviceType);
    }
}