using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Text_rpg_game.classer
{
    internal class Load
    {
        public static Player GLoad()
        {
            Console.Clear();
            Console.WriteLine("Choose your save file:");

            string[] paths = Directory.GetFiles("Saves", "*.json");
            if (paths.Length == 0)
            {
                Console.WriteLine("No save files found.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
                Main_menu.ShowMainMenu();
            }

            List<Player> players = new List<Player>();
            List<string> displayList = new List<string>();

            foreach (string path in paths)
            {
                string jsonString = File.ReadAllText(path);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                if (player != null)
                {
                    players.Add(player);
                    FileInfo fileInfo = new FileInfo(path);
                    string formattedDate = fileInfo.LastWriteTime.ToString("d/M yyyy HH:mm");
                    displayList.Add($"{player.Name} - {formattedDate}");
                }
            }

            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < displayList.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {displayList[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"  {displayList[i]}");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : displayList.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % displayList.Count;
                        break;
                    case ConsoleKey.Enter:
                        return players[selectedIndex];
                    case ConsoleKey.Escape:
                        return null; // Lägg till detta om du vill tillåta användaren att avbryta med Escape-tangenten
                }
            }
        }
        public static Player LoadLatestSave()
        {
            var saveDirectory = new DirectoryInfo(Path.Combine("Saves"));
            if (!saveDirectory.Exists || saveDirectory.GetFiles("*.json").Length == 0)
            {
                Console.WriteLine("No save files found.");
                return null; // Ingen sparfil finns, så ett nytt spel bör startas.
            }

            var latestSaveFile = saveDirectory.GetFiles("*.json").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            if (latestSaveFile != null)
            {
                string jsonString = File.ReadAllText(latestSaveFile.FullName);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                if (player != null)
                {
                    return player; // Returnera den senast sparade spelaren.
                }
            }

            Console.WriteLine("Failed to load the latest save.");
            return null; // Något gick fel under laddningen, så ett nytt spel bör startas.
        }
    }
}

    

