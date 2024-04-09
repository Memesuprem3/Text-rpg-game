using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine($"{monster.Name}\nPower: {monster.Power} / Health: {monster.Health}");
                Console.WriteLine("======================");
                Console.WriteLine("| (A)ttack (D)efend  |");
                Console.WriteLine("| (R)un    (H)eal    |");
                Console.WriteLine("======================");
                Console.WriteLine($"Health: {player.health} Damage: {player.weaponValue}");

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
                            Console.WriteLine("You successfully escaped!");
                            return; 
                        }
                        break;
                    case "h":
                    case "heal":
                        PerformHeal(player);
                        break;
                    default:
                        Console.WriteLine("Confused by the heat of battle, you lose your turn...");
                        break;
                }

                
                if (monster.Health > 0)
                {
                    int damageToPlayer = monster.Power - player.armorValue;
                    if (damageToPlayer < 0) damageToPlayer = 0;
                    player.health -= damageToPlayer;
                    Console.WriteLine($"The {monster.Name} attacks you back and deals {damageToPlayer} damage.");
                }

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"You have defeated the {monster.Name}!");
                    break; 
                }

                if (player.health <= 0)
                {
                    Console.WriteLine("You have been defeated...");
                    // implemenmtera retun main menu eller load save osv.
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void PerformAttack(Player player, Monster monster)
        {
            int damageToMonster = rand.Next(0, player.weaponValue) + rand.Next(1, 4); 
            monster.Health -= damageToMonster;
            Console.WriteLine($"You attack the {monster.Name} and deal {damageToMonster} damage.");
        }

        private static void PerformDefend(Player player, Monster monster)
        {
            Console.WriteLine("You defend against the attack, but still take damage.");
            
            int damageReduced = (monster.Power / 2) - player.armorValue;
            if (damageReduced < 0) damageReduced = 0;
            player.health -= damageReduced;
            Console.WriteLine($"The attack done to you is {damageReduced}.");
        }

        private static bool AttemptRun(Player player, Monster monster)
        {
            //utöka baserad på speed stat
            if (rand.Next(0, 2) == 0)
            {
                Console.WriteLine("You failed to escape and take damage!");
                int damageToPlayer = monster.Power - player.armorValue;
                if (damageToPlayer < 0) damageToPlayer = 0;
                player.health -= damageToPlayer;
                Console.WriteLine($"The {monster.Name} attacks you as you try to run and deals {damageToPlayer} damage.");
                return false;
            }
            else
            {
                Console.WriteLine("You use your quick thinking to escape from the battle!");
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
    }
}



