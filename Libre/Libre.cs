using System;
using System.Threading.Tasks;
using Libre;

namespace AppliedTestware
{
    public class Libre
    {
        public static void Log(ILogger logger, bool throwLogExceptions=false)
        {
            try
            {
                logger.Log();
            }
            catch (Exception ex)
            {
                if (throwLogExceptions)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void LogAsync(ILogger logger, bool ignoreExceptions = true)
        {
            // Await missing by design. Using Task.Run() is "fire and forget",
            // using an await here would be the same as a syncronous call.
            Task.Run(() => Log(logger, ignoreExceptions));
        }

        public static void LogToConsole(params object[] logInfo)
        {
            var consoleLogger = new ConsoleLogger(logInfo);

            Log(consoleLogger);
        }

        public static void LogTextToFileAsync(string text, string fullFilePath)
        {
            var textLogger = new TextFileLogger(text, fullFilePath);

            LogAsync(textLogger);
        }
    }
}
