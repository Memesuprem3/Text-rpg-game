using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Player.Player;
using Text_rpg_game.classer.Shops;

namespace Text_rpg_game.classer.Monsters
{
    public class Monster
    {        
        public string Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public int XPValue;
        public List<Equipment> LootTable { get; set; } = new List<Equipment>();

        public Monster(string name, int power, int health, int xpValue)
        {
            Name = name;
            Power = power;
            Health = health;
            XPValue = xpValue;
        }


        public void AddLoot(Equipment equipment)
        {
            LootTable.Add(equipment);
        }

        // Metod för att lägga till loot till monstret
        public List<Equipment> Defeat()
        {
            Console.WriteLine($"{Name} Defeated!");
            return LootTable;
        }
        public void Defeated(CurrentPlayer player)
        {
            Console.WriteLine($"{Name} besegrad!");
            player.AddXP(XPValue);  // Tilldela XP till spelaren
        }

        // Statisk metod för att generera slumpmässiga monster
        public static Monster GenerateRandomMonster(int playerLevel)
        {
            Random rand = new Random();
            int choice = rand.Next(0, 5);

            switch (choice)
            {
                case 0:
                    return Orc.CreateRandomOrc(playerLevel);
                case 1:
                    return Skeleton.CreateRandomSkeleton(playerLevel);
                case 2:
                    return Undead.CreateRandomUndead(playerLevel);
                case 3:
                    return Troll.CreateRandomTroll(playerLevel);
                case 4:
                    return Vampire.CreateRandomVampire(playerLevel);
                case 5:
                    return Goblin.CreateRandomGoblin(playerLevel);
                case 6:
                    return Human.CreateRandomHuman(playerLevel);
                default:
                    return Rat.CreateRandomRat(playerLevel);
            }
        }
        public class Human : Monster
        {
            public Human(string name, int power, int health, int xpValue) : base(name, power, health, xpValue)
            {
                //förmågor eller egenskaper
            }

            public static Human CreateRandomHuman(int playerLevel)
            {
                Random rand = new Random();
                List<Monster> possibleMonsters = new List<Monster>();


                if (playerLevel <= 5)
                {
                    possibleMonsters.Add(new Human("Bandit",2,7,20));

                }

                if (playerLevel <= 10)
                {

                }

                if (playerLevel <= 20)
                {

                }

                if (possibleMonsters.Count > 0)
                {
                    return (Human)possibleMonsters[rand.Next(possibleMonsters.Count)];
                }
                return new Human("Skön Grabb", 1, 2,3);
            }
        }


        public class Orc : Monster
        {
            public Orc(string name, int power, int health, int xpValue) : base(name, power, health, xpValue)
            {
                // Ytterligare kod för Orc specifika egenskaper kan läggas här
            }

            public static Orc CreateRandomOrc(int playerLevel)
            {
                Random rand = new Random();
                List<Monster> possibleMonsters = new List<Monster>();

                if (playerLevel <= 5)
                {
                    possibleMonsters.Add(new Orc("Orc", 2, 3,10));
                    
                }
                if (playerLevel <= 10)
                {
                    possibleMonsters.Add(new Orc("Orc Archer", 5, 6, 50));
                    possibleMonsters.Add(new Orc("Orc Spearman", 5, 9,55));
                }
                if (playerLevel <= 20)
                {
                    possibleMonsters.Add(new Orc("Orc Warlord", 15, 60, 150));
                }
                if (possibleMonsters.Count > 0)
                {
                    return (Orc)possibleMonsters[rand.Next(possibleMonsters.Count)];
                }
                return new Orc("Weak Orc", 1, 2, 1);
            }
            /*public override void DisplayArt()
            {
                // Exempel på att använda namnet för att avgöra vilken ASCII-konst som ska visas
                switch (Name)
                {
                    case "Orc Archer":
                        Console.WriteLine("Här visas ASCII-konsten för en Orc Archer...");
                        break;
                    case "Orc Warlord":
                        Console.WriteLine("Här visas ASCII-konsten för en Orc Warlord...");
                        break;
                    default:
                        Console.WriteLine("Generisk ASCII-konst för en Orc...");
                        break;
                }
            }*/
        }
    }
    public class Skeleton : Monster
    {
        public Skeleton(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) 
        {

        }

        public static Skeleton CreateRandomSkeleton(int playerLevel)
        {
            Random rand = new Random();
            List<Monster> possibleMonsters = new List<Monster>();

            if (playerLevel <= 5)
            {
                possibleMonsters.Add(new Skeleton("Skeleton", 2, 3, 10));

            }
            if (playerLevel <= 10)
            {
                possibleMonsters.Add(new Skeleton("Skeleton Warrior", 5, 6,50));
                possibleMonsters.Add(new Skeleton("Skeleton Archer", 5, 9,55));
            }
            if (playerLevel <= 20)
            {
                possibleMonsters.Add(new Orc("Deamon Skeleton", 15, 60, 150));
            }
            if (possibleMonsters.Count > 0)
            {
                return (Skeleton)possibleMonsters[rand.Next(possibleMonsters.Count)];
            }
            return new Skeleton("Benrangel", 1, 2, 1);
        }
    }
}

    public class Undead : Monster
    {
        public Undead(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) 
        {

        }

        public static Undead CreateRandomUndead(int playerLevel)
        {
            Random rand = new Random();
            List<Monster> possibleMonsters = new List<Monster>();

            if (playerLevel <= 5)
            {
                possibleMonsters.Add(new Undead("Zombie", 2, 4, 10));

            }       
            if (playerLevel <= 10)
            {
             possibleMonsters.Add(new Undead("Gohul", 6, 15, 50));
            }   
            if (playerLevel <= 20)
            {

            }
            if (possibleMonsters.Count > 0)
            {
            return (Undead)possibleMonsters[rand.Next(possibleMonsters.Count)];
            }
            return new Undead("Levande Död", 1, 1, 1);
        }
    }

    public class Troll : Monster
    {
        public Troll(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) 
        { 
    
        }

        public static Troll CreateRandomTroll(int playerLevel)
        {
            Random rand = new Random();
            List<Monster> possibleMonsters = new List<Monster>();

            if (playerLevel <= 5)
            {


            }
            if (playerLevel <= 10)
            {

            }
            if (playerLevel <= 20)
            {

            }
            if (possibleMonsters.Count > 0)
            {   
            return (Troll)possibleMonsters[rand.Next(possibleMonsters.Count)];
            }
            return new Troll("Flashback Grabb", 1, 2,1);
        }
    }


    public class Goblin : Monster
    {
        public Goblin(string name, int power, int health, int xpValue) : base(name, power, health, xpValue)
        {

        }

        public static Goblin CreateRandomGoblin(int playerLevel)
        {
            Random rand = new Random();
            List<Monster> possibleMonsters = new List<Monster>();

            if (playerLevel <= 5)
            {


            }
            if (playerLevel <= 10)
            {

            }
            if (playerLevel <= 20)
            {

            }
            if (possibleMonsters.Count > 0)
            {
            return (Goblin)possibleMonsters[rand.Next(possibleMonsters.Count)];
            }
            return new Goblin("Little Green Man", 1, 2,1);
        }
    }


    public class Vampire : Monster
    {
        public Vampire(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) 
        {

        }

        public static Vampire CreateRandomVampire(int playerLevel)
        {
            Random rand = new Random();
            List<Monster> possibleMonsters = new List<Monster>();


            if (playerLevel <= 5)
            {
                possibleMonsters.Add(new Vampire("Vampire Thane", 5, 5, 25));

        }
            if (playerLevel <= 10)
            {
                possibleMonsters.Add(new Vampire("Lower Vampire", 6, 7, 50));
                possibleMonsters.Add(new Vampire("Vampire", 11, 13, 75));
            }
            if (playerLevel <= 20)
            {
                possibleMonsters.Add(new Vampire("Vampire Lord", 14, 16, 100));
            }
            if (possibleMonsters.Count > 0)
            {
            return (Vampire)possibleMonsters[rand.Next(possibleMonsters.Count)];
            }
            return new Vampire("bloodsugare", 1, 2,1);
        }
    }
public class Rat : Monster
{
    public Rat(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) 
    {

    }

    public static Rat CreateRandomRat(int playerLevel)
    {
        Random rand = new Random();
        List<Monster> possibleMonsters = new List<Monster>();

        if (playerLevel <= 5)
        {
            possibleMonsters.Add(new Rat("Small Ratt", 1, 5, 10));
            possibleMonsters.Add(new Rat("Cave Rat", 1, 2, 10));
            possibleMonsters.Add(new Rat("Large Rat", 2, 15, 25));

        }
        if (playerLevel <= 10)
        {

        }
        if (playerLevel <= 20)
        {

        }
        if (possibleMonsters.Count > 0)
        {
            return (Rat)possibleMonsters[rand.Next(possibleMonsters.Count)];
        }
        return new Rat("Råtta", 1, 2,3);
    }
}







