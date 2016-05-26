using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Caravan : BaseBuilding, ILevelUP
    {
        private List<BaseHeros> _herosDispo;
        int _maxNewHero;
        public Caravan(CaravanConfig b) : base(b)
        {
            HerosDispo = b.HerosDispo;
            _maxNewHero = b.MaxNewHero;
        }

        public void Initialized()
        {
            for (int i = 0; i < _maxNewHero; i++)
            {
                Array heroEnum = Enum.GetValues( typeof( HerosEnum ) );
                HerosEnum hero = (HerosEnum)heroEnum.GetValue( Ctx.Rnd.Next( heroEnum.Length ) );
                HerosDispo.Add(Ctx.HeroManager.Find(hero.ToString()).CreateHeroToBuy());
            }
        }

        public void BuyHero(BaseHeros hero)
        {
            if (Ctx.MoneyManager.CanBuy( hero.Price ))
                Ctx.MoneyManager.Buy( hero.Price );
            else throw new ArgumentException( "You Can't buy this thing" );
            Ctx.PlayerInfo.MyHeros.Add(hero);
        }
        public void SuppresAnHero(BaseHeros hero)
        {
            Ctx.PlayerInfo.MyHeros.Remove(hero);
        }
        public void LevelUP()
        {
            Level++;
            _maxNewHero++;
        }

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

        public int MaxNewHero
        {
            get
            {
                return _maxNewHero;
            }
        }
    }
}
