using S_M_D.Camp.Class;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.ClassConfig
{
    public class CemeteryConfig : BuildingType
    {
        private List<BaseHeros> _herosDispo;
        public CemeteryConfig(GameContext ctx) : base(BuildingNameEnum.Cemetery,0, 1,ctx)
        {
            this._herosDispo = ctx.PlayerInfo.DeadHero;
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
            return new Cemetery(this);
        }
    }
}
