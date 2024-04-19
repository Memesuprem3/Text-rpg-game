using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_rpg_game.classer.World
{
    internal class Dungeon
    {


        public string Name { get; set; }
        public int DifficultyLevel { get; set; } // Svårighetsnivå som kan öka

        public Dungeon(string name, int startingDifficulty)
        {
            Name = name;
            DifficultyLevel = startingDifficulty;
        }

        public void GenerateNextLevel()
        {
            // Generera nästa nivå av dungeon baserat på DifficultyLevel
            Console.WriteLine($"Entering {Name} level {DifficultyLevel}...");
            DifficultyLevel++;
            // Logik för att generera rum och korridorer här
        }

    }
}