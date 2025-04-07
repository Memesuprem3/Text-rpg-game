using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Player.Core;
using Text_rpg_game.classer.Utilitys.Menus;

namespace Text_rpg_game.classer.Utilitys
{
    public static class GameMenu
    {
        public static void PauseMenu()
        {
            string[] options = new[]
            {
                "Continue exploring",
                "Check inventory",
                "View stats",
                "View map (coming soon)",
                "Exit to main menu"
            };

            Dictionary<string, string[]> descriptions = new()
            {
              { "Continue exploring", new[] { "Move forward into the unknown..." } },
              { "Check inventory", new[] { "View all items you currently hold." } },
              { "View stats", new[] { "Inspect your character’s stats and progress." } },
              { "View map (coming soon)", new[] { "Map is not available yet, but soon!" } },
              { "Exit to main menu", new[] { "Return to the title screen." } }
            };

            while (true)
            {
                Console.Clear();
                CenteredWriter.Write("=== What would you like to do? ===", -4);

                string selected = CenteredWriter.ShowSelectionMenu(options, descriptions);

                switch (selected)
                {
                    case "Continue exploring":
                        Console.Clear();
                        CenteredWriter.Write("You move forward into the unknown...");
                        Thread.Sleep(1500);
                        Encounters.Encounters.RandomFightEncounter();
                        return;

                    case "Check inventory":
                        Console.Clear();
                        //CurrentPlayer.currentPlayer.lookInventory(CurrentPlayer.currentPlayer);
                        Console.WriteLine("\nPress any key to return...");
                        Console.ReadKey();
                        break;

                    case "View stats":
                        Console.Clear();
                        CurrentPlayer.currentPlayer.ShowStatsMenu();
                        break;

                    case "View map (coming soon)":
                        Console.Clear();
                        Console.WriteLine("Map system is not implemented yet!");
                        Console.ReadKey();
                        break;

                    case "Exit to main menu":
                        Console.Clear();
                        Main_menu.ShowMainMenu();
                        return;
                }
            }
        }
    }
}
