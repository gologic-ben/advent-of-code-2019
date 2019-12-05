using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2019 - Day 3");

            String fileName = "input.data";
            var lines = System.IO.File.ReadAllLines(fileName);
            Console.WriteLine("lines length is " + lines.Length);

            String[] wires = new String[2];
            // Exemple 1
            //wires = new String[]{"R8,U5,L5,D3","U7,R6,D4,L4"};
            // Exemple 2
            //wires = new String[]{"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83"};
            // Exemple 3
            //wires = new String[]{"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51","U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"};
            // input
            wires = lines;
            int centralX = 0; 
            int centralY = 0;
            // move wires
            var wire1 = drawWires(centralX, centralY, wires[0].Split(","));
            var wire2 = drawWires(centralX, centralY, wires[1].Split(","));
            // intersections
            var intersections = getIntersections(wire1, wire2);
            // calculate distance
            int distance = manhattan(centralX, centralY, intersections);
            Console.WriteLine("Manhattan distance is " + distance);
        }

        static Dictionary<int, List<int>> drawWires(int x, int y, String[] points) {            
            var wire = new Dictionary<int, List<int>>();
            Console.WriteLine("starting at [" + x + "][" + y + "]");
            foreach (String p in points) {                
                int move = Int32.Parse(p.Substring(1));
                String direction = p.Substring(0,1);
                for(var i=0; i < move; i++) {
                    if(direction == "R") x++;
                    if(direction == "L") x--;
                    if(direction == "U") y++;
                    if(direction == "D") y--;
                    if(!wire.ContainsKey(x)) {
                        wire.TryAdd(x, new List<int>());
                    }
                    wire[x].Add(y);
                }
                Console.Write("[" + x + "][" + y + "];");
            }            
            return wire;
        }

        static Dictionary<int, List<int>> getIntersections(Dictionary<int, List<int>> wire1, Dictionary<int, List<int>> wire2) {
            var intersections = new Dictionary<int, List<int>>();

            foreach (var pair in wire1) {
                int x = pair.Key;
                if(wire2.ContainsKey(x)) {                        
                    List<int> ys1 = pair.Value;
                    List<int> ys2 = wire2[x];
                    intersections.TryAdd(x, new List<int>(ys1.Intersect(ys2)));
                }
            }
            return intersections;
        }

        static int manhattan(int x, int y, Dictionary<int, List<int>> intersections) {
            int central = x + y;
            int manhattan = 0;
            foreach (var pair in intersections) {
                int i = pair.Key;
                foreach(int j in pair.Value) {
                    Console.WriteLine("Found a intersection at [" + i + "][" + j + "]");
                    int distanceX = Math.Abs(x - i);
                    int distanceY = Math.Abs(y - j);
                    int distance = distanceX + distanceY;
                    if(manhattan == 0 || manhattan > distance) {
                        Console.WriteLine("Found a smallest distance at [" + i + "][" + j + "], central is " + central + ", distance is " + distance + ", manhattan is " + manhattan);
                        manhattan = distance;
                    }
                }
            }
            return manhattan;
        }
    }


}
