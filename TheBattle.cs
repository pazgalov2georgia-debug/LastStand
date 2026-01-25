using Battle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastStand
{
    internal class TheBattle
    {
        public TheBattle()
        {
            string[] fightersNames = File.ReadAllLines("FightersNames.txt");
            var rightSquadsNames = new List<string> { "Alfa", "Beta" };
            var wrongSquadsNames = new List<string> { "Alfa", "Beta" };
            var right = CreateFraction("Right", rightSquadsNames, fightersNames);
            var wrong = CreateFraction("Wrong", wrongSquadsNames, fightersNames);
        }
        private Fraction CreateFraction(string name, List <string>squadsNames, string[] fightersNames)
        {
            
            List<Squad> squads = new List<Squad>();
            foreach (var squadName in squadsNames)
            {
                var squad = CreateSquad(squadName, fightersNames);
                squads.Add(squad);
            }
            return new Fraction(name, squads);
        }
        private Squad CreateSquad(string name, string[] fightersNames)
        {
            for (int i = 0; i < 10; i++)
            {
               var fighther = CreateFighter(name, fightersNames);
            }
            return new Squad(name, fighter);
        }
        private Fighter CreateFighter(string name, string[] fightersNames)
        {
            Random rand = new Random();
            List<Fighter> fighters = new List<Fighter>();
            {
                
                var fighterName = fightersNames[rand.Next(fightersNames.Length - 1)];
                var fighter = new Fighter(fighterName);
            }
            return Fighter.Create(fighter);
        }
    }
}
