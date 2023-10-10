using Garage; // Assuming your IVehicle and IHandler interfaces are defined here
using System.Drawing;
using System.Numerics;

namespace GarageMaker
{
    public class Manager : IManager
    {
        public IHandler handler;
        public int inputCap { get; set; }

      
        private List<string> searchTerms; // stores terms to search with.
        public int loopNr;
        public List<string> usedRegNos = new List<string>(); //List of allready used reg numbers.
       


        public Manager()
        {
            inputCap = 0; // Give inputCap initial value.
            handler = new GarageHandler(inputCap);
           


        }


        public bool CheckParking()
        {
            if (!handler.IsGarageFull())
            {
                Console.WriteLine("Free spot");
                return true; // Parking available
            }
            else
            {
                Console.WriteLine("The garage is full. Cannot add more vehicles.");
                return false; // Parking not available
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome Too GarageMaker 3000. Please make your choice.");
                Console.WriteLine("1) Check the size of the current garage");
                Console.WriteLine("2) Create a new Garage");
                Console.WriteLine("3) Park a new Vehicle within the garage");
                Console.WriteLine("4) Search for a specific vehicle within the garage");
                Console.WriteLine("5) List all currently available vehicles");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Please input a valid number");
                    break;
                }
                else if(choice > 5){

                    Console.WriteLine("Please input a valid number");
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Please make a valid choice");
                           
                            break;
                        case 1:
                            GetGarageSize();
                            break;
                        case 2:
                            SetGarage();
                            break;
                        case 3:
                            if (inputCap == 0) {
                                Console.WriteLine("You need to make a garage first");
                                break;
                            }
                            else if (CheckParking()) // if the garage is full, it breaks out of the case.
                            {
                                    Console.WriteLine("Garage is full");
                                    break;
                                }
                                else
                                {
                                    Park(); // Park the vehicle
                                    break;
                                }
                          
                            
                        case 4:
                            searchVehicles();
                            break;
                        case 5:
                            List<string> allVehicles = handler.ListAllVehiclesInGarage();
                            if (allVehicles.Count > 0)
                            {
                                Console.WriteLine("List of All Vehicles in Garage:");
                                foreach (string vehicleInfo in allVehicles)
                                {
                                    Console.WriteLine(vehicleInfo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No vehicles in the garage.");
                            }
                            break;


                    }
                }


            }
        }

        public void GetGarageSize()
        {
            if (inputCap <= 0) 
            {
                Console.WriteLine("There is not garage to tally, please create one.");
               
            }
            else
            {
                int filledSpots = handler.GetFilledSpots();
                Console.WriteLine("The number of filled spots in the current garage is: " + filledSpots + " out of " + inputCap);
                
            }
           
            
        }

        public void SetGarage()
        {
            Console.WriteLine("Please Specify the size of the garage");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Please input a valid number");
            }
            else if(input > 50) {
                Console.WriteLine("Input number to high, please keep it under 50.");
            }
            else
            {
                inputCap = input; // Set the inputCap to the value entered by the user
                handler = new GarageHandler(inputCap);
            }

            Console.WriteLine("Would you like to add vehicles into the garage? Y/N?");
            string YesNo = Console.ReadLine();
            if (YesNo != "Y" && YesNo != "N") {
                Console.WriteLine("Please input Y or N");
            }
            else
            {
                switch (YesNo.ToUpper())
                {
                    case "Y":
                        Park();
                        break;
                    case "N":
                        Run();
                        break;
                }
            }
         
        }


        public void Park()
        {
            Console.WriteLine("How many vehicles would you like to park?");
            int.TryParse(Console.ReadLine(), out loopNr);

            if(loopNr > inputCap)
            {
                Console.WriteLine("There are not enough space in the garage for so many vehicles. Exiting out to main menu.");
                Console.WriteLine();
                return;
            }

            while (loopNr > 0)
            {
                Console.WriteLine("Enter the type of vehicle (Car, Airplane, Bus):");
                string vehicleType = Console.ReadLine();

                if (vehicleType == null)
                {
                    Console.WriteLine("Please type a number.");
                    return;
                }

                switch (vehicleType.ToLower())
                { // Create methods for each vehicle. 
                    case "car":
                        CreateCar();
                        loopNr--;
                        break;
                    case "airplane":
                        CreateAirplane();
                        loopNr--;
                        break;
                    case "bus":
                        CreateBus();
                        loopNr--;
                        break;
                    case "boat":
                        CreateBoat();
                        loopNr--;
                        break;
                    case "motorcycle":
                        CreateMotorCycle();
                        loopNr--;
                        break;
                    default:
                        Console.WriteLine("Invalid Vehicle type type.");
                        break;
                }
            }
        }



        public void CreateCar()
        {
            bool isUnique = false;

            Console.WriteLine("Enter car manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter car type, such as 18 wheeler, pickup, limousine");
            string vehicleType = Console.ReadLine();

            string regno;

            do
            {
                Console.WriteLine("Registry Number:");
                regno = Console.ReadLine().ToUpper();

                if (!usedRegNos.Contains(regno))
                {
                    isUnique = true;
                    usedRegNos.Add(regno);
                }
                else
                {
                    Console.WriteLine("Registration Number is not unique. Please enter a different one.");
                }

            } while (!isUnique);

            Console.WriteLine("Enter number of wheels:");
            int nrofwheels = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the color:");
            string color = Console.ReadLine().ToUpper();

            IVehicle newVehicle = new Car(model, manufacturer, vehicleType, regno, nrofwheels, color);
            handler.AddVehicle(newVehicle);
        }

        public void CreateAirplane()
        {
            bool isUnique = false;

            Console.WriteLine("Enter car manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter car type, such as 18 wheeler, pickup, limousine");
            string vehicleType = Console.ReadLine();

            string regno;

            do //Ensures that while the regnumber isnt unique, it asks you to write a new one.
            {
                Console.WriteLine("Registry Number:");
                regno = Console.ReadLine().ToUpper();

                if (!usedRegNos.Contains(regno))
                {
                    isUnique = true;
                    usedRegNos.Add(regno);
                }
                else
                {
                    Console.WriteLine("Registration Number is not unique. Please enter a different one.");
                }

            } while (!isUnique);

            Console.WriteLine("Enter the Wingspan:");
            int wingspan = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the color:");
            string color = Console.ReadLine().ToUpper();


            IVehicle newVehicle = new Airplane(model, manufacturer, vehicleType, regno, wingspan, color);
            handler.AddVehicle(newVehicle);
        }
        public void CreateMotorCycle()
        {
            bool isUnique = false;

            Console.WriteLine("Enter car manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter car type, such as 18 wheeler, pickup, limousine");
            string vehicleType = Console.ReadLine();

            string regno;

            do //Ensures that while the regnumber isnt unique, it asks you to write a new one.
            {
                Console.WriteLine("Registry Number:");
                regno = Console.ReadLine().ToUpper();

                if (!usedRegNos.Contains(regno))
                {
                    isUnique = true;
                    usedRegNos.Add(regno);
                }
                else
                {
                    Console.WriteLine("Registration Number is not unique. Please enter a different one.");
                }

            } while (!isUnique);

            Console.WriteLine("Does it have Offroad capabilities:");
            string offroad = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the color:");
            string color = Console.ReadLine().ToUpper();


            IVehicle newVehicle = new MotorCycle(model, manufacturer, vehicleType, regno, offroad, color);
            handler.AddVehicle(newVehicle);
        }
        public void CreateBoat()
        {
            bool isUnique = false;

            Console.WriteLine("Enter car manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter car type, such as 18 wheeler, pickup, limousine");
            string vehicleType = Console.ReadLine();

            string regno;

            do//Ensures that while the regnumber isnt unique, it asks you to write a new one.
            {
                Console.WriteLine("Registry Number:");
                regno = Console.ReadLine().ToUpper();

                if (!usedRegNos.Contains(regno))
                {
                    isUnique = true;
                    usedRegNos.Add(regno);
                }
                else
                {
                    Console.WriteLine("Registration Number is not unique. Please enter a different one.");
                }

            } while (!isUnique);

            Console.WriteLine("Enter topspeed, in Knots:");
            int speedKnots = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the color:");
            string color = Console.ReadLine().ToUpper();

            IVehicle newVehicle = new Boat(model, manufacturer, vehicleType, regno, speedKnots, color);
            handler.AddVehicle(newVehicle);
        }
        public void CreateBus()
        {
            bool isUnique = false;

            Console.WriteLine("Enter car manufacturer:");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter car type, such as 18 wheeler, pickup, limousine");
            string vehicleType = Console.ReadLine();

            string regno;

            do //Ensures that while the regnumber isnt unique, it asks you to write a new one.
            {
                Console.WriteLine("Registry Number:");
                regno = Console.ReadLine().ToUpper();

                if (!usedRegNos.Contains(regno))
                {
                    isUnique = true;
                    usedRegNos.Add(regno);
                }
                else
                {
                    Console.WriteLine("Registration Number is not unique. Please enter a different one.");
                }

            } while (!isUnique);

            Console.WriteLine("Enter max number of Passengers:");
            int passengers = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the color:");
            string color = Console.ReadLine().ToUpper();

            IVehicle newVehicle = new Bus(model, manufacturer, vehicleType, regno, passengers, color);
            handler.AddVehicle(newVehicle);
        }

        public void searchVehicles()
        {
            Console.WriteLine("Enter search terms (separated by spaces):");
            string searchTermInput = Console.ReadLine();
            searchTerms = searchTermInput.Split(' ').ToList(); // Splits the input into search terms

            List<string> matchingVehicles = handler.SearchAndListVehicles(searchTerms); // Uses the list defined in GarageHandler to match input with current vehicles. 

            if (matchingVehicles.Count > 0) // For as long as it remains above zero, it iterates trough the list and pings any matches. 
            {
                Console.WriteLine("Matching Vehicles:");
                foreach (string vehicleInfo in matchingVehicles)
                {
                    Console.WriteLine(vehicleInfo);
                }
            }
            else
            {
                Console.WriteLine("No matching vehicles found.");
            }
        }
    }
}