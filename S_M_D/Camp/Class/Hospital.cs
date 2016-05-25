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
            _hero.Sicknesses.ForEach( c => c.Price = 1000 / this.Level );
        }
        public void deleteHeros()
        {
            _hero = null;
        }
        public void HealHero(Sickness sickness)
        {
            _hero.DeleteSickness(sickness);
            if (Ctx.MoneyManager.CanBuy( sickness.Price )) Ctx.MoneyManager.Buy(sickness.Price);
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
