using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class ArmoryConfig : BuildingType
    {
        readonly BaseHeros _hero;
        readonly int _actionPrice;
        public ArmoryConfig(GameContext ctx) : base(BuildingNameEnum.Armory, 600,0,ctx)
        {
            this._hero = null;
            _actionPrice = 1000;
        }
        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }
        }

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }

        protected override BaseBuilding DoCreateBuilding()
        {
            return new Armory(this);
        }
    }
}
