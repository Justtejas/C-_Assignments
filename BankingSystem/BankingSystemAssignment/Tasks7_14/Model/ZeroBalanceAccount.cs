namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class ZeroBalanceAccount : Account
    {
        public ZeroBalanceAccount(Customer customer) : base(customer, "ZeroBalance",0) { }

        //public override void Deposit(double amount)
        //{
        //    Balance += amount;
        //}

        //public override void Withdraw(double amount)
        //{
        //    if (Balance - amount >= 0)
        //    {
        //        Balance -= amount;
        //    }
        //}
    }
}
