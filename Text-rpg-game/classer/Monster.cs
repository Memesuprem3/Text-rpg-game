using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    public class Monster
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public List<Equipment> LootTable { get; set; } = new List<Equipment>();

        public Monster(string name, int power, int health)
        {
            Name = name;
            Power = power;
            Health = health;
        }

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
            switch (rand.Next(0, 5)) // Generera ett tal mellan 0 och 4
            {
                case 0:
                    return new Monster("Skeleton", 2, 5);
                case 1:
                    return new Monster("Zombie", 3, 6);
                case 2:
                    return new Monster("Orc", 4, 7);
                case 3:
                    return new Monster("Troll", 5, 8);
                case 4:
                    return new Monster("Vampire", 6, 9);
                default:
                    return new Monster("Goblin", 1, 4); // Säkerhetsfall, bör ej inträffa
            }
        }
    }
}