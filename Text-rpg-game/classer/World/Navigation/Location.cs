using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.World.Dungeons;

namespace Text_rpg_game.classer.World.Navigation
{
    internal class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Location> Exits { get; private set; }
        public List<Dungeon> NearbyDungeons { get; private set; } // Dungeons i närheten

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Location>();
            NearbyDungeons = new List<Dungeon>();
        }

        public void DefineExit(string direction, Location destination)
        {
            Exits[direction] = destination;
        }

        public void AddDungeon(Dungeon dungeon)
        {
            NearbyDungeons.Add(dungeon);
        }
    }
}