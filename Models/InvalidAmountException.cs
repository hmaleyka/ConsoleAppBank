using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal class InvalidAmountException : Exception
    {

        public InvalidAmountException() : base(" the entering amount was invalid") { }
    }
}