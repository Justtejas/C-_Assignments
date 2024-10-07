using System.Transactions;

namespace BankingSystemAssignment.Tasks7_14.DAO
{
    internal interface ICustomerServiceProvider
    {
        double GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        string GetAccountDetails(long accountNumber);
    }
}
