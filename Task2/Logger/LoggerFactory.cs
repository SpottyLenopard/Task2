using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public enum LogWriterType
    {
        ConsoleWriterType,
        FileWriterType
    }
    public class LoggerFactory
    {
        public static ILogger GetLogger()
        {
            return new Logger();
        }

        public static ILogger GetLogger(LogWriterType logWriterType)
        {
            switch (logWriterType)
            {
                case LogWriterType.FileWriterType:
                    return new Logger(new FileLogWriter());
                default:
                    return new Logger();
            }


        }
    }
}
