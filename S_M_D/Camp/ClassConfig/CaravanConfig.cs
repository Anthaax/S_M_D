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
        public CaravanConfig(GameContext ctx) : base(BuildingName.Caravan,500,1, ctx)
        {
            this._herosDispo = new List<BaseHeros>();
        }
        public List<BaseHeros> HerosDispo
        {
            get
            {
                return _herosDispo;
            }
        }
        protected override BaseBuilding DoCreateBuilding()
        {
            return new Caravan(this);
        }
    }
}
 