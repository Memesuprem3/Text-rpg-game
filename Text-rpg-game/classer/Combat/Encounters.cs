using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Player.Player;
using static Text_rpg_game.classer.Monsters.Monster;

namespace Text_rpg_game.classer.Combat
{
    public class Encounters
    {


        public static void FirstEncounter(CurrentPlayer player)
        {
            Monster humanRogue = new Monster("Human Rogue", 1, 4,0);
            CreCharacter.WriteCenteredPrompt("You throw open the door and grab a rusty metal sword, charging towards your captor.");
            CreCharacter.WriteCenteredPrompt("He turns...");
            Console.ReadKey();
            Combat.StartFight(player, humanRogue);
        }


        public static void BasicFightEncounter(CurrentPlayer player)
        {
            Console.Clear();
            CreCharacter.WriteCenteredPrompt("You turn the corner and see an Enemy.");
            Console.ReadKey();
            Monster randomMonster = GenerateRandomMonster(player.Level);
            Combat.StartFight(player, randomMonster);
        }


        public static void WizardEncounter(CurrentPlayer player)
        {
            Monster darkWizard = new Monster("Dark Wizard", 4, 2,0);
            Console.Clear();
            Console.WriteLine("The door slowly opens as you peer into the dark room. You see a man with a wide and pointy hat...");
            Console.ReadKey();
            Combat.StartFight(player, darkWizard);
        }

    }
}