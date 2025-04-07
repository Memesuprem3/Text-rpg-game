using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Text_rpg_game.classer.Monsters;

namespace Text_rpg_game.classer.Monsters
{
    public class MonsterLore
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public string Origin { get; set; }
        public string Weakness { get; set; }
        public string Resistance { get; set; }
        public bool IsBoss { get; set; }
        public string AsciiArt { get; set; }
        public ConsoleColor DisplayColor { get; private set; }


        public void ShowMonsterLore()
        {
            Console.ForegroundColor = DisplayColor;
            Console.WriteLine(Name.ToUpper());
            Console.ResetColor();

            if (!string.IsNullOrWhiteSpace(AsciiArt))
                Console.WriteLine(AsciiArt);

            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Habitat: {Habitat} | Origin: {Origin}");
            Console.WriteLine($"Weakness: {Weakness} | Resistance: {Resistance}");
            Console.WriteLine(IsBoss ? "** This is a BOSS monster! **" : "");
            Console.WriteLine();
        }
    }
}