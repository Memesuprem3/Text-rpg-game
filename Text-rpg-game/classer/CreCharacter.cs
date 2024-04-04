using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer
{
    [Serializable]
    internal class CreCharacter : Player
    {

        

        public void MakeKnight(Player player)
        {
            CharacterClass = "Knight";
            health = 25; 
            weaponValue = 5; 
            armorValue = 5;
                            
        }
        public void MakePaladin()
        {
            CharacterClass = "Paladin";
            health = 20;
            weaponValue = 7;
            armorValue = 5;
        }

        public void MakeRogue()
        {
            CharacterClass = "Rogue";
            health = 15; 
            weaponValue = 4; 
            agility = 7; 
                         
        }
        public void MakeWizard()
        {
            CharacterClass = "Wizard";
            health = 12; 
            weaponValue = 8; 
            armorValue = 2; 
                            
        }

        public void MakeArcher()
        {
            CharacterClass = "Archer";
            health = 15; 
            weaponValue = 6;
            armorValue = 3;
            agility = 10; 
                          
        }
        public void MakePessant()
        {
            CharacterClass = "Pessant";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }

       
        public static void CharMenu()
        {
            Console.Clear();
            Console.WriteLine("Chose your profession:");
            Console.WriteLine("1. Knight");
            Console.WriteLine("2. Rogue");
            Console.WriteLine("3. Wizard");
            Console.WriteLine("4. Archer");
            Console.WriteLine("5. Peessant");
            Console.WriteLine("6. Paladin");
            Console.Write("Gör ditt val (1-6: ");

            CreCharacter playerCharacter = new CreCharacter();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    playerCharacter.MakeKnight(currentPlayer);
                    break;
                case "2":
                    playerCharacter.MakeRogue();
                    break;
                case "3":
                    playerCharacter.MakeWizard();
                    break;
                case "4":
                    playerCharacter.MakeArcher();
                    break;
                case "5":
                        playerCharacter.MakePessant();
                    break;
                    case "6":
                        playerCharacter.MakePaladin();
                    break;
                default:
                    Console.WriteLine("You will be made a Pessant.");
                    playerCharacter.MakePessant();
                    break;
            }

            Console.WriteLine($"You are a: {playerCharacter.CharacterClass} With {playerCharacter.health} HP, {playerCharacter.damage} Damge and {playerCharacter.agility} Agility.");

        } 
    }

}

