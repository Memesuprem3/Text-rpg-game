using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters
{
    public class MonsterLore
    {
        public string Description { get; set; }
        public string Habitat { get; set; }
        public string Origin { get; set; }
        public string Weakness { get; set; }
        public string Resistance { get; set; }
        public bool IsBoss { get; set; } = false;
    }
}
