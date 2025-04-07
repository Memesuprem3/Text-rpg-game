using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.World.Dungeons;

namespace Text_rpg_game.classer.World.Navigation
{
    internal class GameWorld
    {
        public Location CurrentLocation { get; set; }
        public List<Location> Locations { get; set; }
        public List<Dungeon> Dungeons { get; set; }

        public GameWorld()
        {
            Locations = new List<Location>();
            Dungeons = new List<Dungeon>();
        }

        public void DisplayNavigationMenu()
        {
            Console.WriteLine($"You are now at {CurrentLocation.Name}. Where would you like to go next?");
            int index = 1;
            foreach (var exit in CurrentLocation.Exits)
            {
                Console.WriteLine($"{index++}: Go to {exit.Value.Name}");
            }
            foreach (var dungeon in CurrentLocation.NearbyDungeons)
            {
                Console.WriteLine($"{index++}: Explore {dungeon.Name}");
            }

            // Hantera användarens val här
            //implementera inputhantering som tillåter användaren att välja ett index och sedan navigera därefter
        }
    }
}