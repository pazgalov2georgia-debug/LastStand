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
        public string Name;
        public List<Squad> Formations;
        public ConsoleColor Color;
        public Fraction (string name, List<Squad> formations, ConsoleColor color)
        {
            Name = name;
            Formations = formations;
            Color = color;
        }
    }
}
