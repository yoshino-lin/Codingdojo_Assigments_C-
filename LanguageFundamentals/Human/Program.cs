using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Human{
    // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        
        // add a public "getter" property to access health
        public int getter{
            get{return health;}
        }
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public string constructor1{
            get{
                return Name;
            }
            set{
                Name = value;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                health = 100;
            }
        }
        // Add a constructor to assign custom values to all fields
        public Human(string C_name, int C_strength, int C_intelligence, int C_dexterity, int C_health){
            Name=C_name;
            Strength=C_strength;
            Intelligence=C_intelligence;
            Dexterity=C_dexterity;
            health=C_health;
        }
        // Build Attack method
        public int Attack(Human target){
            health-=5;
            return getter;
        }
    }
}
