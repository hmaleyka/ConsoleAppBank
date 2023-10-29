using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("the funds are exception") { }

    }
}
