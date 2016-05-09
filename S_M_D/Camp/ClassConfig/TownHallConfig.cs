using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Camp.ClassConfig
{
    public class TownHallConfig : BuildingType
    {

        public TownHallConfig(string name, int buildingCost, List<BaseBuilding> buildings) : base(name, buildingCost, buildings)
        {

        }
    }
}
