﻿using S_M_D.Camp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp
{
    public abstract class BuildingType
    {
        readonly BuildingName _name;
        readonly int _buildingCost;
        readonly int _level;
        readonly GameContext _ctx;

        protected BuildingType(BuildingName name, int buildingCost,int level, GameContext ctx)
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

        public BuildingName Name
        {
            get { return _name; }
        }
        public BaseBuilding CreateBuilding()
        {
            if (_ctx.PlayerInfo.MyBuildings.Count >=9) throw new InvalidOperationException("You have already 9 buildings");
            BaseBuilding building = DoCreateBuilding();
            _ctx.PlayerInfo.MyBuildings.Add(building);
            return building;
        }
        protected abstract BaseBuilding DoCreateBuilding();
    }
}