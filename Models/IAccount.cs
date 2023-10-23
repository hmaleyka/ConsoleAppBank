using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal class IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string CurrencyType { get; set; }



        void Deposit(decimal amount)
        {

        }

        void Withdraw(decimal amount)
        {

        }


    }
}
