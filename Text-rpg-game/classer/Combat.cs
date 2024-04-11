using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    internal class Combat
    {
        static Random rand = new Random();

        public static void StartFight(Player player, Monster monster)
        {
            while (player.health > 0 && monster.Health > 0)
            {
                Console.Clear();
                string battleMenu = $"{monster.Name}\nPower: {monster.Power} / Health: {monster.Health}" +
                    "\n======================" +
                    "\n| (A)ttack (D)efend  |" +
                    "\n| (R)un    (H)eal    |" +
                    "\n======================" +
                    $"\n    {Player.currentPlayer.Name}    " +
                    $"\nHealth: {player.health} Damage: {player.weaponValue}";

                WriteCenteredText(battleMenu);
                string action = "Action:";
                WriteCenteredTextLower2(action);
                Console.SetCursorPosition(116, 35);
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                    case "attack":
                        PerformAttack(player, monster);
                        break;
                    case "d":
                    case "defend":
                        PerformDefend(player, monster);
                        break;
                    case "r":
                    case "run":
                        if (AttemptRun(player, monster))
                        {
                            string escapedS = "You successfully escaped!";
                            WriteCenteredTextLower(escapedS);
                            return;
                        }
                        break;
                    case "h":
                    case "heal":
                        PerformHeal(player);
                        break;
                    default:
                        string actionfail = "Confused by the heat of battle, you lose your turn...";
                        WriteCenteredTextLower(actionfail);
                        break;
                }


                if (monster.Health > 0)
                {
                    int damageToPlayer = monster.Power - player.armorValue;
                    if (damageToPlayer < 0) damageToPlayer = 0;
                    player.health -= damageToPlayer;
                    string m = $"The {monster.Name} attacks you back and deals {damageToPlayer} damage.";
                    WriteCenteredTextLower(m);
                }

                if (monster.Health <= 0)
                {
                    string Md = $"You have defeated the {monster.Name}!";
                    WriteCenteredTextLower(Md);
                    break;
                }

                if (player.health <= 0)
                {
                    string death = $"You have been killed by {monster.Name}";
                    WriteCenteredTextLower(death);
                    Console.ReadKey();
                    Console.Clear();
                    Main_menu.ShowMainMenu();
                    // implemenmtera retun main menu eller load save osv.
                }


                Console.ReadKey();
            }
        }

        private static void PerformAttack(Player player, Monster monster)
        {
            int damageToMonster = rand.Next(0, player.weaponValue) + rand.Next(1, 4);
            monster.Health -= damageToMonster;
            //Console.WriteLine($"You attack the {monster.Name} and deal {damageToMonster} damage.");
            string atk = $"You attack the {monster.Name} and deal {damageToMonster} damage.";
            WriteCenteredTextLower1(atk);
        }

        private static void PerformDefend(Player player, Monster monster)
        {
            //Console.WriteLine("You defend against the attack, but still take damage.");
            string def1 = "You defend against the attack, but still take damage.";
            WriteCenteredTextLower(def1);
            int damageReduced = (monster.Power / 2) - player.armorValue;
            if (damageReduced < 0) damageReduced = 0;
            player.health -= damageReduced;
            //Console.WriteLine($"The attack done to you is {damageReduced}.");
            string def2 = $"The attack done to you is {damageReduced}.";
            WriteCenteredTextLower(def2);
        }

        private static bool AttemptRun(Player player, Monster monster)
        {
            //utöka baserad på speed stat
            if (rand.Next(0, 2) == 0)
            {
                string runF = "You failed to escpae and take damage in the process";
                WriteCenteredTextLower(runF);
                //Console.WriteLine("You failed to escape and take damage!");
                int damageToPlayer = monster.Power - player.armorValue;
                if (damageToPlayer < 0) damageToPlayer = 0;
                player.health -= damageToPlayer;
                //Console.WriteLine($"The {monster.Name} attacks you as you try to run and deals {damageToPlayer} damage.");
                string runFD = $"The {monster.Name} attacks you as you try to run and deals {damageToPlayer} damage.";
                WriteCenteredTextLower(runFD);
                return true;
            }
            else
            {
                //Console.WriteLine("You use your quick thinking to escape from the battle!");
                string runSuc = "You use your quick thinking to escape from the battle!";
                WriteCenteredTextLower(runSuc);
                Shop.Loadshop(player);
                return true;
            }
        }

        private static void PerformHeal(Player player)
        {
            //utöka för att passa bättre med invenrtory system
            if (player.inventory.ContainsKey("Minor Healing Potion") && player.inventory["Minor Healing Potion"] > 0)
            {
                player.health += 5; // Lägger till hälsa
                player.inventory["Minor Healing Potion"]--; // Tar bort en potion från inventariet
                Console.WriteLine("You use a Minor Healing Potion to restore 5 health.");
            }
            else
            {
                Console.WriteLine("You have no Minor Healing Potions left!");
            }
        }

        public static void WriteCenteredText(string text, int offsetY = 0)
        {
            Console.Clear();
            string[] lines = text.Split('\n');
            int centerY = (Console.WindowHeight - lines.Length) / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, centerY + i + offsetY);
                Console.WriteLine(line);
            }
        }

        public static void WriteCenteredTextLower(string text, int offsetY = 0)
        {

            string[] lines = text.Split('\n');
            int centerY = (Console.WindowHeight - lines.Length) / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, centerY + 7 + i + offsetY);
                Console.WriteLine(line);
            }
        }

        public static void WriteCenteredTextLower1(string text, int offsetY = 0)
        {

            string[] lines = text.Split('\n');
            int centerY = (Console.WindowHeight - lines.Length) / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, centerY + 6 + i + offsetY);
                Console.WriteLine(line);
            }
        }
        public static void WriteCenteredTextLower2(string text, int offsetY = 0)
        {

            string[] lines = text.Split('\n');
            int centerY = (Console.WindowHeight - lines.Length) / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX-7, centerY + 4 + i + offsetY);
                Console.WriteLine(line);
            }
        }
    }
}



