using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooks
{
    public class User : IEquatable<User>
    {
        #region Public properties

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateAdded { get; private set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }

        #endregion Public properties

        #region Constructors

        public User(string lastName, string firstName, DateTime birthDate, string city, string address, string phoneNumber, char gender, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            DateAdded = DateTime.Now;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
        }

        #endregion Constructors

        #region IEquatable

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            User user = obj as User;
            if (user == null) return false;
            else return Equals(user);
        }

        public bool Equals(User user)
        {
            if (user == null) return false;
            return Equals(this, user);
        }

        public static bool Equals(User user1, User user2)
        {
            if (user1 == null || user2 == null) return false;

            return user1.FirstName.Equals(user2.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                user1.LastName.Equals(user2.LastName, StringComparison.InvariantCultureIgnoreCase) &&
                user1.Email.Equals(user2.Email, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} with email :{2}", FirstName, LastName, Email);
        }

        #endregion IEquatable
    }
}
