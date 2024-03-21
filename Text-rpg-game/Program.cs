using Text_rpg_game.classer;

namespace Text_rpg_game
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
            
            Shop.RunShop(Program.currentPlayer);
        }

        static void start()
        {
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
            currentPlayer.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("everything i hazy AF, you wake up in a dark room and have no recoletion of who you are");
            Console.WriteLine("anything about your past is gone");
            if(currentPlayer.Name == "")
            {
                Console.WriteLine("you cant even remeber your own name");
            }
             else
            Console.WriteLine("you know your name is " + currentPlayer.Name);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You grope around in the darkness untill you find a door handel. You feel some risitance");
            Console.WriteLine("as you turn the handel but the rusty lock breaks with little ease. You se your captor");
            Console.WriteLine("you se your captor starind with his back to you outside the door ");
        }



    }
}
