namespace Tasks.Tasks;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select Task: ");
        int opt = 0;
        do
        {
            Console.WriteLine("1 for Conditionals: ");
            Console.WriteLine("2 for NestedConditionals: ");
            Console.WriteLine("3 for Loops: ");
            Console.WriteLine("4 for Looping, Array, Data Validation: ");
            Console.WriteLine("5 for Password Validation: ");
            Console.WriteLine("6 for Transaction History: ");
            Console.WriteLine("7 to Exit: ");
            opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Console.WriteLine(Conditional());
                    break;
                case 2:
                    NestedConditional();
                    break;
                case 3:
                    CalculateCompountInterest();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    PasswordValidator();
                    break;
                case 6:
                    TransactionHistory();
                    break;
                case 7:
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid Option, Try again.");
                    break;
            }

        } while (opt != 7);
    }

    public static string Conditional()
    {

        //            Task 1: Conditional Statements
        //In a bank, you have been given the task is to create a program that checks if a customer is eligible for
        //a loan based on their credit score and income. The eligibility criteria are as follows:
        //• Credit Score must be above 700.
        //• Annual Income must be at least $50,000.
        //Tasks:
        //1. Write a program that takes the customer's credit score and annual income as input.
        //2. Use conditional statements (if-else) to determine if the customer is eligible for a loan.
        //3. Display an appropriate message based on eligibility.

        Console.WriteLine("Enter your credit score: ");
        int creditScore = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your annual income: ");
        int annualIncome = int.Parse(Console.ReadLine());

        if (creditScore > 700 && annualIncome >= 50000)
        {
            return "You are eligible for the loan";
        }
        else
        {
            return "You are not eligible for the loan";
        }
    }

    public static void NestedConditional()
    {
        //            Task 2: Nested Conditional Statements
        //Create a program that simulates an ATM transaction. Display options such as "Check Balance,"
        //"Withdraw," "Deposit,". Ask the user to enter their current balance and the amount they want to
        //withdraw or deposit. Implement checks to ensure that the withdrawal amount is not greater than the
        //available balance and that the withdrawal amount is in multiples of 100 or 500. Display appropriate
        //messages for success or failure.
        Console.WriteLine("Enter your balance: ");
        int balance = int.Parse(Console.ReadLine());
        int opt = 0;

        do
        {
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");
            opt = int.Parse(Console.ReadLine());
            int withdrawalAmt = 0;
            int depositAmt = 0;
            switch (opt)
            {
                case 1:
                    Console.WriteLine($"Your Balance is {balance}");
                    break;
                case 2:
                    Console.WriteLine("Insert the amount you want to withdraw");
                    withdrawalAmt = int.Parse(Console.ReadLine());
                    if (withdrawalAmt > balance || withdrawalAmt < 1)
                    {
                        Console.WriteLine("The current amount cannot be withdrawn");
                    }
                    else if (withdrawalAmt % 100 != 0 || withdrawalAmt % 500 != 0)
                    {
                        Console.WriteLine("Insert an amount that is multiple of 100 or 500");
                    }
                    else
                    {
                        balance = balance - withdrawalAmt;
                        Console.WriteLine($"Amount withdrawn: {withdrawalAmt}");
                        Console.WriteLine($"Current Balance: {balance}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Insert the amount you want to deposit");
                    depositAmt = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Previous balance:  {balance}");
                    balance = balance + depositAmt;
                    Console.WriteLine($"Current balance:  {balance}");
                    break;
                case 4:
                    Console.WriteLine("Exiting task 2");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        } while (opt != 4);
    }

    public static void CalculateCompountInterest()
    {
        //            Task 3: Loop Structures
        //You are responsible for calculating compound interest on savings accounts for bank customers. You
        //need to calculate the future balance for each customer's savings account after a certain number of years.
        //Tasks:
        //1. Create a program that calculates the future balance of a savings account.
        //2. Use a loop structure (e.g., for loop) to calculate the balance for multiple customers.
        //3. Prompt the user to enter the initial balance, annual interest rate, and the number of years.
        //4. Calculate the future balance using the formula:
        //future_balance = initial_balance * (1 + annual_interest_rate/100)^years.
        //5. Display the future balance for each customer.
        int customerCount = 0;
        Console.WriteLine("Insert customer count:");
        customerCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < customerCount; i++)
        {
            int initialBalance = 0;
            Console.WriteLine("Enter your balance:");
            initialBalance = Convert.ToInt32(Console.ReadLine());
            int annualInterestRate = 0;
            Console.WriteLine("Enter your annual interest rate:");
            annualInterestRate = Convert.ToInt32(Console.ReadLine());
            int numberOfYears = 0;
            Console.WriteLine("Enter your numberOfYears:");
            numberOfYears = Convert.ToInt32(Console.ReadLine());

            int futureBalance = initialBalance * (1 + annualInterestRate / 100) * numberOfYears;
            Console.WriteLine($"Your future balance will be: {futureBalance}");
        }
    }

    public static void Task4()
    {
        //            Task 4: Looping, Array and Data Validation
        //You are tasked with creating a program that allows bank customers to check their account balances.
        //The program should handle multiple customer accounts, and the customer should be able to enter their
        //account number, balance to check the balance.
        //Tasks:
        //1. Create a Python program that simulates a bank with multiple customer accounts.
        //2. Use a loop (e.g., while loop) to repeatedly ask the user for their account number and
        //balance until they enter a valid account number.
        //3. Validate the account number entered by the user.
        //4. If the account number is valid, display the account balance. If not, ask the user to try again.
        int[] accountID = { 1, 2, 3, };
        int[] balance = { 13400, 54330, 67893 };
        while (true)
        {
            Console.WriteLine("Enter your account number: ");
            int accountId = Convert.ToInt32(Console.ReadLine());
            if (accountID.Contains(accountId))
            {
                Console.WriteLine($"Your accountId is {accountId} and your balance is {balance[accountId]}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid AccountId");
            }
        }
    }

    public static void PasswordValidator()
    {
        //            Task 5: Password Validation
        //Write a program that prompts the user to create a password for their bank account. Implement if
        //conditions to validate the password according to these rules:
        //• The password must be at least 8 characters long.
        //• It must contain at least one uppercase letter.
        //• It must contain at least one digit.
        //• Display appropriate messages to indicate whether their password is valid or not.

        Console.WriteLine("Enter password:");
        string pass = Console.ReadLine();
        if (IsValid(pass))
        {
            Console.WriteLine("Your password is valid.");
        }
        else
        {
            Console.WriteLine("Your password is not valid. Password should be at least 8 characters long, must contain a UpperCase letter and a digit.");
        }

    }

    public static bool IsValid(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
    public static void TransactionHistory()
    {
        //Create a program that maintains a list of bank transactions (deposits and withdrawals) for a customer.
        //Use a while loop to allow the user to keep adding transactions until they choose to exit. Display the
        //transaction history upon exit using looping statements.

        List<string> history = new List<string>();
        int opt;
        do
        {
            Console.WriteLine("1.Add Deposit");
            Console.WriteLine("2.Withdraw amount");
            Console.WriteLine("3.Exit");
            opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {

                case 1:
                    Console.WriteLine("Enter the amount you want to deposit");
                    double despositAmt = Convert.ToDouble(Console.ReadLine());
                    history.Add($"You Deposited {despositAmt} amount.");
                    break;
                case 2:
                    Console.WriteLine("Enter the amount you want to withdraw");
                    double withdrawAmt = Convert.ToDouble(Console.ReadLine());
                    history.Add($"You Withdrew {withdrawAmt} amount.");
                    break;
                case 3:
                    foreach(string transaction in history)
                    {
                        Console.WriteLine(transaction);
                    }
                    Console.WriteLine("Exiting");
                    break;
            }
        } while (opt != 3);

    }
}
