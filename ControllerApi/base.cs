using System.Data.Common;
using ControllerApi.Models;
using ControllerApi.Interfaces;

namespace ControllerApi;

// Abstraction
// public abstract class Base // Abstract Class
// {
//     public abstract void Start(); // Abstract Method
//     public abstract void Stop(); // Abstract Method

//     public void Reset() // Normal Method
//     {
//         Console.WriteLine("Resetting the primary system!");
//     }
// }

// public class Car : Base
// {
//     // Note: We can not make object of abstract class
//     private string Category = "Car"; // Used private access modifier

//     private double fuel = 100;
//     public override void Start() // Uses the abstract method from the parent class
//     {
//         if (fuel < 20)
//         {
//             Console.WriteLine("Low Fuel!");
//         }
//         else
//         {
//             Console.WriteLine("You are good to go!");
//         }
//     }

//     public override void Stop()
//     {
//         if (fuel == 0)
//         {
//             Console.WriteLine("Your car has been stopped due to no fuel, Please refuel to start the car!");
//         }
//     }

//     public void Refuel(double amount)
//     {
//         if (fuel < 20)
//         {
//             Console.WriteLine("Refueling the car!");
//             fuel += amount;
//         }
//         else if (fuel == 100)
//         {
//             Console.WriteLine("Your car has already full capacity of fuel!");
//         }
//         else
//         {
//             Console.WriteLine("Your car has more fuel than minimum level no need to refuel!");
//         }
//     }

//     public double GetFuelLevel()
//     {
//         return fuel;
//     }

// }

// public class Vehicle
// {
//     public string Category = "Car";
//     public void Start() => Console.WriteLine("Starting vehicle...");

// }

// public class Bike : Vehicle
// {
//     public void Ride() => Console.WriteLine("Riding bike...");

//     // Inheritance: Used Category from parent class
//     // Polymorphism: Method Overloading
//     public void Ride(int a) => Console.WriteLine($"{Category} says: Woof!" + $"{a} times");
// }


// // Polymorphism

// // Method Overloading
// public class Inventory : Car
// {
//     public int AddInventory(int a, int b) => a + b; // Same name methods with different parameters
//     public double AddInventory(double a, double b) => a + b; //Method Overloading: Same name methods with different parameters
//     public virtual void GetInventory(int a) => Console.WriteLine("Inventory:" + a); // Same name methods
// };

// //Method Overriding
// public class InventoryDetails : Inventory
// {
//     public override void GetInventory(int a) => Console.WriteLine("No Items Left In Inventory!"); // Method is override form the parent class with same name and same parameters
//     static void Main()
//     {
//         //Object Creation
//         Bike newBike = new Bike();
//         newBike.Ride(); // Base Method Calling From Bike Class
//         newBike.Ride(5); // Overloaded Method Calling From Bike Class
//         Inventory inventory = new Inventory();
//         inventory.Refuel(20); // Inheritance: Refuel is not present in Inventory class but it is inherited from the parent class Car
//         // inventory.fuel = 150; // Encapsulation: Here it denies access to the private variable of the parent class because the property is private
//     }
// }

// Dependency Injection
public interface IPaymentService
{
    void MakePayment(decimal amount);
    string GetTransactionStatus(string transactionId);
    IEnumerable<Car> GetAllCars();
}

public class PaymentService : IPaymentService
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using PayPal.");
        Console.WriteLine($"Transaction successful! {amount} paid using PayPal.");
        Console.WriteLine($"Transaction Id: {Guid.NewGuid()}");
    }

    public string GetTransactionStatus(string transactionId)
    {
        return "Completed from PayPal";
    }

    private readonly List<Car> cars = new List<Car>{
        new Car{Category="Sedan", fuel=98},
        new Car{Category="Xuv", fuel=100},
        new Car{Category="Mini Xuv", fuel=78}
    };
    public IEnumerable<Car> GetAllCars()
    {
        return cars;
    }

}

public class PaymentGateway
{
    private readonly IPaymentService _payment;
    // public IPaymentService Payment { get; set; }

    public PaymentGateway(IPaymentService payment)
    {
        _payment = payment;  // Dependency Injection (Loosed Coupling)
    }

    // static void Main()
    // {
    //     PaymentService paymentService = new PaymentService();   // Dependency Injection (Tight Coupling)
    //     paymentService.MakePayment(100);
    // }


    // public void PrePayment(IPayment payment, decimal amount) //Method Dependency Injection
    public void PrePayment(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Please enter valid amount!");
        }
        else
        {
            _payment.MakePayment(amount); // Through Constructor Dependency Injection
            // Payment.MakePayment(amount); // Through Property Dependency Injection
            // payment.MakePayment(amount); // Through Method Dependency Injection
        }
    }
}