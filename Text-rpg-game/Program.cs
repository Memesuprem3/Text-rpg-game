using Text_rpg_game.classer;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.ComponentModel.Design;
using System.Text.Json;
using Spectre.Console;


namespace Text_rpg_game
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            
            Images.DrawLogo2();
            Console.ReadKey();
            Console.Clear();
            Main_menu.ShowMainMenu();
        }
    }
}