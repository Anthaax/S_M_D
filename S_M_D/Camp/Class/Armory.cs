using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class Armory : BaseBuilding, ILevelUP
    {
        BaseHeros _hero;
        int _actionPrice;
        /// <summary>
        /// Armory for upgrate hero equipement
        /// </summary>
        /// <param name="b"></param>
        public Armory(ArmoryConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        /// <summary>
        /// Set an hero in the building
        /// </summary>
        /// <param name="h"></param>
        public void SetHero( BaseHeros h )
        {
            _hero = h;
            _hero.InBuilding = this;
        }
        /// <summary>
        /// Delete the hero from the armory
        /// </summary>
        public void DeleteHero()
        {
            _hero.InBuilding = null;
            _hero = null;
        }
        /// <summary>
        /// Upgrate one item from the current hero in the armory
        /// </summary>
        /// <param name="HeroItem">Hero item to upgrate</param>
        /// <exception cref="ArgumentException">Reurn exception if hero was null</exception>
        /// <exception cref="ArgumentException">Reurn exception if you haven't enought money</exception>
        public void UpgrateItemOfAnHero(BaseItem HeroItem)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (Ctx.MoneyManager.CanBuy( ActionPrice )) Ctx.MoneyManager.Buy( ActionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            HeroItem.LevelUp(); 
        }
        /// <summary>
        /// Level up the building
        /// </summary>
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
        /// <summary>
        /// Retunr the action price
        /// </summary>
        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }
    }
}
