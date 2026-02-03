using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LastStand
{
    internal class Fraction
    {
        public string Name { get; }
        public List<Squad> Formations { get; }
        public ConsoleColor Color { get; }

        public Fraction(string name, List<Squad> formations, ConsoleColor color)
        {
            Name = name;
            Formations = formations;
            Color = color;
        }

        public Fighter PickRandomFighter()
        {
            var rnd = new Random();
            Squad squad = PickRandomSquad();
            var fighters = squad.Fighters;
            var squadFighther = fighters[rnd.Next(fighters.Count)];
            return squadFighther;
        }

        public Squad PickRandomSquad()
        {
            var rnd = new Random();
            return Formations[rnd.Next(Formations.Count)];
        }
    }
}
