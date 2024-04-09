using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Text_rpg_game.classer
{
    [Serializable]
public enum Race
    {
        Human,
        Dwarf,
        Elf,
        Gnome,
        Undead,
        Orc,
        Troll

    }
    public class Player
    {
        public static Player currentPlayer = new Player();
        private Random rand = new Random();

        public int playerID;
        public string Name;
        public string CharacterClass;
        public int coins = 300;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 2;
        public int weaponValue = 1;
        public int mods = 0; // öka svårighetsgrad 

        // Primary stats
        public int strength = 1; // påverka skada med vapen
        public int agility = 1; // - || -
        public int stammina = 1; // påverkar hälsa
        public int spirit = 1; // inplementara hp reg?
        public int inteligens = 1; 
        public int charisma = 1; // påverka dialoger/handel
        public int speed = 1; // ska påverka RUN i combat - skapa funk
        public int perception = 1; // påverka klasser/dialoger
        public int luck = 1;

        //Mele stats 

        public double armorPen = 0.40;
        public double attackPow = 1;
        public double critChans = 0.50;
        public double hitChans = 1;


        //Caster stats
        public double spellPen = 0.50;
        public double spellPow = 1;
        public double spellCrit = 0.50;
        public double spellhit = 1;
        public Race PlayerRace { get; set; }

        public void SetRaceAttributes()
        {
            switch (PlayerRace)
            {
                case Race.Dwarf:
                    strength += 1;
                    stammina += 1;
                    coins += 25;
                    break;
                case Race.Elf:
                    agility += 2;
                    break;
                case Race.Gnome:
                    inteligens += 2;
                    break;
                case Race.Undead:
                    inteligens += 2;
                    break;
                case Race.Orc:
                    health += 10;
                    strength += 2;
                    break;
                
            }
        }
        // inventory list
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
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
            inventory.Add("Minor Healing Potion", 5);
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
        public int GetCoins()
        {
            int upper = (15 * mods + 2);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }
    }
}

