using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Text_rpg_game.classer.Player.Player;
namespace Text_rpg_game.classer.Utilitys
{
    internal static class Main_menu
    {

        public static CurrentPlayer currentPlayer = new CurrentPlayer();
        private static readonly string[] logoLines = { @"






                         ▄████████    ▄████████ ▄██   ▄      ▄███████▄     ███        ▄████████       ▄██████▄     ▄████████         ▄████████     ███        ▄████████    ▄████████ ███▄▄▄▄    ▄█      ███     ▄██   ▄  
                        ███    ███   ███    ███ ███   ██▄   ███    ███ ▀█████████▄   ███    ███      ███    ███   ███    ███        ███    ███ ▀█████████▄   ███    ███   ███    ███ ███▀▀▀██▄ ███  ▀█████████▄ ███   ██▄
                        ███    █▀    ███    ███ ███▄▄▄███   ███    ███    ▀███▀▀██   ███    █▀       ███    ███   ███    █▀         ███    █▀     ▀███▀▀██   ███    █▀    ███    ███ ███   ███ ███▌    ▀███▀▀██ ███▄▄▄███
                        ███         ▄███▄▄▄▄██▀ ▀▀▀▀▀▀███   ███    ███     ███   ▀   ███             ███    ███  ▄███▄▄▄           ▄███▄▄▄         ███   ▀  ▄███▄▄▄      ▄███▄▄▄▄██▀ ███   ███ ███▌     ███   ▀ ▀▀▀▀▀▀███
                        ███        ▀▀███▀▀▀▀▀   ▄██   ███ ▀█████████▀      ███     ▀███████████      ███    ███ ▀▀███▀▀▀          ▀▀███▀▀▀         ███     ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ███   ███ ███▌     ███     ▄██   ███
                        ███    █▄  ▀███████████ ███   ███   ███            ███              ███      ███    ███   ███               ███    █▄      ███       ███    █▄  ▀███████████ ███   ███ ███      ███     ███   ███
                        ███    ███   ███    ███ ███   ███   ███            ███        ▄█    ███      ███    ███   ███               ███    ███     ███       ███    ███   ███    ███ ███   ███ ███      ███     ███   ███
                        ████████▀    ███    ███  ▀█████▀   ▄████▀         ▄████▀    ▄████████▀        ▀██████▀    ███               ██████████    ▄████▀     ██████████   ███    ███  ▀█   █▀  █▀      ▄████▀    ▀█████▀ 
                                     ███    ███                                                                                                                           ███    ███                                     
                            " };
        private static readonly int spaceBetweenLogoAndMenu = 2;
        private static int currentLine = 0;

        public static void ShowMainMenu()
        {
            Console.CursorVisible = false;

            DrawLogo();

            bool hasSaves = Load.CheckForSaves();


            string[] menuItems = hasSaves ? new string[] { "Continue", "Load Game", "Settings", "Exit" }
                                          : new string[] { "start new game", "Load Game", "Settings", "Exit" };

            int selectedIndex = 0;

            while (true)
            {

                DrawMenu(menuItems, selectedIndex);
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : menuItems.Length - 1;
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
            currentLine = 0;
            foreach (var line in logoLines)
            {
                int leftPosition = Math.Max((Console.WindowWidth - line.Length) / 2, 0);
                Console.SetCursorPosition(leftPosition, currentLine++);
                Console.WriteLine(line);
            }
            currentLine += spaceBetweenLogoAndMenu;
        }

        private static void DrawMenu(string[] menuItems, int selectedIndex)
        {


            int menuHeight = menuItems.Length;
            int startLine = (int)Math.Round((Console.WindowHeight - menuHeight) / 2.0);

            for (int i = 0; i < menuItems.Length; i++)
            {

                int leftPosition = (int)Math.Round((Console.WindowWidth - menuItems[i].Length) / 2.0);
                Console.SetCursorPosition(leftPosition, startLine + i);
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
                        CurrentPlayer player = Load.LoadLatestSave();
                        if (player != null)
                        {
                            currentPlayer = player;
                            Console.Clear();
                            Load.LoadLatestSave();
                        }
                        else
                        {
                            Console.WriteLine("Failed to load the game.");
                            Console.ReadKey();
                            Console.Clear();
                            ShowMainMenu();
                        }
                        break;
                    case 1:
                        Load.GLoad();
                        break;
                    case 2:
                        ShowSettingsMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                // När det inte finns sparade spel

                switch (selectedIndex)
                {
                    case 0:
                        GameStart.StartOrContinueGame();
                        break;
                    case 1:
                        Load.GLoad();
                        break;
                    case 2:
                        ShowSettingsMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static void ShowSettingsMenu()
        {
            string[] settingsItems = { "Sound: ON", "Back to Main Menu" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Settings\n");
                for (int i = 0; i < settingsItems.Length; i++)
                {
                    string prefix = i == selectedIndex ? "> " : "  ";
                    Console.WriteLine($"{prefix}{settingsItems[i]}");
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : settingsItems.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % settingsItems.Length;
                        break;
                    case ConsoleKey.Enter:
                        HandleSettingsSelection(selectedIndex, ref settingsItems);
                        break;
                }

                if (selectedIndex == 1 && key.Key == ConsoleKey.Enter) break;
            }

            ShowMainMenu();
        }

        private static void HandleSettingsSelection(int selectedIndex, ref string[] settingsItems)
        {
            switch (selectedIndex)
            {
                case 0:
                    settingsItems[0] = settingsItems[0].Contains("ON") ? "Sound: OFF" : "Sound: ON";
                    // fixa logic här för ljud
                    break;
                case 1:
                    Console.Clear();
                    break;
            }
        }


        static void ClearMenuArea(int lineCount)
        {
            for (int i = 0; i < lineCount; i++)
            {
                Console.SetCursorPosition(0, currentLine + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, currentLine);
        }



    }
}
