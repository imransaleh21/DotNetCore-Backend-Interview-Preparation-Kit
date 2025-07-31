namespace SOLID_Principles.OCP
{
    /// <summary>
    /// Open/Closed Principle (OCP) states that software entities (classes, modules, functions, etc.) should be open for extension
    /// but closed for modification.
    /// To follow OCP, we must follow SRP (Single Responsibility Principle) first because SRP is a prerequisite for OCP.
    /// </summary>

    // The commented-out scenario below violates the Open/Closed Principle (OCP)
    // because the Account class requires modification whenever a new account type is introduced,
    // rather than being extended through new classes.
    /*
    internal class Account 
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        // this method violates OCP because it requires modification to add new account types
        public double CalculateInterest(string accountType)
        {
            // Suppose we have two types of accounts: Saving and Current and now we want to add a Fixed account type.
            // so what we have to do is modify this method to add the logic for Fixed account type. This violates OCP
            if (accountType == "Saving")
            {
                return (double)(Balance * 0.04m); // 4% interest for Saving account
            }
            else if(accountType == "Current")
            {
                return (double)(Balance * 0.02m); // 2% interest for Current account
            }

            // Adding a new account type requires modifying this method, which violates OCP
            else if (accountType == "Fixed")
            {
                return (double)(Balance * 0.06m); // 6% interest for Fixed account
            }
            else
            {
                throw new ArgumentException("Invalid account type");
            }
        }
    }
    */

    //---------------------------------------------------------------------------------------
    // Now this below code portions provides a solution to the above problem by following OCP.
    // Account class is now abstract and does not implement interest calculation directly
    internal class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
        // Abstract method to calculate interest, which must be implemented by derived classes
    }

    // This interface is now implemented by concrete account classes to calculate interest
    interface IInterestCalculator
    {
        double CalculateInterest(Account account);
    }

    // Concrete class for Saving account that implements interest calculation
    internal class SavingAccount : IInterestCalculator
    {
        public double CalculateInterest(Account account)
        {
            return (double)(account.Balance * 0.04m); // 4% interest for Saving account
        }
    }
    // Concrete class for Current account that implements interest calculation
    internal class CurrentAccount : IInterestCalculator
    {
        public double CalculateInterest(Account account)
        {
            return (double)(account.Balance * 0.02m); // 2% interest for Current account
        }
    }
    // Concrete class for Fixed account that implements interest calculation
    internal class FixedAccount : IInterestCalculator
    {
        public double CalculateInterest(Account account)
        {
            return (double)(account.Balance * 0.06m); // 6% interest for Fixed account
        }
    }
}
