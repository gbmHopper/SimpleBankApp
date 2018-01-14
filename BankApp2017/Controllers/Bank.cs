using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp2017.Models;

namespace BankApp2017
{
    class Bank
    {
        List<Account> AccountList = new List<Account>();
        List<TransactionHistory> history = new List<TransactionHistory>();
        public Account CurrentUser = new Account();


        public void AddNewBankMember(Account account)
        {
            history.Add(new TransactionHistory() //There may be a better way to do this. I am unsure of how atm.
            {
                Username = account.Username,
                Time = DateTime.Now,
                Description = "Withdrawal",
                Change = 0,
                Balance = account.Balance
            });
            AccountList.Add(account);
        }

        public Account AccountAuth(string username, string password) //please re-write this. 
        {
            try
            {
                return AccountList.First(item => item.Username.Equals(username) && item.Password.Equals(password)); // NEEDS EXCEPTION HANDLING
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("There are no users to log in with!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("User not found.");
            }
            return null;
        }

        /**
         * NOTE ABOUT AUTHENTICATION FOR THIS APPLICATION:
         * This program is currently using basic authentication (credentials are stored in base64 encoded fashion)
         * Keep in mind that THIS IS NOT A GOOD SECURITY PRACTICE as the level of authentication is weak, and very
         * very easy to crack. Typically businesses authenticate their users through a third party system like
         * OAuth or if in a corporate setting, their user list from their coporate domain using Windows authentication.
         * There are many ways to authenticate users, but for the sake of simplicity in my program I am taking an easier path. 
         * 
         * Authentication of users is always something that should be taken seriously in order to keep customer's data safe. 
         * 
         **/          
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
            if (!balance.Equals(0))
            {
                balance -= amount;
            }
            history.Add(new TransactionHistory()
            {
                Username = CurrentUser.Username,
                Time = DateTime.Now,
                Description = "Withdrawal",
                Change = Decimal.Negate(amount),
                Balance = balance
            });
            return balance;
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            history.Add(new TransactionHistory()
            {
                Username = CurrentUser.Username,
                Time = DateTime.Now,
                Description = "Deposit",
                Change = Decimal.Negate(amount),
                Balance = balance
            });
            return balance;
        }

        public string PrintTransactionHistory()
        {
            StringBuilder build = new StringBuilder();
            build.Append(String.Format("{0, -17} {1, -17} {2, -17} {3, -17} {4, 17}\n", "Username", "Description", "Change", "Balance", "Time"));
            foreach (var trans in history.Where(item => item.Username.Equals(CurrentUser.Username)))
            {
                build.Append(String.Format("{0, -17} {1, -17} {2, -17} {3, -17} {4, 17}\n", trans.Username, trans.Description, FormatMoney(trans.Change), FormatMoney(trans.Balance), trans.Time)); 
            }
            return build.ToString();
        }

        public string FormatMoney(decimal money)
        {
            return String.Format("{0:C}", money);
        }

        public string PrintAccountUsers()
        {
            StringBuilder build = new StringBuilder();
            foreach (var item in AccountList)
            {
                build.Append("First Name: " + item.Username + " Last Name: " + item.Email);
            }
            return build.ToString();
        }
    }
}
