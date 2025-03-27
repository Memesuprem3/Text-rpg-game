using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Utilitys;


namespace Text_rpg_game.classer.Player.Player
{
    [Serializable]
    internal class CreCharacter : CurrentPlayer
    {
        public static CreCharacter Char = new();
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
        {"Human", new List<string>{ "Warrior","Knight", "Rogue", "Wizard", "Ranger", "Paladin", "Priest","Warlock" }},
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
        {"Knight", new string[] {"Knights are of nobel blood, fighting with finnes and honor. They uphold the names of the houses they serve and kingdom they protect." } },
        {"Paladin", new string[] {"Paladins are holy warriors, blessed with divine power that they use to heal and protect, as well as combat evil. Their faith is their shield, and their conviction their weapon."} },
        {"Rogue",   new string[] {"Rogues are shadow walkers, masters of stealth and deception. They are skilled thieves and assassins, always ready to strike from the shadows." } },
        {"Wizard",  new string[] {"Wizards are scholars of the arcane arts, capable of weaving powerful spells that can create and destroy. Their knowledge of magic is unmatched."} },
        {"Ranger",  new string[] {"Rangers are  of ranged and close combat, their arrows never missing their mark. They move with agility and use the terrain to their advantage." } },
        {"Priest",  new string[] {"Priests are spiritual guides with the ability to heal and bless, as well as wield holy magic against the forces of evil." } },
        {"Warlock", new string[] {"DEATH COME FOR YE"} },
        {"Shaman", new string[] {"Earth wind and fire, heed my call"} },
        {"Druid", new string[] {"Elune hear my call"} }
        };

        //karaktär skapas
        public static void CharMenu()
        {
            Console.Clear();
            CenteredWriter.Write("Enter your name:", -4);
            string name = CenteredWriter.CenteredInput();
            Char.Name = name;

            Console.Clear();
            CenteredWriter.Write("Choose your race", -4);
            string selectedRace = CenteredWriter.ShowSelectionMenu(raceDescriptions.Keys.ToArray(), raceDescriptions);
            Char.PlayerRace = (Race)Enum.Parse(typeof(Race), selectedRace, true);

            Console.Clear();
            CenteredWriter.Write("Choose your class", -4);
            string selectedClass = CenteredWriter.ShowSelectionMenu(raceToClassMap[selectedRace].ToArray(), classDescriptions);

            switch (selectedClass.ToLower())
            {
                case "warrior": Char.Warrior(); break;
                case "paladin": Char.Paladin(); break;
                case "rogue": Char.Rogue(); break;
                case "wizard": Char.Wizard(); break;
                case "ranger": Char.Ranger(); break;
                case "priest": Char.Priest(); break;
                case "warlock": Char.Warlock(); break;
                case "shaman": Char.Shaman(); break;
                case "druid": Char.Druid(); break;
                default: Char.Pessant(); break;
            }

            CurrentPlayer.currentPlayer = Char;

            Console.Clear();
            CenteredWriter.Write($"You are a {selectedRace} {selectedClass} named {Char.Name}.", -2);
            Console.ReadKey();
        }

        //klasser flytta till egen klass sen
        public void Warrior()
        {
            SetBaseStats();
            CharacterClass = "Warrior";
            health = 30;
            weaponValue = 3;
            armorValue = 1;

            strength = 3;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 2;
            perception = 2;
            luck = 2;

            spellPow = 5;
            InitializeStartingSkills();

        }
        public void Knight()
        {
            SetBaseStats();
            CharacterClass = "Knight";
            health = 35;
            weaponValue = 2;
            armorValue = 2;

            strength = 2;
            agility = 2;
            stamina = 3;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();

        }
        public void Paladin()
        {
            SetBaseStats();
            CharacterClass = "Paladin";
            health = 36;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Rogue()
        {
            SetBaseStats();
            CharacterClass = "Rogue";
            health = 300;
            weaponValue = 30;
            armorValue = 30;

            strength = 30;
            agility = 20;
            stamina = 20;
            spirit = 30;
            intelligence = 40;
            charisma = 20;
            speed = 10;
            perception = 29;
            luck = 10;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Wizard()
        {
            SetBaseStats();
            CharacterClass = "Wizard";
            health = 25;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Ranger()
        {
            SetBaseStats();
            CharacterClass = "Ranger";
            health = 30;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Priest()
        {
            SetBaseStats();
            CharacterClass = "Preist";
            health = 30;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Pessant()
        {
            SetBaseStats();
            CharacterClass = "Pessant";
            health = 20;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Warlock()
        {
            SetBaseStats();
            CharacterClass = "Warlock";
            health = 25;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Shaman()
        {
            SetBaseStats();
            CharacterClass = "Shaman";
            health = 32;
            weaponValue = 2;
            armorValue = 1;

            strength = 1;
            agility = 2;
            stamina = 2;
            spirit = 6;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }
        public void Druid()
        {
            SetBaseStats();
            CharacterClass = "Druid";
            health = 35;
            weaponValue = 2;
            armorValue = 1;

            strength = 5;
            agility = 3;
            stamina = 5;
            spirit = 3;
            intelligence = 4;
            charisma = 2;
            speed = 1;
            perception = 2;
            luck = 1;

            spellPow = 5;
            InitializeStartingSkills();
        }

        private void InitializeStartingSkills()
        {
            switch (CharacterClass.ToLower())
            {
                case "Knight":
                    Skills.Add(new Skill("Sword", 2));
                    Skills.Add(new Skill("Sheild", 2));
                    break;
                case "warrior":
                    Skills.Add(new Skill("Sword", 2));
                    Skills.Add(new Skill("Axe", 2));
                    break;
                case "paladin":
                    Skills.Add(new Skill("Sword", 1));
                    Skills.Add(new Skill("Magic", 1));
                    break;
                case "rogue":
                    Skills.Add(new Skill("Bow", 14));
                    Skills.Add(new Skill("Dagger", 23));
                    Skills.Add(new Skill("Sword", 11));
                    Skills.Add(new Skill("Magic", 6));
                    
                    break;
                case "ranger":
                    Skills.Add(new Skill("bow", 2));
                    break;
                case "wizard":
                    Skills.Add(new Skill("magic", 3));
                    break;
                case "priest":
                    Skills.Add(new Skill("magic", 2));
                    break;
                case "warlock":
                    Skills.Add(new Skill("magic", 3));
                    break;
                case "shaman":
                    Skills.Add(new Skill("magic", 2));
                    break;
                case "druid":
                    Skills.Add(new Skill("magic", 2));
                    break;
                default:
                    Skills.Add(new Skill("fist", 1));
                    break;
            }
        }

        private void SetBaseStats()
        {
            gold = 30;
            health = 10;
            damage = 3;
            armorValue = 1;
            weaponValue = 1;
            Level = 1;
            XP = 0;
            XPToNextLevel = 100;

            strength = 1;
            agility = 1;
            stamina = 1;
            spirit = 1;
            intelligence = 1;
            charisma = 1;
            speed = 1;
            perception = 1;
            luck = 1;

            armorPen = 0.40;
            attackPow = 1;
            critChans = 0.50;
            hitChans = 1;

            spellPen = 0.50;
            spellPow = 1;
            spellCrit = 0.50;
            spellhit = 1;
        }
    }
}




