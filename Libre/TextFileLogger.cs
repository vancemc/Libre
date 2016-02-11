
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Libre
{
    public class TextFileLogger : ILogger
    {
        private readonly string _filePath;

        private readonly string _logText;

        public TextFileLogger(string logText, string fullFilePath)
        {
            _logText = logText;
            _filePath = fullFilePath;
        }
        public void Log()
        {
            WriteToLog(_filePath, _logText);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteToLog(string fullFilePath, string logText)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fullFilePath, FileMode.Append, FileAccess.Write, FileShare.Read);

                using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    writer.Write(logText);
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Dispose();
            }
        }
    }
}
