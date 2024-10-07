using BankingSystemAssignment.Tasks7_14.Model;

namespace BankingSystemAssignment.Tasks7_14.DAO
{
    internal interface IBankServiceProvider
    {
        void CreateAccount(Customer customer, long accNo, string accType, float balance);

        Account[] ListAccounts();

        void CalculateInterest();
    }
}
