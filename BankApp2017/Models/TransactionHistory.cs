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
        public decimal StartTransaction { get; set; }
        public decimal EndTransaction { get; set; }
    }
}
