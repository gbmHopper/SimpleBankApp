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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }

    }
}
