using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    class ArmoryConfig : BuildingType
    {
        private BaseHeros _hero;
        public ArmoryConfig(string name, int buildingCost,int level, List<BaseBuilding> buildings, BaseHeros heros) : base(name, buildingCost,level, buildings)
        {
            this._hero = heros;
        }
        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }

            set
            {
                _hero = value;
            }
        }
    }
}
