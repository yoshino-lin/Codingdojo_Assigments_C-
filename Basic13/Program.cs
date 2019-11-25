using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSum();
        }
        public static void PrintNumbers(){
            for(int i=1;i<=255;i++){
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds(){
            for(int i=1;i<=255;i++){
                if(i%2!=0){
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum(){
            int sum=0;
            for(int i=0;i<=255;i++){
                sum+=i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        public static void LoopArray(int[] numbers){
            for(int i=0;i<=numbers.Count;i++){
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
