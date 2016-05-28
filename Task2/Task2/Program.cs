using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBooks;
using Logger;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            

            ILogger consoleLogger = LoggerFactory.GetLogger();
            ILogger fileLogger = LoggerFactory.GetLogger(LogWriterType.FileWriterType);

            AddressBookChangesHandler handler = new AddressBookChangesHandler(consoleLogger);

            consoleLogger.Debug("app started");
            fileLogger.Debug("app started");
            //ILogger fileLogger2 = LoggerFactory.GetLogger(LogWriterType.FileWriterType);

            //fileLogger.Info("app started");
            addressBook.UsedAdded += handler.LogAddUserChange;
            addressBook.UserRemoved += handler.LogRemoveUserChange;
            
            User addedUser = new User("Ivanov", "Ivan", DateTime.Parse("2010/10/02"), "Kyiv", "Gonchara 23", "87324232", 'M', "i.ivanov@gmail.com");

            try
            {
                addressBook.AddUser(addedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }


            User removedUser = new User("Petrov", "Ivan", DateTime.Parse("2010/10/02"), "Kyiv", "Gonchara 23", "87324232", 'M', "i.petrov@gmail.com");

            try
            { 
                addressBook.RemoveUser(removedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }

            try
            { 
            addressBook.AddUser(removedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }

            try
            { 
                addressBook.RemoveUser(removedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }

            try
            {
                addressBook.AddUser(addedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
