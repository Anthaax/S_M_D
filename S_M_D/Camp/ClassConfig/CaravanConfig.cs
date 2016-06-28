using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp.Class;

namespace S_M_D.Camp.ClassConfig
{
    [Serializable]
    public class CaravanConfig : BuildingType
    {
        readonly List<BaseHeros> _herosDispo;
        readonly int _maxNewHero;
        public CaravanConfig( GameContext ctx ) : base(BuildingNameEnum.Caravan,500,1, ctx)
        {
            this._herosDispo = new List<BaseHeros>();
            _maxNewHero = 3;
        }
        public List<BaseHeros> HerosDispo
        {
            get
            {
                return _herosDispo;
            }
        }

        public int MaxNewHero
        {
            get
            {
                return _maxNewHero;
            }
        }

        protected override BaseBuilding DoCreateBuilding()
        {
            return new Caravan(this);
        }
    }
}
 