using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Battle
{
    public class Fighter
    {
        public string Name;
        public int HealthPool;
        public int Attack;
        public int Strenght;
             
        public Fighter (string name)
        {
            Name = name;
            
            Random rand = new Random();
            HealthPool = 50+ rand.Next(1, 31);
            Attack = 6+ rand.Next(1, 6);
            Strenght = 1 + rand.Next(0, 4);
        }

    }
}
