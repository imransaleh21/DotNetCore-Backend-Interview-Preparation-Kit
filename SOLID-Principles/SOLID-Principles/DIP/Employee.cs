namespace SOLID_Principles.DIP
{
    /// <summary>
    /// Dependency Inversion Principle (DIP) states that high-level modules should not depend on low-level modules.
    /// Both should depend on abstractions (e.g., interfaces).
    /// Actually, To achieve Dpendency Injection, we need to follow the Inversion of Control (IoC) principle, which is a broader concept that includes DIP.
    /// DIP actually reduces the tight coupling between high-level and low-level modules by introducing abstractions(interfaces).
    /// </summary>
    /// 

    // In this scenario, we have a high-level module (EmployeeController) directly depending on a low-level module (EmployeeService).
    // This creates tight coupling between the two classes.
    /*
    public class EmployeeController
    {
        private EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService(); // Direct instantiation creates tight coupling.
            _employeeService.SetEmployeeDetails(1, "John Doe", "Software Engineer");
        }
    }

    // Low-level module responsible for employee-related operations.
    public class EmployeeService
    {
        public void SetEmployeeDetails(int employeeId, string name, string position)
        {
            // Logic to set employee details
        }
    }
    */

    /*
         *Problem: Tight Coupling
         *
         * The EmployeeController (high-level module) directly depends on EmployeeService (low-level module).
         * This means:
         * 
         * 1. If the methods in the EmployeeService class are not yet implemented,
         * the EmployeeController cannot be tested or compiled properly, since it directly depends on the concrete implementation.
         * 2. We cannot replace EmployeeService with a different implementation (e.g., MockEmployeeService for testing, or a service that calls an API).
         * 3. If the constructor or method signatures of EmployeeService change, we must also modify EmployeeController.
     */

    //----------------------------------------------------------------------------------------
    /*
     *Solution:
     * Introduce an interface (e.g., IEmployeeService) that EmployeeService implements.
     * Inject the dependency via constructor (Dependency Injection).
     * This way, EmployeeController depends on an abstraction, not on a concrete implementation.
     */

    // Now, we have an interface IEmployeeService that defines the contract for employee-related operations.
    // The EmployeeController class now depends on this interface instead of the concrete EmployeeService class.
    // So, the EmployeeController can work with any implementation of IEmployeeService, allowing for greater flexibility and testability.

    // The EmployeeController Doesn't need to know about what is inside the EmployeeService class,
    // it only needs to know about the IEmployeeService interface.
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        // Constructor injection of the IEmployeeService dependency
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public void SetEmployeeDetails(int employeeId, string name, string position)
        {
            _employeeService.SetEmployeeDetails(employeeId, name, position);
        }
    }

    // Interface defining the contract for employee-related operations
    public interface IEmployeeService
    {
        void SetEmployeeDetails(int employeeId, string name, string position);
    }

    // Low-level module implementing the IEmployeeService interface
    public class EmployeeService : IEmployeeService
    {
        public void SetEmployeeDetails(int employeeId, string name, string position)
        {
            // Logic to set employee details
        }
    }
}
