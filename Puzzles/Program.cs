using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(TossMultipleCoins(10));
            //Console.WriteLine(Names()[1]);
        }
        public static Random rand = new Random();
        public static void RandomArray(){
            int[] numArray = new int[10];
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
        public static string TossCoin(){
            int result = rand.Next(0,2);
            if(result == 0){
                Console.WriteLine("Heads");
                return "Heads";
            }else{
                Console.WriteLine("Tails");
                return "Tails";
            }
        }
        public static double TossMultipleCoins(int num){
            int head_times=0,tail_times = 0;
            for(int i=0; i<num;i++){
                string result_of = TossCoin();
                if(result_of == "Heads"){
                    head_times++;
                }else{
                    tail_times++;
                }
            }
            return (float)head_times/num;
        }
        public static List<object> Names(){
            List<object> name = new List<object>();
            name.Add("Todd");
            name.Add("Tiffany");
            name.Add("Charlie");
            name.Add("Geneva");
            name.Add("Sydney");
            for(int i=0;i<name.Count;i++){
                int new_idx = rand.Next(0,name.Count);
                string temp = (string)name[i];
                name[i] = name[new_idx];
                name[new_idx] = temp;
            }
            for(int i=0;i<name.Count;i++){
                if(name[i].<)
            }
            return name;
        }
        
    }
}
