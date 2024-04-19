using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.World
{
    internal class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Location> Exits { get; set; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Location>();
        }

        public void DefineExit(string direction, Location destination)
        {
            Exits[direction] = destination;
        }
    
        public void City_valorwind()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }

        public void City_Stonedeep()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location  ("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }
        public void City_Silverleaf()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }
        public void City_Tinkertown()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }
        public void City_Necropilis()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }

        public void City_IronFist()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }

        public void City_Mudgulch()
        {
            Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
            Location Keep = new Location("Keep", "You stand before the keep");
            Location Shop = new Location("Shop", "you are outside of the shop");
            Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
        }
    }
}
