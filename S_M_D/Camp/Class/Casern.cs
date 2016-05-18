using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Casern : BaseBuilding
    {
        private BaseHeros _hero;
        private Spells _spell;
        public Casern(CasernConfig b) : base(b)
        {
            _hero = b.Hero;
            _spell = b.Spell;
        }
        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }

            set
            {
                _hero = value;
            }
        }
        public void deleteHero()
        {
            _hero = null;
        }
        public void buySpellToHero(BaseHeros h,Spells s)
        {
            // ajoute le spell au héro
        }
    }
}
