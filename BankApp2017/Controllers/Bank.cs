using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp2017.Models;

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
        public Account CurrentUser = new Account();
        List<TransactionHistory> transactions = new List<TransactionHistory>();

        public void AddNewBankMember(Account account)
        {
            AccountList.Add(account);
        }

        public Account AccountAuth(string username, string password) //please re-write this. 
        {
            try
            {
                return AccountList.First(item => item.Username.Equals(username) && item.Password.Equals(password)); // NEEDS EXCEPTION HANDLING
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("There are no users to log in with!");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("User not found.");
            }
            return null;
        }

        public static string EnterPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;
            Console.WriteLine("Please enter password(characters allowed: a - z, A - Z, 0 - 9):");
            do
            {
                //TODO: add check to make sure that if the user presses the backspace key, it removes a character from the screen and the string
                key = Console.ReadKey(true);
                // The if statement below is checking the key pressed that it is within the ranges of 0 - 9, A - Z, and a - z.
                if ((((int)key.Key >= 48) && ((int)key.Key <= 57)) || (((int)key.Key >= 65) || ((int)key.Key <= 90)) || (((int)key.Key >= 97) && ((int)key.Key <= 122)))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine(); //This places the curser on a new line after password typing pr you end up at the end of the ***** section.
            var temp = password.ToString();
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(temp));
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
