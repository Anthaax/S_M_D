using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Casern : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero;
        int _actionPrice;
        public Casern(CasernConfig b) : base(b)
        {
            _hero = b.Hero;
        }
        public void setHero(BaseHeros h)
        {
            _hero = h;
        }
        public void deleteHeros()
        {
            _hero = null;
        }
        public void buySpellToHero()
        {
            // ajoute le spell au héro
        }
        public void LevelUP()
        {
            Level++;
            _actionPrice = _actionPrice / Level;
        }

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }

        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }
        }
    }
}
