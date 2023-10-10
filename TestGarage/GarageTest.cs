using Garage;

namespace GarageMaker.Tests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void AddVehicle_ShouldAddVehicleToGarage()
        {
            // Arrange
            var garage = new Garage<IVehicle>(3);
            IVehicle car1 = new Car("Toyota", "Sedan", "Gasoline", "ABC123", 4, "Blue");
            IVehicle car2 = new Car("Honda", "SUV", "Electric", "XYZ789", 4, "Red");

            // Act
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);

            // Assert
            Assert.AreEqual(2, garage.Count());
        }

        [TestMethod]
        public void AddVehicle_ShouldNotAddVehicleWhenFull()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            IVehicle car1 = new Car("Toyota", "Sedan", "Gasoline", "ABC123", 4, "Blue");
            IVehicle car2 = new Car("Honda", "SUV", "Electric", "XYZ789", 4, "Red");
            IVehicle car3 = new Car("Ford", "Truck", "Diesel", "LMN456", 4, "Green");

            // Act
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3); // This should not be added due to full capacity

            // Assert
            Assert.AreEqual(2, garage.Count());
        }

        [TestMethod]
        public void GetEnumerator_ShouldEnumerateVehicles()
        {
            // Arrange
            var garage = new Garage<IVehicle>(3);
            IVehicle car1 = new Car("Toyota", "Sedan", "Gasoline", "ABC123", 4, "Blue");
            IVehicle car2 = new Car("Honda", "SUV", "Electric", "XYZ789", 4, "Red");
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);

            // Act
            var vehicles = garage.ToList();

            // Assert
            Assert.AreEqual(2, vehicles.Count);
            Assert.IsTrue(vehicles.Contains(car1));
            Assert.IsTrue(vehicles.Contains(car2));
        }
    }

}