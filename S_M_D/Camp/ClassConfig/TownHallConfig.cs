using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D;
using S_M_D.Camp.Class;

namespace S_M_D.Camp.ClassConfig
{
    [Serializable]
    public class TownHallConfig : BuildingType
    {
        public TownHallConfig( GameContext ctx) : base(BuildingNameEnum.Townhall,500,1, ctx)
        {

        }

        protected override BaseBuilding DoCreateBuilding()
        {
            return new TownHall(this);
        }
    }
}
