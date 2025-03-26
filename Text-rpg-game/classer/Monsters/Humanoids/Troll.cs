using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.Humanoids
{
    public class Troll : Monster
    {
        public Troll(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Troll> Create)> _variants = new()
        {
            ("Cave Troll", 5, CreateCaveTroll),
            ("Forest Troll", 10, CreateForestTroll),
            ("Troll King", 20, CreateTrollKing)
        };

        private static Troll CreateCaveTroll()
        {
            return new Troll("Cave Troll", 8, 14, 40);
        }

        private static Troll CreateForestTroll()
        {
            var troll = new Troll("Forest Troll", 10, 18, 60)
            {
                DisplayColor = ConsoleColor.DarkGreen,
                Lore = new MonsterLore
                {
                    Description = "A hulking beast that dwells in deep woods.",
                    Habitat = "Forests",
                    Origin = "Ancient troll tribes",
                    Weakness = "Fire",
                    Resistance = "Earth",
                    IsBoss = false
                }
            };

            troll.Abillities.Add(new MonsterAbility("Club Smash", (m, p) =>
            {
                Console.WriteLine($"{m.Name} smashes the ground violently!");
                p.health -= m.Power + 3;
            }));

            return troll;
        }

        private static Troll CreateTrollKing()
        {
            var king = new Troll("Troll King", 16, 25, 100)
            {
                Level = 20,
                GoldDrop = 300,
                DisplayColor = ConsoleColor.Gray,
                Lore = new MonsterLore
                {
                    Description = "The mighty king of trolls.",
                    Habitat = "Mountain thrones",
                    Origin = "Troll royalty",
                    Weakness = "Lightning",
                    Resistance = "Physical",
                    IsBoss = true
                }
            };

            king.Abillities.Add(new MonsterAbility("Regenerate", (m, p) =>
            {
                Console.WriteLine($"{m.Name} regenerates!");
                m.Health += 10;
                if (m.Health > m.MaxHealth) m.Health = m.MaxHealth;
            }));

            return king;
        }

        public static Troll CreateTroll(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Troll("Unknown Troll", 4, 6, 15);
        }

        public static Troll CreateRandomTroll(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return CreateCaveTroll();

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
