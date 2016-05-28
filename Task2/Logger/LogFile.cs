using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LogFile : IDisposable
    {
        private static readonly Lazy<LogFile> _logFile = new Lazy<LogFile>(() => new LogFile());

        private TextWriter _textWriter;
        private LogFile()
        {
            try
            {
                if (_textWriter == null)
                    _textWriter = TextWriter.Synchronized(File.AppendText(Environment.CurrentDirectory + "\\Log.txt"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("{0} {1} : FATAL ERROR - Unable to create file log", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public static LogFile Instance { get { return _logFile.Value; } }
       
        public TextWriter TextWriter { get { return _textWriter; } }

        public void Dispose()
        {
            _textWriter.Dispose();
        }
    }
}
