using System;
using System.Text;

namespace Libre
{
    public class ConsoleLogger : ILogger
    {
        public object[] LogDataParams{ get; set; }

        private readonly Action<string, object[]> _stdOutFormattable;
        private readonly Action<string> _stdOut;

        public ConsoleLogger(params object[] logDataParams)
        {
            LogDataParams = logDataParams;

            _stdOut = Console.WriteLine;

            _stdOutFormattable = Console.WriteLine;
        }

        public void Log()
        {
            if (ContainsFormatReplacementTokens(LogDataParams))
            {
                string format = LogDataParams[0].ToString();

                var parameters = GetSubArry(1, LogDataParams);

                _stdOutFormattable(format, parameters);
            }
            else
            {
                if (LogDataParams != null && LogDataParams.Length > 0)
                {
                    string logData = ConvertObjectArrayToString(LogDataParams);

                    _stdOut(logData);
                }
            }
        }

        public static string ConvertObjectArrayToString(object[] objArray)
        {
            var sb = new StringBuilder();

            foreach (object obj in objArray)
            {
                sb.Append(obj);
            }

            return sb.ToString();
        }

        public bool ContainsFormatReplacementTokens(object[] logData)
        {
            bool result = false;

            if (logData != null)
            {
                if (logData.Length > 1 &&
                    (string.IsNullOrWhiteSpace(logData[0].ToString()) == false))
                {
                    if (logData[0].ToString().Contains("{"))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private object[] GetSubArry(ulong startIndex, object[] sourceArray)
        {
            long newLength = (sourceArray.Length - (long)startIndex);

            object[] result = new object[newLength];

            Array.Copy(sourceArray, (long)startIndex, result, 0, newLength);

            return result;
        }
    }
}
