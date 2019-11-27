using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxes = new List<object>();
            boxes.Add(7);
            boxes.Add(28);
            boxes.Add(-1);
            boxes.Add(true);
            boxes.Add("chair");
            int sum=0;
            for(var i=0;i<boxes.Count;i++){
                if(boxes[i] is int){
                    Console.WriteLine("Int: "+boxes[i]);
                    sum += (int)boxes[i];
                }else if(boxes[i] is string){
                    Console.WriteLine("String:"+boxes[i]);
                }else if(boxes[i] is bool){
                    Console.WriteLine("Boolean:"+boxes[i]);
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
