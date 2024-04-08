using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Text_rpg_game.classer.Monster;

namespace Text_rpg_game.classer
{
    public class Encounters
    {


        public static void FirstEncounter(Player player)
        {
            Monster humanRogue = new Monster("Human Rogue", 1, 4);
            Console.WriteLine("You throw open the door and grab a rusty metal sword, charging towards your captor.");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat.StartFight(player, humanRogue);
        }


        public static void BasicFightEncounter(Player player)
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and see an Enemy.");
            Console.ReadKey();
            Monster randomMonster = Monster.GenerateRandomMonster();
            Combat.StartFight(player, randomMonster);
        }


        public static void WizardEncounter(Player player)
        {
            Monster darkWizard = new Monster("Dark Wizard", 4, 2);
            Console.Clear();
            Console.WriteLine("The door slowly opens as you peer into the dark room. You see a man with a wide and pointy hat...");
            Console.ReadKey();
            Combat.StartFight(player, darkWizard);
        }
        
    }
}