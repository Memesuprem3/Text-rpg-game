using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.Beasts
{
    public class Rat : Monster
    {
        public Rat(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Rat> Create)> _variants = new()
        {
            ("Giant Rat", 1, GiantRat),
            ("Sewer Rat", 3, SewerRat),
            ("Plague Rat", 5, PlagueRat),
            ("Rat King", 10, RatKing)
        };

        private static Rat GiantRat()
        {
            return new Rat("Giant Rat", 1, 2, 5);
        }

        private static Rat SewerRat()
        {
            return new Rat("Sewer Rat", 2, 3, 8)
            {
                DisplayColor = ConsoleColor.DarkGray,
                Lore = new MonsterLore
                {
                    Description = "A filthy rat from the depths of the sewers.",
                    Habitat = "Sewers",
                    Origin = "Waste-filled tunnels",
                    Weakness = "Fire",
                    Resistance = "Poison",
                    IsBoss = false
                }
            };
        }

        private static Rat PlagueRat()
        {
            var rat = new Rat("Plague Rat", 4, 5, 12)
            {
                Lore = new MonsterLore
                {
                    Description = "Carries a vile disease. Avoid its bite!",
                    Habitat = "Dark sewers",
                    Origin = "Filth and rot",
                    Weakness = "Fire",
                    Resistance = "Poison",
                    IsBoss = false
                },
                DisplayColor = ConsoleColor.DarkYellow
            };

            rat.Abillities.Add(new MonsterAbility("Infectious Bite", (monster, player) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{monster.Name} bites with diseased fangs!");
                Console.ResetColor();
                player.health -= monster.Power;
            }));

            return rat;
        }

        private static Rat RatKing()
        {
            var king = new Rat("Rat King", 7, 10, 40)
            {
                Level = 10,
                GoldDrop = 80,
                DisplayColor = ConsoleColor.DarkGray,
                Lore = new MonsterLore
                {
                    Description = "A horrific mass of rats fused into a single mind.",
                    Habitat = "Cursed catacombs",
                    Origin = "Dark sorcery",
                    Weakness = "Light",
                    Resistance = "Dark",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanTalk = false
                }
            };

            king.Abillities.Add(new MonsterAbility("Swarm Attack", (monster, player) =>
            {
                Console.WriteLine($"{monster.Name} commands a swarm of rats!");
                player.health -= monster.Power + 2;
            }));

            return king;
        }

        public static Rat CreateRat(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Rat("Mysterious Rat", 1, 2, 5);
        }

        public static Rat CreateRandomRat(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return new Rat("Tiny Rat", 1, 1, 2);

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
