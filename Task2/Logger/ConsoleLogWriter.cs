using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLogWriter : ILogWriter
    {
        public void Log(string lvl, string msg)
        {
            Console.WriteLine(string.Format("{0} {1} : {2} - {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), lvl, msg));
        }
    }
}
