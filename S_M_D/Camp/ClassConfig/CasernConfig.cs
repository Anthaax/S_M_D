using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    class CasernConfig : BuildingType
    {
        private BaseHeros _hero;
        private Spells _spell;
        public CasernConfig(string name, int buildingCost,int level, List<BaseBuilding> buildings, BaseHeros heros,Spells spell) : base(name, buildingCost,level, buildings)
        {
            this._hero = heros;
            this._spell = spell;
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
        public Spells Spell
        {
            get
            {
                return _spell;
            }

            set
            {
                _spell = value;
            }
        }
    }
}
