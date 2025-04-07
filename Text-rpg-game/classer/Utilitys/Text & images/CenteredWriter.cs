using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Utilitys
{
    public static class CenteredWriter
    {
        public static void Write(string[] lines, int startY)
        {
            foreach (var line in lines)
            {
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, startY++);
                Console.WriteLine(line);
            }
        }

        public static void Write(string text, int offsetY = 0)
        {
            Write(new[] { text }, (Console.WindowHeight / 2) - 4 + offsetY);
        }

        public static string CenteredInput(int offsetY = 0)
        {
            int centerX = (Console.WindowWidth - 10) / 2;
            int centerY = (Console.WindowHeight / 2) + offsetY;
            Console.SetCursorPosition(centerX, centerY);
            return Console.ReadLine();
        }

        public static string ShowSelectionMenu(string[] options, Dictionary<string, string[]> descriptions)
        {
            int selectedIndex = 0;
            int menuTop = (Console.WindowHeight - options.Length) / 2;

            // Rita första gången
            Console.Clear();
            Write(descriptions[options[selectedIndex]], menuTop - descriptions[options[selectedIndex]].Length - 2);
            DrawMenu(options, selectedIndex, menuTop);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : options.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = selectedIndex < options.Length - 1 ? selectedIndex + 1 : 0;
                }

                // Rensa menyområdet och beskrivning, men inte hela skärmen
                ClearArea(menuTop - 10, Console.WindowHeight);

                // Rita om meny + ny beskrivning
                Write(descriptions[options[selectedIndex]], menuTop - descriptions[options[selectedIndex]].Length - 2);
                DrawMenu(options, selectedIndex, menuTop);

            } while (key != ConsoleKey.Enter);

            return options[selectedIndex];
        }

        private static void DrawMenu(string[] options, int selectedIndex, int startLine)
        {
            for (int i = 0; i < options.Length; i++)
            {
                int left = (Console.WindowWidth - options[i].Length - 2) / 2;
                Console.SetCursorPosition(left, startLine + i);
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {options[i]}");
                }
            }
        }

        private static void ClearArea(int fromY, int toY)
        {
            for (int i = fromY; i < toY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }
    }
}

