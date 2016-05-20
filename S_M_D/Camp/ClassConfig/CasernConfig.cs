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
        private BaseHeros _hero;
        private Spells _spell;
        public CasernConfig(GameContext ctx) : base(BuildingName.Casern, 400,0, ctx)
        {
            this._hero = null;
            this._spell = null;
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
