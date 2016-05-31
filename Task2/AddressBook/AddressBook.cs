using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooks
{
    public class AddressBook
    {
        private List<User> _addressBookList;

        public AddressBook()
        {
            _addressBookList = new List<User>();
        }

        public delegate void AddressBookChangeHandler();

        public event AddressBookChangeHandler UsedAdded;
        public event AddressBookChangeHandler UserRemoved;

        public void AddUser(User user)
        {
            if (!_addressBookList.Contains(user))
            {
                _addressBookList.Add(user);
                if (UsedAdded != null)
                    UsedAdded();
            }
            else
                throw new Exception(string.Format("User {0} already in address book",user.ToString()));
        }

        public void RemoveUser(User user)
        {
            if (_addressBookList.Contains(user))
            {
                _addressBookList.Remove(user);
                if (UserRemoved != null)
                    UserRemoved();
            }
            else
                throw new Exception(string.Format("User {0} not found in address book", user.ToString()));

        }

        public List<User> GetUsersWithGmailAccount()
        {
            List<User> gmailUsers = new List<User>();
            if (_addressBookList.Count > 0)
                gmailUsers = _addressBookList.Where(x => x.Email.ToUpperInvariant().Contains("GMAIL.COM")).ToList<User>();

            return gmailUsers;
        }

        public List<User> GetRecentlyAddedWomen()
        {
            var res = from user in _addressBookList
                      where user.Gender == 'F' && user.DateAdded > DateTime.Today.AddDays(-10)
                      select user;

            return res != null ? res.ToList<User>() : new List<User>();             
        }

        public List<User> GetJanuaryBornUsersWithPhoneAndAddress()
        {
            List<User> januaryBornUsersWithPhoneAndAddress = new List<User>();
            if (_addressBookList.Count > 0)
                januaryBornUsersWithPhoneAndAddress = _addressBookList.Where(x => x.BirthDate.Month==1 &&
                                                                                    x.Address != string.Empty &&
                                                                                    x.PhoneNumber != string.Empty).OrderByDescending(x => x.LastName).ToList<User>();

            return januaryBornUsersWithPhoneAndAddress;
        }

        public Dictionary<string, List<User>> GetUserDictionaryByGender()
        {
            try
            {
                var genderDictionary = new Dictionary<string, List<User>>
                {
                    {"man",_addressBookList.Where(x => x.Gender =='M').ToList<User>() },
                    {"woman",_addressBookList.Where(x => x.Gender =='F').ToList<User>() }
                };

                return genderDictionary;
            }
            catch (Exception)
            {
                LoggerFactory.GetLogger().Error("can not create dictionary");
            }

            return new Dictionary<string, List<User>>();
        }

        public List<User> GetFilteredUsers(Func<User, bool> condition, int from, int to)
        {
            List<User> filteredUsers = new List<User>();

            if (_addressBookList.Count > 0)
                try
                {
                    filteredUsers = _addressBookList.Where(condition).Skip(from - 1).Take(to - from).ToList<User>();
                }
                catch
                {
                    LoggerFactory.GetLogger().Error("Unable to select requested range");
                }

            return filteredUsers;
        }

        public List<User> GerUsersFromCertainCity(string city)
        {
            var res = from user in _addressBookList
                      where user.City == city && user.BirthDate.Month == DateTime.Today.Month &&
                      user.BirthDate.Day == DateTime.Today.Day
                      select user;

            return res != null ? res.ToList<User>() : new List<User>();
        }

        public List<User> GetAddressBookList()
        {
            return _addressBookList;
        }


    }

    public static class AddressBookExtensions
    {
        public static IEnumerable<User> GetKyivAdultUsers(this AddressBook ad)
        {
            foreach (User u in ad.GetAddressBookList())
                if (u.BirthDate != null && u.City.ToUpperInvariant() != "KIEV" && u.BirthDate < DateTime.Now.Date.AddYears(-18))
                    yield return u;

        }
    }

}
