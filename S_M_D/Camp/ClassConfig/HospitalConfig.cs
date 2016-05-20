using S_M_D.Camp.Class;
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
        public HospitalConfig(GameContext ctx) : base(BuildingName.Hospital, 1500,0, ctx)
        {
            this._hero = null;
        }
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Hospital(this);
        }
        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }
        }
    }
}
