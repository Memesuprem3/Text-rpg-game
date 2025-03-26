using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Text_rpg_game.classer.Combat;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Utilitys
{
    internal class GameStart
    {
        public static CurrentPlayer currentPlayer = new CurrentPlayer();
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
            Encounters.FirstEncounter(currentPlayer);
            Encounters.RandomFightEncounter(currentPlayer);

            //skapa olika start beroende på ras
        }
    }

}
