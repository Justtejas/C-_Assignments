namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class Transaction
    {
        public int TransactionID { get; set; }
        public Account Account { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }

        public Transaction(Account account, string transactionType, double transactionAmount)
        {
            Account = account;
            TransactionDate = DateTime.Now;
            TransactionType = transactionType;
            Amount = transactionAmount;
        }
    }
}
