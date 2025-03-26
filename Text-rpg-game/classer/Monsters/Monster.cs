using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Monsters.Beasts;
using Text_rpg_game.classer.Monsters.Humanoids;
using Text_rpg_game.classer.Monsters.Undead;
using Text_rpg_game.classer.Player;
using Text_rpg_game.classer.Player.Player;
using Text_rpg_game.classer.Shops;

namespace Text_rpg_game.classer.Monsters
{
    public class Monster
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int XPValue { get; set; }
        public int Level { get; set; }
        public int GoldDrop { get; set; }

        public int Defense { get; set; }
        public int Speed { get; set; }
        public int CriticalChance { get; set; }
        public int Evasion { get; set; }

        public MonsterAI AI { get; set; } = new MonsterAI();
        public MonsterLore Lore { get; set; } = new MonsterLore();

        public string AsciiArt { get; set; }
        public ConsoleColor DisplayColor { get; set; } = ConsoleColor.Gray;

        public List<Equipment> LootTable { get; set; } = new List<Equipment>();
        public List<MonsterAbility> Abillities { get; set; } = new List<MonsterAbility>();

        public Monster(string name, int power, int health, int xpValue)
        {
            Name = name;
            Power = power;
            Health = health;
            MaxHealth = health;
            XPValue = xpValue;
            Level = 1;
        }

        public static int RandomGold(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        public void AddLoot(Equipment equipment)
        {
            LootTable.Add(equipment);
        }

        public List<Equipment> Defeat()
        {
            Console.WriteLine($"{Name} Defeated!");
            return LootTable;
        }

        public void Defeated(CurrentPlayer player)
        {
            Console.WriteLine($"{Name} besegrad!");
            player.AddXP(XPValue);
        }

        public void UseRandomAbility(CurrentPlayer player)
        {
            if (Abillities.Count > 0)
            {
                Random rand = new Random();
                MonsterAbility ability = Abillities[rand.Next(Abillities.Count)];
                Console.WriteLine($"{Name} uses {ability.Name}!");
                //ability.Effect(this, player);
            }
            else
            {
                Console.WriteLine($"{Name} uses Auto-Attack");
            }
        }

        public void ShowIntro()
        {
            Console.ForegroundColor = DisplayColor;
            Console.WriteLine(Name);
            Console.ResetColor();

            if (!string.IsNullOrWhiteSpace(AsciiArt))
                Console.WriteLine(AsciiArt);

            if (AI.CanTalk && !string.IsNullOrWhiteSpace(AI.DialogueLine))
                Console.WriteLine($"\"{AI.DialogueLine}\"");

            Console.WriteLine($"Description: {Lore.Description}");
            Console.WriteLine($"Habitat: {Lore.Habitat} | Origin: {Lore.Origin}");
            Console.WriteLine($"Weakness: {Lore.Weakness} | Resistance: {Lore.Resistance}");
            Console.WriteLine();
        }

        public static Monster GenerateRandomMonster(int playerLevel)
        {
            Random rand = new Random();
            int choice = rand.Next(0, 7);

            Monster monster = choice switch
            {
                0 => Orc.CreateRandomOrc(playerLevel),
                1 => Skeleton.CreateRandomSkeleton(playerLevel),
                2 => Undead.Undead.CreateRandomUndead(playerLevel),
                3 => Troll.CreateRandomTroll(playerLevel),
                4 => Vampire.CreateRandomVampire(playerLevel),
                5 => Goblin.CreateRandomGoblin(playerLevel),
                6 => Human.CreateRandomHuman(playerLevel),
                _ => Rat.CreateRandomRat(playerLevel)
            };

            ApplyDefaults(monster);
            return monster;
        }

        public static Monster GenerateMonster(string monsterType, string variant, int playerLevel)
        {
            Monster monster = monsterType.ToLower() switch
            {
                "orc" => Orc.CreateOrc(variant),
                "skeleton" => Skeleton.CreateSkeleton(variant),
                "undead" => Undead.Undead.CreateUndead(variant),
                "human" => Human.CreateHuman(variant),
                "vampire" => Vampire.CreateVampire(variant),
                "rat" => Rat.CreateRat(variant),
                "goblin" => Goblin.CreateGoblin(variant),
                "troll" => Troll.CreateTroll(variant),
                _ => new Rat("Dålig Hygien", 1, 2, 1)
            };

            ApplyDefaults(monster);
            return monster;
        }

        private static void ApplyDefaults(Monster monster)
        {
            monster.AI ??= new MonsterAI
            {
                BehaviorType = "aggressive",
                CanFlee = false,
                CanTalk = false,
                DialogueLine = null
            };

            monster.Lore ??= new MonsterLore
            {
                Description = "An eerie creature with unknown motives.",
                Habitat = "Unknown lands",
                Origin = "Forgotten magic",
                Weakness = "None",
                Resistance = "None",
                IsBoss = false
            };

            if (monster.DisplayColor == default)
                monster.DisplayColor = ConsoleColor.Gray;
        }
    }
}




