using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
        }
    }
    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int health;
        public int Health{
            get { return health; }
        }
        public Human(string name){
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int str, int intel, int dex, int hp){
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
        // Build Attack method
        public virtual void Attack(Human target){
            int dmg = Strength * 3;
            target.health -= dmg;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }
    }
    class Wizard : Human{
        public Wizard(string name) : base(name){
            health=50;
            Intelligence=175;
        }
        public override void Attack(Human target){
            int dmg = Intelligence * 5;
            target.health -= dmg;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }
        public void heal(Human target){
            target.health += Intelligence * 10;
        }
    }
    class Ninja : Human{
        public Random rand = new Random();
        public Ninja(string name) : base(name){
            Dexterity = 200;
        }
        public override void Attack(Human target){
            int dmg = Dexterity * 5;
            int chance = rand.Next(1,101);
            if(chance <=20){
                dmg+=10;
            }
            target.health -= dmg;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }
        public void Steal(Human target){
            target.health-=5;
            health+=5;
        }
    }
    class Samurai : Human{
        public Samurai(string name) : base(name){
            health=200;
        }
        public override void Attack(Human target){
            base.Attack(target);
            if(target.health<50){
                target.health=0;
            }
        }
        public void Meditate(){
            health=200;
        }
    }
}
