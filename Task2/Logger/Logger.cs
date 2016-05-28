using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : ILogger
    {
        private ILogWriter _logWriter;

        public Logger()
        {
            _logWriter = new ConsoleLogWriter();
        }

        public Logger(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public void Info(string msg)
        {
            Log("Info", msg);
        }

        public void Debug(string msg)
        {
            Log("Debug", msg);
        }

        public void Warning(string msg)
        {
            Log("Warning", msg);
        }

        public void Error(string msg)
        {
            Log("Error", msg);
        }

        private void Log(string lvl, string msg)
        {
            _logWriter.Log(lvl, msg);
        }

    }
}
