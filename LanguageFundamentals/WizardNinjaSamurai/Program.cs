using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human me = new Human("me");
            Ninja tokyo = new Ninja("tokyo");
            Wizard pine = new Wizard("pine");
            Samurai king = new Samurai("king");
            me.Attack(tokyo);
            System.Console.WriteLine($"tokyo's health: {tokyo.Health}");
            pine.Heal(tokyo);
            System.Console.WriteLine($"tokyo's health: {tokyo.Health}");
            tokyo.Steal(king);
            System.Console.WriteLine($"tokyo's health: {tokyo.Health}");
            System.Console.WriteLine($"king's health: {king.Health}");
            king.Meditate();
            System.Console.WriteLine($"king's health: {king.Health}");
        }
    }
    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        
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
        public virtual int Attack(Human target){
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
        public int decreaseHealth(int dmg){
            health -= dmg;
            return health;
        }

        public int increaseHealth(int hp_amount){
            health += hp_amount;
            return health;
        }
    }
    class Wizard : Human{
        public Wizard(string name) : base(name){
            health=50;
            Intelligence=175;
        }
        public override int Attack(Human target){
            int dmg = Intelligence * 5;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.decreaseHealth(dmg);
        }
        public int Heal(Human target){
            return target.increaseHealth(Intelligence * 10);
        }
    }
    class Ninja : Human{
        public Random rand = new Random();
        public Ninja(string name) : base(name){
            Dexterity = 200;
        }
        public override int Attack(Human target){
            int dmg = Dexterity * 5;
            int chance = rand.Next(1,101);
            if(chance <=20){
                dmg+=10;
            }
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.decreaseHealth(dmg);
        }
        public int Steal(Human target){
            health+=5;
            return target.decreaseHealth(5);
        }
    }
    class Samurai : Human{
        public Samurai(string name) : base(name){
            health=200;
        }
        public override int Attack(Human target){
            base.Attack(target);
            if(target.Health<50){
                target.decreaseHealth(target.Health);
                Console.WriteLine($"Due to Samurai's skill, {Name} have 0 hp remaining!");
            }
            return target.Health;
        }
        public int Meditate(){
            health=200;
            return health;
        }
    }
}
