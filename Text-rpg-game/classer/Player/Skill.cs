using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Player
{
    public class Skill
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int XPToNextLevel { get; set; }

        public Skill(string name, int level = 1)
        {
            Name = name;
            Level = level;
            XP = 0;
            XPToNextLevel = 10 + (level * 5);
        }

        public void AddXP(int amount)
        {
            XP += amount;
            if (XP >= XPToNextLevel)
            {
                XP -= XPToNextLevel;
                Level++;
                XPToNextLevel = 10 + (Level * 5);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"🎉 Your {Name} skill increased to level {Level}!");
                Console.ResetColor();
            }
        }
    }
}