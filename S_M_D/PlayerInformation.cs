using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;
using S_M_D.Camp.ClassConfig;
using S_M_D.Camp.Class;

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
            _myBuildings = new List<BaseBuilding>();
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
        public BaseBuilding GetBuilding(BuildingName name)
        {
            return _myBuildings.Find(t => t.Name == name);
        }
        private void InitializedBuilding()
        {
            _ctx.BuildingManager.Find(Camp.Class.BuildingName.Townhall).CreateBuilding();
        }
    }
}
