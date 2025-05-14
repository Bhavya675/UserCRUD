using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Vehicle
    {
        public string Category = "Car";
        public void StartVehicle() => Console.WriteLine("Starting vehicle...");
    }
}