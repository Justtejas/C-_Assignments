namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class CurrentAccount : BankAccount
    {
        public const double OverdraftLimit = 5000.0;
        private Customer customer;
        private int accID;

        public CurrentAccount(long accNo, object name, float balance) : base()
        {
        }

        public CurrentAccount(int accountNumber, string customerName, double balance)
            : base(accountNumber, customerName, balance)
        {
        }

        public CurrentAccount(Customer customer, int accID, float balance)
        {
            this.customer = customer;
            this.accID = accID;
            Balance = balance;
        }

        public override void Deposit(float amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }


        public override void Withdraw(float amount)
        {
            if (amount > 0)
            {
                if (Balance - amount >= -OverdraftLimit)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrew {amount}. Now balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"Cannot withdraw {amount}. Exceeds overdraft limit of {OverdraftLimit}");
                }
            }
            else
            {
                Console.WriteLine($"Withdrawal amount must be greater than {amount}");
            }
        }
        public override void CalculateInterest()
        {
            Console.WriteLine("There is no interest for Current Account.");
        }
    }
}
