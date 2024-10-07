using BankingSystemAssignment.Tasks7_14.Model;

namespace BankingSystemAssignment.Tasks7_14.DAO
{
    internal class CustomerServiceProviderImp:ICustomerServiceProvider
    {
         private readonly Dictionary<long, Account> accounts; 
        public CustomerServiceProviderImp()
        {
            accounts = new Dictionary<long, Account>();
            
        }

        public double GetAccountBalance(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Balance; 
            }
            Console.WriteLine("Account not found.");
            return 0;
        }

        public float Deposit(long accountNumber, float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Deposit(amount);
            }
            Console.WriteLine("Account not found.");
            return 0;
        }

        public float Withdraw(long accountNumber, float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Withdraw(amount); 
            }
            Console.WriteLine("Account not found.");
            return 0;
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            if (accounts.ContainsKey(fromAccountNumber) && accounts.ContainsKey(toAccountNumber))
            {
                float withdrawalResult = Withdraw(fromAccountNumber, amount);
                if (withdrawalResult > 0)
                {
                    Deposit(toAccountNumber, amount);
                    Console.WriteLine($"Transferred {amount} from account {fromAccountNumber} to {toAccountNumber}.");
                }
            }
            else
            {
                Console.WriteLine("One or both account numbers are invalid.");
            }
        }

        public string GetAccountDetails(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].ToString(); 
            }
            return "Account not found.";
        }

    }
}
