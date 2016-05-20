using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class MentalHospital : BaseBuilding
    {
        private BaseHeros _hero;
        public MentalHospital(MentalHospitalConfig b) : base(b)
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
        public void HealHero(Psychology psycho)
        {
            _hero.DeletePsycho(psycho);
        }
    }
}
