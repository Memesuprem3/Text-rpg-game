using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.ComponentModel.Design;
using System.Text.Json;
using Spectre.Console;
using System.Runtime.InteropServices;
using Text_rpg_game.classer.Utilitys;
using Text_rpg_game.classer.Utilitys.Menus;
using Text_rpg_game.classer.Player.Core;


namespace Text_rpg_game
{
    internal class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        const int SW_MAXIMIZE = 3;
        public static CurrentPlayer currentPlayer = new CurrentPlayer();
        public static bool mainLoop = true;


        static void Main(string[] args)
        {
            IntPtr consoleWindow = GetConsoleWindow();
            ShowWindow(consoleWindow, SW_MAXIMIZE);
            Images.DrawLogo2();
            Console.ReadKey();
            Console.Clear();
            Main_menu.ShowMainMenu();
        }
    }
}