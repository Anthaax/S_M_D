using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    class HotelConfig : BuildingType
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        public HotelConfig(string name, int buildingCost,int level, List<BaseBuilding> buildings, BaseHeros hero1, BaseHeros hero2) : base(name, buildingCost,level, buildings)
        {
            this._hero1 = hero1;
            this._hero2 = hero2;
        }
        public BaseHeros Hero1
        {
            get
            {
                return _hero1;
            }

            set
            {
                _hero1 = value;
            }
        }
        public BaseHeros Hero2
        {
            get
            {
                return _hero2;
            }

            set
            {
                _hero2 = value;
            }
        }
    }
}
