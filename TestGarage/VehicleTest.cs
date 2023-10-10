using Garage;
using GarageMaker;

namespace GarageMaker.Tests
{

    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            string model = "Toyota";
            string manufacturer = "Sedan";
            string vehicleType = "Gasoline";
            string regNo = "ABC123";
            int numberOfWheels = 4;
            string color = "Blue";

            IVehicle car = new Car(model, manufacturer, vehicleType, regNo, numberOfWheels, color);

            // Act
            string result = car.ToString();

            // Assert
            string expected = $"Model: {model}, Vehicle Type: {vehicleType}, manufacturer: {manufacturer}, Registration Number: {regNo}, Number of Wheels: {numberOfWheels}";
            Assert.AreEqual(expected, result);
        }

       
    }

}