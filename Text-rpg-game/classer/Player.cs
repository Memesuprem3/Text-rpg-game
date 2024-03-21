using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    public class Player
    {
        private Random rand = new Random();

        public int playerID { get; set; }
        public string Name;
        public int coins = 30000;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int weaponValue = 1;
        public int mods = 0;

        // inventory list
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        
        // inventroy

        public static void lookInventory(Player p)
        {
            int index = 1;
            Dictionary<int, string> itemMapping = new Dictionary<int, string>();
            foreach (var item in p.inventory)
            {
                Console.WriteLine($"{index}: {item.Key} x{item.Value}"); // Visa föremål och antal
                itemMapping[index] = item.Key; // Mappa index till föremålets namn
                index++;
            }
        }
        public Player()
        {
            
            inventory.Add("Minor Healing Potion",5); 
                                                      
        }

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

     
    }

}

