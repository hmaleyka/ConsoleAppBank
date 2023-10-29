using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Consoleapp.Exceptions
{
    internal class InvalidAge : Exception
    {
        public InvalidAge() : base ("Age should be greater than 18") { }
    }
}
