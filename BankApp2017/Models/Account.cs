﻿using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BankApp2017.Models
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public Account() { }

        public Account(string username, string password, string email, decimal balance)
        {
            Username = username;
            Password = password;
            Email = email;
            Balance = balance;
        }
    }
}
