using Battle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastStand
{
    internal class TheBattle

    {
        public List<Fraction> Fractions = new List<Fraction>();
        public TheBattle()
        {
            List<string> fightersNames = File.ReadAllLines("FightersNames.txt").ToList();
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
                    Console.WriteLine($"Team: " + squad.Name);
                    foreach (var fighter in squad.Fighters)
                    {
                        Console.WriteLine($"Fighter name: " + fighter.Name);
                    }
                }
            }
        }

        public void RasNaRas()
        {
            var rightFractionFighter = Fractions.First().PickRandomFighter();
            var wrongFractionFighter = Fractions.Last().PickRandomFighter();
            Console.WriteLine($"Today's fight is between {rightFractionFighter.Name} and {wrongFractionFighter.Name}");

            while (rightFractionFighter.IsAlive && wrongFractionFighter.IsAlive)
            {
                rightFractionFighter.OnePunch(wrongFractionFighter);
                wrongFractionFighter.OnePunch(rightFractionFighter);
            }
            if (rightFractionFighter.IsAlive)
            {
                Console.WriteLine($"{rightFractionFighter.Name} Is Victoriuos!");
            }
            else if (wrongFractionFighter.IsAlive)
            {
                Console.WriteLine($"{wrongFractionFighter.Name} Is Victoriuos!");
            }
            else
            {
                Console.WriteLine($"Death Took Both {rightFractionFighter.Name} and {wrongFractionFighter.Name}!");
            }
            
        }

        //public void StenkaNaStenku()
        //{
        //    var squad = Fractions.First().PickRandomSquad();

        //}


        private Fraction CreateFraction(string name, List<string> squadsNames, List<string> fightersNames, ConsoleColor color)
        {

            List<Squad> squads = new List<Squad>();
            foreach (var squadName in squadsNames)
            {
                var squad = CreateSquad(squadName, fightersNames);
                squads.Add(squad);
            }
            return new Fraction(name, squads, color);
        }
        private Squad CreateSquad(string name, List<string> fightersNames)
        {
            List<Fighter> fighters = new List<Fighter>();

            for (int i = 0; i < 10; i++)
            {
                var fighter = CreateFighter(fightersNames);
                fighters.Add(fighter);
            }
            return new Squad(name, fighters);
        }
        private Fighter CreateFighter(List<string> fightersNames)
        {
            Random rand = new Random();
            int randomFigterNameIndex = rand.Next(fightersNames.Count - 1);
            var fighterName = fightersNames[randomFigterNameIndex];
            fightersNames.RemoveAt(randomFigterNameIndex);
            return new Fighter(fighterName);
        }
    }
}
