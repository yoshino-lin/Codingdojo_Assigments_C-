using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[10,10];
            for(int i=0;i<10;i++){
                for(int a=0;a<10;a++){
                    array2D[i,a] = (i+1)*(a+1);
                }
            }
            for(int i=0;i<10;i++){
                string list_out = "[";
                for(int a=0;a<10;a++){
                    list_out += array2D[i,a] + ", ";
                }
                list_out += "]";
                Console.WriteLine(list_out);
            }
        }
    }
}
