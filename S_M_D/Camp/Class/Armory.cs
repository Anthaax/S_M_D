using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Armory : BaseBuilding
    {
        private BaseHeros _hero;
        public Armory(ArmoryConfig b) : base(b)
        {
            _hero = b.Hero;
        }
        public void buyItemToHero(BaseHeros hero)
        {
            //ajoute l itam au héro selectionné
        }
    }
}
