using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Armory : BaseBuilding, ILevelUP
    {
        BaseHeros _hero;
        int _actionPrice;
        public Armory(ArmoryConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        public void DeleteHero()
        {
            Hero = null;
        }
        public void UpgrateItemOfAnHero(BaseItem HeroItem)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (Ctx.MoneyManager.CanBuy( ActionPrice )) Ctx.MoneyManager.Buy( ActionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            HeroItem.LevelUp(); 
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

            set
            {
                _hero = value;
            }
        }

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }
    }
}
