using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    //Method Overriding
    public class InventoryDetails : Inventory
    {
        public override void GetInventory(int a) => Console.WriteLine("No Items Left In Inventory!"); // Method is override form the parent class with same name and same parameters
        static void Main()
        {
            //Object Creation
            Bike newBike = new Bike();
            newBike.Ride(); // Base Method Calling From Bike Class
            newBike.Ride(5); // Overloaded Method Calling From Bike Class
            Inventory inventory = new Inventory();
            inventory.Refuel(20); // Inheritance: Refuel is not present in Inventory class but it is inherited from the parent class Car
            // inventory.fuel = 150; // Encapsulation: Here it denies access to the private variable of the parent class because the property is private
        }
    }
}