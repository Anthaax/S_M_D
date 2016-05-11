using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    class Cemetery : BaseBuilding
    {
        private List<BaseHeros> _herosDispo;
        public Cemetery(CemeteryConfig b) : base(b)
        {
            _herosDispo = b.HerosDispo;
        }
        public void buyHero()
        {
            // Ajoute le hero choisi a la liste des heros du joueur
        }
    }
}
