namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class Account
    {
        private double InterestRate;
        public int AccountID { get;  set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }

        public Account(int accID, string accountType, double balance)
        {
            AccountID = accID;
            AccountType = accountType;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"AccountId: {AccountID} \t AccountType : {AccountType} \t Balance: {Balance}";
        }
        internal float Deposit(float amount)
        {
            throw new NotImplementedException();
        }

        internal float Withdraw(float amount)
        {
            throw new NotImplementedException();
        }
        //public virtual void Deposit(double amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid amount");
        //    }
        //    Balance = Balance + amount;
        //    Console.WriteLine($"{amount} deposited successfully");
        //}
        //public virtual void Deposit(float amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid amount");
        //    }
        //    Balance = Balance + amount;
        //    Console.WriteLine($"{amount} deposited successfully");
        //}
        //public virtual void Deposit(int amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid amount");
        //    }
        //    Balance = Balance + amount;
        //    Console.WriteLine($"{amount} deposited successfully");
        //}

        //public virtual void Withdraw(float amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid Amount");
        //    }
        //    else if (amount > Balance)
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }

        //    Balance = Balance - amount;
        //    Console.WriteLine($"{amount} withdrawn successfully");
        //}
        //public virtual void Withdraw(double amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid Amount");
        //    }
        //    else if (amount > Balance)
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }

        //    Balance = Balance - amount;
        //    Console.WriteLine($"{amount} withdrawn successfully");
        //}

        //public virtual void Withdraw(int amount)
        //{
        //    if (amount < 0)
        //    {
        //        Console.WriteLine("Invalid Amount");
        //    }
        //    else if (amount > Balance)
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }

        //    Balance = Balance - amount;
        //    Console.WriteLine($"{amount} withdrawn successfully");
        //}
        //public virtual double CalculateInterest()
        //{
        //    double rate = 4.5 / 100;
        //    double interest = rate * Balance;
        //    return interest;
        //}
    }
}
