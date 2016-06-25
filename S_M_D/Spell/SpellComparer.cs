using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class SpellComparer : IComparer<Spells>
    {
        public int Compare(Spells x, Spells y)
        {
            if (x.IsEquiped && !y.IsEquiped)
                return -1;
            if (!x.IsEquiped && y.IsEquiped)
                return 1;
            return 0;
        }
    }
}
