using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class Hospital : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero;
        int _actionPrice;
        public Hospital(HospitalConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        /// <summary>
        /// Put the hero in the building
        /// </summary>
        /// <param name="h"> The hero to add </param>
        public void setHero(BaseHeros h)
        {
            _hero = h;
            _hero.InBuilding = this;
        }
        /// <summary>
        /// Remove the from the building
        /// </summary>
        public void deleteHeros()
        {
            _hero.InBuilding = null;
            _hero = null;
        }
        /// <summary>
        /// Remove the sickness from an hero.
        /// </summary>
        /// <param name="sickness">Sickness to remove</param>
        public void HealHero(Sickness sickness)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (_hero.Sicknesses.Count == 0) throw new ArgumentException( "You Need An sickness" );
            if (_hero.Sicknesses.Where(c => c==sickness).Count() != 1) throw new ArgumentException( "Hero haven't this sickness" );
            if (Ctx.MoneyManager.CanBuy( ActionPrice )) Ctx.MoneyManager.Buy(ActionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            _hero.DeleteSickness(sickness);
        }
        /// <summary>
        /// Level up the building
        /// </summary>
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
