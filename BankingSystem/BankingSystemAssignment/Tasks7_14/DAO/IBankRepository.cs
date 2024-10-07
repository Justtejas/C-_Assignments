using BankingSystemAssignment.Tasks7_14.Model;
namespace BankingSystemAssignment.Tasks7_14.DAO
{
    internal interface IBankRepository
    {
        void CreateAccount(Customer customer, long accNo, string accType, decimal balance);
        List<Account> ListAccounts();
        decimal GetAccountBalance(long accountNumber);
        decimal Deposit(long accountNumber, decimal amount);
        decimal Withdraw(long accountNumber, decimal amount);
        bool Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        string GetAccountDetails(long accountNumber);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
