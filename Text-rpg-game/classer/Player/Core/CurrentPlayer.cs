using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Text_rpg_game.classer.Equipment;
using Text_rpg_game.classer.Utilitys;


namespace Text_rpg_game.classer.Player.Core
{
    [Serializable]
    public enum Race
    {
        Human,
        Dwarf,
        Elf,
        Gnome,
        Undead,
        Orc,
        Troll

    }
    public class CurrentPlayer
    {
        public static CurrentPlayer currentPlayer = new CurrentPlayer();
        private Random rand = new Random();

        public int playerID;
        public string Name;
        public string Gender;
        public string CharacterClass;
        public int gold = 30;
        public int health = 10;
        public int damage = 3;
        public int armorValue = 1;
        public int weaponValue = 1;
        public int Level = 1;
        public int XP = 0;
        public int XPToNextLevel = 100;

        // Primary stats
        public int strength = 1; // påverka skada med vapen
        public int agility = 1; // - || -
        public int stamina = 1; // påverkar hälsa
        public int spirit = 1; // inplementara hp reg?
        public int intelligence = 1;
        public int charisma = 1; // påverka dialoger/handel
        public int speed = 1; // ska påverka RUN i combat - skapa funk
        public int perception = 1; // påverka klasser/dialoger
        public int luck = 1;

        //Mele/Ranged stats 

        public double armorPen = 0.40;
        public double attackPow = 1;
        public double critChans = 0.50;
        public double hitChans = 1;


        //Caster stats
        public double spellPen = 0.50;
        public double spellPow = 1;
        public double spellCrit = 0.50;
        public double spellhit = 1;

        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Ability> Abilities { get; set; }

        public Race PlayerRace { get; set; }

        public CurrentPlayer()
        {
            Skills = new List<Skill>();
            Abilities = new List<Ability>();
            InitializeAllPossibleAbilities();
            InitializeInventory();
        }


        public void SetRaceAttributes()
        {
            switch (PlayerRace)
            {
                case Race.Dwarf:
                    strength += 1;
                    stamina += 1;
                    gold += 25;
                    break;
                case Race.Elf:
                    agility += 2;
                    break;
                case Race.Gnome:
                    intelligence += 2;
                    break;
                case Race.Undead:
                    intelligence += 2;
                    break;
                case Race.Orc:
                    health += 10;
                    strength += 2;
                    break;

            }
        }
        // inventory list
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public static void lookInventory(CurrentPlayer p)
        {
            int index = 1;
            Dictionary<int, string> itemMapping = new Dictionary<int, string>();
            foreach (var item in p.inventory)
            {
                Console.WriteLine($"{index}: {item.Key} x{item.Value}"); // Visa föremål och antal
                itemMapping[index] = item.Key; // Mappa index till föremålets namn
                index++;
            }
        }
        private void InitializeInventory()
        {

            inventory.Add("Minor Healing Potion", 5);
        }


        public void GainSkillXP(string skillName, int xp = 1)
        {
            var skill = Skills.FirstOrDefault(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
            if (skill != null)
            {
                skill.AddXP(xp);
            }
        }

        //kolla skill nivå i char menu?
        public int GetSkillBonus(string skillName)
        {
            var skill = Skills.FirstOrDefault(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
            return skill != null ? skill.Level : 0;
        }

        public void AddXP(int amount)
        {
            XP += amount;
            Console.WriteLine($"Du fick {amount} XP, totalt {XP} XP.");

            // Kontrollera om spelaren har nått XP-gränsen för nästa nivå
            while (XP >= XPToNextLevel)
            {
                LevelUp();  // Uppdatera spelarens stats och nivå
            }
        }
        private void CheckForNewAbilities()
        {
            var newlyUnlockedAbilities = Abilities.Where(ability => ability.MinLevel == Level).ToList();
            foreach (var ability in newlyUnlockedAbilities)
            {
                Console.WriteLine($"You gained a level! You now know how to use '{ability.Name}'.");
            }
        }

        public void LevelUp()
        {
            Level++;
            XP -= XPToNextLevel;
            XPToNextLevel = (int)(XPToNextLevel * 1.25);
            Console.WriteLine($"You are now Level {Level} and your health increased to {health}.");


            CheckForNewAbilities();

            switch (CharacterClass)
            {
                case "Warrior":
                    strength += 2;
                    stamina += 2;
                    health += 10;
                    break;
                case "Rogue":
                    agility += 2;
                    speed += 2;
                    health += 5;
                    break;
                case "Wizard":
                    intelligence += 3;
                    spirit += 1;
                    health += 3;
                    break;
                case "Ranger":
                    agility += 2;
                    perception += 1;
                    health += 5;
                    break;
                case "Paladin":
                    strength += 1;
                    spirit += 2;
                    health += 8;
                    break;
                case "Priest":
                    spirit += 3;
                    intelligence += 1;
                    health += 5;
                    break;
                case "Warlock":
                    intelligence += 2;
                    spirit += 1;
                    health += 4;
                    break;
                case "Shaman":
                    spirit += 2;
                    strength += 1;
                    health += 6;
                    break;
                case "Druid":
                    intelligence += 2;
                    agility += 1;
                    health += 5;
                    break;
            }
            Console.WriteLine($"You are now Level {Level} and health incresaed to {health}.");
        }

        //Abilitys SE ÖVER!!!
        public void InitializeAllPossibleAbilities()
        {
            //melee
            Abilities.Add(new Ability("Heroic Strike", "A powerful melee attack that deals significant damage.", 1, "Warrior", (player, monster) =>
            {
                monster.Health -= 10 + 2 * player.Level;
                Console.WriteLine($"{player.Name} deals {10 + 2 * player.Level} damage to {monster.Name} with Heroic Strike.");
            }));
            //renged


            //utilitty
            Abilities.Add(new Ability("Flash Heal",
                "Instantly heals a moderate amount of health.", 3, "Paladin", (player, monster) =>
                {
                    player.health += 10 + 5 * player.Level;
                    Console.WriteLine($"{player.Name} heals themselves for {10 + 5 * player.Level} HP with Flash Heal.");
                }));


            //caster
            Abilities.Add(new Ability("Fireball", "Casts a fiery explosion that damages a single target severely.", 2, "Mage", (player, monster) =>
            {
                monster.Health -= 15 + 3 * player.Level;
                Console.WriteLine($"{player.Name} casts Fireball and deals {15 + 3 * player.Level} damage to {monster.Name}.");
            }));


        }

        public int CalculateWeaponDamage()
        {
            if (EquippedWeapon == null)
                return damage + weaponValue;

            var weapon = EquippedWeapon;
            int baseDamage = weapon.BaseDamage;
            int elementalDamage = weapon.ElementalDamage;

            // Skillnamn = t.ex. "sword", "fire"
            int weaponSkill = GetSkillBonus(weapon.WeaponType.ToString().ToLower()); // swords, bows etc
            int elementSkill = GetSkillBonus(weapon.DamageType.ToString().ToLower()); // fire, ice etc

            int statBonus = weapon.IsMagic
                ? (int)(intelligence * 1.5)
                : (int)(strength * 1.5);

            int total = baseDamage + statBonus + elementalDamage;
            total += weaponSkill * 2;
            total += elementSkill * 2;

            double critChance = weapon.IsMagic ? spellCrit : critChans;
            if (rand.NextDouble() < critChance + luck * 0.01)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚡ Kritisk träff!");
                Console.ResetColor();
                total = (int)(total * 1.5);
            }
            if (weapon.IsMagic)
                GainSkillXP("magic", 2);
            else
                GainSkillXP(weapon.WeaponType.ToString().ToLower(), 2);

            return total;
        }

        public void ShowStatsMenu()
        {
            Console.Clear();
            int startY = -8; // Startposition från toppen
            int lineOffset = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            CenteredWriter.Write("===== Character Stats =====", startY + lineOffset++);
            Console.ResetColor();

            CenteredWriter.Write($"Name: {Name}", startY + lineOffset++);
            CenteredWriter.Write($"Class: {CharacterClass} | Level: {Level} | XP: {XP}/{XPToNextLevel}", startY + lineOffset++);
            CenteredWriter.Write($"Health: {health}", startY + lineOffset++);
            CenteredWriter.Write($"Gold: {gold}", startY + lineOffset++);
            lineOffset++; // Extra rad för spacing

            CenteredWriter.Write("Attributes:", startY + lineOffset++);
            CenteredWriter.Write($"- Strength: {strength}", startY + lineOffset++);
            CenteredWriter.Write($"- Agility: {agility}", startY + lineOffset++);
            CenteredWriter.Write($"- Stamina: {stamina}", startY + lineOffset++);
            CenteredWriter.Write($"- Spirit: {spirit}", startY + lineOffset++);
            CenteredWriter.Write($"- Intelligence: {intelligence}", startY + lineOffset++);
            CenteredWriter.Write($"- Charisma: {charisma}", startY + lineOffset++);
            CenteredWriter.Write($"- Speed: {speed}", startY + lineOffset++);
            CenteredWriter.Write($"- Perception: {perception}", startY + lineOffset++);
            CenteredWriter.Write($"- Luck: {luck}", startY + lineOffset++);
            lineOffset++;

            CenteredWriter.Write("Skills:", startY + lineOffset++);
            foreach (var skill in Skills.OrderBy(s => s.Name))
            {
                CenteredWriter.Write($"- {skill.Name}: Level {skill.Level} ({skill.XP}/{skill.XPToNextLevel} XP)", startY + lineOffset++);
            }

            lineOffset++;
            CenteredWriter.Write("Press any key to return...", startY + lineOffset);
            Console.ReadKey();
        }
    }
}

