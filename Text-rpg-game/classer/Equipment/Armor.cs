using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Equipment
{
    public class Armor : Gear
    {
        public int ArmorValue { get; set; }
        public int AgilityBonus { get; set; }

        public Armor(string name, int armorValue, int agilityBonus = 0, int value = 0)
            : base(name, value)
        {
            ArmorValue = armorValue;
            AgilityBonus = agilityBonus;
        }
    }
}
