using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal class IAccount
    {
        public static int _id {  get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string CurrencyType { get; set; }
        public int Age { get; set; }

        public IAccount()
        {
            
            _id++;
            AccountId = _id;
        }


        void Deposit(decimal amount)
        {

        }

        void Withdraw(decimal amount)
        {

        }


    }
}
