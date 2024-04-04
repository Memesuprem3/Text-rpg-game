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
        static void StartOrContinueGame()
        {
            if (CheckForSaves()) // En metod som kollar om sparade spel finns
            {
                Load.LoadLatestSave();
            }
            else
            {
                
            }
        }

        public static bool CheckForSaves()
        {
            string saveDirectory = Path.Combine("Saves");
            if (!Directory.Exists(saveDirectory))
            {
                return false;
            }

            string[] saveFiles = Directory.GetFiles(saveDirectory, "*.json");
            return saveFiles.Length > 0;
        }
    }
    
}
