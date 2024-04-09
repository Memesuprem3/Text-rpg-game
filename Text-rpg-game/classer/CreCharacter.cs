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
        public static CreCharacter Char = new CreCharacter(); 
        //info om varje ras
        private static Dictionary<string, string> raceDescriptions = new Dictionary<string, string>
        {
        {"Human", "Versatile and ambitious, +1 to all attributes"},
        {"Dwarf", "Stout and sturdy, +2 Strength, finds more gold"},
        {"Elf",   "Proud and Noble Race, with Ancient wisdome, + 1 Agility and intelect" },
        {"Gnome", "Young and currious race, good at tinkering, +2 to interlect" },
        {"Undead","Rissen Against Their will, some become mindless zombies and others \n remberers their past life + 1 to all skills"},
        {"Orc", "Battle sturdy and proud race, steeped in tradition and Honor, 2+ to strength and Spirit" }
        };
        //raser + vilka klasser som olika race kan vara.
        private static Dictionary<string, List<string>> raceToClassMap = new Dictionary<string, List<string>>
        {
        {"Human", new List<string>{ "Knight", "Rogue", "Wizard", "Archer", "Paladin", "Priest" }},
        {"Dwarf", new List<string>{ "Knight", "Rogue", "Archer", "Priest" }},
        {"Elf", new List<string>{ "Wizard", "Archer", "Rogue", "Priest" }},
        {"Gnome", new List<string>{ "Wizard", "Rogue" }},
        {"Undead", new List<string>{ "Rogue", "Wizard" }},
        {"Orc", new List<string>{ "Knight", "Rogue", "Archer" }}
        };
        //info om klasser
        private static Dictionary<string, string> classDescriptions = new Dictionary<string, string>
        {
        {"Knight", "Brave warriors with high defense"},
        {"Paladin", "Holy warriors with healing abilities"},
        {"Rogue", "Stealthy characters with high damage"},
        {"Wizard", "Masters of magic with powerful spells"},
        {"Archer", "Ranged attackers with high accuracy"},
        {"Priest", "Healer and defender of the light" },
        {"Pessant", "Common folks with no particular strength"}
        };
        public static void CharMenu()
        {
            Console.Clear();
            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();
            currentPlayer.Name = name;

            // Välj ras med dynamisk beskrivning
            string selectedRace = ChooseWithDescription(raceDescriptions, "race");
            currentPlayer.PlayerRace = (Race)Enum.Parse(typeof(Race), selectedRace, true);

            // Välj klass baserat på ras med dynamisk beskrivning
            string selectedClass = ChooseClassWithDescription(selectedRace);

            Console.WriteLine($"You are a {selectedRace} {selectedClass} named {currentPlayer.Name}.");
        }
        private static void WriteCentered(string text, int y)
        {
            int centerX = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(centerX, y);
            Console.WriteLine(text);
        }

        private static string ChooseWithDescription(Dictionary<string, string> options, string choosingFor)
        {
            int selectedIndex = 0;
            List<string> keys = options.Keys.ToList();
            int startY = 25; 
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(); 

                for (int i = 0; i < keys.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        WriteCentered($"> {keys[i]}", startY + i);
                    }
                    else
                    {
                        WriteCentered($"  {keys[i]}", startY + i);
                    }
                }

                // Dynamisk beskrivning visas under menyn
                int descriptionStartY = startY + keys.Count + 2; 
                string description = options[keys[selectedIndex]];
                WriteCentered(description, descriptionStartY);

                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + keys.Count) % keys.Count;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % keys.Count;
                }

            } while (key != ConsoleKey.Enter);

            return keys[selectedIndex];
        }

        private static string ChooseClassWithDescription(string selectedRace)
        {
            // här skapas en lista över tillgängliga klasser baserat på den valda rasen
            List<string> availableClasses = raceToClassMap[selectedRace];
            Dictionary<string, string> classOptions = availableClasses.ToDictionary(c => c, c => classDescriptions[c]);

            return ChooseWithDescription(classOptions, "class");
        }

     
        //skapas klassen
        public void MakeKnight()
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
            inteligens = 3;
            spellPow = 5;
        }
        public void MakeArcher()
        {
            CharacterClass = "Archer";
            health = 15;
            weaponValue = 6;
            armorValue = 3;
            agility = 10;
        }
        public void MakePriest()
        {
            CharacterClass = "Preist";
            health = 13;
            weaponValue = 1;
            armorValue = 1;
            inteligens = 2;
            spirit = 4;
            spellPow = 4;
        }
        public void MakePessant()
        {
            CharacterClass = "Pessant";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }
    }


}



