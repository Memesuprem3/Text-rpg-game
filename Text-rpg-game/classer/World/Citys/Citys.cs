using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.World.Navigation;

namespace Text_rpg_game.classer.World.Citys
{
    internal class Citys : Location
    {
        public Citys(string name, string description) : base(name, description)
        {

            InitializeCity();

            void InitializeCity()
            {
                // Exempel på att definiera platser och kopplingar inom en stad
                Location townSquare = new Location("Trade District", "Your in the Trade District");
                Location keep = new Location("Keep", "you stand infron of the keep");
                Location shop = new Location("Shop", "You stand infron of the shop");
                Location tavern = new Location("Tavern", "You hear songs and laugther from the tavern");
                Location baracks = new Location("baracks", "The baracks looks worn down and grey");

                // Definiera vägar mellan platser
                townSquare.DefineExit("north", baracks);
                townSquare.DefineExit("east", keep);
                townSquare.DefineExit("south", shop);
                townSquare.DefineExit("west", tavern);

                DefineExit("townSquare", townSquare); // Lägg till huvudingången till stadens torg
            }

            void City_valorwind()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }

            void City_Stonedeep()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }
            void City_Silverleaf()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }
            void City_Tinkertown()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }
            void City_Necropilis()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }

            void City_IronFist()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }

            void City_Mudgulch()
            {
                Location townSquare = new Location("Trade District", "You are in the Trade Disctrict");
                Location Keep = new Location("Keep", "You stand before the keep");
                Location Shop = new Location("Shop", "you are outside of the shop");
                Location Tavern = new Location("Tarvern", "You hear songs and laufther comming from the tavern");
            }
        }s
    }
}
