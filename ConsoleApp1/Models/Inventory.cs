using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    // Polymorphism

    // Method Overloading
    public class Inventory: Car
    {
        public int AddInventory(int a, int b) => a + b; // Same name methods with different parameters
        public double AddInventory(double a, double b) => a + b; //Method Overloading: Same name methods with different parameters
        public virtual void GetInventory(int a) => Console.WriteLine("Inventory:" + a); // Same name methods
    }
}