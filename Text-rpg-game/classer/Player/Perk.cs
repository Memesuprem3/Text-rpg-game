using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Player
{
    internal class Perk
    {
        public string Name;
        public string Description;
        public Func<CurrentPlayer, bool> UnlockCondition;
        public Action<CurrentPlayer> ApplyEffect;
    };
}
