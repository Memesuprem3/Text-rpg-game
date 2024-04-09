using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Text_rpg_game.classer
{
    public class Shop
    {
        //Shop.RunShop(Program.currentPlayer);
        public static void Loadshop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        { 
            while (true)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("|        ~ Mystical Emporium ~       |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|    Here are the weares i supply!   |");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("| (H)ealing Elixirs                  |");
                Console.WriteLine("| (W)eapons                          |");
                Console.WriteLine("| (M)agic Armors                     |");
                Console.WriteLine("| (S)ell Items                       |");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("| (E)xit Shop                        |");
                Console.WriteLine("======================================");
                Console.WriteLine($"Your Gold: {Program.currentPlayer.coins}");
                Console.WriteLine(" (Q)uite Game");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("You rest in the shop and check your gear and vaitals");
                Console.WriteLine("======================================");
                Console.WriteLine("|         ~ " + p.Name + "'s Stats ~ |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| Health:        " + p.health.ToString().PadRight(20) + "|");
                Console.WriteLine("| Attack:        " + p.weaponValue.ToString().PadRight(20) + "|");
                Console.WriteLine("| Armor:         " + p.armorValue.ToString().PadRight(20) + "|");
                Console.WriteLine("| (I)nventory                        |");
                Console.WriteLine("======================================");





                string choice = Console.ReadLine().ToUpper();
                Console.Clear();

                switch (choice)
                {
                    case "H":
                        ShowHealingElixirsMenu(p);
                        break;
                    case "W":
                        ShowWeaponsMenu(p);
                        break;
                    case "M":
                        ShowMagicArmorsMenu(p);
                        break;
                    case "S":
                        Sell(p);
                        break;
                    case "E":
                        Console.WriteLine("Barnabas Arcanum:Thank you for visiting the Mystical Emporium!");
                        return;
                    case "I":
                      Player.lookInventory(p);
                        break;
                    case "Q":
                        Save.GSave();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Barnabas Arcanum: Sadly i dont supply that");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowHealingElixirsMenu(Player p)
        {
            Console.WriteLine("Barnabas Arcanum: Choose your Healing Elixir!");
            Console.WriteLine("1.Minor  Healing Potion - 20 Gold");
            Console.WriteLine("2.Medium Healing Potion - 50 Gold");
            Console.WriteLine("3.Large  Healing Potion - 80 Gold");
            string potionChoice = Console.ReadLine().ToUpper();
            int cost = 0;

            switch (potionChoice)
            {
                case "1":
                    cost = 20;
                    Buy("Minor Healing Potion", cost, p, 1);
                    break;
                case "2":
                    cost = 50;
                    Buy("Medium Healing Potion", cost, p, 1);
                    break;
                case "3":
                    cost = 80;
                    Buy("Large Healing Potion", cost, p, 1);
                    break;
                default:
                    Console.WriteLine("Barnabas Arcanum: stop messing around");
                    break;
            }
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
                        Buy("Sword", cost, p, 3);
                        break;
                    case "2":
                        cost = 80;
                        Buy("Staff", cost, p, 2); 
                        break;
                    case "3":
                        cost = 150;
                        Buy("Magic Weapon", cost, p, 4); 
                        break;
                    case "4":
                        cost = 120;
                        Buy("Bow", cost, p, 3); 
                        break;
                    case "5":
                        cost = 90;
                        Buy("Mace", cost, p, 3); 
                        break;
                    default:
                        Console.WriteLine("Barnabas Arcanum: Det verkar inte vara ett giltigt val.");
                        break;
                }
            }
        }

        static void ShowMagicArmorsMenu(Player p)
        {
            Console.WriteLine("Barnabas Arcanum: deefens is the best offens!");
            Console.WriteLine("1. Leather Armor");
            Console.WriteLine("2. Chainmail");
            Console.WriteLine("3. Plate Armor");
            Console.Write("Select an armor: ");
            // logic för val ska vara här:
        }

        static void Buy(string item, int cost, Player p, int valueIncrease = 0)
        {
            if (p.coins >= cost)
            {
                p.coins -= cost;
                Console.WriteLine($"Barnabas Arcanum: You have bought {item} for {cost} gold coins.");

                // Lägg till eller uppdatera föremålet i spelarens inventory
                if (p.inventory.ContainsKey(item))
                {
                    p.inventory[item]++; // Ökar antalet av föremålet om det redan finns
                }
                else
                {
                    p.inventory[item] = 1; // Lägger till ett nytt föremål om det inte fanns tidigare
                }

                // Uppdatera spelarens stats eller antal föremål baserat på vad som köptes
                switch (item)
                {
                    case "Minor Healing Potion":
                    case "Medium Healing Potion":
                    case "Major Healing Potion":
                        Console.WriteLine($"You now have: {p.inventory[item]} {item}.");
                        break;
                    case "Sword":
                    case "Staff":
                    case "Magic Weapon":
                    case "Bow":
                    case "Mace":
                        p.weaponValue += valueIncrease;
                        Console.WriteLine($"Your attack strength has increased by {valueIncrease}.");
                        break;
                    case "Leather Armor":
                    case "Brass Armor":
                    case "Iron Armor":
                    case "Steel Armor":
                    case "Magic Armor":
                        p.armorValue += valueIncrease;
                        Console.WriteLine($"Your defense has increased by {valueIncrease}.");
                        break;
                    default:
                        Console.WriteLine("Barnabas Arcanum: I don't know what happened.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Barnabas Arcanum: Looks like you don't have enough coins, and I don't do discounts.");
            }
            Console.ReadKey(); 
        }

        static void Sell(Player p)
        {
            Console.WriteLine("Barnabas Arcanum: Visa vad du har");

            int index = 1;
            Dictionary<int, string> itemMapping = new Dictionary<int, string>();
            foreach (var item in p.inventory)
            {
                Console.WriteLine($"{index}: {item.Key} x{item.Value}"); 
                itemMapping[index] = item.Key; 
                index++;
            }

            Console.WriteLine("Välj numret på föremålet du vill sälja eller tryck '0' för att avbryta:");
            string sellChoice = Console.ReadLine();
            int itemIndex;
            bool isNumeric = int.TryParse(sellChoice, out itemIndex);

            if (isNumeric && itemIndex > 0 && itemIndex < index)
            {
                string itemName = itemMapping[itemIndex];
                int sellPrice = DetermineSellPrice(itemName);

                if (sellPrice > 0 && p.inventory[itemName] > 0)
                {
                    p.coins += sellPrice;
                    p.inventory[itemName]--;
                    if (p.inventory[itemName] == 0)
                    {
                        p.inventory.Remove(itemName);
                    }
                    Console.WriteLine($"You have sold {itemName} for {sellPrice} gold.");

                    // Minska spelarens attribut baserat på vad som såldes
                    switch (itemName)
                    {
                        case "Sword":
                            
                            p.weaponValue -= 3;
                            Console.WriteLine("You have sold your Sword and lost some attack power.");
                            break;
                        case "Leather Armor":
                            
                            p.armorValue -= 4; 
                            Console.WriteLine("You have sold your Leather Armor and lost some defense.");
                            break;
                            // Lägg till fler case här för andra föremål, eller integrera med eq klass
                    }
                }
                else
                {
                    Console.WriteLine($"You can't sell {itemName}.");
                }
            }
            else if (itemIndex == 0)
            {
                Console.WriteLine("Transaction cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid selection, try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static int DetermineSellPrice(string itemName)
        {
            
            switch (itemName)
            {
                case "Minor Healing Potion": return 10;
                case "Medium Healing Potion": return 25;
                case "Large Healing Potion": return 40;
                case "Sword": return 50;
                case "Leather Armor": return 25;
                default: return 0; // Om föremålet inte känns igen, kan det inte säljas
            }
        }


    }
}