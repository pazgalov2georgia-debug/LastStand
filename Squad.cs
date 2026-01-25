using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastStand
{
    internal class Squad
    {
        public string Name;
        public List<Fighter> Fighters;

        public Squad(string name, List<Fighter> fighters)
        {
            Name = name;
            Fighters = fighters;
        }

    
    }
}
