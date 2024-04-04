using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_rpg_game.classer
{
    internal class GameStart
    {
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
        }
    }
    
}
