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
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potionsS = 5; 
        public int potionsM = 0; 
        public int potionsL = 0; 
        public int weaponValue = 1;
        public int mods = 0;

        // inventory list
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        
        // inventroy
        public Player()
        {
            
            inventory.Add("Healing Potion", potionsS); 
                                                      
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

