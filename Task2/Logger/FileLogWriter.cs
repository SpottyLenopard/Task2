using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogWriter : ILogWriter
    {
        private LogFile _logFile;

        public FileLogWriter()
        {
            _logFile = LogFile.Instance;
        }
        public void Log(string lvl, string msg)
        {
           _logFile.TextWriter.WriteLine(string.Format("{0} {1} : {2} - {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), lvl, msg));
           _logFile.TextWriter.Flush();
        }
    }
}
