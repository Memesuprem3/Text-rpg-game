using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Text_rpg_game.classer.Combat;
using Text_rpg_game.classer.Monsters;
using Text_rpg_game.classer.Monsters.Humanoids;
using Text_rpg_game.classer.Monsters.Undead;
using Text_rpg_game.classer.Player.Core;
using Text_rpg_game.classer.Utilitys;
using static Text_rpg_game.classer.Monsters.Monster;



namespace Text_rpg_game.classer.Encounters
{
    public class Encounters
    {


        public static void FirstEncounter()
        {
            var player = CurrentPlayer.currentPlayer;
            string race = player.PlayerRace.ToString();
            string playerClass = player.CharacterClass.ToLower();

  
            CenteredWriter.Write("Your story begins...", -4);
            Console.ReadKey();
            Console.Clear();
            

            switch (player.PlayerRace)
            {
                case Race.Human:
                    switch (playerClass)
                    {
                        case "warrior":
                            CenteredWriter.Write("You awaken in the charred ruins of a barracks, flames licking the distant treetops.", -1);
                            CenteredWriter.Write("Through the smoke, a deserter warms his hands by a fire. You grip your rusted blade and charge.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Deserter", 2, 5, 0));
                            break;

                        case "knight":
                            CenteredWriter.Write("Rain pours as you kneel before a ruined shrine. The sky cracks open with thunder.", -1);
                            CenteredWriter.Write("A rogue mage defiles the sacred ground—you raise your sword in righteous fury.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Crazed Mage", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("Your song echoes across the alley walls.", -1);
                            CenteredWriter.Write("From the shadows, a Rogue lunges");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Thug Rouge", 2, 4, 30));
                            break;

                        case "inquisitor":
                            CenteredWriter.Write("You trace runes across the cold chapel floor, hunting whispers of forbidden rituals.", -1);
                            CenteredWriter.Write("Suddenly, a shadow emerges—it's a Priest, cloaked in doubt and fear, and they will not let you pass.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Fearful Priest", 2, 4, 30));
                            break;

                        case "priest":
                            CenteredWriter.Write("You pray in the candlelit chapel, but divine peace is shattered.",-1);
                            CenteredWriter.Write("The door bursts open—an Inquisitor storms in, accusing you of consorting with darkness.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Overzealous Inquisitor", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("You silently slip through the back alleys...", -1);
                            CenteredWriter.Write("But a Bard is already there, strumming a chord that shatters glass!");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Duelling Bard", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("The forest breathes around you as you crouch near a fire.", -1);
                            CenteredWriter.Write("Suddenly, arrows rain down—another ranger, territorial and swift, steps from the mist.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Wildwood Tracker", 2, 4, 30));
                            break;

                        case "paladin":
                            CenteredWriter.Write("Beneath the cathedral, whispers echo from the crypt.", -1);
                            CenteredWriter.Write("You descend and see the ritual too late. The necromancer raises his hands to strike.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Necromancer Acolyte", 2, 4, 30));
                            break;

                        case "wizard":
                            CenteredWriter.Write("Arcane symbols pulse as you open your spellbook.", -1);
                            CenteredWriter.Write("The door crashes open—a Knight of Engora charges in, blade drawn, condemning your heresy.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Knight of Engora", 2, 4, 30));
                            break;

                        case "warlock":
                            CenteredWriter.Write("The scroll ignites in eerie flame as your ritual completes.", -1);
                            CenteredWriter.Write("A novice Paladin bursts into the room, fury in their eyes, ready to strike you down.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Novice Paladin", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Dwarf:
                    switch (playerClass.ToLower())
                    {
                        case "warrior":
                            CenteredWriter.Write("You awaken to the sound of clashing steel in the mountain hold.",-1);
                            CenteredWriter.Write("A rogue Dwarf has challenged your authority. You raise your axe.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Rebel Dwarf Rogue", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("In the underhalls, shadows flicker. A fellow dwarf eyes your gold.",-1);
                            CenteredWriter.Write("Greed overtakes brotherhood. Time to defend what's yours.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Greedy Dwarf Bard", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("You scout the edge of the dwarven territory when a rival ranger ambushes you.", -1);
                            CenteredWriter.Write("This part of the mountain is contested.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Territorial Dwarf Ranger", 2, 4, 30));
                            break;

                        case "priest":
                            CenteredWriter.Write("Deep in the shrine, you tend to ancient runes.", -1);
                            CenteredWriter.Write("An Inquisitor bursts in, accusing you of heresy.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Fanatical Dwarf Inquisitor", 2, 4, 30));
                            break;

                        case "inquisitor":
                            CenteredWriter.Write("In the chamber of judgement, you uncover forbidden scriptures.", -1);
                            CenteredWriter.Write("A priest stands in your way, desperate to protect the truth.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Defensive Dwarf Priest", 2, 4, 30));
                            break;

                        case "knight":
                            CenteredWriter.Write("Patrolling the upper halls, you hear a strange melody.", -1);
                            CenteredWriter.Write("A bard is stirring unrest with songs of rebellion.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Seditious Dwarf Bard", 2, 4, 30));
                            break;

                        case "paladin":
                            CenteredWriter.Write("Your oath is tested as a fellow warrior questions your divine right.", -1);
                            CenteredWriter.Write("Steel must speak.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Doubting Dwarf Warrior", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("Your song stirs the hearts of the tavern, but a rogue challenges your tale.", -1);
                            CenteredWriter.Write("This will be a duel of blade and verse.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Jealous Dwarf Rogue", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Elf:
                    switch (playerClass.ToLower())
                    {
                        case "wizard":
                            CenteredWriter.Write("In your secluded grove, you weave ancient elven spells.", -1);
                            CenteredWriter.Write("A ranger disrupts your ritual, accusing you of disturbing the forest spirits.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Forestbound Elf Ranger", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("While patrolling the edge of the woods, you spot arcane fire.", -1);
                            CenteredWriter.Write("An elf wizard experiments dangerously close to sacred ground.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Wild Elf Wizard", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("You slip through the treetop homes of your kin, seeking riches.", -1);
                            CenteredWriter.Write("A bard has noticed your presence and aims to expose you.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Vigilant Elf Bard", 2, 4, 30));
                            break;

                        case "priest":
                            CenteredWriter.Write("You chant prayers beneath a moonlit glade.", -1);
                            CenteredWriter.Write("An inquisitor approaches, demanding answers for your rituals.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Suspicious Elf Inquisitor", 2, 4, 30));
                            break;

                        case "druid":
                            CenteredWriter.Write("Tending to wounded animals, you hear snapping branches.", -1);
                            CenteredWriter.Write("A ranger appears, weapon raised—you've crossed territorial lines.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Territorial Elf Ranger", 2, 4, 30));
                            break;

                        case "inquisitor":
                            CenteredWriter.Write("You investigate rumors of dark practices in the glade.", -1);
                            CenteredWriter.Write("A priest blocks your path, pleading for understanding.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Protective Elf Priest", 2, 4, 30));
                            break;

                        case "knight":
                            CenteredWriter.Write("Riding through elven strongholds, you are stopped by a bard questioning your leadership.", -1);
                            CenteredWriter.Write("Insults are traded—steel follows.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Defiant Elf Bard", 2, 4, 30));
                            break;

                        case "warrior":
                            CenteredWriter.Write("Your martial training is interrupted by a paladin doubting your dedication.", -1);
                            CenteredWriter.Write("Time to settle it with combat.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Righteous Elf Paladin", 2, 4, 30));
                            break;

                        case "paladin":
                            CenteredWriter.Write("You are called to defend sacred elven ruins.", -1);
                            CenteredWriter.Write("A warlock has breached the site.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Defiling Elf Warlock", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("Your latest performance has earned envy.", -1);
                            CenteredWriter.Write("A rogue seeks to silence you.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Jealous Elf Rogue", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Gnome:
                    switch (playerClass.ToLower())
                    {
                        case "wizard":
                            CenteredWriter.Write("In your arcane lab, a fellow gnome questions your theories.", -1);
                            CenteredWriter.Write("The debate gets... explosive.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Rival Gnome Warlock", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("You crack open a vault only to find another gnome got there first.", -1);
                            CenteredWriter.Write("One of you must leave with the treasure.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Sneaky Gnome Rogue", 2, 4, 30));
                            break;

                        case "warrior":
                            CenteredWriter.Write("You train in a hidden gym when a bard mocks your form.", -1);
                            CenteredWriter.Write("You accept their duel.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Boastful Gnome Bard", 2, 4, 30));
                            break;

                        case "warlock":
                            CenteredWriter.Write("You delve into the void, but your actions draw divine ire.", -1);
                            CenteredWriter.Write("A priest bursts in, intent on stopping you.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Alarmed Gnome Priest", 2, 4, 30));
                            break;

                        case "priest":
                            CenteredWriter.Write("Your meditations are interrupted by dark whispers.", -1);
                            CenteredWriter.Write("A warlock gnome believes you're the cause.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Suspicious Gnome Warlock", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("During your performance, a rival bard challenges your lyrics.", -1);
                            CenteredWriter.Write("You both draw instruments—and blades.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Competing Gnome Bard", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Undead:
                    switch (playerClass.ToLower())
                    {
                        case "warrior":
                            CenteredWriter.Write("You rise from your grave, only to see another undead looting bones.", -1);
                            CenteredWriter.Write("This desecration must be stopped.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Bonepicker Rogue", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("In the dead forest, another undead ranger stalks your prey.", -1);
                            CenteredWriter.Write("There can only be one master of the hunt.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Silent Bone Ranger", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("You creep through crypt corridors, but someone beat you to the vault.", -1);
                            CenteredWriter.Write("An undead knight guards the treasures.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Cryptbound Knight", 2, 4, 30));
                            break;

                        case "wizard":
                            CenteredWriter.Write("In your lair, you scribe forbidden glyphs.");
                            CenteredWriter.Write("An undead warlock appears, claiming dominion over this tomb.", -1);
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Ancient Warlock", 2, 4, 30));
                            break;

                        case "warlock":
                            CenteredWriter.Write("You channel dark power, but the arcane disturbance attracts a wizard.", -1);
                            CenteredWriter.Write("He believes you threaten the balance.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Keeper of the Veil", 2, 4, 30));
                            break;

                        case "knight":
                            CenteredWriter.Write("At the ruins of an old fortress, a rogue mocks your code.", -1);
                            CenteredWriter.Write("You cannot allow this disrespect to stand.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Blasphemous Rogue", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Orc:
                    switch (playerClass.ToLower())
                    {
                        case "warrior":
                            CenteredWriter.Write("You roar as you enter the arena, but a fellow orc refuses to yield.", -1);
                            CenteredWriter.Write("Only one warrior may leave.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Challenger Orc Ranger", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("Sneaking through camp, you're caught by a bard crafting tales of your treachery.", -1);
                            CenteredWriter.Write("The blade is faster than the lute.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Slandering Bard", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("You hunt boar beyond the ridge, but another orc stalks your prey.", -1);
                            CenteredWriter.Write("Only the strongest shall feast tonight.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Feral Orc Warrior", 2, 4, 30));
                            break;

                        case "shaman":
                            CenteredWriter.Write("In a ritual circle, visions disturb your trance.", -1);
                            CenteredWriter.Write("A warlock demands your silence.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Blighted Warlock", 2, 4, 30));
                            break;

                        case "warlock":
                            CenteredWriter.Write("The spirits are restless. Another shaman accuses you of corruption.", -1);
                            CenteredWriter.Write("You must prove your will.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Furious Orc Shaman", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("Your latest war chant enrages a rogue who believes you’ve stolen their story.", -1);
                            CenteredWriter.Write("There will be blood and verses.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Envious Orc Rogue", 2, 4, 30));
                            break;
                    }
                    break;

                case Race.Troll:
                    switch (playerClass.ToLower())
                    {
                        case "warrior":
                            CenteredWriter.Write("Beneath the jungle canopy, your shout echoes.", -1);
                            CenteredWriter.Write("Another troll charges from the shadows—your rival.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Rival Troll Knight", 2, 4, 30));
                            break;

                        case "rogue":
                            CenteredWriter.Write("You climb temple ruins for loot, but a bard already sings of your deeds—incorrectly.", -1);
                            CenteredWriter.Write("You’ll correct that personally.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Boastful Bard", 2, 4, 30));
                            break;

                        case "ranger":
                            CenteredWriter.Write("The swamp's silence breaks as a warrior crosses your path.", -1);
                            CenteredWriter.Write("Neither of you will yield your hunting ground.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Territorial Troll Warrior", 2, 4, 30));
                            break;

                        case "shaman":
                            CenteredWriter.Write("The winds whisper of a knight’s judgment.", -1);
                            CenteredWriter.Write("You are summoned—but refuse to be condemned.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Holy Troll Knight", 2, 4, 30));
                            break;

                        case "warlock":
                            CenteredWriter.Write("The sky darkens as a shaman calls you out for disturbing the balance.", -1);
                            CenteredWriter.Write("Your magic shall defend your cause.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Judging Shaman", 2, 4, 30));
                            break;

                        case "bard":
                            CenteredWriter.Write("You perform for the jungle spirits—but a rogue sabotages your stage.", -1);
                            CenteredWriter.Write("Music or daggers? You choose both.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Spiteful Troll Rogue", 2, 4, 30));
                            break;

                        case "knight":
                            CenteredWriter.Write("While enforcing order in the tribal village, a shaman refuses your decree.", -1);
                            CenteredWriter.Write("The people watch as tradition clashes with law.");
                            Console.ReadKey();
                            Combats.StartFight(player, new Monster("Defiant Troll Shaman", 2, 4, 30));
                            break;
                    }
                    break;
            }
        }


        public static void SpecificEncounter()
        {
            var player = CurrentPlayer.currentPlayer;

            //placeholder
            Monster SpecificMonster = GenerateMonster("Human", "Bandit", 1);
            CenteredWriter.Write("You throw open the door and grab a rusty metal sword, charging towards your captor.");
            CenteredWriter.Write("He turns...");
            Console.ReadKey();
            
            Combats.StartFight(player, SpecificMonster);
        }


        public static void RandomFightEncounter()
        {
            var player = CurrentPlayer.currentPlayer;

            if (player.health > 0)
            {
                Console.Clear();
                CenteredWriter.Write("A Monster Appears!");
                Thread.Sleep(1000);
                Monster randomMonster = GenerateRandomMonster(player.Level);
                Combats.StartFight(player, randomMonster);
            }
        }

        public static void FightEncounter()
        {
            var player = CurrentPlayer.currentPlayer;

            if (player.health > 0)
            {
                Console.Clear();
                CenteredWriter.Write("You turn the corner and see an Enemy.");
                Console.ReadKey();
                Monster randomMonster = GenerateRandomMonster(player.Level);
                Combats.StartFight(player, randomMonster);
            }
        }


        public static void BossFightEncounter()
        {
            var player = CurrentPlayer.currentPlayer;

            Console.Clear();
            CenteredWriter.Write("A sinister presence lingers in the air...");
            Console.ReadKey();

            Monster boss = Skeleton.CreateSkeleton("Deamon Skeleton"); // ELLER annan Create-metod
            Combats.StartFight(player, boss);
        }

    }
}