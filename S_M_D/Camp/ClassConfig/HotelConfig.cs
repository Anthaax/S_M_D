using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class HotelConfig : BuildingType
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        public HotelConfig(GameContext ctx) : base(Class.BuildingName.Hotel, 1000,0, ctx)
        {
            this._hero1 = null;
            this._hero2 = null;
        }
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Hotel(this);
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
