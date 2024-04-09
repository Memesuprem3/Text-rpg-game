using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    public class Monster
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }

        public Monster(string name, int power, int health)
        {
            Name = name;
            Power = power;
            Health = health;
        }
        public List<Equipment> LootTable { get; set; } = new List<Equipment>();


        public void AddLoot(Equipment equipment)
        {
            LootTable.Add(equipment);
        }

        // Metod för att lägga till loot till monstret
        public List<Equipment> Defeat()
        {
            Console.WriteLine($"{Name} besegrad!");
            return LootTable;
        }

        // Statisk metod för att generera slumpmässiga monster
        public static Monster GenerateRandomMonster()
        {
            Random rand = new Random();
            int choice = rand.Next(0, 5); 

            switch (choice)
            {
                case 0:
                    return Orc.CreateRandomOrc();
                case 1:
                    return Skeleton.CreateRandomSkeleton();
                case 2:
                    return Zombie.CreateRandomZombie();
                case 3:
                    return Troll.CreateRandomTroll();
                case 4:
                    return Vampire.CreateRandomVampire();
                case 5:
                    return Goblin.CreateRandomGoblin();
                default:
                    return Rat.CreateRandomRat();
            }
        }


        public class Orc : Monster
        {
            public Orc(string name, int power, int health) : base(name, power, health) { }

            public static Orc CreateRandomOrc()
            {
                Random rand = new Random();
                
                int choice = rand.Next(0, 2); 

                switch (choice)
                {
                    case 0:
                        return CreateOrcArcher();
                    case 1:
                        return CreateOrcWarlord();
                    case 2:
                        return CreateOrcWarlord();
                    default:
                        return new Orc("Generic Orc", 4, 7); 
                }
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
            public static Orc CreateOrcArcher()
            {
                return new Orc("Orc Archer", 5, 6);
            }
            public static Orc CreateOrcWarlord()
            {
                return new Orc("Orc Warlord", 7, 9);
            }
        }
    }


    public class Skeleton : Monster
    {
        public Skeleton(string name, int power, int health) : base(name, power, health) { }

        public static Skeleton CreateRandomSkeleton()
        {
            Random rand = new Random();
            // Du kan anpassa vikter eller lägga till fler typer här.
            int choice = rand.Next(0, 2); 

            switch (choice)
            {
                case 0:
                    return CreateSkeletonWarr();
                case 1:
                    return CreateDemonSkeleton();
                case 2:
                    return CreateSkeletonArcher();
                default:
                    return new Skeleton("Generic Orc", 2, 4); 
            }
        }

        static Skeleton CreateSkeletonWarr()
        {
            return new Skeleton("Skeleton Warrior", 4, 8);
        }
        static Skeleton CreateDemonSkeleton()
        {
            return new Skeleton("Skeleton Warrior", 4, 8);
        }
        static Skeleton CreateSkeletonArcher()
        {
            return new Skeleton("Skeleton Archer", 4, 5);
        }


    }

    public class Zombie : Monster
    {
        public Zombie(string name, int power, int health) : base(name, power, health) { }

        public static Zombie CreateRandomZombie()
        {
            Random rand = new Random();
            
            int choice = rand.Next(0, 2); 

            switch (choice)
            {
                case 0:
                    return CreateZombieRotten();
                case 1:
                    return CreateZombieRotten();
                case 2:
                    return CreateZombieRotten();
                default:
                    return new Zombie("Generic Orc", 4, 7); 
            }
        }
        static Zombie CreateZombieRotten()
        {
            return new Zombie("Rotten Zombie", 4, 8);
        }

    }


    public class Troll : Monster
    {
        public Troll(string name, int power, int health) : base(name, power, health) { }

        public static Troll CreateRandomTroll()
        {
            Random rand = new Random();

            int choice = rand.Next(0, 2);

            switch (choice)
            {
                case 0:
                    return CreateTroll();
                case 1:
                    return CreateSwampTroll();
                case 2:
                    return CreateForestTroll();
                default:
                    return new Troll("Troll", 1, 4);
            }
            static Troll CreateTroll()
            {
                return new Troll("Troll", 3, 4);
            }
            static Troll CreateSwampTroll()
            {
                return new Troll("Swamp Troll", 4, 8);
            }
            static Troll CreateForestTroll()
            {
                return new Troll("Forrest Troll", 4, 8);
            }
        }

    }


    public class Goblin : Monster
    {
        public Goblin(string name, int power, int health) : base(name, power, health) { }

        public static Goblin CreateRandomGoblin()
        {
            Random rand = new Random();
           
            int choice = rand.Next(0, 2); 

            switch (choice)
            {
                case 0:
                    return CreateGoblin();
                case 1:
                    return CreateGoblinGaurd();
                case 2:
                    return CreateGoblinRouge();
                default:
                    return new Goblin("Goblin", 3, 3); 
            }
            static Goblin CreateGoblin()
            {
                return new Goblin("Goblin", 2, 4);
            }
            static Goblin CreateGoblinGaurd()
            {
                return new Goblin("Goblin Gaurd", 2, 4);
            }
            static Goblin CreateGoblinRouge()
            {
                return new Goblin("Goblin Rouge", 2, 4);
            }
        }

    }


    public class Vampire : Monster
    {
        public Vampire(string name, int power, int health) : base(name, power, health) { }

       public static Vampire CreateRandomVampire()
       {
            Random rand = new Random();
            
            int choice = rand.Next(0, 2); 

            switch (choice)
            {
                case 0:
                    return CreateVampire();
                case 1:
                    return CreateVampireThane();
                case 2:
                    return CreateLowerVampire();
                default:
                    return new Vampire("Generic Orc", 4, 7); 
            }
            static Vampire CreateVampire()
            {
                return new Vampire("Vampire", 11, 13);
            }
            static Vampire CreateVampireThane()
            {
                return new Vampire("Vampire Thane", 15, 17);
            }
            static Vampire CreateLowerVampire()
            {
                return new Vampire("Lower Vampire", 8, 8);
            }
       }

    }
    public class Rat : Monster
    {
        public Rat(string name, int power, int health) : base(name, power, health) { }

        public static Rat CreateRandomRat()
        {
            Random rand = new Random();
           
            int choice = rand.Next(0, 2); 

            switch (choice)
            {
                case 0:
                    return CreateSmallRat();
                case 1:
                    return CreateCaveRat();
                case 2:
                    return CreateLargeRat();
                default:
                    return new Rat("Rat", 1, 2); 
            }

            static Rat CreateSmallRat()
            {
                return new Rat("Small Ratt", 1, 1);
            }
            static Rat CreateCaveRat()
            {
                return new Rat("Cave Rat", 1, 2);
            }
            static Rat CreateLargeRat()
            {
                return new Rat("Large Rat", 2, 3);
            }
            
        }

    }
}






