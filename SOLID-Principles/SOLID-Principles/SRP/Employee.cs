namespace SOLID_Principles.SRP
{
    /// <summary>
    /// Single Responsibility Principle (SRP) states that a class should have only one responsibility
    /// or a class should have only one reason to change.
    /// </summary>
    internal class Employee
    {
        // GetSalary and GetDepartment methods are part of the Employee class,
        public int GetSalary()
        {
            // Logic to calculate salary
            return 50000; // Example salary
        }
        public string GetDepartment()
        {
            // Logic to get department
            return "Engineering"; // Example department
        }

        // But the SetEmployee method is not directly related to the Employee's core responsibilities. So, it violates SRP.
        // To adhere to SRP, this method should be moved to a separate class, such as EmployeeManager or EmployeeRepository
        /*
         public Employee SetEmployee(Employee employee)
         {
             // Logic to set employee details
             return employee; // Example return
         }
        */
    }

    internal class EmployeeRepository
    {
        /// <summary>
        /// Now, we can create a separate class to handle the employee management responsibilities.
        /// So, now we have a class that adheres to SRP.
        /// </summary>
        /// <param name="employee"></param>
        public void SetEmployee(String employee)
        {
            // Logic to set employee details into the Database or any storage
        }
    }
}
