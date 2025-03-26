using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Player.Player
{
    [Serializable]
    internal class CreCharacter : CurrentPlayer
    {
        public static CreCharacter Char = new CreCharacter();
        //info om varje ras
        private static Dictionary<string, string[]> raceDescriptions = new Dictionary<string, string[]>
{
    {
            "Human",
            new string[]
            {
                "Valorwind",
                "",
                "Valorwind stands as a beacon of hope and resilience, nestled at the confluence of peaceful rivers and lush, green valleys.",
                "Surrounded by high stone walls, its inhabitants are renowned for their hospitality and their ability to overcome any adversity.",
                "Here, where human will meets true valor, trade, arts, and science flourish, making the city a kaleidoscope of opportunities and adventures."
            }
    },
            {
                "Dwarf",
                new string[]
                {
                    "Stonedeep",
                    "",
                    "Hidden beneath snow-capped peaks, Stonedeep is an underground marvel, carved out of the heart of mountains.",
                    " Its halls are illuminated by glowing forge fires and shimmering crystals, with the echo of hammer strikes",
                    " telling tales of dwarves tireless pursuit of craftsmanship and precious metals. The city is a fortress of ",
                    "strength and endurance, where ancient traditions and dwarven kinship are held sacred."
                }
            },
             {
                "Elf",
                new string[]
                {
                    "Silverleaf",
                    "",
                    "Located in an enchanted forest where tree canopies reach towards the sky and sunbeams play with evergreen leaves,",
                    " Silverleaf mirrors the elves' graceful essence. The architecture is both organic and elegant,",
                    " with homes and buildings blending seamlessly with nature. The city is a center for magic, wisdom, and harmony,",
                    " with its inhabitants striving to maintain the balance between the natural and the supernatural."
                }
             },
              {
                "Gnome",
                new string[]
                {
                    "Tinkertown",
                    "",
                    "In a maze of steaming machinery and ingenious inventions, Tinkertown stands as the heart of gnomes' boundless creativity",
                    "Situated in an enchanted valley, the city is filled with workshops where sparks fly and magic meets mechanics",
                    "Here, among inventive geniuses and eccentric scientists, the future has already arrived, and nothing is considered impossible.",

                }
              },
               {
                    "Undead",
                    new string[]
                    {
                        "Necropilis",
                        "",
                        "Necropolis is a city that rests on the boundary between the living and the dead, shrouded in a veil of mystery.",
                        "Here, where time seems to stand still, the undead wander among gothic ruins and withering gardens.",
                        "Despite its somber mood, the city is a hub for ancient knowledge and forbidden magic,",
                        "protected by its inhabitants' unique understanding of death and what lies beyond."
                    }
               },
                {
                    "Orc",
                    new string[]
                    {
                        "IronFist",
                        "",
                        "Ironfist is a city built on the glory of wars and battles, where mighty fortresses rise above the rugged landscape.",
                        "Its inhabitants, proud warriors born for combat, are unrivaled in their craft of weapons and armor.",
                        "The city thrums with strength and power, its forges and training grounds",
                        "always bustling with orcs preparing for the next challenge or conquest."
                    }
                },
                 {
                    "Troll",
                    new string[]
                    {
                        "Mudgulch",
                        "",
                        "Mudgulch is a primitive yet surprisingly vibrant city, hidden in a foggy swamp where stout trees stand as sentinels.",
                        "True to their nature, trolls have constructed their city with what the wilderness offers,resulting in a messy",
                        "but functional amalgamation of huts and wooden platforms.The city is a haven for those seeking ",
                        "to live simply, away from civilization's demands, surrounded by the unadorned beauty of nature."
                    }
                 },
        };


        //raser + vilka klasser som olika race kan vara.
        private static Dictionary<string, List<string>> raceToClassMap = new Dictionary<string, List<string>>
        {
        {"Human", new List<string>{ "Warrior", "Rogue", "Wizard", "Ranger", "Paladin", "Priest","Warlock" }},
        {"Dwarf", new List<string>{ "Warrior", "Rogue", "Ranger", "Priest" }},
        {"Elf", new List<string>{ "Wizard", "Ranger", "Rogue", "Priest","Druid" }},
        {"Gnome", new List<string>{ "Wizard", "Rogue" }},
        {"Undead", new List<string>{ "Warrior","Ranger", "Rogue", "Wizard","Warlock" }},
        {"Orc", new List<string>{ "Warrior", "Rogue", "Ranger","Shaman","Warlock" }},
        {"Troll", new List<string>{ "Warrior", "Rogue", "Ranger", "Shaman","Warlock" }}
        };
        //info om klasser
        private static Dictionary<string, string[]> classDescriptions = new Dictionary<string, string[]>
        {
        {"Warrior", new string[] {"Warriors are masters of combat, equipped with strength and skill in wielding various weapons.They are brave defenders and relentless attackers, fighting with honor and courage." } },
        {"Paladin", new string[] {"Paladins are holy warriors, blessed with divine power that they use to heal and protect, as well as combat evil. Their faith is their shield, and their conviction their weapon."} },
        {"Rogue",   new string[] {"Rogues are shadow walkers, masters of stealth and deception. They are skilled thieves and assassins, always ready to strike from the shadows." } },
        {"Wizard",  new string[] {"Wizards are scholars of the arcane arts, capable of weaving powerful spells that can create and destroy. Their knowledge of magic is unmatched."} },
        {"Ranger",  new string[] {"Rangers are  of ranged and close combat, their arrows never missing their mark. They move with agility and use the terrain to their advantage." } },
        {"Priest",  new string[] {"Priests are spiritual guides with the ability to heal and bless, as well as wield holy magic against the forces of evil." } },
        {"Warlock", new string[] {"DEATH COME FOR YE"} },
        {"Shaman", new string[] {"Earth wind and fire, heed my call"} },
        {"Druid", new string[] {"Elune hear my call"} }
        };
        public static void CharMenu()
        {
            Console.Clear();
            string name = WriteCenteredPrompt("Enter your name: ");
            currentPlayer.Name = name;

            // Välj ras med dynamisk beskrivning
            Console.Clear();
            WriteCentered(new string[] { " Choose your race" }, Console.WindowHeight / 2 - raceDescriptions.Count / 2 - 2);
            string selectedRace = ChooseWithDescription(raceDescriptions, "race");
            currentPlayer.PlayerRace = (Race)Enum.Parse(typeof(Race), selectedRace, true);

            // Välj klass baserat på ras med dynamisk beskrivning
            Console.Clear();
            WriteCentered(new string[] { "Choose your class" }, Console.WindowHeight / 2 - raceToClassMap[selectedRace].Count / 2 - 2);
            string selectedClass = ChooseClassWithDescription(selectedRace);

            Console.WriteLine($"You are a {selectedRace} {selectedClass} named {currentPlayer.Name}.");
        }
        private static void WriteCentered(string[] textLines, int startY)
        {
            foreach (string line in textLines)
            {
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, startY++);
                Console.WriteLine(line);
            }
        }
        private static string ChooseWithDescription(Dictionary<string, string[]> options, string choosingFor)
        {
            int selectedIndex = 0;
            List<string> keys = options.Keys.ToList();
            int menuStartY = 25; // Startposition för menyn på skärmen.

            ConsoleKey key;
            do
            {
                Console.Clear();
                //Console.WriteLine($"\nChoose your {choosingFor}:\n");


                for (int i = 0; i < keys.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Highlighta det valda alternativet.
                        WriteCentered(new string[] { $"> {keys[i]}" }, menuStartY + i);
                        Console.ResetColor();
                    }
                    else
                    {
                        WriteCentered(new string[] { $"  {keys[i]}" }, menuStartY + i);
                    }
                }


                int descriptionStartY = menuStartY + keys.Count + 2;
                WriteCentered(options[keys[selectedIndex]], descriptionStartY);

                key = Console.ReadKey(true).Key;


                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : keys.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = selectedIndex < keys.Count - 1 ? selectedIndex + 1 : 0;
                }

            } while (key != ConsoleKey.Enter);

            return keys[selectedIndex];
        }

        //fick lite hjälp av gpt
        private static string ChooseClassWithDescription(string selectedRace)
        {
            // Skapa en lista över tillgängliga klasser baserat på den valda rasen
            List<string> availableClasses = raceToClassMap[selectedRace];

            // Använd availableClasses för att skapa ett dictionary med klassnamn som nycklar och beskrivningar (som string-arrays) som värden
            Dictionary<string, string[]> classOptions = availableClasses
                .Where(c => classDescriptions.ContainsKey(c))
                .ToDictionary(c => c, c => classDescriptions[c]);


            return ChooseWithDescription(classOptions, "class");
        }

        public static string WriteCenteredPrompt(string prompt)
        {
            Console.Clear();
            int centerX = (Console.WindowWidth - prompt.Length) / 2;
            int centerY = Console.WindowHeight / 2;
            Console.SetCursorPosition(centerX, centerY - 1);
            Console.WriteLine(prompt);

            Console.SetCursorPosition(centerX + 3, centerY + 1);
            return Console.ReadLine();
        }


        //skapas klassen
        public void Knight()
        {
            CharacterClass = "Warrior";
            health = 25;
            weaponValue = 5;
            armorValue = 5;
        }
        public void Paladin()
        {
            CharacterClass = "Paladin";
            health = 20;
            weaponValue = 7;
            armorValue = 5;
        }
        public void Rogue()
        {
            CharacterClass = "Rogue";
            health = 15;
            weaponValue = 4;
            agility = 7;
        }
        public void Wizard()
        {
            CharacterClass = "Wizard";
            health = 12;
            weaponValue = 8;
            armorValue = 2;
            intelligence = 3;
            spellPow = 5;
        }
        public void Ranger()
        {
            CharacterClass = "Ranger";
            health = 15;
            weaponValue = 6;
            armorValue = 3;
            agility = 10;
        }
        public void Priest()
        {
            CharacterClass = "Preist";
            health = 13;
            weaponValue = 1;
            armorValue = 1;
            intelligence = 2;
            spirit = 4;
            spellPow = 4;
        }
        public void Pessant()
        {
            CharacterClass = "Pessant";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }
        public void Warlock()
        {
            CharacterClass = "Warlock";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }
        public void Shaman()
        {
            CharacterClass = "Shaman";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }
        public void Druid()
        {
            CharacterClass = "Druid";
            health = 10;
            weaponValue = 2;
            armorValue = 1;
        }
    }


}



