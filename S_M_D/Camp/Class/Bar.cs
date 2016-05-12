using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Bar : BaseBuilding
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;

        public Bar(BarConfig b) : base(b)
        {
            _hero1 = b.Hero1;
            _hero2 = b.Hero2;
        }
        public void setHero(BaseHeros h)
        {
            if (Hero1 == null) Hero1 = h;
            else if (Hero2 == null) Hero2 = h;
        }
        public void deleteHeros()
        {
            Hero1 = null;
            Hero2 = null;
        }
        public void CreateRelationHero()
        {
            //creer relation entre hero1 / hero2
        }
        public BaseHeros Hero1
        {
            get
            {
                return _hero1;
            }

            set
            {
                _hero1 = value;
            }
        }

        public BaseHeros Hero2
        {
            get
            {
                return _hero2;
            }

            set
            {
                _hero2 = value;
            }
        }
    }
}
