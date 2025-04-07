using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Text_rpg_game.classer.Utilitys.Menus;
using Text_rpg_game.classer.Player.Core;

namespace Text_rpg_game.classer.Utilitys
{
    internal class Load
    {
        public static CurrentPlayer GLoad()
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

            List<CurrentPlayer> players = new List<CurrentPlayer>();
            List<string> displayList = new List<string>();

            foreach (string path in paths)
            {
                string jsonString = File.ReadAllText(path);
                CurrentPlayer player = JsonSerializer.Deserialize<CurrentPlayer>(jsonString);
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
                        selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : displayList.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % displayList.Count;
                        break;
                    case ConsoleKey.Enter:
                        return players[selectedIndex];
                    case ConsoleKey.Delete:
                        string selectedFilePath = paths[selectedIndex];
                        if (ConfirmDelete(selectedFilePath))
                        {
                            File.Delete(selectedFilePath);
                            Console.WriteLine($"Save file '{selectedFilePath}' deleted successfully.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return GLoad(); // Reload the save file selection after deletion
                        }
                        break;
                    case ConsoleKey.Escape:
                        return null;
                }
            }
        }
        public static CurrentPlayer LoadLatestSave()
        {
            var saveDirectory = new DirectoryInfo(Path.Combine("Saves"));
            if (!saveDirectory.Exists || saveDirectory.GetFiles("*.json").Length == 0)
            {
                Console.WriteLine("No save files found.");
                return null;
            }

            var latestSaveFile = saveDirectory.GetFiles("*.json").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            if (latestSaveFile != null)
            {
                string jsonString = File.ReadAllText(latestSaveFile.FullName);
                CurrentPlayer player = JsonSerializer.Deserialize<CurrentPlayer>(jsonString);
                if (player != null)
                {
                    return player;
                }
            }

            Console.WriteLine("Failed to load the latest save.");
            return null;
        }
        private static bool ConfirmDelete(string filePath)
        {
            Console.WriteLine($"Are you sure you want to delete {Path.GetFileName(filePath)}? (Y/N)");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    return false;
                }
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



