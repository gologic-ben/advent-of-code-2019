using System;
using System.Collections.Generic;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2019 - Day 4");

            List<string> valids = new List<string>();
            int min = 231832;
            int max = 767346;

//min = 555666; max = 555666;
            for(var i=min; i <= max; i++) {
                char[] pass = i.ToString().ToCharArray();
                isValid(ref valids, pass);
            }
            Console.WriteLine("possible solutions are " + valids.ToArray().Length);
        }

        static void isValid(ref List<string> valids, char[] pass) {
            Boolean same = false; // Two adjacent digits are the same
            Boolean decrease = false; // Going from left to right, the digits never decrease; they only ever increase or stay the same
            Boolean larger = false; // are not part of a larger group of matching digits.
            String passString = String.Join("", pass);
            // Console.WriteLine("validate " + passString);
            
            for(var i=0; i < pass.Length; i++) {
                if(i+1<pass.Length && pass[i+1] < pass[i] ) {
                    decrease = true;
                    break;
                }
            }      
            if(!decrease) {         // ok ! all digits increased
                for(var i=0; i < pass.Length; i++) {
                    if( (i-1>=0 && pass[i-1]==pass[i]) || (i+1<pass.Length && pass[i+1]==pass[i]) ) {
                        // same and not large
                        same = true;
                        //Console.WriteLine(passString);
                        // check if is same digit on the right
                        if(i+2<pass.Length) {
                            for(var j=i+2; j<pass.Length; j++) {
                                if(pass[i] == pass[j]) {
                                    same = false;
                                }
                            }
                            if(!same) {
                                Console.WriteLine("same on the right == " +i +", " + passString);
                            }
                        }
                        // check if is same digit on the left
                        if(i-2>=0 && same) {
                            for(var j=i-2; j>=0; j--) {
                                if(pass[i] == pass[j]) {
                                    same = false;
                                }
                            }
                            if(!same) {
                                Console.WriteLine("same on the left == "+i +", " + passString);
                            }
                        }
                        if(same) {
                            if( (i-1>=0 && pass[i-1]==pass[i]) && (i+1<pass.Length && pass[i+1]==pass[i]) ) {
                                Console.WriteLine("same on left and right == "+i +", " + passString);
                                same = false;
                            }
                        }
                        if(same) {
                            Console.WriteLine("found one " + i + ", " + passString);
                            break;
                        }
                    }
                }
                if(same) {
                    Console.WriteLine(passString);
                    valids.Add(passString);
                }
            }

        }
    }
}
