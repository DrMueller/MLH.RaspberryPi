﻿using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace Mmu.Mlh.RaspberryPi.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<TestConsoleRegistry>();
                scanner.AddAllTypesOf<IConsoleCommand>();
            });
        }
    }
}