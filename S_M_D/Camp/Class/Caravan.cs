using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class Caravan : BaseBuilding, ILevelUP
    {
        readonly List<BaseHeros> _herosDispo;
        int _maxNewHero;
        public Caravan(CaravanConfig b) : base(b)
        {
            _herosDispo = b.HerosDispo;
            _maxNewHero = b.MaxNewHero;
        }
        /// <summary>
        /// Initialized the list hero to buy
        /// </summary>
        public void Initialized()
        {
            for (int i = 0; i < _maxNewHero; i++)
            {
                Array heroEnum = Enum.GetValues( typeof( HerosEnum ) );
                HerosEnum hero = (HerosEnum)heroEnum.GetValue( Ctx.Rnd.Next( heroEnum.Length ) );
                HerosDispo.Add(Ctx.HeroManager.Find(hero.ToString()).CreateHeroToBuy());
            }
        }
        /// <summary>
        /// Buy a hero
        /// </summary>
        /// <param name="hero">Hero to buy</param>
        public void BuyHero(BaseHeros hero)
        {
            if (Ctx.MoneyManager.CanBuy( hero.Price ))
                Ctx.MoneyManager.Buy( hero.Price );
            else throw new ArgumentException( "You Can't buy this thing" );
            Ctx.PlayerInfo.MyHeros.Add(hero);
        }
        /// <summary>
        /// Suppress an hero
        /// </summary>
        /// <param name="hero"></param>
        public void SuppresAnHero(BaseHeros hero)
        {
            Ctx.PlayerInfo.MyHeros.Remove(hero);
        }
        /// <summary>
        /// Level up the building
        /// </summary>
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
