using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters.AI;

namespace Text_rpg_game.classer.Monsters.Undead
{
    public class Skeleton : Monster
    {
        public int LevelRequirement { get; set; }

        public Skeleton(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int Level, Func<Skeleton> Create)> _variants = new()
        {
        ("Skeleton", 1, () => new Skeleton("Skeleton", 2, 3, 10)),
        ("Skeleton Warrior", 10, () => new Skeleton("Skeleton Warrior", 5, 6, 50)),
        ("Skeleton Archer", 10, () => new Skeleton("Skeleton Archer", 5, 9, 55)),
        ("Deamon Skeleton", 20, () => CreateDeamonSkeleton())
        };

        private static Skeleton CreateDeamonSkeleton()
        {
            var s = new Skeleton("Deamon Skeleton", 15, 60, 150)
            {
                Level = 20,
                MaxHealth = 60,
                GoldDrop = 320,
                DisplayColor = ConsoleColor.DarkMagenta,
                Lore = new MonsterLore
                {
                    Description = "A forbidden fusion of bone and hellfire.",
                    Habitat = "Hellish crypts",
                    Origin = "Dark rituals of necromancers",
                    Weakness = "Holy",
                    Resistance = "Fire",
                    IsBoss = true
                },
                AI = new MonsterAI
                {
                    BehaviorType = "aggressive",
                    CanFlee = false,
                    CanTalk = true,
                    DialogueLine = "You will burn with the rest of them!"
                }
            };

            s.Abillities.Add(new MonsterAbility("Hellfire Slash", (monster, player) =>
            {
                int damage = monster.Power + 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{monster.Name} uses HELLFIRE SLASH and deals {damage} damage!");
                Console.ResetColor();
                player.health -= damage;
            }));

            s.Abillities.Add(new MonsterAbility("Bone Shield", (monster, player) =>
            {
                Console.WriteLine($"{monster.Name} raises a wall of bones to block attacks. Its defense increases!");
                monster.Defense += 5;
            }));

            return s;
        }

        public static Skeleton CreateSkeleton(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Skeleton("Unnamed Skeleton", 1, 2, 5);
        }

        public static Skeleton CreateRandomSkeleton(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.Level).ToList();
            if (valid.Count == 0) return new Skeleton("Old Bones", 1, 2, 5);

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}

