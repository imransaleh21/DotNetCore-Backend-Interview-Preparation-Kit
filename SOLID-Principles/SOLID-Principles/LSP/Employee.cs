namespace SOLID_Principles.LSP
{
    /// <summary>
    /// Liskov Substitution Principle (LSP) states that objects of a superclass should be replaceable
    /// with objects of a subclass without affecting the correctness of the program.
    /// </summary>

    // The commented-out scenario below violates the Liskov Substitution Principle(LSP)
    // because the ContractEmployee class is forced to implement the CalculateBonus() method from the parent Employee class,
    // even though contract employees are not eligible for bonuses.
    // This breaks LSP, as ContractEmployee cannot fully substitute the behavior of its base class without issues.

    /*
    internal class Employee // parent/base/super class
    {
        // Employee class has methods to calculate salary and bonus.
        public virtual int CalculateSalary()
        {
            return 120000; // Example salary
        }
        public virtual int CalculateBonus()
        {
            return 10000; // Example bonus
        }
    }

    // ParmanentEmployee class is a subclass of Employee and it overrides the CalculateSalary method but not the CalculateBonus method.
    // This is a valid implementation of LSP as the Subclass can replace the Superclass without affecting the correctness of the program. 
    internal class ParmanentEmployee : Employee // child/derived/sub class
    {
        // PermanentEmployee class overrides the CalculateSalary method to provide specific implementation.
        public override int CalculateSalary()
        {
            return 110000; // Example salary for permanent employee
        }
        // Now, Look at the CalculateBonus method, it is not overridden in the ParmanentEmployee class. So, it will use the base class implementation.
        // and let's say ParmanentEmployee class has the same bonus calculation logic as the Employee class. Now it is not violating LSP.
    }

    internal class ContractEmployee : Employee // child/derived/sub class
    {
        // ContractEmployee class overrides the CalculateSalary method to provide specific implementation.
        public override int CalculateSalary()
        {
            return 80000; // Example salary for contract employee
        }
        // Let's say ContractEmployee class does not have a bonus calculation logic,
        // So we cannot use the base class implementation of CalculateBonus method here.
        // Instead now we have to forcefully throw an exception in the CalculateBonus method. This is not ideal and violates LSP.
        public override int CalculateBonus()
        {
            throw new NotImplementedException("Contract employees do not receive bonuses.");
        }
    }
    */

    //---------------------------------------------------------------------------------------
    // Now this below code portions provides a solution to the above problem by following LSP. We have created an interface for bonus calculation
    // and ContractEmployee class does not implement it, but ParmanentEmployee class implements it.
    // So now ContractEmployee class can be used as a substitute for Employee class without any issues.
    internal class Employee // parent/base/super class
    {
        // Employee class has methods to calculate salary.
        public virtual int CalculateSalary()
        {
            return 120000; // Example salary
        }
    }
    // This interface is now implemented by concrete employee classes to calculate bonus
    interface IBonusCalculator
    {
        int CalculateBonus();
    }
    // ParmanentEmployee class is a subclass of Employee
    internal class ParmanentEmployee : Employee, IBonusCalculator // child/derived/sub class
    {
        // PermanentEmployee class overrides the CalculateSalary method to provide specific implementation.
        public override int CalculateSalary()
        {
            return 110000; // Example salary for permanent employee
        }
        // ParmanentEmployee class implements the IBonusCalculator interface to provide bonus calculation logic.
        public int CalculateBonus()
        {
            return 10000; // Example bonus for permanent employee
        }
    }
    // ContractEmployee class is a subclass of Employee
    internal class ContractEmployee : Employee // child/derived/sub class
    {
        // ContractEmployee class overrides the CalculateSalary method to provide specific implementation.
        public override int CalculateSalary()
        {
            return 80000; // Example salary for contract employee
        }
        // ContractEmployee class does not implement IBonusCalculator interface, so it does not have a bonus calculation logic.
        // This is a valid implementation of LSP as ContractEmployee can be used as a substitute for Employee without any issues.
    }
}

