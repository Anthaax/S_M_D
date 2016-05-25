using S_M_D.Camp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp
{
    public abstract class BuildingType
    {
        readonly BuildingNameEnum _name;
        readonly int _buildingCost;
        readonly int _level;
        readonly GameContext _ctx;

        protected BuildingType(BuildingNameEnum name, int buildingCost,int level, GameContext ctx)
        {
            _name = name;
            _buildingCost = buildingCost;
            _ctx = ctx;
            _level = level;
        }

        public int BuildingCost
        {
            get { return _buildingCost; }
        }
        public int Level
        {
            get { return _level; }
        }

        public BuildingNameEnum Name
        {
            get { return _name; }
        }

        public GameContext Ctx
        {
            get
            {
                return _ctx;
            }
        }

        public BaseBuilding CreateBuilding()
        {
            if (Ctx.PlayerInfo.MyBuildings.Count >=9) throw new InvalidOperationException("You have already 9 buildings");
            BaseBuilding building = DoCreateBuilding();
            Ctx.PlayerInfo.MyBuildings.Add(building);
            return building;
        }
        protected abstract BaseBuilding DoCreateBuilding();
    }
}
