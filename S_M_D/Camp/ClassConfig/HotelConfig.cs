using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    [Serializable]
    public class HotelConfig : BuildingType
    {
        readonly BaseHeros _hero1;
        readonly BaseHeros _hero2;
        readonly int _actionPrice;
        public HotelConfig( GameContext ctx ) : base(Class.BuildingNameEnum.Hotel, 1000,0, ctx)
        {
            this._hero1 = null;
            this._hero2 = null;
            _actionPrice = 1000;
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
        }
        public BaseHeros Hero2
        {
            get
            {
                return _hero2;
            }
        }

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }
    }
}
