using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
namespace S_M_D.Camp.ClassConfig
{
    public class CaravanConfig : BuildingType
    {
        List<BaseHeros> herosDispo;
        public CaravanConfig(string name, int buildingCost, List<BaseBuilding> buildings,List<BaseHeros> heros) : base(name, buildingCost, buildings)
        {
            this.herosDispo = heros;
        }
    }
}
