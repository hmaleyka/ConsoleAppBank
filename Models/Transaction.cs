namespace ConsoleApp.Bank.Models
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Operation TransactionType { get; set; }


    }


}