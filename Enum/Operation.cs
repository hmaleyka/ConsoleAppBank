using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bank.Models
{
    internal enum Operation
    {
        CreateAccount = 1,
        DepositMoney,
        Withdrawmoney,
        ListTransactions,
        ListAccounts,
        TransferMoney,
        CurrencyConversion,
        Exit
    }
}