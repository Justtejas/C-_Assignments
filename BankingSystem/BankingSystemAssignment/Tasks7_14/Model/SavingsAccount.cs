namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }
            
            public SavingsAccount(int accountNumber, string customerName, double balance, double interestRate)
                : base(accountNumber, customerName, balance)
            {
                InterestRate = interestRate;
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
                    if (Balance >= amount)
                    {
                        Balance -= amount;
                        Console.WriteLine($"Withdrew {amount}. New balance: {Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be positive.");
                }
            }

            
            public override void CalculateInterest()
            {
                double interest = (Balance * InterestRate) / 100;
                Console.WriteLine($"Interest on balance {Balance} at rate {InterestRate}%: {interest}");
            }
    }
}
