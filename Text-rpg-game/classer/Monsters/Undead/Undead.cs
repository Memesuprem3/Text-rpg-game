using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters.AI;

namespace Text_rpg_game.classer.Monsters.Undead
{
    public class Undead : Monster
    {
        public Undead(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Undead> Create)> _variants = new()
        {
            ("Wandering Corpse", 1, CreateCorpse),
            ("Ghoul", 5, CreateGhoul),
            ("Lich", 15, CreateLich)
        };

        private static Undead CreateCorpse() =>
            new Undead("Wandering Corpse", 2, 3, 8);

        private static Undead CreateGhoul()
        {
            var ghoul = new Undead("Ghoul", 6, 9, 30)
            {
                Lore = new MonsterLore
                {
                    Description = "A corpse that feeds on the living.",
                    Habitat = "Graveyards",
                    Origin = "Foul rituals",
                    Weakness = "Holy",
                    Resistance = "Dark",
                    IsBoss = false
                },
                DisplayColor = ConsoleColor.DarkGray
            };

            ghoul.Abillities.Add(new MonsterAbility("Gnaw", (m, p) =>
            {
                Console.WriteLine($"{m.Name} gnaws hungrily!");
                p.health -= m.Power;
            }));

            return ghoul;
        }

        private static Undead CreateLich()
        {
            var lich = new Undead("Lich", 12, 14, 100)
            {
                Level = 15,
                GoldDrop = 250,
                DisplayColor = ConsoleColor.Cyan,
                Lore = new MonsterLore
                {
                    Description = "An undead sorcerer bound to this world.",
                    Habitat = "Forgotten towers",
                    Origin = "Forbidden magic",
                    Weakness = "Radiant",
                    Resistance = "Magic",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanTalk = true,
                    DialogueLine = "You will rot where you stand."
                }
            };

            lich.Abillities.Add(new MonsterAbility("Soul Burn", (m, p) =>
            {
                Console.WriteLine($"{m.Name} burns your soul!");
                p.health -= m.Power + 4;
            }));

            return lich;
        }

        public static Undead CreateUndead(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Undead("Unknown Undead", 2, 3, 8);
        }

        public static Undead CreateRandomUndead(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return CreateCorpse();

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
