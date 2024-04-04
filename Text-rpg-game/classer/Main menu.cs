using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Text_rpg_game.classer
{
    internal static class Main_menu
    {
       
        public static Player currentPlayer = new Player(); // Se till att denna instansiering är meningsfull i ditt sammanhang.
        private static readonly string[] logoLines = { "CRYPTS OF ETERNITY" };
        private static readonly int spaceBetweenLogoAndMenu = 2;
        private static int currentLine = 0;

        public static void ShowMainMenu()
        {
            Console.CursorVisible = false;

            DrawLogo();

            bool hasSaves = GameStart.CheckForSaves();

            // Justera menyval baserat på om sparade spel finns
            string[] menuItems = hasSaves ? new string[] { "Continue", "Load Game", "Settings", "Exit" }
                                          : new string[] { "Start New Game", "Load Game", "Settings", "Exit" };

            int selectedIndex = 0;

            while (true)
            {
                DrawMenu(menuItems, selectedIndex);
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Length - 1;
                        ClearMenuArea(menuItems.Length);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % menuItems.Length;
                        ClearMenuArea(menuItems.Length);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        HandleMenuSelection(selectedIndex, hasSaves, menuItems);
                        break;
                }
            }
        }

        private static void DrawLogo()
        {
            currentLine = 0; // Återställer currentLine vid varje anrop till ShowMainMenu
            foreach (var line in logoLines)
            {
                int leftPosition = Math.Max((Console.WindowWidth - line.Length) / 2, 0);
                Console.SetCursorPosition(leftPosition, currentLine++);
                Console.WriteLine(line);
            }
            currentLine += spaceBetweenLogoAndMenu; // Lägg till utrymmet efter loggan
        }

        private static void DrawMenu(string[] menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                int leftPosition = Math.Max((Console.WindowWidth - menuItems[i].Length) / 2, 0);
                Console.SetCursorPosition(leftPosition, currentLine + i);
                if (i == selectedIndex)
                {
                    Console.WriteLine($"> {menuItems[i]}");
                }
                else
                {
                    Console.WriteLine($"  {menuItems[i]}");
                }
            }
        }

        private static void HandleMenuSelection(int selectedIndex, bool hasSaves, string[] menuItems)
        {
            if (hasSaves)
            {
                switch (selectedIndex)
                {
                    case 0: // "Continue" valt
                        Player player = Load.LoadLatestSave();
                        if (player != null)
                        {
                            // Fortsätt spelet med den laddade spelarprofilen
                            currentPlayer = player;
                            // Anta att det finns en metod för att fortsätta spelet, t.ex.:
                            // ContinueGame(currentPlayer);
                        }
                        else
                        {
                            Console.WriteLine("Failed to load the game.");
                            // Logik för att hantera misslyckad laddning, kanske återgå till huvudmenyn
                        }
                        break;
                    case 1: // "Load Game" valt
                        Load.GLoad();
                        break;
                    case 2: // "Settings" valt
                        //ShowSettingsMenu();
                        break;
                    case 3: // "Exit" valt
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                // När det inte finns sparade spel, har vi "Start New Game" som första val
                switch (selectedIndex)
                {
                    case 0: // "Start New Game" valt
                            // Logik för att initiera ett nytt spel här
                            // Exempel: InitNewGame();
                        break;
                    case 1: // "Load Game" valt
                        Load.GLoad();
                        break;
                    case 2: // "Settings" valt
                        //ShowSettingsMenu();
                        break;
                    case 3: // "Exit" valt
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void ClearMenuArea(int lineCount)
        {
                for (int i = 0; i < lineCount; i++)
                {
                    Console.SetCursorPosition(0, currentLine + i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                // Återställer skärmen efter rensning
                Console.SetCursorPosition(0, currentLine);
        }
    }
}
