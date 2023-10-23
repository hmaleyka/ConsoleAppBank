using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal class AccountNotFoundException : Exception
    {

        public AccountNotFoundException() : base("the entering account is invalid") { }
    }
}