using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2019 - Day 1");
            
            // Test
            Console.WriteLine("Testing..." + calculateFuelRequirements(12));
            Console.WriteLine("Testing..." + calculateFuelRequirements(14));
            Console.WriteLine("Testing..." + calculateFuelRequirements(1969));
            Console.WriteLine("Testing..." + calculateFuelRequirements(100756));

            Decimal required = 0;
            String fileName = "input.data";
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i += 1) {
                required += calculateFuelRequirements(Int32.Parse(lines[i]));
            }
            Console.WriteLine("Fuel required is " + required);
        }
        /**
         * Fuel required to launch a given module is based on its mass. 
         * Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.
         */
        static Decimal calculateFuelRequirements(int mass) {
            Decimal fuel = System.Math.Floor(new Decimal(mass/3)) - 2; 
            Console.WriteLine("Processing mass of " + mass + ", fuel requirements is " + fuel);
            return fuel;           
        }
    }
}
