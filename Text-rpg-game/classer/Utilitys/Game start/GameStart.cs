using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Text_rpg_game.classer.Player.Player;
using Text_rpg_game.classer.Player.Core;
using Text_rpg_game.classer.Encounters;

namespace Text_rpg_game.classer.Utilitys
{
    internal class GameStart
    {
        public static CurrentPlayer currentPlayer = new();
        public static void StartOrContinueGame()
        {
            if (Load.CheckForSaves()) // En metod som kollar om sparade spel finns
            {
                Load.LoadLatestSave();
            }
            else
            {
                StartNewGame();
            }
        }

        public static void StartNewGame()
        {
            
            CreCharacter.CharMenu();
            Encounters.Encounters.FirstEncounter();
            Encounters.Encounters.RandomFightEncounter();

            //skapa olika start beroende på ras och klass?
        }
    }

}
