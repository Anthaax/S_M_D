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
        GameContext _ctx;
        public Armory(ArmoryConfig b) : base(b)
        {
            _hero = b.Hero;
            _ctx = b.Ctx;
        }
        public void deleteHero()
        {
            Hero = null;
        }
        public void UpgrateItemOfAnHero(BaseItem HeroItem)
        {
            HeroItem.LevelUp();  
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
                _hero.InBuilding = this;           }
        }
    }
}
