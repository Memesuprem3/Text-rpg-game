using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.AI
{
    public class MonsterAI
    {
        public string BehaviorType { get; set; } = "aggressive";
        public bool CanFlee { get; set; } = false;
        public bool HasTriedToFlee { get; set; } = false;
        public bool CanTalk { get; set; } = false;
        public string DialogueLine { get; set; }
    }
}
