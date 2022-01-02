using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ASS\n");
            string filesDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\TestHere";
            Console.WriteLine(filesDirectory);

            string pathToGenerated = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\GeneratedTests\\Tests";
            Console.WriteLine(pathToGenerated);
            if (!Directory.Exists(filesDirectory))
            {
                Console.WriteLine($"Couldn't find directory {filesDirectory}");
                return;
            }
            if (!Directory.Exists(pathToGenerated))
            {
                Directory.CreateDirectory(pathToGenerated);
            }

            var allFiles = Directory.GetFiles(filesDirectory);
            int maxThreads = GetNumberFromUser();
            var files = from file in allFiles
                        where file.Substring(file.Length - 3) == ".cs"
                        select file;
            GeneratorStarter manager = new GeneratorStarter();

            Task task = manager.Generate(files, pathToGenerated, maxThreads);
            task.Wait();
            Console.WriteLine("end.");
            Console.ReadKey();
        }

        private static int GetNumberFromUser()
        {
            int threadsNum;
            do
            {
                Console.WriteLine("Write max number of threads: ");
                string threads = Console.ReadLine();
                try
                {
                    threadsNum = int.Parse(threads);
                    return threadsNum;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\"" + threads + "\"" + " is not a number.");
                    continue;
                }
            } while (true);
        }
    }
}
