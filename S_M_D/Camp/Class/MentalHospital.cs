using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class MentalHospital : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero;
        int _actionPrice;
        public MentalHospital(MentalHospitalConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        public void setHero(BaseHeros h)
        {
            _hero = h;
        }
        public void deleteHeros()
        {
            _hero = null;
        }
        public void HealHero(Psychology psycho)
        {
            _hero.DeletePsycho(psycho);
        }

        public void LevelUP()
        {
            Level++;
            _actionPrice = _actionPrice / Level;
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
