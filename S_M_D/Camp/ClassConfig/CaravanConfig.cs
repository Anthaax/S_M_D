﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
namespace S_M_D.Camp.ClassConfig
{
    public class CaravanConfig : BuildingType
    {
        private List<BaseHeros> _herosDispo;
        public CaravanConfig(string name, int buildingCost,int level, List<BaseBuilding> buildings,List<BaseHeros> heros) : base(name, buildingCost,level, buildings)
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
 