using Garage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GarageMaker
{
    public abstract class Vehicle : IVehicle
    {

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string VehicleType { get; set; }

        public string RegNo { get; set; }

        public string Color { get; set; }


        public Vehicle(string model, string manufacturer, string vehicleType, string regno, string color)
        {

            Model = model;

            VehicleType = vehicleType;

            Manufacturer = manufacturer;

            RegNo = regno;

            Color = color;

        }


    }
    internal class Airplane : IVehicle
    {
        public int Wingspan { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public string RegNo { get; set; }
        public string Color { get; set; }

        public Airplane(string model, string vehicleType, string manufacturer, string regno, int wingspan, string color)
        {
            Model = model;
            VehicleType = vehicleType;
            Manufacturer = manufacturer;
            RegNo = regno;
            Wingspan = wingspan;
            Color = color;

        }

    }

    public class Car : IVehicle
    {
        public int Nrofwheels { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public string RegNo { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"Model: {Model}, Vehicle Type: {VehicleType}, manufacturer: {Manufacturer}, Registration Number: {RegNo}, Number of Wheels: {Nrofwheels}";
        }
        public Car(string model, string manufacturer, string vehicleType, string regno, int nrofwheels, string color)

        {
            Model = model;
            VehicleType = vehicleType;
            Manufacturer = manufacturer;
            RegNo = regno;
            Nrofwheels = nrofwheels;
            Color = color;
        }

    }

    public class Bus : IVehicle
    {
        public string RegNo { get; set; }
        public int Passengers { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }


        public override string ToString()
        {
            return $"Model: {Model}, Vehicle Type: {VehicleType}, manufacturer: {Manufacturer}, Registration Number: {RegNo}, Number of Passengers: {Passengers}";
        }
        public Bus(string model, string vehicleType, string manufacturer, string regno, int passangers, string color)
 
        {
            Model = model;
            VehicleType = vehicleType;
            Manufacturer = manufacturer;
            RegNo = regno;
            Passengers = passangers;
            Color = color;

        }

    }
    public class Boat : IVehicle
    {
        public string RegNo { get; set; }
        public int Passengers { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public int SpeedKnots { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"Model: {Model}, Vehicle Type: {VehicleType}, manufacturer: {Manufacturer}, Registration Number: {RegNo}, Top Speed: {SpeedKnots}";
        }
        public Boat(string model, string vehicleType, string manufacturer, string regno, int speedknots, string color)
        
        {
            Model = model;
            VehicleType = vehicleType;
            Manufacturer = manufacturer;
            RegNo = regno;
            SpeedKnots = speedknots;
            Color = color;
        }

    }

    public class MotorCycle : IVehicle
    {
        public string RegNo { get; set; }
        public int Passengers { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public string Offroad { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Model: {Model}, Vehicle Type: {VehicleType}, manufacturer: {Manufacturer}, Registration Number: {RegNo}, Offroad: {Offroad}";
        }
        public MotorCycle(string model, string vehicleType, string manufacturer, string regno, string offroad, string color)
            
        {
            Model = model;
            VehicleType = vehicleType;
            Manufacturer = manufacturer;
            RegNo = regno;
            Offroad = offroad;
            Color = color;


        }

    }
    
 



}
