using System;
using System.IO;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2019 - Day 2");

            String fileName = "input.data";
            var lines = File.ReadAllLines(fileName);
            
            // https://adventofcode.com/2019/day/2

            // TEST
            //String test = "1,9,10,3,2,3,11,0,99,30,40,50";
            //String result = "3500,9,10,70,2,3,11,0,99,30,40,50";
            //String output = String.Join(",", getInitialValue(test));
            //Console.WriteLine("Testing... " + test + " ==> " + output + ", test =" + (output==result));

            // Executing...
            // Once you have a working computer, the first step is to restore the gravity assist program (your puzzle input) 
            //  to the "1202 program alarm" state it had just before the last computer caught fire. 
            //  To do this, before running the program, replace position 1 with the value 12 and replace position 2 with the value 2.
            String[] intCodeStr = lines[0].Split(",");
            intCodeStr[1] = "12";
            intCodeStr[2] = "2";
            String newIntCode = String.Join(",", intCodeStr);
            String output = String.Join(",", getInitialValue(newIntCode));
            Console.WriteLine("Testing... " + newIntCode);
            Console.WriteLine("Result... " + output);
        }
        static int[] getInitialValue(String input) {
            String[] intCodeStr = input.Split(",");
            int[] intCode = Array.ConvertAll(intCodeStr, s => int.Parse(s));

            for(int i=0; i <= intCode.Length; i++) {
                if(i%4==0) {
                    int opCode = intCode[i];
                    int inputPos1 = intCode[i+1];
                    int inputPos2 = intCode[i+2];
                    int outputPos = intCode[i+3];
                    // Console.WriteLine(opCode + ", " + inputPos1 + ", " + inputPos2 + ", " + outputPos);
                    if(opCode == 1) intCode[outputPos] = intCode[inputPos1] + intCode[inputPos2];
                    if(opCode == 2) intCode[outputPos] = intCode[inputPos1] * intCode[inputPos2];
                    if(opCode == 99) return intCode;
                }
            }
            return intCode;
        }

    }
}
