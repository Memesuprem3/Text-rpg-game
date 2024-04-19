using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Text_rpg_game.classer.Player.Player;

namespace Text_rpg_game.classer.Utilitys
{
    internal class Save
    {
        public static CurrentPlayer currentPlayer = new CurrentPlayer();
        public static void GSave()
        {
            string path = Path.Combine("Saves", $"{currentPlayer.playerID}.json");
            string jsonString = JsonSerializer.Serialize(currentPlayer, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }
    }
}
