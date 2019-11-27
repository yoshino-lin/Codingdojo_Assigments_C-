using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            int[] numArray = {1,2,3,4,5,6,7,8,9};
            string[] numArray2 = {"Tim","Martin","Nikki","Sara"};
            bool[] numArray3 = {true,false,true,false,true,false,true,false,true};
            //List of Flavors
            List<string> Flavors = new List<string>();
            Flavors.Add("Chocolate");
            Flavors.Add("Strawberry");
            Flavors.Add("Vanilla");
            Flavors.Add("GreenTea");
            Flavors.Add("Mango");
            Console.WriteLine(Flavors.Count);
            Console.WriteLine(Flavors[2]);
            Flavors.RemoveAt(2);
            Console.WriteLine(Flavors.Count);
            //User Info Dictionary
            Dictionary<string,string> profile = new Dictionary<string,string>();
            Random rand = new Random();
            for(int i=0;i<numArray2.Length;i++){
                profile.Add(numArray2[i], Flavors[rand.Next(Flavors.Count)]);
            }
            foreach(var entry in profile){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
            
        }
    }
}
