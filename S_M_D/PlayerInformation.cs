using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;

namespace S_M_D
{
    public class PlayerInformation
    {
        readonly GameContext _ctx;
        readonly List<BaseHeros> _myHeros;
        readonly List<BaseBuilding> _myBuildings;
        public PlayerInformation(GameContext ctx)
        {
            _ctx = ctx;
            _myHeros = new List<BaseHeros>();
        }

        public GameContext Ctx
        {
            get
            {
                return _ctx;
            }
        }

        public List<BaseHeros> MyHeros
        {
            get
            {
                return _myHeros;
            }
        }
        public List<BaseBuilding> MyBuildings
        {
            get
            {
                return _myBuildings;
            }
        }
    }
}
