using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    class CemeteryConfig : BuildingType
    {
        private List<BaseHeros> _herosDispo;
        public CemeteryConfig(string name, int buildingCost, int level, List<BaseBuilding> buildings, List<BaseHeros> heros) : base(name, buildingCost,level, buildings)
        {
            this._herosDispo = heros;
        }
        public List<BaseHeros> HerosDispo
        {
            get
            {
                return _herosDispo;
            }

            set
            {
                _herosDispo = value;
            }
        }
    }
}
