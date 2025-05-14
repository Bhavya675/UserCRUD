using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class Base
    {
        public abstract void Start(); // Abstract Method
        public abstract void Stop(); // Abstract Method

        public void Reset() // Normal Method
        {
            Console.WriteLine("Resetting the primary system!");
        }
    }
}