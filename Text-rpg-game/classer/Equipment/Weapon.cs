using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Equipment
{
    public class Weapon : Gear
    {
        public int BaseDamage { get; set; }
        public int ElementalDamage { get; set; }
        public WeaponType WeaponType { get; set; }
        public DamageType DamageType { get; set; }
        public bool IsMagic => WeaponType == WeaponType.Wand || WeaponType == WeaponType.Staff;

        public Weapon(string name, int baseDamage, int elementalDamage, WeaponType weaponType, DamageType damageType, int value = 0)
            : base(name, value)
        {
            BaseDamage = baseDamage;
            ElementalDamage = elementalDamage;
            WeaponType = weaponType;
            DamageType = damageType;
        }
    }
}
