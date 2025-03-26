using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.Undead
{
    public class Vampire : Monster
    {
        public Vampire(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Vampire> Create)> _variants = new()
        {
            ("Vampire Thrall", 1, CreateThrall),
            ("Vampire Noble", 10, CreateNoble),
            ("Vampire Lord", 20, CreateLord)
        };

        private static Vampire CreateThrall()
        {
            return new Vampire("Vampire Thrall", 3, 5, 15);
        }

        private static Vampire CreateNoble()
        {
            var vamp = new Vampire("Vampire Noble", 7, 10, 40)
            {
                Level = 10,
                GoldDrop = 125,
                DisplayColor = ConsoleColor.DarkRed,
                Lore = new MonsterLore
                {
                    Description = "A refined predator with a taste for blood.",
                    Habitat = "Ancient castles",
                    Origin = "Cursed lineage",
                    Weakness = "Sunlight",
                    Resistance = "Dark",
                    IsBoss = false
                }
            };

            vamp.Abillities.Add(new MonsterAbility("Blood Drain", (m, p) =>
            {
                Console.WriteLine($"{m.Name} drains blood and heals!");
                int dmg = m.Power;
                p.health -= dmg;
                m.Health += dmg / 2;
            }));

            return vamp;
        }

        private static Vampire CreateLord()
        {
            var lord = new Vampire("Vampire Lord", 12, 18, 90)
            {
                Level = 20,
                GoldDrop = 250,
                DisplayColor = ConsoleColor.Magenta,
                Lore = new MonsterLore
                {
                    Description = "Master of darkness and immortal ruler.",
                    Habitat = "Blood cathedrals",
                    Origin = "First of his kind",
                    Weakness = "Holy",
                    Resistance = "All magic",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanTalk = true,
                    DialogueLine = "You cannot kill what is already dead."
                }
            };

            lord.Abillities.Add(new MonsterAbility("Vampiric Mist", (m, p) =>
            {
                Console.WriteLine($"{m.Name} vanishes into mist and avoids the next attack!");
                m.Evasion += 20;
            }));

            return lord;
        }

        public static Vampire CreateVampire(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Vampire("Unknown Vampire", 2, 4, 10);
        }

        public static Vampire CreateRandomVampire(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return CreateThrall();

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
