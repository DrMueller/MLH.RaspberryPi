﻿using System;
using System.IO;
using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole
{
    public static class Program
    {
        public static void Main()
        {
            var config = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(config);

            var senseHatFactory = container.GetInstance<ISenseHatFactory>();
            var senseHat = senseHatFactory.Create(GetCodeBasePath());

            Task.WaitAll(Task.Run(async () =>
            {
                ////var textColor = RedGreenBlue.CreateBlack();
                ////var backgroumd = RedGreenBlue.CreateWhite();
                ////await senseHat.LedMatrix.ShowMessage("Hello World!", 1, textColor, backgroumd);

                senseHat.Joystick.Listen(ev =>
                {
                    Console.WriteLine(ev.Action);
                    Console.WriteLine(ev.Direction);
                });
            }));

            Console.WriteLine("Tra");
            Console.ReadKey();
        }

        private static string GetCodeBasePath()
        {
            var codeBase = typeof(Program).Assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);

            return result;
        }
    }
}