using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Monsters
{
    public class MonsterAbility
    {
        public string Name { get; private set; }
        public Action<Monster, CurrentPlayer> Execute { get; private set; }

        public MonsterAbility(string name, Action<Monster, CurrentPlayer> execute)
        {
            Name = name;
            Execute = execute;
        }
    }
}
