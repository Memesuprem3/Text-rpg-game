using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Player
{
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action<CurrentPlayer, Monster> Execute;  // Delegation för utförandet av förmågan

        public Ability(string name, string description, Action<CurrentPlayer, Monster> execute)
        {
            Name = name;
            Description = description;
            Execute = execute;
        }

        public void Perform(CurrentPlayer player, Monster target)
        {
            Console.WriteLine($"{player.Name} använder {Name}!");
            Execute(player, target);
        }

        public void IncreaseLevel()
        {
            // Om nödvändigt kan vi även hantera nivåökningar för förmågor
        }
    }
}

