using ConsoleApp.Bank.Models;

namespace Bank.Consoleapp.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            BankAccount account = new BankAccount(1, "checking", "eur");

            bool check = true;

            Console.WriteLine("Welcome to our Bank Application:");
            while (check)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Please choose one of the choices from the Menu:");
                Console.WriteLine("------------------Menu--------------------");
                Console.WriteLine("1.CreateAccount:");
                Console.WriteLine("2.DepositMoney:");
                Console.WriteLine("3.WithDrawMoney:");
                Console.WriteLine("4.ListofTransactions:");
                Console.WriteLine("5.ListofAccounts:");
                Console.WriteLine("6.TransferMoney:");
                Console.WriteLine("7.CurrencyConversion:");
                Console.WriteLine("8.Exit:");

                Operation operation1 = Operation.CreateAccount;
                Operation operation2 = Operation.DepositMoney;
                Operation operation3 = Operation.Withdrawmoney;
                Operation operation4 = Operation.ListTransactions;
                Operation operation5 = Operation.ListAccounts;
                Operation operation6 = Operation.TransferMoney;
                Operation operation7 = Operation.CurrencyConversion;
                Operation operation8 = Operation.Exit;

                int number = Convert.ToInt32(Console.ReadLine());


                switch (number)
                {
                    case (int)Operation.CreateAccount:
                        Console.WriteLine("Enter Account Type: 1 - Checking, 2 - Savings, 3 - Business:");
                        int accountType = Convert.ToInt32(Console.ReadLine());
                        if (accountType > 0 && accountType < 4)
                        {
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("Enter Currency Type (1 - USD, 2 - AZN, 3 - EUR):");
                            int currencyType = Convert.ToInt32(Console.ReadLine());
                            if (currencyType > 0 && currencyType < 4)
                            {
                                account.CreateAccount((AccountType)accountType, (CurrencyType)currencyType);
                                Console.WriteLine("The bank account was created:");
                            }
                            else
                            {
                                Console.WriteLine("Invalid currency type.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid account type.");
                        }
                        break;

                    case (int)Operation.DepositMoney:
                        Console.WriteLine("Enter Account ID:");
                        string depositAccountId = Console.ReadLine();
                        Console.WriteLine("you login succesfully for depositing money");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Enter the amount to deposit:");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        try
                        {
                            account.DepositMoney(depositAccountId, depositAmount);
                            Console.WriteLine("Money deposited successfully.");


                            break;
                        }
                        catch (AccountNotFoundException)
                        {
                            Console.WriteLine("Account not found, Please register from the application carefully");
                        }


                        break;
                    case (int)Operation.Withdrawmoney:

                        Console.WriteLine("Enter Account ID:");
                        int withdrawAccountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the amount to withdraw:");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                        try
                        {
                            account.WithdrawMoney(withdrawAccountId, withdrawAmount);


                            Console.WriteLine("Money withdrawn successfully.");
                        }
                        catch (AccountNotFoundException)
                        {
                            Console.WriteLine("Account not found.");
                        }
                        catch (InvalidAmountException)
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        catch (InsufficientFundsException)
                        {
                            Console.WriteLine("Insufficient funds in the account.");
                        }


                        break;
                    case (int)Operation.ListTransactions:

                        account.ListTransactions();




                        break;
                    case (int)Operation.ListAccounts:
                        account.GetAllAccounts();
                        Console.WriteLine("List of all accounts");


                        break;
                    case (int)Operation.TransferMoney:

                        Console.WriteLine("Enter your AccountId to transfer value");
                        int fromAccountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the AccountId which you want to transfer to it");
                        int toAccountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your amount to transfer value");
                        decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

                        try
                        {
                            account.TransferMoney(fromAccountId, toAccountId, transferAmount);
                            Console.WriteLine("Money transferred successfully.");
                        }
                        catch (AccountNotFoundException)
                        {
                            Console.WriteLine("Account not found.");
                        }
                        catch (InvalidAmountException)
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        catch (InsufficientFundsException)
                        {
                            Console.WriteLine("Insufficient funds in the account.");
                        }
                        break;

                    case (int)Operation.CurrencyConversion:

                        Console.WriteLine("Welcome to convertCalculator which calculate your exchange with other currencies");
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine("Enter your AccountId to exchange value");
                        int currencyAccountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the value how much do you want to exchange");
                        decimal amountfull = Convert.ToDecimal(Console.ReadLine());
                        try
                        {

                            Console.WriteLine("Enter the your AZN value for converting currency type (1 for USD, 2 for EUR ):");
                            int currencyChoice = Convert.ToInt32(Console.ReadLine());

                            CurrencyType currencyType;

                            switch (currencyChoice)
                            {
                                case 1:
                                    currencyType = CurrencyType.USD;
                                    break;
                                case 2:
                                    currencyType = CurrencyType.EUR;
                                    break;
                                
                                default:
                                    Console.WriteLine("Invalid currency choice");
                                    break; ;
                            }
                            account.CurrencyConversion((CurrencyType)currencyChoice, currencyAccountId, amountfull);
                                    
                        }

                        catch (AccountNotFoundException)
                        {
                            Console.WriteLine("Account not found.");
                        }
                        catch (InvalidAmountException)
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case (int)Operation.Exit:

                        check = false;
                        Console.WriteLine("Thanks for visiting our Bank Application");
                        Console.WriteLine("We will waiting for you again:");
                        Console.WriteLine("-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-");
                        Console.WriteLine("GoodByeee:");
                        break;
                    default:
                        Console.WriteLine("Invalid Operation: Try Again Please");
                        break;
                }


            }

        }
    
    }
}