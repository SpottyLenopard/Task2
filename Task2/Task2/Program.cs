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
            
            User addedUser = new User("Ivanov", "Ivan", DateTime.Parse("2010/10/02"), "Kiev", "Gonchara 23", "87324232", 'M', "i.ivanov@gmail.com");

            try
            {
                addressBook.AddUser(addedUser);
            }
            catch (Exception ex)
            {
                consoleLogger.Error(ex.Message);
                fileLogger.Error(ex.Message);
            }


            User removedUser = new User("Petrov", "Ivan", DateTime.Parse("2010/10/02"), "Kiev", "Gonchara 23", "87324232", 'M', "i.petrov@gmail.com");

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

            FillAddressBook(addressBook);
            ShowUsersWithGoogleAccount(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowAdultsFromKiev(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowRecentlyAddedWomen(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowJanuaryBorns(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowGenderDic(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowFilteredUsers(addressBook, consoleLogger);
            consoleLogger.Debug("\n");
            ShowTodayBithDayUsers(addressBook, consoleLogger);
            Console.ReadLine();

        }

        public static void ShowUsersWithGoogleAccount(AddressBook ad, ILogger log)
        {
            log.Info("Gmail users:");
            if (ad != null)
                foreach (User u in ad.GetUsersWithGmailAccount())
                    log.Info(u.ToString());
                
        }

        public static void ShowAdultsFromKiev(AddressBook ad, ILogger log)
        {
            log.Info("Kiev Adults");
            if (ad != null)
                foreach (User u in ad.GetKyivAdultUsers())
                    log.Info(u.ToString());
        }

        public static void ShowRecentlyAddedWomen(AddressBook ad, ILogger log)
        {
            log.Info("Recently added women");
            if (ad != null)
                foreach (User u in ad.GetRecentlyAddedWomen())
                    log.Info(u.ToString());
        }

        public static void ShowJanuaryBorns(AddressBook ad, ILogger log)
        {
            log.Info("January born people");
            if (ad != null)
                foreach (User u in ad.GetJanuaryBornUsersWithPhoneAndAddress())
                    log.Info(u.ToString());
        }

        public static void ShowGenderDic(AddressBook ad, ILogger log)
        {
            log.Info("people by gender");
            if (ad != null)
            {
                foreach (User u in ad.GetUserDictionaryByGender()["man"])
                    log.Info(u.ToString());
                log.Info("next");
                foreach (User u in ad.GetUserDictionaryByGender()["woman"])
                    log.Info(u.ToString());
            }
        }

        public static void ShowFilteredUsers(AddressBook ad, ILogger log)
        {
            log.Info("filerted users");
            if (ad != null)
            {
                foreach (User u in ad.GetFilteredUsers(u =>u.City.ToUpperInvariant() == "KIEV",2,5))
                    log.Info(u.ToString());

            }
        }

        public static void ShowTodayBithDayUsers(AddressBook ad, ILogger log)
        {
            log.Info("today bithday users");
            if (ad != null)
            {
                foreach (User u in ad.GerUsersFromCertainCity("Dnepr")) 
                    log.Info(u.ToString());

            }
        }

        public static void FillAddressBook(AddressBook ad)
        {
            ad.AddUser(new User("Sidorova", "Svetlana", DateTime.Parse("1987/10/02"), "Kiev", "Gonchara 25", "87324232", 'F', "s.sid@gmail.com"));
            ad.AddUser(new User("Efimova", "Keti", DateTime.Parse("1967/10/02"), "Dnepr", "Gonchara 25", "87324232", 'F', "k.efi@gmail.com"));
            ad.AddUser(new User("Romov", "Stepan", DateTime.Parse("1967/01/02"), "Dnepr", "Gonchara 25", "87324232", 'M', "s.romov@gmail.com"));
            ad.AddUser(new User("Romova", "Lyuba", DateTime.Parse("1967/01/02"), "Dnepr", "", "87324232", 'F', "l.romova@mail.ru"));
            ad.AddUser(new User("Last", "Klava", DateTime.Parse("1967/01/02"), "Dnepr", "Ivana", "87324232", 'F', "k.Last@mail.ru"));
            ad.AddUser(new User("Lastov", "Klavdiy", DateTime.Parse("1967/05/31"), "Dnepr", "Ivana", "87324232", 'M', "k.Lastov@mail.ru"));
        }
    }
}
