using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.Monsters.Humanoids
{
    public class Orc : Monster
    {
        public Orc(string name, int power, int health, int xpValue) : base(name, power, health, xpValue) { }

        private static readonly List<(string Name, int LevelRequirement, Func<Orc> Create)> _variants = new()
        {
            ("Orc Grunt", 1, () => new Orc("Orc Grunt", 3, 5, 15)),
            ("Orc Warrior", 5, () => new Orc("Orc Warrior", 6, 8, 35)),
            ("Orc Berserker", 10, () =>
            {
                var berserker = new Orc("Orc Berserker", 10, 12, 60)
                {
                    GoldDrop = 80,
                    DisplayColor = ConsoleColor.DarkRed,
                    Lore = new MonsterLore
                    {
                        Description = "A furious orc blinded by rage.",
                        Habitat = "Mountain Caves",
                        Origin = "Orcish war clans",
                        Weakness = "Cold",
                        Resistance = "Fire",
                        IsBoss = false
                    }
                };

                berserker.Abillities.Add(new MonsterAbility("Rage Smash", (monster, player) =>
                {
                    int damage = monster.Power + 3;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{monster.Name} enters a rage and deals {damage} damage!");
                    Console.ResetColor();
                    player.health -= damage;
                }));

                return berserker;
            }),
            ("Orc Chieftain", 20, () =>
            {
                var chieftain = new Orc("Orc Chieftain", 14, 18, 100)
                {
                    Level = 20,
                    GoldDrop = 200,
                    DisplayColor = ConsoleColor.DarkGreen,
                    Lore = new MonsterLore
                    {
                        Description = "The mighty leader of an orc tribe.",
                        Habitat = "Fortified camps",
                        Origin = "Ancestral orcish bloodlines",
                        Weakness = "Lightning",
                        Resistance = "Poison",
                        IsBoss = true
                    },
                    AI = new MonsterAI
                    {
                        BehaviorType = "aggressive",
                        CanFlee = false,
                        CanTalk = true,
                        DialogueLine = "You shall kneel before the chieftain!"
                    }
                };

                chieftain.Abillities.Add(new MonsterAbility("War Cry", (monster, player) =>
                {
                    Console.WriteLine($"{monster.Name} lets out a war cry, boosting its strength!");
                    monster.Power += 2;
                }));

                return chieftain;
            })
        };

        public static Orc CreateOrc(string name)
        {
            var match = _variants.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match.Create?.Invoke() ?? new Orc("Unknown Orc", 2, 3, 5);
        }

        public static Orc CreateRandomOrc(int playerLevel)
        {
            var valid = _variants.Where(v => playerLevel >= v.LevelRequirement).ToList();
            if (!valid.Any()) return new Orc("Young Orc", 2, 3, 5);

            Random rand = new Random();
            return valid[rand.Next(valid.Count)].Create();
        }
    }
}
