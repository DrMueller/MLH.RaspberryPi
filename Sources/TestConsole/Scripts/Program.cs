using System;
using System.IO;
using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Areas.SenseHats.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Mlh.RaspberryPi.TestConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(config);

            var senseHatFactory = container.GetInstance<ISenseHatFactory>();
            var senseHat = senseHatFactory.Create(GetCodeBasePath());

            Task.WaitAll(Task.Run(async () =>
            {
                await senseHat.LedMatrix.ShowMessage("Hello World!");
            }));

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

        //private static void Main(string[] args)
        //{
        //    var config = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
        //    var container = ContainerInitializationService.CreateInitializedContainer(config);
        //    var executor = container.GetInstance<IPythonExecutor>();

        //    var filePath = @"C:\MyGit\Personal\MLH\MLH.RaspberryPi\Sources\TestConsole\Scripts\hello.py";
        //    var arg = new PythonArgument[]
        //    {
        //        new PythonArgument("I am", true),
        //        new PythonArgument("here", false)
        //    };

        //    var req = new PythonExecutionRequest(filePath, "showMessage", arg);
        //    var res = executor.ExecuteAsnc(req).Result;

        //    res.ErrorMessage.Evaluate(
        //        whenSome: (str) =>
        //        {
        //            Console.WriteLine("error Message: " + str);
        //        },
        //        whenNone: () =>
        //         {
        //             Console.WriteLine("No error Message");
        //         });

        //    res.Result.Evaluate(
        //        whenSome: (str) =>
        //        {
        //            Console.WriteLine("Result: " + str);
        //        },
        //        whenNone: () =>
        //        {
        //            Console.WriteLine("No Result");
        //        });

        //    Console.ReadKey();
        //}
    }
}