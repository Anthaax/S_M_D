using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Caravan : BaseBuilding
    {
        private List<BaseHeros> _herosDispo;

        public List<BaseHeros> HerosDispo
        {
            get
            {
                return _herosDispo;
            }

            set
            {
                _herosDispo = value;
            }
        }

        public Caravan(CaravanConfig b) : base(b)
        {
            HerosDispo = b.HerosDispo;
        }

        public void Initialized()
        {
            for (int i = 0; i < 4; i++)
            {
                int heroEnum = Ctx.Rnd.Next(1, 5);
                HerosEnum hero = (HerosEnum)heroEnum;
                HerosDispo.Add(Ctx.HeroManager.Find(hero.ToString()).CreateHeroToBuy());
            }
        }

        public void BuyHero(BaseHeros hero)
        {
            Ctx.PlayerInfo.MyHeros.Add(hero);
        }
    }
}
