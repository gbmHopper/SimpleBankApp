using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp2017.Models
{
    class TransactionHistory
    {
        public string Username { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public decimal Change { get; set; }
        public decimal Balance { get; set; }

    }
}
