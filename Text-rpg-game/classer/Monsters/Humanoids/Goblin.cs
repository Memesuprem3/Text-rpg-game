using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters.AI;

namespace Text_rpg_game.classer.Monsters.Humanoids
{
    public class Goblin : Monster
    {
        public Goblin(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Goblin> Create)> _variants = new()
        {
            ("Goblin", 1, BasicGoblin),
            ("Goblin Thief", 3, GoblinThief),
            ("Goblin Shaman", 5, GoblinShaman),
            ("Goblin King", 15, GoblinKing)
        };

        private static Goblin BasicGoblin()
        {
            return new Goblin("Goblin", 2, 3, 10);
        }

        private static Goblin GoblinThief()
        {
            var goblin = new Goblin("Goblin Thief", 3, 4, 15)
            {
                Level = 3,
                GoldDrop = 19,
                DisplayColor = ConsoleColor.Green,
                Lore = new MonsterLore
                {
                    Description = "A sneaky goblin that steals from adventurers.",
                    Habitat = "Dark forests",
                    Origin = "Nomadic clans",
                    Weakness = "Piercing",
                    Resistance = "Poison",
                    IsBoss = false
                }
            };

            goblin.Abillities.Add(new MonsterAbility("Steal Gold", (monster, player) =>
            {
                int stolen = 5;
                Console.WriteLine($"{monster.Name} steals {stolen} gold!");
                player.gold -= stolen;
            }));

            return goblin;
        }

        private static Goblin GoblinShaman()
        {
            var goblin = new Goblin("Goblin Shaman", 4, 6, 25)
            {
                Level = 5,
                GoldDrop = 30,
                DisplayColor = ConsoleColor.DarkCyan,
                Lore = new MonsterLore
                {
                    Description = "A goblin who dabbles in wild magic.",
                    Habitat = "Swamp huts",
                    Origin = "Magical misfires",
                    Weakness = "Fire",
                    Resistance = "Magic",
                    IsBoss = false
                }
            };

            goblin.Abillities.Add(new MonsterAbility("Wild Hex", (monster, player) =>
            {
                Console.WriteLine($"{monster.Name} casts a chaotic hex!");
                player.health -= monster.Power;
            }));

            return goblin;
        }

        private static Goblin GoblinKing()
        {
            var king = new Goblin("Goblin King", 8, 12, 60)
            {
                Level = 15,
                GoldDrop = 120,
                DisplayColor = ConsoleColor.DarkYellow,
                Lore = new MonsterLore
                {
                    Description = "The self-proclaimed ruler of all goblins.",
                    Habitat = "Underground throne rooms",
                    Origin = "Royal goblin bloodlines",
                    Weakness = "Holy",
                    Resistance = "Physical",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanTalk = true,
                    DialogueLine = "Bow before the Goblin King!"
                }
            };

            king.Abillities.Add(new MonsterAbility("Royal Command", (monster, player) =>
            {
                Console.WriteLine($"{monster.Name} roars orders, becoming stronger!");
                monster.Power += 2;
            }));

            return king;
        }

        public static Goblin CreateGoblin(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Goblin("Unknown Goblin", 2, 3, 5);
        }

        public static Goblin CreateRandomGoblin(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return new Goblin("Young Goblin", 1, 2, 5);

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
