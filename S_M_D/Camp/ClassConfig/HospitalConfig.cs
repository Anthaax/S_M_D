using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class HospitalConfig : BuildingType
    {
        private BaseHeros _hero;
        public HospitalConfig(string name, int buildingCost,int level, List<BaseBuilding> buildings,BaseHeros hero) : base(name, buildingCost,level, buildings)
        {
            this._hero = hero;
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
