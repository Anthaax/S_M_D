using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Hospital : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero;
        int _actionPrice;
        public Hospital(HospitalConfig b) : base(b)
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
        public void HealHero(Sickness sickness)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (_hero.Sicknesses.Count == 0) throw new ArgumentException( "You Need An sickness" );
            if (_hero.Sicknesses.Where(c => c==sickness).Count() != 1) throw new ArgumentException( "Hero haven't this sickness" );
            if (Ctx.MoneyManager.CanBuy( ActionPrice )) Ctx.MoneyManager.Buy(ActionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            _hero.DeleteSickness(sickness);
        }
        public void LevelUP()
        {
            Level++;
            _actionPrice = _actionPrice / Level ;
        }
        public BaseHeros Hero
        {
            get
            {
                return _hero;
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
