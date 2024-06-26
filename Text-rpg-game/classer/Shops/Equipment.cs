﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Shops
{
    public class Equipment
    {
        // utöka för passa med shop, inventory och items/loot
        public string Name { get; set; }
        public int Damage { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public int AgilityBonus { get; set; } = 0;

        public Equipment(string name, int damage = 0, int armor = 0, int agilityBonus = 0)
        {
            Name = name;
            Damage = damage;
            Armor = armor;
            AgilityBonus = agilityBonus;
        }
    }

    public class Weapon : Equipment
    {
        public Weapon(string name, int damage) : base(name, damage: damage) { }
    }

    public class Armor : Equipment
    {
        public Armor(string name, int armor, int agilityBonus = 0) : base(name, armor: armor, agilityBonus: agilityBonus) { }
    }
}
