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
        public string Description { get; set; }
        public int Level { get; set; }

        public Skill(string name, string description)
        {
            Name = name;
            Description = description;
            Level = 1; // Alla färdigheter börjar på nivå 1
        }

        public void IncreaseLevel()
        {
            Level++;
            Console.WriteLine($"{Name} har ökat till nivå {Level}.");
        }
    }
}