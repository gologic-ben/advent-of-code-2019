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
            String[] intCodeStr = lines[0].Split(",");
            String expected = "19690720";

            /* day 2 / first half
            int noun = 12;
            int verb = 2;
            String expected = "19690720";
            String result = testNounAndVerb(intCodeStr, noun, verb);
            Console.WriteLine("noun = " + noun + ", verb = " + verb + ", result + " + result + ", test is " + (expected == result));
            */

            // day 2 / second half
            var expectedNoun = 0;
            var expectedVerb = 0;
            for(var noun=0; noun <= 99; noun++) {
                for(var verb=0; verb <= 99; verb++) {
                    String result = testNounAndVerb(intCodeStr, noun, verb);
                    if(expected == result) {
                        Console.WriteLine("noun = " + noun + ", verb = " + verb + ", result + " + result + ", test is " + (expected == result));
                        expectedNoun = noun;
                        expectedVerb = verb;
                        break;
                    }
                }
            }
            // What is 100 * noun + verb?
            Console.WriteLine(100 * expectedNoun + expectedVerb);
        }

        static String testNounAndVerb(String[] intCodeStr, int noun, int verb) {
            intCodeStr[1] = noun.ToString();
            intCodeStr[2] = verb.ToString();
            String newIntCode = String.Join(",", intCodeStr);
            int[] intCode = processIntCode(newIntCode);
            return intCode[0].ToString();
        }

        static int[] processIntCode(String input) {
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
