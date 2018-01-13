using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BankApp2017
{
    class Account
    {
        private string _username;
        private string _password;
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private decimal _balance;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public decimal Balance { get => _balance; set => _balance = value; }

        //Please add a line here for the account history stored as a List type (should be empty to start)

        public void UpdateAccountDetails(string email, string fname, string lname, string phone)
        {
            Email = email;
            FirstName = fname;
            LastName = lname;
            Phone = phone;
        }

    }
}
