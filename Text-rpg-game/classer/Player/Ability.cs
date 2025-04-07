using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Player.Core;

namespace Text_rpg_game.classer.Player
{
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinLevel { get; set; }
        public string RequiredClass { get; set; }
        public Action<CurrentPlayer, Monster> Execute;  // Delegation för utförandet av förmågan

        public Ability(string name, string description,int minLevel,string requiredClass, Action<CurrentPlayer, Monster> execute)
        {
            Name = name;
            Description = description;
            MinLevel = minLevel;
            RequiredClass = requiredClass;
            Execute = execute;
        }

        public void Perform(CurrentPlayer player, Monster target)
        {
            if (player.Level >= MinLevel && player.CharacterClass == RequiredClass)
            {
                Console.WriteLine($"{player.Name} uses {Name}!");
                Execute(player, target);
            }
            else
            {
                if (player.CharacterClass != RequiredClass)
                    Console.WriteLine($"{Name} is not available for your class.");
                else
                    Console.WriteLine($"{player.Name} is not high enough level to use {Name}. Needs level {MinLevel}.");
            }
        }

        public void IncreaseLevel()
        {
            
        }
    }
}

