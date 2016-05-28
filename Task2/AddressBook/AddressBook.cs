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

    }
}
