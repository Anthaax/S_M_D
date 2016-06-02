using S_M_D.Camp.ClassConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class TownHall : BaseBuilding
    {
        public TownHall(TownHallConfig b) : base(b)
        {
        }
        /// <summary>
        /// Buy a building
        /// </summary>
        /// <param name="b"></param>
        public void BuyBuilding(BaseBuilding b)
        {
            if (Ctx.MoneyManager.CanBuy( b.BuildingCost )) Ctx.MoneyManager.Buy( b.BuildingCost );
            else throw new ArgumentException( "You Can't buy this thing" );
            ILevelUP bulding = b as ILevelUP;
            bulding.LevelUP();
        }
        /// <summary>
        /// Upgrate building
        /// </summary>
        /// <param name="b"></param>
        public void UpgradeBuilding(BaseBuilding b)
        {
            if (Ctx.MoneyManager.CanBuy( b.BuildingCost + Level * 100 )) Ctx.MoneyManager.Buy( b.BuildingCost + Level * 100 );
            else throw new ArgumentException( "You Can't buy this thing" );
            ILevelUP bulding = b as ILevelUP;
            bulding.LevelUP();
        }
    }
}
