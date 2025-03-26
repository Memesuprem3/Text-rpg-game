using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.Humanoids
{
    public class Human : Monster
    {
        public Human(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Human> Create)> _variants = new()
        {
            ("Bandit", 1, Bandit),
            ("Mercenary", 8, Mercenary),
            ("Dark Knight", 15, DarkKnight)
        };

        private static Human Bandit()
        {
            var bandit = new Human("Bandit", 3, 20, 50)
            {
                Name = "Bandit",
                Level = 4,
                Health = 20,
                XPValue = 50,
                GoldDrop = RandomGold(3,19),

                Power = 3,
                Defense = 3,
                Speed = 7,
                CriticalChance = 7,
                Evasion = 7,

                DisplayColor = ConsoleColor.Green,
                Lore = new MonsterLore
                {
                    Description = "Vagabond who steals and murders to get by",
                    Habitat = "Everywhere",
                    Origin = "Gangs, towns",
                    Weakness = "Blunt,precing, Law",
                    Resistance = "Smooth Talk",
                    IsBoss = false,
                },
            };

            return bandit;
        }

        private static Human Mercenary()
        {
            var merc = new Human("Mercenary", 7, 50, 35)
            {
                Level = 8,
                GoldDrop = 30,
                DisplayColor = ConsoleColor.DarkBlue,
                Lore = new MonsterLore
                {
                    Description = "A hired sword with no loyalty.",
                    Habitat = "Roads & forts",
                    Origin = "War zones",
                    Weakness = "Bribery",
                    Resistance = "None",
                    IsBoss = false
                },
            };

            merc.Abillities.Add(new MonsterAbility("Heavy Slash", (m, p) =>
            {
                Console.WriteLine($"{m.Name} swings a heavy blade!");
                p.health -= m.Power + 2;
            }));

            return merc;
        }

        private static Human DarkKnight()
        {
            var Dknight = new Human("Dark Knight", 14, 16, 85)
            {
                Level = 40,
                GoldDrop = RandomGold(90,120),
                DisplayColor = ConsoleColor.DarkMagenta,
                Lore = new MonsterLore
                {
                    Description = "A cursed knight wielding forbidden power.",
                    Habitat = "Ruined castles",
                    Origin = "Broken oaths",
                    Weakness = "Holy",
                    Resistance = "Dark",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanTalk = true,
                    DialogueLine = "I serve the darkness."
                }
            };

            Dknight.Abillities.Add(new MonsterAbility("Shadow Pierce", (m, p) =>
            {
                Console.WriteLine($"{m.Name} strikes with a blade of shadows!");
                p.health -= m.Power + 3;
            }));

            return Dknight;
        }

        public static Human CreateHuman(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Human("Peasant", 1, 2, 5);
        }

        public static Human CreateRandomHuman(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return Bandit();

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
