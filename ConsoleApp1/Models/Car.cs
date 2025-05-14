using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Car : Base
    {
        // Note: We can not make object of abstract class
        private string Category = "Car"; // Used private access modifier

        private double fuel = 100;
        public override void Start() // Uses the abstract method from the parent class
        {
            if (fuel < 20)
            {
                Console.WriteLine("Low Fuel!");
            }
            else
            {
                Console.WriteLine("You are good to go!");
            }
        }

        public override void Stop()
        {
            if (fuel == 0)
            {
                Console.WriteLine("Your car has been stopped due to no fuel, Please refuel to start the car!");
            }
        }

        public void Refuel(double amount)
        {
            if (fuel < 20)
            {
                Console.WriteLine("Refueling the car!");
                fuel += amount;
            }
            else if (fuel == 100)
            {
                Console.WriteLine("Your car has already full capacity of fuel!");
            }
            else
            {
                Console.WriteLine("Your car has more fuel than minimum level no need to refuel!");
            }
        }

        public double GetFuelLevel()
        {
            return fuel;
        }
    }
}