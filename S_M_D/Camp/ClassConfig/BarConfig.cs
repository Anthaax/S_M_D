using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class BarConfig : BuildingType
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        public BarConfig(GameContext ctx) : base(Class.BuildingName.Bar, 900,0,ctx)
        {
            this._hero1 = null;
            this._hero2 = null;
        }
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Bar(this);
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
    }
}
