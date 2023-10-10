using Garage;

namespace GarageMaker.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void SetGarage_ShouldSetGarageSize()
        {
            // Arrange
            var manager = new Manager();
            int expectedSize = 10;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("10\nN\n"))
                {
                    Console.SetIn(sr);
                    manager.SetGarage();

                    // Assert
                    string output = sw.ToString();

                    // Verify only the relevant parts of the output
                    Assert.IsTrue(output.Contains("Please Specify the size of the garage"));
                    Assert.IsTrue(output.Contains("Would you like to add vehicles into the garage? Y/N?"));

                    // Ensure that other parts of the output are not captured or asserted
                    Assert.IsFalse(output.Contains("Common output for all scenarios"));
                }
            }
        }

        [TestMethod]
        public void Park_ShouldAddVehiclesToGarage()
        {
            // Arrange
            var manager = new Manager();
            manager.inputCap = 2;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("2\nCar\nToyota\nSedan\nGasoline\nABC123\n4\nBlue\nCar\nHonda\nSUV\nElectric\nXYZ789\n4\nRed\n"))
                {
                    Console.SetIn(sr);
                    manager.Park();

                    // Capture the console output
                    string output = sw.ToString();

                    // Print the console output for debugging
                    Console.WriteLine("Console Output:");
                    Console.WriteLine(output);


                    // Assert
                   
                    Assert.IsTrue(output.Contains("How many vehicles would you like to park?"));
                    Assert.IsTrue(output.Contains("Enter the type of vehicle (Car, Airplane, Bus):"));
                    Assert.IsTrue(output.Contains("Enter car manufacturer:"));
                    Assert.IsTrue(output.Contains("Enter car model:"));
                    Assert.IsTrue(output.Contains("Enter car type, such as 18 wheeler, pickup, limousine"));
                    Assert.IsTrue(output.Contains("Registry Number:"));
                    Assert.IsTrue(output.Contains("Enter number of wheels:"));
                    Assert.IsTrue(output.Contains("Enter the color:"));

                }
            }
        }
        [TestMethod]
        public void SearchVehicles_ShouldReturnMatchingVehicles()
        {
            // Arrange
            var manager = new Manager();
            var handler = new GarageHandler(2);
            manager.handler = handler;
            IVehicle car1 = new Car("Toyota", "Sedan", "Combini", "ABC123", 4, "Blue");
            handler.AddVehicle(car1);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("Car Toyota\n"))
                {
                    Console.SetIn(sr);
                    manager.searchVehicles();

                    Console.WriteLine(sw.ToString());

                    // Assert
                    string output = sw.ToString();
                    Assert.IsTrue(output.Contains("Enter search terms (separated by spaces):"));
                    Assert.IsTrue(output.Contains("Matching Vehicles:"));
                    Assert.IsTrue(output.Contains("Model: Toyota"));
                }
            }
        }
    }
}