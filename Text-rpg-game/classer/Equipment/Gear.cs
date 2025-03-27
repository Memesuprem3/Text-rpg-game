using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Equipment
{
    public enum WeaponType { Sword, Axe, Club, Bow, Crossbow, Wand, Staff }
    public enum DamageType { Physical, Fire, Ice, Poison, Shadow, Holy, Arcane }

    public abstract class Gear
    {
        public string Name { get; set; }
        public int Value { get; set; } // Pris i butik
        public string RequiredClass { get; set; } 
        public Dictionary<string, int> StatRequirements { get; set; } = new(); // t.ex. "strength": 4

        public Gear(string name, int value = 0)
        {
            Name = name;
            Value = value;
        }

        public virtual bool CanEquip(CurrentPlayer player)
        {
            if (!string.IsNullOrEmpty(RequiredClass) && RequiredClass != player.CharacterClass)
                return false;

            foreach (var req in StatRequirements)
            {
                var playerStat = player.GetType().GetField(req.Key)?.GetValue(player);
                if (playerStat is int value && value < req.Value)
                    return false;
            }

            return true;
        }
    }
}
