using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("======================");
                Console.WriteLine("| (A)ttack (D)fend   |");
                Console.WriteLine("| (R)un    (H)eal    |");
                Console.WriteLine("======================");
                Console.WriteLine("potions: " + Program.currentPlayer.potions + "  Health:  " + Program.currentPlayer.health);
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
                        // go to store or base what ever idc
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // heal
                    if (Program.currentPlayer.potionsS == 0 || Program.currentPlayer.potionsM == 0  || Program.currentPlayer.potionsL == 0)
                    {
                        Console.WriteLine("you check your pockets and find nothing to heal with");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " strikes you while you search and you lose " + damage + " health");
                    }
                    else
                    {
                        Console.WriteLine("you reach into your bag and pull out a glowing purple flask and take a drank");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you drank " + n + " strikes you");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose "+damage+" health");
                    }
                }
                if(Program.currentPlayer.health <= 0)
                {
                    // deathcode

                    Console.WriteLine("you fall to the ground as "+n+" stands over your slain body");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = rand.Next(10, 51);
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