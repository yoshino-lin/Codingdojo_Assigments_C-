using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
        }
        public static void RandomArray(){
            int[] numArray = new int[10];
            Random rand = new Random();
            for(int val = 0; val < 10; val++){
                numArray[val] = rand.Next(5,26);
            }
            int sum = 0;
            int min = numArray[0];
            int max = numArray[0];
            for(int i=0;i<numArray.Length;i++){
                sum += numArray[i];
                if(min>numArray[i]){
                    min = numArray[i];
                }
                if(max<numArray[i]){
                    max = numArray[i];
                }
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Avg:{(double)sum/numArray.Length}");
        }
        
    }
}
