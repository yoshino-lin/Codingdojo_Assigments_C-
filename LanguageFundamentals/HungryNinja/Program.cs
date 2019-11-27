using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja yudong = new Ninja();
            Buffet stuffToEat = new Buffet();
            while(yudong.IsFull!=true){
                yudong.Eat(stuffToEat.Serve());
            }
        }
    }
    class Food{
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweetcopy
        public Food(string name, int calories, bool isSpicy, bool isSweet){
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }
    class Buffet{
        Random rand = new Random();
        public List<Food> Menu;
        //constructor
        public Buffet(){
            Menu = new List<Food>(){
                new Food("Fish", 400, false, false),
                new Food("Pork", 600, true, false),
                new Food("Vegetable", 350, false, false),
                new Food("Fruit", 300, false, true),
                new Food("Cheeseburger", 550, false, false),
                new Food("Taco", 450, true, true),
                new Food("Candy", 200, false, true),
                new Food("Chili", 100, true, false)
            };
        }
        public Food Serve(){
            return Menu[rand.Next(0,Menu.Count)];
        }
    }
    class Ninja{
        private int calorieIntake;
        public List<Food> FoodHistory;
        // add a constructor
        public Ninja(){
            calorieIntake=0;
            FoodHistory = new List<Food>();
        }
        // add a public "getter" property called "IsFull"
        public bool IsFull{
            get{
                if(calorieIntake>1200){
                    return true;
                }else{
                    return false;
                }
            }
        }
        // build out the Eat method
        public void Eat(Food item){
            if(IsFull==false){
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.Write($"Name: {item.Name}, Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}");
            }else{
                Console.WriteLine("This Ninja is full and cannot eat any more");
            }
        }
    }
}
