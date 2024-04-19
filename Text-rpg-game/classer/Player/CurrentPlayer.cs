﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Text_rpg_game.classer.Player.Player
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
    public class CurrentPlayer
    {
        public static CurrentPlayer currentPlayer = new CurrentPlayer();
        private Random rand = new Random();

        public int playerID;
        public string Name;
        public string CharacterClass;
        public int coins = 300;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 2;
        public int weaponValue = 1;
        public int Level = 1; 
        public int XP = 0;
        public int XPToNextLevel = 100;

        // Primary stats
        public int strength = 1; // påverka skada med vapen
        public int agility = 1; // - || -
        public int stamina = 1; // påverkar hälsa
        public int spirit = 1; // inplementara hp reg?
        public int intelligence = 1;
        public int charisma = 1; // påverka dialoger/handel
        public int speed = 1; // ska påverka RUN i combat - skapa funk
        public int perception = 1; // påverka klasser/dialoger
        public int luck = 1;

        //Mele/Ranged stats 

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
                    stamina += 1;
                    coins += 25;
                    break;
                case Race.Elf:
                    agility += 2;
                    break;
                case Race.Gnome:
                    intelligence += 2;
                    break;
                case Race.Undead:
                    intelligence += 2;
                    break;
                case Race.Orc:
                    health += 10;
                    strength += 2;
                    break;

            }
        }
        // inventory list
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public static void lookInventory(CurrentPlayer p)
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
        public void LevelUp()
        {
            Level++;
            XP -= XPToNextLevel;
            XPToNextLevel = (int)(XPToNextLevel * 1.25);

            // Öka stats baserat på klass
            switch (CharacterClass)
            {
                case "Warrior":
                    strength += 2;
                    stamina += 2;
                    health += 10;
                    break;
                case "Rogue":
                    agility += 2;
                    speed += 2;
                    health += 5;
                    break;
                case "Wizard":
                    intelligence += 3;
                    spirit += 1;
                    health += 3;
                    break;
                case "Ranger":
                    agility += 2;
                    perception += 1;
                    health += 5;
                    break;
                case "Paladin":
                    strength += 1;
                    spirit += 2;
                    health += 8;
                    break;
                case "Priest":
                    spirit += 3;
                    intelligence += 1;
                    health += 5;
                    break;
                case "Warlock":
                    intelligence += 2;
                    spirit += 1;
                    health += 4;
                    break;
                case "Shaman":
                    spirit += 2;
                    strength += 1;
                    health += 6;
                    break;
                case "Druid":
                    intelligence += 2;
                    agility += 1;
                    health += 5;
                    break;
            }
            Console.WriteLine($"Grattis! Du är nu nivå {Level} och din hälsa har ökats till {health}.");
        }

        public void AddXP(int amount)
        {
            XP += amount;
            Console.WriteLine($"Du fick {amount} XP, totalt {XP} XP.");

            // Kontrollera om spelaren har nått XP-gränsen för nästa nivå
            while (XP >= XPToNextLevel)
            {
                LevelUp();  // Uppdatera spelarens stats och nivå
            }
        }
    }
}

