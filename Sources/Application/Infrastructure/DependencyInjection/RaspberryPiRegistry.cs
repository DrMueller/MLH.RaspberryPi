﻿using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services.Implementation;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.RaspberryPi.Infrastructure.DependencyInjection
{
    public class RaspberryPiRegistry : Registry
    {
        public RaspberryPiRegistry()
        {
            For<ISenseHatFactory>().Use<SenseHatFactory>().Singleton();
            For<IPythonExecutor>().Use<PythonExecutor>().Singleton();
        }
    }
}