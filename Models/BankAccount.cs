using Bank.Consoleapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp.Bank.Models
{
    internal class BankAccount : IAccount
    {
        private string[] account { get; set; }


        IAccount[] accounts = new IAccount[0];
        Transaction[] transactions = new Transaction[0];

        public BankAccount(int accountId, string accountType, string currencyType)
        {
            AccountId = accountId;
            AccountType = accountType;
            CurrencyType = currencyType;
        }
        public void CreateAccount(AccountType accountType, CurrencyType currencyType)
        {
            bool check;
            Console.WriteLine("let's create account for you:");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("create the account ID:");
            int accountid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"New account created with Account ID: {accountid}");
            string accounttype = accountType.ToString();

            string currencytype = currencyType.ToString();

            IAccount account = new IAccount()
            {
                AccountId = accountid,
                AccountType = accounttype,
                CurrencyType = currencytype,
            };
            Array.Resize(ref accounts, accounts.Length + 1);
            accounts[accounts.Length - 1] = account;
        }
        public void DepositMoney(string id, decimal amount)
        {
            bool correctInfo = false;
            int account1 = int.Parse(id);

            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            for (int i = 0; i < accounts.Length; i++)
            {
                if (account1 == accounts[i].AccountId)
                {


                    correctInfo = true;
                    break;

                }
            }
            if (!correctInfo)
            {
                throw new AccountNotFoundException();
            }

            if (account1 == null)
            {
                throw new AccountNotFoundException();
            }

            decimal amount1 = Convert.ToDecimal(amount);

            accounts[account1 - 1].Balance += amount;

            Console.WriteLine("the money was deposited on your amount");
            Transaction depositTransaction = new Transaction
            {
                TransactionId = account1,
                Amount = amount1,
                TransactionDate = DateTime.Now,
                TransactionType = Operation.DepositMoney
            };
            Array.Resize(ref transactions, transactions.Length + 1);
            transactions[transactions.Length - 1] = depositTransaction;

        }
        public void WithdrawMoney(int accountId, decimal amount)
        {
            int accountId1 = accountId;
            decimal amount1 = Convert.ToDecimal(amount);
            if (amount <= 0 || amount > accounts[accountId1 - 1].Balance)
            {
                throw new InvalidAmountException();
            }

            //Balance -= amount1;
            Transaction withdrawTransaction = new Transaction
            {
                TransactionId = accountId1,
                Amount = amount,
                TransactionDate = DateTime.Now,
                TransactionType = Operation.Withdrawmoney
            };
            Array.Resize(ref transactions, transactions.Length + 1);
            transactions[transactions.Length - 1] = withdrawTransaction;


            accounts[accountId1 - 1].Balance -= amount1;

        }

        public void TransferMoney(int fromAccountId, int toAccountId, decimal transferAmount)
        {

            if (fromAccountId < 0 || fromAccountId > accounts.Length || toAccountId < 0 || toAccountId > accounts.Length)
            {
                throw new AccountNotFoundException();
            }
            else if (accounts[fromAccountId - 1].Balance < transferAmount)
            {
                throw new InsufficientFundsException();
            }
            else
            {
                accounts[fromAccountId - 1].Balance -= transferAmount;
                accounts[toAccountId - 1].Balance += transferAmount;
            }

            Transaction withdrawTransaction = new Transaction
            {
                TransactionId = fromAccountId,
                Amount = transferAmount,
                TransactionDate = DateTime.Now,
                TransactionType = Operation.TransferMoney
            };
            Array.Resize(ref transactions, transactions.Length + 1);
            transactions[transactions.Length - 1] = withdrawTransaction;
        }

        private void Deposit(decimal transferAmount)
        {
            throw new NotImplementedException();
        }

        private void Withdraw(decimal transferAmount)
        {
            throw new NotImplementedException();
        }

        public void GetAllAccounts()
        {
            Console.WriteLine("List of all accounts were placed on the below:");

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account ID: {account.AccountId}, Type:{account.AccountType},  Balance: {account.Balance}, Currency: {account.CurrencyType}");
            }
        }
        public void ListTransactions()
        {

            Console.WriteLine("there are all transactionslist on the below");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId} , Type: {transaction.TransactionType} , Date: {transaction.TransactionDate}");
            }
        }
        public void CurrencyConversion(CurrencyType currency, int accountId, decimal Balance)
        {
            int accountID = accountId;
            Console.WriteLine("please choose again, it should not be change after. 1-USD, 2- EURO  ");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("the amount with DOLLAR  " + Balance * 0.588256M + " $");
                    break;
                case 2:
                    Console.WriteLine("the amount with EURO  " + Balance * 0.554554M + " euro");
                    break;
                
                default:
                    Console.WriteLine("Invalid currency");
                    break;
            }








        }
    }  }
