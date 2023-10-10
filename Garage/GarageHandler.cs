using Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GarageMaker
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> newGarage;

        //private Garage<Airplane> airplaneGarage; //These were meant for unique vehicle garages. But the code got messy, needed to move onto the tests. 
        //private Garage<Bus> busGarage;
        //private Garage<Car> carGarage;
        //private Garage<MotorCycle> motorcycleGarage;
        //private Garage<Boat> boatGarage;

        public GarageHandler(int capacity)
        {
            newGarage = new Garage<IVehicle>(capacity);
            //airplaneGarage = new Garage<Airplane>(capacity);
            //busGarage = new Garage<Bus>(capacity);
            //carGarage = new Garage<Car>(capacity);
            //motorcycleGarage = new Garage<MotorCycle>(capacity);
            //boatGarage = new Garage<Boat>(capacity);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            newGarage.AddVehicle(vehicle);
        }

        public bool IsGarageFull()
        {
            return newGarage.IsFull();
        }

        public List<string> ListAllVehiclesInGarage()
        {
            List<string> vehicleList = new List<string>();

            foreach (var vehicle in newGarage)
            {
                string vehicleInfo = GetVehicleInfo(vehicle);
                if (vehicleInfo != null)
                {
                    vehicleList.Add(vehicleInfo);
                }
            }

            return vehicleList;
        }

        public int GetFilledSpots()
        {
            return newGarage.CountNonEmptySpots();
        }

        public string GetVehicleInfo(IVehicle vehicle)
        {
            if (vehicle is Car car && car != null)
            {
                return $"Car - Model: {car.Model}, Vehicle Type: {car.VehicleType}, manufacturer: {car.Manufacturer}, Registration Number: {car.RegNo}, Number of Wheels: {car.Nrofwheels}";
            }
            else if (vehicle is Airplane airplane)
            {
                return $"Airplane - Model: {airplane.Model}, Vehicle Type: {airplane.VehicleType}, manufacturer: {airplane.Manufacturer}, Registration Number: {airplane.RegNo}, Wingspan: {airplane.Wingspan}";
            }
            else if (vehicle is Bus bus)
            {
                return $"Bus - Model: {bus.Model}, Vehicle Type: {bus.VehicleType}, manufacturer: {bus.Manufacturer}, Registration Number: {bus.RegNo}, Passengers: {bus.Passengers}";
            }
            else if (vehicle is Boat boat)
            {
                return $"Boat - Model: {boat.Model}, Vehicle Type: {boat.VehicleType}, manufacturer: {boat.Manufacturer}, Registration Number: {boat.RegNo}, Speed Knots: {boat.SpeedKnots}";
            }
            else if (vehicle is MotorCycle motorCycle)
            {
                return $"Motorcycle - Model: {motorCycle.Model}, Vehicle Type: {motorCycle.VehicleType}, manufacturer: {motorCycle.Manufacturer}, Registration Number: {motorCycle.RegNo}, Offroad: {motorCycle.Offroad}";
            }

            return null; // If the vehicle type is not recognized
        }

        public List<string> SearchAndListVehicles(List<string> searchTerms)
        {
            List<string> matchingVehicles = new List<string>();

            foreach (var vehicle in newGarage)
            {
                // Check if the vehicle matches any of the search terms
                if (MatchesSearchTerms(vehicle, searchTerms))
                {
                    string vehicleInfo = GetVehicleInfo(vehicle);
                    if (vehicleInfo != null)
                    {
                        matchingVehicles.Add(vehicleInfo);
                    }
                }
            }

            return matchingVehicles;
        }

        private bool MatchesSearchTerm(IVehicle vehicle, string searchTerm)
        {
          
            if (vehicle is Car car)
            {
                if (car.RegNo.Contains(searchTerm) ||
                    car.Model.Contains(searchTerm) ||
                    car.Manufacturer.Contains(searchTerm) ||
                    car.VehicleType.Contains(searchTerm))
                {
                    return true;
                }
            }
            else if (vehicle is Airplane airplane)
            {
                if (airplane.RegNo.Contains(searchTerm) ||
                     airplane.Model.Contains(searchTerm) ||
                     airplane.Manufacturer.Contains(searchTerm) ||
                     airplane.VehicleType.Contains(searchTerm))
                {
                    return true;
                }
            }
            else if (vehicle is Bus bus)
            {
                if (bus.RegNo.Contains(searchTerm) ||
                     bus.Model.Contains(searchTerm) ||
                     bus.Manufacturer.Contains(searchTerm) ||
                     bus.VehicleType.Contains(searchTerm))
                {
                    return true;
                }
            }
            else if (vehicle is Boat boat)
            {
                if (boat.RegNo.Contains(searchTerm) ||
                     boat.Model.Contains(searchTerm) ||
                     boat.Manufacturer.Contains(searchTerm) ||
                     boat.VehicleType.Contains(searchTerm))
                {
                    return true;
                }
            }
            else if (vehicle is MotorCycle motorcycle)
            {
                if (motorcycle.RegNo.Contains(searchTerm) ||
                     motorcycle.Model.Contains(searchTerm) ||
                     motorcycle.Manufacturer.Contains(searchTerm) ||
                     motorcycle.VehicleType.Contains(searchTerm))
                {
                    return true;
                }
            }

            return false; // If the vehicle doesn't match the search term
        }

        private bool MatchesSearchTerms(IVehicle vehicle, List<string> searchTerms)
        {
           
            foreach (string searchTerm in searchTerms)
            {
             
                if (MatchesSearchTerm(vehicle, searchTerm))
                {
                    return true;
                }
            }

            return false; 
        }
       
    }



}

   

