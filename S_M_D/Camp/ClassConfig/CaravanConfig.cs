using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp.Class;

namespace S_M_D.Camp.ClassConfig
{
    public class CaravanConfig : BuildingType
    {
        private List<BaseHeros> _herosDispo;
        public CaravanConfig(GameContext ctx) : base(BuildingName.Caravan,500,0, ctx)
        {
            this._herosDispo = null;
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
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Caravan(this);
        }
    }
}
 