using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class MentalHospital : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero;
        int _actionPrice;
        public MentalHospital(MentalHospitalConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        /// <summary>
        /// Set the hero in the building
        /// </summary>
        /// <param name="h"></param>
        public void setHero(BaseHeros h)
        {
            _hero = h;
            _hero.InBuilding = this;
        }
        /// <summary>
        /// Remove hero from this building
        /// </summary>
        public void deleteHeros()
        {
            _hero.InBuilding = null;
            _hero = null;
        }
        /// <summary>
        /// Delete a psycholigy from an hero
        /// </summary>
        /// <param name="psycho">Psycology to delete</param>
        public void DeletePsychologyHero(Psychology psycho)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (_hero.Psycho.Count == 0) throw new ArgumentException( "You Need An Psyco" );
            if (_hero.Psycho.Where( c => c == psycho ).Count() != 1) throw new ArgumentException( "Hero haven't this psyco" );
            if (Ctx.MoneyManager.CanBuy( 1000 / Level )) Ctx.MoneyManager.Buy( 1000 / Level );
            else throw new ArgumentException( "You Can't buy this thing" );
            _hero.DeletePsycho(psycho);
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

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }
    }
}
