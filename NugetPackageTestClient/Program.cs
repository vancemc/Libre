using System;
using System.Diagnostics;
using Libre;

namespace TestClientApp
{
    using AppliedTestware;

    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            var go = Stopwatch.StartNew();

            //await Task.Run(() =>
            //{
            Libre.LogToConsole("Log to file async:");

            for (int i = 0; i < 5000; ++i)
            {
                Libre.LogTextToFileAsync(DateTime.Now + " - test " + i.ToString() + "\r\n", @"c:\test.txt");
            }

            Libre.LogToConsole("test one two three");

            Libre.LogToConsole("test ", "four ", "five ", "six ");

            Libre.LogToConsole("test {0},{1},{2}", 7, 8, 9);

            Libre.LogToConsole("Log syncronous:");

            for (int i = 0; i < 50; ++i)
            {
                var consoleLogger = new ConsoleLogger(i);

                Libre.Log(consoleLogger);
            }

            Libre.LogToConsole("Log async:");

            for (int i = 0; i < 50; ++i)
            {
                var consoleLogger = new ConsoleLogger(i);

                Libre.LogAsync(consoleLogger);
            }
            //});

            go.Stop();

            Console.WriteLine("Elapsed time in milliseconds: {0}", go.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
