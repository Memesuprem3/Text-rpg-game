using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    public class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic








        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door, and grap a rusty metal sowrd, charging towards your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Human Rouge", 1, 4);
        }

        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("you turn the corner and se a Enemy");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door slowly opens as you peer in to the darkroom. You se a man with a wide and pointy hat");
            Console.WriteLine(", long beard lookin at a large tome");
            Console.ReadKey();
            Combat(false, "Dark Wizard",4,2);
        }



        //Encounter Tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0, 2))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("Power: " +p+ " / "+" Health: "+h);
                Console.WriteLine("======================");
                Console.WriteLine("| (A)ttack (D)fend   |");
                Console.WriteLine("| (R)un    (H)eal    |");
                Console.WriteLine("| (I)ventory         |");
                Console.WriteLine("======================");
                ShowTotalPotions(Program.currentPlayer);

                //bygga inventroy i mid fight
               /* Console.WriteLine("======================================");
                Console.WriteLine("|         ~ " + p.Name + "'s Stats ~ |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| Health:        " + p.health.ToString().PadRight(20) + "|");
                Console.WriteLine("| Attack:        " + p.weaponValue.ToString().PadRight(20) + "|");
                Console.WriteLine("| Armor:         " + p.armorValue.ToString().PadRight(20) + "|");
                Console.WriteLine("| (I)nventory                        |");
                Console.WriteLine("======================================");*/


                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // attack
                    Console.WriteLine("with haste you sruge forth, your sword dancing in your hands! As you pass, the " + n + " strikes you as you pass");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and you deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;

                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // defend
                    Console.WriteLine("as the " + n + " prepares to strike, you ready your sword in a defensive stance");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You lose " + damage + " health and you deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from " + n + " ,its strike catches you in the back and sends you sprawling down on the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("you lose " + damage + " health and are unabel to escape");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("You use your crazy legs and escape " + n + " that was close!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("you run untill you se a door with the sighn Mystical Emporium");
                        Shop.RunShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // heal
                    bool hasPotion = Program.currentPlayer.inventory.Any(kvp => kvp.Key.Contains("Healing Potion") && kvp.Value > 0);
                    if (!hasPotion)
                    {
                        Console.WriteLine("You check your pockets and find nothing to heal with.");
                        int damage = p - Program.currentPlayer.armorValue;
                        damage = Math.Max(damage, 0); // Ensure damage is not negative
                        Console.WriteLine($"The {n} strikes you while you search and you lose {damage} health.");
                    }
                    else
                    {
                        Console.WriteLine("Choose a potion to use: (S)mall, (M)edium, (L)arge");
                        string potionInput = Console.ReadLine();
                        int potionValue = 0;
                        string potionName = "";
                        switch (potionInput.ToLower())
                        {
                            case "s":
                                potionName = "Minor Healing Potion";
                                potionValue = 5; // Adjust value as needed
                                break;
                            case "m":
                                potionName = "Medium Healing Potion";
                                potionValue = 10; // Adjust value as needed
                                break;
                            case "l":
                                potionName = "Major Healing Potion";
                                potionValue = 20; // Adjust value as needed
                                break;
                            default:
                                Console.WriteLine("Invalid choice. You lose your turn.");
                                break;
                        }

                        if (potionValue > 0 && Program.currentPlayer.inventory.ContainsKey(potionName) && Program.currentPlayer.inventory[potionName] > 0)
                        {
                            Console.WriteLine($"You use a {potionName} and gain {potionValue} health.");
                            Program.currentPlayer.health += potionValue;
                            Program.currentPlayer.inventory[potionName]--; // Reduce the number of the chosen potion
                            if (Program.currentPlayer.inventory[potionName] == 0)
                            {
                                Program.currentPlayer.inventory.Remove(potionName); // Remove the potion from inventory if it's now zero
                            }

                            int damage = (p / 2) - Program.currentPlayer.armorValue;
                            damage = Math.Max(damage, 0);
                            Console.WriteLine($"The {n} strikes you after you heal and you lose {damage} health.");
                        }
                        else
                        {
                            Console.WriteLine("You reach for a potion but find none left of that type.");
                            int damage = p - Program.currentPlayer.armorValue;
                            damage = Math.Max(damage, 0);
                            Console.WriteLine($"The {n} takes advantage of your distraction and strikes you, causing {damage} health loss.");
                        }
                    }
                }

                static void ShowTotalPotions(Player p)
                {
                    int totalPotions = 0;
                    // Loopa igenom inventory och addera antalet för varje healing potion
                    if (p.inventory.ContainsKey("Minor Healing Potion"))
                    {
                        totalPotions += p.inventory["Minor Healing Potion"];
                    }
                    if (p.inventory.ContainsKey("Medium Healing Potion"))
                    {
                        totalPotions += p.inventory["Medium Healing Potion"];
                    }
                    if (p.inventory.ContainsKey("Major Healing Potion"))
                    {
                        totalPotions += p.inventory["Major Healing Potion"];
                    }

                    Console.WriteLine($"potions: {totalPotions}  Health: {Program.currentPlayer.health}");
                }

                if (Program.currentPlayer.health <= 0)
                {
                    // deathcode

                    Console.WriteLine("you fall to the ground as "+n+" stands over your slain body");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine("As you stand victorius over the "+n+" , you loot it and find "+c+ " gold coins");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
        public static string GetName()
        {
           switch(rand.Next(0, 10))
           {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
                case 4:
                    return "Giant Spider";
                case 5:
                    return "Orc";
                case 6:
                    return "Minutaur";
                case 7:
                    return "Troll";
                case 8:
                    return "Black kight";
                case 9:
                    return "Cyklops";

            }
            return "Human Rouge";
        }
    }
}