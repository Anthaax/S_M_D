using S_M_D.Camp.ClassConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class TownHall : BaseBuilding
    {
        GameContext _ctx;
        public TownHall(TownHallConfig b) : base(b)
        {
            _ctx = b.Ctx;
        }

        public void BuyBuilding(BaseBuilding b)
        { 
            b.Level = 1;
            _ctx.MoneyManager.Buy(b.BuildingCost);
        }
        public void UpgradeBuilding(BaseBuilding b)
        {
            b.Level += 1;
            b.BuildingCost = b.BuildingCost + Level * 100;
            _ctx.MoneyManager.Buy(b.BuildingCost);
        }

        
    }
}
