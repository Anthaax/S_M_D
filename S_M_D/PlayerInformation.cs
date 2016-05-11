using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D
{
    public class PlayerInformation
    {
        readonly GameContext _ctx;
        readonly List<BaseHeros> _myHeros;
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
    }
}
