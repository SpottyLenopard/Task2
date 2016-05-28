using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Task2
{
    class AddressBookChangesHandler
    {
        ILogger _logger;
        public AddressBookChangesHandler(ILogger logger)
        {
            _logger = logger;
        }
        public void LogAddUserChange()
        {
            _logger.Info("User added");
        }

        public void LogRemoveUserChange()
        {
            _logger.Info("User removed");
        }
    }
}
