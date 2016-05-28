using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger
    {
        void Info(string msg);
        void Debug(string msg);
        void Warning(string msg);
        void Error(string msg);
    }
}
