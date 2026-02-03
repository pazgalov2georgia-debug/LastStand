using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Battle
{
    public class Fighter
    {
        public string Name { get; }
        public int HealthPool;
        public int Attack;
        public int Strenght;
        public bool IsAlive { get; private set; } = true;


        public Fighter(string name)
        {
            Name = name;

            Random rand = new Random();
            HealthPool = 50 + rand.Next(1, 31);
            Attack = 6 + rand.Next(1, 6);
            Strenght = 1 + rand.Next(0, 4);
        }

        public void OnePunch(Fighter fighter)
        {
            Random rand = new Random();
            var damage = rand.Next(1, Attack) + Strenght;
            //Console.WriteLine($"{Name} attacked {fighter.Name} by {damage}");
            fighter.DamagePerHit(damage);
        }

        public void DamagePerHit(int damage)
        { 
            HealthPool -= damage;
            //Console.WriteLine($"{Name} took {damage} damage");

            if (HealthPool <= 0)
            {
                IsAlive = false;
                ///Console.Write(" and died");
            }
        }
    }    
}
