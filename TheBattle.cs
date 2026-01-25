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
        public List<Fraction> Fractions = new List<Fraction>();
        public List<Squad> Squads = new List<Squad>();
        public List<Fighter> Fighters = new List<Fighter>();
        public TheBattle()
        {
            string[] fightersNames = File.ReadAllLines("FightersNames.txt");
            var rightSquadsNames = new List<string> { "Alfa", "Beta" };
            var wrongSquadsNames = new List<string> { "Alfa", "Beta" };
            
            var right = CreateFraction("Right", rightSquadsNames, fightersNames, ConsoleColor.Green);
            var wrong = CreateFraction("Wrong", wrongSquadsNames, fightersNames, ConsoleColor.Red);
            Fractions.Add(right);
            Fractions.Add(wrong);
        }
        public void Report()
        {
            foreach (var fraction in Fractions) 
            {
                Console.ForegroundColor = fraction.Color;
                Console.WriteLine(fraction.Name);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var squad in fraction.Formations) 
                {
                    Console.WriteLine($"Team: "+ squad.Name);
                    foreach (var fighter in squad.Fighters)
                    { 
                    Console.WriteLine($"Fighter name: "+ fighter.Name);
                    }
                }
                
            }
        }
        private Fraction CreateFraction(string name, List <string>squadsNames, string[] fightersNames, ConsoleColor color)
        {
            
            List<Squad> squads = new List<Squad>();
            foreach (var squadName in squadsNames)
            {
                var squad = CreateSquad(squadName, fightersNames);
                squads.Add(squad);
            }
            return new Fraction(name, squads, color);
        }
        private Squad CreateSquad(string name, string[] fightersNames)
        {
            List<Fighter> fighters = new List<Fighter>();

            for (int i = 0; i < 10; i++)
            {
            var fighter = CreateFighter(fightersNames);
             fighters.Add(fighter);
            }
            return new Squad(name, fighters);
        }
        private Fighter CreateFighter(string[] fightersNames)
        {
            Random rand = new Random();
            var fighterName = fightersNames[rand.Next(fightersNames.Length - 1)];
            return new Fighter(fighterName);
        }
    }
}
