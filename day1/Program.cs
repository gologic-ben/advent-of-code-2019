using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2019 - Day 1");
            Decimal required = 0;
            String fileName = "input.data";
            var lines = File.ReadAllLines(fileName);

            // Day 1 / half one
            /*
            // Test
            Console.WriteLine("Testing..." + calculateFuelRequirements(12));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(12)));
            Console.WriteLine("Testing..." + calculateFuelRequirements(14));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(14)));
            Console.WriteLine("Testing..." + calculateFuelRequirements(1969));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(1969)));
            Console.WriteLine("Testing..." + calculateFuelRequirements(100756));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(100756)));
            for (var i = 0; i < lines.Length; i += 1) {
                required += calculateFuelRequirements(Decimal.Parse(lines[i]));
            }
            */
            // Day 1 / half two
            // Test
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(12)));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(14)));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(1969)));
            Console.WriteLine("Testing Additional fuel..." + calculateAdditinoalFuelRequirements(calculateFuelRequirements(100756)));
            for (var i = 0; i < lines.Length; i += 1) {
                Decimal fuelRequired = calculateFuelRequirements(Decimal.Parse(lines[i]));
                required += calculateAdditinoalFuelRequirements(fuelRequired);
            }

            Console.WriteLine("Fuel required is " + required);
        }
        /**
         * Fuel required to launch a given module is based on its mass. 
         * Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.
         */
        static Decimal calculateFuelRequirements(Decimal mass) {
            Decimal fuel = System.Math.Floor(mass/3) - 2; 
            Console.WriteLine("--> Processing mass of " + mass + ", fuel requirements is " + fuel);
            return fuel;           
        }

        /**
        * So, for each module mass, calculate its fuel and add it to the total.
        * Then, treat the fuel amount you just calculated as the input mass and repeat the process, continuing until a fuel requirement is zero or negative.
        */
        static Decimal calculateAdditinoalFuelRequirements(Decimal fuel) {
            Decimal fuelSum = fuel;
            while(calculateFuelRequirements(fuel) > 0) {
                fuel = calculateFuelRequirements(fuel);
                fuelSum += fuel;
                Console.WriteLine("--> Processing additional fuel of " + fuel + ", sum is " + fuelSum);
            }
            return fuelSum;
        }

    }
}
