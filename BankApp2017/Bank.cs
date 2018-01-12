using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp2017
{
    class Bank
    {
        /***
         * 
         * This is a quick writeup of the bank application for reference. 
         * I need a way of accessing some bank functions so that we can make this easier. 
         * This will be deleted after I am done with the design.  
         * 
         * Struggling with design ideas related to the bank - user interaction. 
         * Should I store users in a list and then check that after I have logged in? I am thinking possibly so. 
         * So, store users in a list within Bank so they can see it. 
         * Also, store History in a list as well so it is easy to access. The class should just demonstrate the functionality. 
         * I'm overthinking. 
         * 
         * Bank needs these things:
         * Withdrawal
         * Deposit
         * ViewHistory
         * */

        List<Account> AccountList = new List<Account>();

        public void AddNewBankMember(Account account)
        {
            AccountList.Add(account);
        }


        public decimal Withdrawal(decimal balance, decimal amount)
        {
            return balance -= amount;
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            return balance += amount;
        }

        public string FormatMoney(decimal money)
        {
            return String.Format("{0:C}", money);
        }

        public void PrintAccountUsers()
        {
            foreach(var item in AccountList)
            {
                Console.WriteLine("First Name: " + item.FirstName + " Last Name: " + item.LastName);
            }
        }
    }
}
