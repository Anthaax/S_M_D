using S_M_D.Camp.Class;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class CasernConfig : BuildingType
    {
        readonly BaseHeros _hero;
        readonly int _actionPrice;
        public CasernConfig( GameContext ctx) : base(BuildingNameEnum.Casern, 400,0, ctx)
        {
            this._hero = null;
            _actionPrice = 1000;
        }
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Casern(this);
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
    }
}
