using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Hotel : BaseBuilding
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        public Hotel(HotelConfig b) : base(b)
        {
            _hero1 = b.Hero1;
            _hero2 = b.Hero2;
        }
        public void setHero(BaseHeros h)
        {
            if (_hero1 == null) _hero1 = h;
            else if (_hero2 == null) _hero2 = h;
        }
        public void deleteHeros()
        {
            _hero1 = null;
            _hero2 = null;
        }
        public void CreateRelationHeroHero()
        {
            //creer relation entre hero1 / hero2
        }
    }
}
