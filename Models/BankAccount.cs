using Bank.Consoleapp.Exceptions;
using Bank.Consoleapp.Models.AccountModels;

namespace ConsoleApp.Bank.Models
{
    internal class BankAccount : IAccount
    {
        private string[] account { get; set; }

        


        IAccount[] accounts = new IAccount[0];
        Transaction[] transactions = new Transaction[0];

       


        public void CreateAccount(AccountType accountType, CurrencyType currencyType, int accountId, int Idage)
        {
            bool check;
            Console.WriteLine("let's create account for you:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Please enter your Name for new account");
            string accountName = Console.ReadLine();

            bool checkage = false;
            if (Idage>=18)
            {
                checkage = true;
            }
            if(!checkage)
            {
                throw new InvalidAge();
            }
           
            bool checkid = false;
            if(accountId >0)
            {
                checkid = true;
            }
            if (!checkid)
            {
                throw new InvalidID();
            }
           


            string accounttype = accountType.ToString();

            string currencytype = currencyType.ToString();
            
            IAccount account = new IAccount()
            {
                AccountId=accountId,
                Age = Idage,
                Name = accountName,
                AccountType = accounttype,
                CurrencyType = currencytype,
            };
            Array.Resize(ref accounts, accounts.Length + 1);
            accounts[accounts.Length - 1] = account;

        }
        public void DepositMoney(string id, decimal amount)
        {
            bool correctInfo = false;
            bool correctamount = false;
            int account1 = int.Parse(id);

            //if (amount <= 0)
            //{
            //    throw new InvalidAmountException();
            //}

            for (int i = 0; i < accounts.Length; i++)
            {
                if (account1 == accounts[i].AccountId)
                {


                    correctInfo = true;
                    break;

                }
            }
            if (amount>0)
            {
                correctamount = true;
            }
            if (!correctInfo)
            {
                throw new AccountNotFoundException();
                
            }
            if(!correctamount)
            {
                throw new InvalidAmountException();
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
                Console.WriteLine($"Account ID: {account.AccountId}, Name: {account.Name}, Age: {account.Age},  Type:{account.AccountType},  Balance: {account.Balance}, Currency: {account.CurrencyType}");
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
        public void CurrencyConversion(CurrencyType currencytype, int accountId )
        {
            int currencyaccountId = accountId;
            Console.WriteLine("IF you are sure to convert, please choose again it should not be change after process 1-AZN , 2-USD 3- EURO");

            int number = Convert.ToInt32(Console.ReadLine());
            


                switch (number)
                {

                case 1:
                    Console.WriteLine("your amount is already in AZN value");
                    accounts[accountId - 1].Balance *= 1.7M;
                    accounts[accountId - 1].CurrencyType = "AZN";
                    break;
                case 2:
                    Console.WriteLine("The full balance converted to Dollar, check your value with fifth option:");
                    accounts[accountId - 1].Balance *= 0.588256M;
                    accounts[accountId - 1].CurrencyType = "USD";

                        break;
                case 3:
                        Console.WriteLine("The full balance converted to Euro , chec your value with fifth option:");
                        accounts[accountId - 1].Balance *= 0.95M;
                        accounts[accountId - 1].CurrencyType = "EURO";
                        break;

                    default:
                        Console.WriteLine("please implement the process correctly");
                        break;
                }

        }




        }
    }  
