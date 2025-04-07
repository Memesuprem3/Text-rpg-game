using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.World.Dungeons
{
    internal class DungeonRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DungeonRoom(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}