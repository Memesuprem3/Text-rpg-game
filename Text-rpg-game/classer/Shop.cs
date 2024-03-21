using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    public class Shop
    {

        public static void Loadshop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;

            //potions

            //armor

            //weapons


            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * p.armorValue;
                weaponP = 100 * (p.weaponValue + 1);
                Console.WriteLine("======================================");
                Console.WriteLine("|        ~ Mystical Emporium ~       |");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("| (H)ealing Elixirs                  |");
                Console.WriteLine("| (W)eapons                          |");
                Console.WriteLine("| (M)agic Armors                     |");
                Console.WriteLine("| (S)ell Items                       |");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("| (E)xit Shop                        |");
                Console.WriteLine("======================================");
                Console.WriteLine($"Your Gold: {Program.currentPlayer.coins}");
                Console.Write("Barnabas Arcanum: Here are the weares i supply, dont take to long, there is a war going on.");
                Console.WriteLine("");

                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "H":
                        ShowHealingElixirsMenu();
                        break;
                    case "W":
                        ShowWeaponsMenu();
                        break;
                    case "M":
                        ShowMagicArmorsMenu();
                        break;
                    case "E":
                        Console.WriteLine("Barnabas Arcanum:Thank you for visiting the Mystical Emporium!");
                        return;
                    default:
                        Console.WriteLine("Barnabas Arcanum: Sadly i dont supply that");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowHealingElixirsMenu()
        {
            Console.WriteLine("Barnabas Arcanum: Choose your Healing Elixir!");
            // Add options for different types of healing elixirs
            Console.WriteLine("Minor Healing Potion");
            Console.WriteLine("Medium Healing Potion");
            Console.WriteLine("Large Healing Potion");
            // Add logic for purchasing an elixir
        }

        static void ShowWeaponsMenu(Player p)
        {
            {
                Console.WriteLine("Barnabas Arcanum: Välj ditt vapen!");
                Console.WriteLine("1. Sword - 100 Gold");
                Console.WriteLine("2. Staff - 80 Gold");
                Console.WriteLine("3. Magic Weapon - 150 Gold");
                Console.WriteLine("4. Bow - 120 Gold");
                Console.WriteLine("5. Mace - 90 Gold");
                Console.Write("Välj ett vapen: ");

                string weaponChoice = Console.ReadLine().ToUpper();
                int cost = 0;
                
                switch (weaponChoice)
                {
                    case "1":
                        cost = 100;
                        Buy("Sword", cost, p, 3); // Låt oss anta att "3" är attackvärdeökningen
                        break;
                    case "2":
                        cost = 80;
                        Buy("Staff", cost, p, 2); // Exempelvärde
                        break;
                    case "3":
                        cost = 150;
                        Buy("Magic Weapon", cost, p, 4); // Exempelvärde
                        break;
                    case "4":
                        cost = 120;
                        Buy("Bow", cost, p, 3); // Exempelvärde
                        break;
                    case "5":
                        cost = 90;
                        Buy("Mace", cost, p, 3); // Exempelvärde
                        break;
                    default:
                        Console.WriteLine("Barnabas Arcanum: Det verkar inte vara ett giltigt val.");
                        break;
                }
            }
        }

        static void ShowMagicArmorsMenu()
        {
            Console.WriteLine("Barnabas Arcanum: deefens is the best offens!");
            Console.WriteLine("1. Leather Armor");
            Console.WriteLine("2. Chainmail");
            Console.WriteLine("3. Plate Armor");
            // Add more as needed
            Console.Write("Select an armor: ");
            // Add logic for armor selection and purchasing
        }

        static void Buy(string item, int cost, Player p, int valueIncrease = 0)
        {
            if (p.coins >= cost)
            {
                p.coins -= cost; 
                Console.WriteLine($"Barnabas Arcanum: Du har framgångsrikt köpt {item} för {cost} mynt.");

                // Uppdatera spelarens stats baserat på vad som köptes
                switch (item)
                {
                    case "Minor Healing Potion":
                        p.potionsS += valueIncrease;
                        Console.WriteLine($"You now have:  {p.potionsS}.");
                        break;
                    case "Medium Healing Potion":
                        p.potionsM += valueIncrease;
                        Console.WriteLine($"You now have:  {p.potionsM}.");
                        break;
                    case "Major Healing Potion":
                        p.potionsL += valueIncrease;
                        Console.WriteLine($"You now have:  {p.potionsL}.");
                        break;
                    case "Sword":
                    case "Staff":
                    case "Magic Weapon":
                    case "Bow":
                    case "Mace":
                        p.weaponValue += valueIncrease;
                        Console.WriteLine($"Din attackstyrka har ökat med {valueIncrease}.");
                        break;
                    case "Leather Armor":
                    case "Brass Armor":
                    case "Iron Armor":
                    case "Steel Armor":
                    case "Magic Armor":
                        p.armorValue += valueIncrease;
                        Console.WriteLine($"Ditt försvar har ökat med {valueIncrease}.");
                        break;
                    default:
                        Console.WriteLine("Något gick fel. Försök igen.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Barnabas Arcanum: Tyvärr, du har inte tillräckligt med mynt för detta köp.");
            }
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        static void Sell(Player p)
        {
            Console.WriteLine("Barnabas Arcanum: Show me what you have");
            Console.WriteLine(Program.currentPlayer.inventory);
           

            string sellChoice = Console.ReadLine().ToUpper();
            int sellPrice = 0;

            switch (sellChoice)
            {
                case "1":
                    // Anta att spelaren kan sälja en Healing Potion
                    // Kontrollera först att spelaren faktiskt har ett Healing Potion
                    sellPrice = 10; // Antag att säljpriset är mindre än köppriset
                    p.coins += sellPrice;
                    // Minska antalet Healing Potions i spelarens inventar
                    Console.WriteLine($"Du har sålt en Healing Potion för {sellPrice} mynt.");
                    break;
                case "2":
                    // Anta att spelaren kan sälja ett Sword
                    sellPrice = 50; // Ange lämpligt säljpris
                    p.coins += sellPrice;
                    // Uppdatera spelarens inventory för att reflektera försäljningen
                    Console.WriteLine($"Du har sålt ett Sword för {sellPrice} mynt.");
                    break;
                case "3":
                    // Anta att spelaren kan sälja Leather Armor
                    sellPrice = 25; // Ange lämpligt säljpris
                    p.coins += sellPrice;
                    // Uppdatera spelarens inventory för att reflektera försäljningen
                    Console.WriteLine($"Du har sålt Leather Armor för {sellPrice} mynt.");
                    break;
                default:
                    Console.WriteLine("Barnabas Arcanum: Tyvärr, det verkar inte som vi kan köpa det där.");
                    break;
            }
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }

    
}
