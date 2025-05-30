﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Utilitys;
using Text_rpg_game.classer.Player;
using Text_rpg_game.classer.World.Shops;
using Text_rpg_game.classer.Utilitys.Menus;
using Text_rpg_game.classer.Player.Core;

namespace Text_rpg_game.classer.Combat
{
    internal class Combats
    {
        static Random rand = new Random();

        public static void StartFight(CurrentPlayer player, Monster monster)
        {
            Console.Clear();
            
            while (player.health > 0 && monster.Health > 0)
            {
                Console.Clear();
                string battleMenu = $"{monster.Name}\nPower: {monster.Power} / Health: {monster.Health}" +
                    "\n=======================" +
                    "\n| (A)ttack (D)efend    |" +
                    "\n| (R)un    (H)eal      |" +
                    "\n| (B) Abilities        |" +
                    "\n=======================" +
                    $"\n{CurrentPlayer.currentPlayer.Name}" +
                    $"\nHealth: {player.health} Damage: {player.weaponValue}";

                WriteCenteredText(battleMenu);
                string action = "Action:";
                WriteCenteredTextLower2(action);
                Console.SetCursorPosition(116, 36);
                string input = Console.ReadLine().ToLower();


                switch (input)
                {
                    case "a":
                    case "attack":
                        PerformAttack(player, monster);
                        WriteCenteredTextLower($"You attack the {monster.Name} and deal {player.weaponValue} damage.");
                        break;
                    case "d":
                    case "defend":
                        PerformDefend(player, monster);
                        WriteCenteredTextLower("You defend against the attack, but still take some damage.");
                        break;
                    case "r":
                    case "run":
                        if (AttemptRun(player, monster)) return;
                        WriteCenteredTextLower("You failed to escape and take damage in the process.");
                        break;
                    case "h":
                    case "heal":
                        PerformHeal(player);
                        break;
                    case "b":
                        DisplayAbilitiesMenu(player, monster);
                        break;
                    default:
                        WriteCenteredTextLower("Confused by the heat of battle, you lose your turn...");
                        break;
                }

                MonsterResponse(monster, player);
            }

            //EndFight(player, monster);
        }

        private static void DisplayAbilitiesMenu(CurrentPlayer player, Monster monster)
        {
            Console.Clear();
            List<Ability> availableAbilities = player.Abilities
                .Where(a => a.MinLevel <= player.Level && a.RequiredClass == player.CharacterClass)
                .ToList();

            if (availableAbilities.Count == 0)
            {
                WriteCenteredTextLower("No abilities available.");
                Console.ReadKey();
                return;
            }

            StringBuilder abilitiesDisplay = new StringBuilder();
            abilitiesDisplay.AppendLine("Select an Ability:");
            for (int i = 0; i < availableAbilities.Count; i++)
            {
                abilitiesDisplay.AppendLine($"{i + 1}. {availableAbilities[i].Name} - {availableAbilities[i].Description}");
            }

            WriteCenteredTextLower(abilitiesDisplay.ToString());

            Console.SetCursorPosition((Console.WindowWidth - 1) / 2, Console.WindowHeight / 2 + availableAbilities.Count + 2);
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= availableAbilities.Count)
            {
                availableAbilities[choice - 1].Perform(player, monster);
                Console.ReadKey();
            }
            else
            {
                WriteCenteredTextLower("Invalid ability choice.");
                Console.ReadKey();
            }
        }

        private static void MonsterResponse(Monster monster, CurrentPlayer player)
        {
            if (monster.Health > 0)
            {
                // AI-logik: Flee när HP < 20% om CanFlee = true
                if (monster.Health <= monster.MaxHealth * 0.2 && monster.AI.CanFlee && !monster.AI.HasTriedToFlee)
                {
                    monster.AI.HasTriedToFlee = true;

                    int fleeChance = rand.Next(100);

                    if (fleeChance < 33)
                    {
                        WriteCenteredTextLower($"{monster.Name} panics and successfully flees from battle!");
                        return;
                    }
                    else
                    {
                        WriteCenteredTextLower($"{monster.Name} tries to flee but fails!");
                        return;
                    }
                }

                    // Använder förmåga om den har några, 35% chans
                if (monster.Abillities.Count > 0 && rand.Next(100) < 35)
                {
                    monster.UseRandomAbility(player);
                }
                else
                {
                int totalArmor = player.armorValue;

                 if (player.EquippedArmor != null)
                    totalArmor += player.EquippedArmor.ArmorValue;

                    int damageToPlayer = monster.Power - totalArmor;
                 if (damageToPlayer < 0) damageToPlayer = 0;

                    player.health -= damageToPlayer;
                    WriteCenteredTextLower($"The {monster.Name} attacks and deals {damageToPlayer} damage.");
                }
            }

            if (monster.Health <= 0)
            {
                WriteCenteredTextLower($"You have defeated the {monster.Name}!");
                Console.ReadKey();
                Console.Clear();

                var loot = monster.Defeat();
                if (loot.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CenteredWriter.Write("You found:");
                    foreach (var item in loot)
                    {
                        CenteredWriter.Write($"- {item.Name}");
                        CurrentPlayer.currentPlayer.inventory.TryAdd(item.Name, 1); // SE ÖVER
                    }
                    Console.ResetColor();
                }
                else
                {
                    CenteredWriter.Write("The monster dropped nothing.");
                    Console.ReadKey();
                    Console.Clear();
                }

                CenteredWriter.Write("Press any key to continue...");
                Console.ReadKey();

                // Starta pausmeny
                GameMenu.PauseMenu();
            }

            if (player.health <= 0)
            {
                WriteCenteredTextLower($"You were slain by {monster.Name}.");
                Console.ReadKey();
                Console.Clear();
                Main_menu.ShowMainMenu();
            }
        }

        private static void PerformAttack(CurrentPlayer player, Monster monster)
        {
            int damageToMonster = player.CalculateWeaponDamage();
            monster.Health -= damageToMonster;

            string atk = $"You attack the {monster.Name} and deal {damageToMonster} damage.";
            WriteCenteredTextLower1(atk);
        }

        private static void PerformDefend(CurrentPlayer player, Monster monster)
        {
            //Console.WriteLine("You defend against the attack, but still take damage.");
            string def1 = "You defend against the attack, but still take damage.";
            WriteCenteredTextLower(def1);
            int damageReduced = monster.Power / 2 - player.armorValue;
            if (damageReduced < 0) damageReduced = 0;
            player.health -= damageReduced;
            //Console.WriteLine($"The attack done to you is {damageReduced}.");
            string def2 = $"The attack done to you is {damageReduced}.";
            WriteCenteredTextLower(def2);
        }

        private static bool AttemptRun(CurrentPlayer player, Monster monster)
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

        private static void PerformHeal(CurrentPlayer player)
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
                Console.SetCursorPosition(centerX - 7, centerY + 5 + i + offsetY);
                Console.WriteLine(line);
            }
        }
    }
}



