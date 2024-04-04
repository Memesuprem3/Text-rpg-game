using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    internal class Save
    {
        public static Player currentPlayer = new Player();
        public static void GSave()
        {
            string path = Path.Combine("Saves", $"{currentPlayer.playerID}.json");
            string jsonString = JsonSerializer.Serialize(currentPlayer, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(path, jsonString);
        }
    }
}
