using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class MentalHospitalConfig : BuildingType
    {
        private BaseHeros _hero;
        public MentalHospitalConfig(GameContext ctx) : base(BuildingName.MentalHospital, 500,0,ctx)
        {
            this._hero = null;
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
        protected override BaseBuilding DoCreateBuilding()
        {
            return new MentalHospital(this);
        }
    }
}
