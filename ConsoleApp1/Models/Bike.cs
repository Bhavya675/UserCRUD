using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Bike : Vehicle
    {
        public void Ride() => Console.WriteLine("Riding bike...");

        // Inheritance: Used Category from parent class
        // Polymorphism: Method Overloading
        public void Ride(int a) => Console.WriteLine($"{Category} says: Woof!" + $"{a} times");
    }
}