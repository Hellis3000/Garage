using Garage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GarageMaker
{
     public class Garage<T> : IEnumerable<T> where T :  IVehicle
    {

        private T[] vehicles;
        private int capacity;
        //IsFull






        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
        
        }
        public void AddVehicle(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return;
                }
            }
            
            Console.WriteLine("The garage is full. Cannot add more vehicles.");
        }

     public bool IsFull()
        {
            // Check if the number of non-null elements in the array equals the capacity
            return vehicles.Count(item => item != null) >= capacity;
        }

        public int CountNonEmptySpots()
        {
            return vehicles.Count(item => item != null);
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if (item != null) {
                    yield return item;

                }

                else if(item == null){
                    Console.WriteLine("No Vehicle Found");
                }
               
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
  



}


