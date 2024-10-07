namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal abstract class BankAccount
    {
        public int AccountID { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        public BankAccount()
        {
        }


        public BankAccount(int accountID, string customerName, double balance)
        {
            AccountID = accountID;
            CustomerName = customerName;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"AccountId: {AccountID} \t Customer Name : {CustomerName} \t Balance: {Balance}";
        }

        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void CalculateInterest();
    }
}
