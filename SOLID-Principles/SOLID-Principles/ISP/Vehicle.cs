namespace SOLID_Principles.ISP
{
    /// <summary>
    /// Interface Segregation Principle (ISP) states that no class should be forced to depend on methods it does not use.
    /// </summary>

    // The commented-out scenario below violates the Interface Segregation Principle (ISP)
    // because the IVehicle interface forces all vehicles to implement both Dirve() and Fly() methods,
    // even if they do not support flying (like car). This leads to unnecessary complexity and potential errors.
    /*
    internal interface IVehicle
    {
        void Dirve();
        void Fly();
    }

    // For flying cars, we can implement the IVehicle interface correctly.
    internal class FlyingCar : IVehicle
    {
        public void Dirve()
        {
            // Implementation for driving a flyingCar
        }
        public void Fly()
        {
            // Implementation for flying a flyingCar
        }
    }

    // But for regular cars, we should not force them to implement the Fly method.
    internal class Car : IVehicle
    {
        public void Dirve()
        {
            // Implementation for driving a car
        }

        // Here, the Car class is forced to implement the Fly method, but it does not make sense for a car to fly.
        public void Fly()
        {
            throw new NotImplementedException("Cars cannot fly.");
        }
    }
    */

    //---------------------------------------------------------------------------------------
    // Now this below code portions provides a solution to the above problem by following ISP.
    // We have created two separate interfaces: IDriveable and IFlyable. The class which needs to implement the driving functionality
    // will implement the IDriveable interface and the class which needs to implement the flying functionality will implement the IFlyable interface.

    internal interface IDriveable
    {
        void Drive();
    }
    internal interface IFlyable
    {
        void Fly();
    }
    // For flying cars, we can implement both interfaces.
    internal class FlyingCar : IDriveable, IFlyable
    {
        public void Drive()
        {
            // Implementation for driving a flying car
        }
        public void Fly()
        {
            // Implementation for flying a flying car
        }
    }
    // For regular cars, we only implement the IDriveable interface.
    internal class Car : IDriveable
    {
        public void Drive()
        {
            // Implementation for driving a car
        }
        // No Fly method here, as cars do not fly.
    }
}
