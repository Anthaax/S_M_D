using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    class Bar : BaseBuilding
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        public Bar(BarConfig b) : base(b)
        {
            _hero1 = b.Hero1;
            _hero2 = b.Hero2;
        }

        public void CreateRelationHero()
        {
            //creer relation entre hero1 / hero2
        }
    }
}
