﻿using S_M_D.Camp.ClassConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class TownHall : BaseBuilding
    {
        public TownHall(TownHallConfig b) : base(b)
        {
        }

        public void BuyBuilding(BaseBuilding b)
        { 
            b.Level = 1;
        }
        public void UpgradeBuilding(BaseBuilding b)
        {
            b.Level += 1;
            b.BuildingCost = b.BuildingCost + Level * 100;
        }

        
    }
}