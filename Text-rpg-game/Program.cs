using Text_rpg_game.classer;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.ComponentModel.Design;
using System.Text.Json;

namespace Text_rpg_game
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            if (!Directory.Exists("Saves"))
            {
                Directory.CreateDirectory("Saves");
            }
            currentPlayer = Load(out bool newplayer);
            if (newplayer)
                Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }

            Shop.RunShop(Program.currentPlayer);
        }

        static Player start(int i)
        {
            Console.Clear();
            Player p = new Player();
            //Console.WriteLine("Crypts of Eternity");
            Console.WriteLine(" ▄████████    ▄████████ ▄██   ▄      ▄███████▄     ███        ▄████████       ▄██████▄     ▄████████         ▄████████     ███        ▄████████    ▄████████ ███▄▄▄▄    ▄█      ███     ▄██   ▄   ");
            Console.WriteLine("███    ███   ███    ███ ███   ██▄   ███    ███ ▀█████████▄   ███    ███      ███    ███   ███    ███        ███    ███ ▀█████████▄   ███    ███   ███    ███ ███▀▀▀██▄ ███  ▀█████████▄ ███   ██▄ ");
            Console.WriteLine("███    █▀    ███    ███ ███▄▄▄███   ███    ███    ▀███▀▀██   ███    █▀       ███    ███   ███    █▀         ███    █▀     ▀███▀▀██   ███    █▀    ███    ███ ███   ███ ███▌    ▀███▀▀██ ███▄▄▄███ ");
            Console.WriteLine("███         ▄███▄▄▄▄██▀ ▀▀▀▀▀▀███   ███    ███     ███   ▀   ███             ███    ███  ▄███▄▄▄           ▄███▄▄▄         ███   ▀  ▄███▄▄▄      ▄███▄▄▄▄██▀ ███   ███ ███▌     ███   ▀ ▀▀▀▀▀▀███ ");
            Console.WriteLine("███        ▀▀███▀▀▀▀▀   ▄██   ███ ▀█████████▀      ███     ▀███████████      ███    ███ ▀▀███▀▀▀          ▀▀███▀▀▀         ███     ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ███   ███ ███▌     ███     ▄██   ███ ");
            Console.WriteLine("███    █▄  ▀███████████ ███   ███   ███            ███              ███      ███    ███   ███               ███    █▄      ███       ███    █▄  ▀███████████ ███   ███ ███      ███     ███   ███ ");
            Console.WriteLine("███    ███   ███    ███ ███   ███   ███            ███        ▄█    ███      ███    ███   ███               ███    ███     ███       ███    ███   ███    ███ ███   ███ ███      ███     ███   ███ ");
            Console.WriteLine("████████▀    ███    ███  ▀█████▀   ▄████▀         ▄████▀    ▄████████▀        ▀██████▀    ███               ██████████    ▄████▀     ██████████   ███    ███  ▀█   █▀  █▀      ▄████▀    ▀█████▀  ");
            Console.WriteLine("             ███    ███                                                                                                                           ███    ███                                      ");
            Console.ReadKey();
            Console.WriteLine("what is your name?");
            p.Name = Console.ReadLine();
            p.playerID = i;
            Console.Clear();
            Console.WriteLine("everything i hazy AF, you wake up in a dark room and have no recoletion of who you are");
            Console.WriteLine("anything about your past is gone");
            if (currentPlayer.Name == "")
            {
                Console.WriteLine("you cant even remeber your own name");
            }
            else
                Console.WriteLine("you know your name is " + p.Name);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You grope around in the darkness untill you find a door handel. You feel some risitance");
            Console.WriteLine("as you turn the handel but the rusty lock breaks with little ease. You se your captor");
            Console.WriteLine("you se your captor starind with his back to you outside the door ");
            return p;
        }

        public static void Save()
        {
            string path = Path.Combine("Saves", $"{currentPlayer.playerID}.json");
            string jsonString = JsonSerializer.Serialize(currentPlayer, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(path, jsonString);
        }


        public static Player Load(out bool newPlayer)
        {
            newPlayer = false;
            Console.Clear();
            Console.WriteLine("Choose your save file:");
            string[] paths = Directory.GetFiles("Saves", "*.json");
            List<Player> players = new List<Player>();

            foreach (string path in paths)
            {
                string jsonString = System.IO.File.ReadAllText(path);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                if (player != null)
                {
                    players.Add(player);
                }
            }

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {players[i].Name} (ID: {players[i].playerID})");
                }
                Console.WriteLine("\nEnter the number to select a player, type 'create' to start a new save, or 'exit' to quit:");

                string input = Console.ReadLine().Trim().ToLower();

                if (input == "create")
                {
                    newPlayer = true;
                    return start(players.Count); // Antagande att denna metod returnerar en ny Player-instans
                }
                else if (input == "exit")
                {
                    Environment.Exit(0);
                }
                else if (int.TryParse(input, out int selected) && selected >= 1 && selected <= players.Count)
                {
                    return players[selected - 1];
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}