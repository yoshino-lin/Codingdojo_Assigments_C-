using System;

namespace FirstCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=1;i<=255;i++){
                Console.WriteLine(i);
            }
            for(int i=1;i<=255;i++){
                if(i%3==0 && i%5!=0){
                    Console.WriteLine(i);
                }else if(i%5==0 && i%3!=0){
                    Console.WriteLine(i);
                }
            }
            for(int i=1;i<=100;i++){
                if(i%3==0 && i%5==0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3==0){
                    Console.WriteLine("Fizz");
                }else if(i%5==0){
                    Console.WriteLine("Buzz");
                }
            }
            for(int i=1;i<=100;i++){
                if(i%3==0 && i%5==0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3==0){
                    Console.WriteLine("Fizz");
                }else if(i%5==0){
                    Console.WriteLine("Buzz");
                }
            }
            int a=1;
            while(a<=100){
                if(a%3==0 && a%5==0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(a%3==0){
                    Console.WriteLine("Fizz");
                }else if(a%5==0){
                    Console.WriteLine("Buzz");
                }
                a++;
            }
        }
    }
}
