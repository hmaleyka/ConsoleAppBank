using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Consoleapp.Exceptions
{
    internal class InvalidID : Exception
    {
        public InvalidID() : base ("ID should be greater than 0, create account again:") { }
    }
}
